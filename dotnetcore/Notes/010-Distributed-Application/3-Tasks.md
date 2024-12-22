# Tasks in .NET Task Parallel Library

- [Quick Overview (TLDR)](#quick-overview-tasks)
- [Task Fundamentals](#task-fundamentals)
- [Task States and Lifecycle](#task-states-and-lifecycle)
- [Task Creation & Management](#task-creation)
- [Advanced Task Concepts](#advanced-task-concepts)
- [Best Practices](#task-best-practices)

## Quick Overview (TLDR) <a name="quick-overview-tasks"></a>

- **What is a Task?**
  - Higher-level abstraction over threads
  - Represents an asynchronous operation
  - Part of the Task Parallel Library (TPL)
  - Supports both CPU-bound and I/O-bound operations
- **Always Background Threads**: Tasks run on background threads from the thread pool.
- **Cannot be Aborted**: Tasks do not support aborting.
- **Fixed Priority**: Tasks run with normal priority.

    ```csharp
    // Basic Task usage
    Task task = Task.Run(() => Console.WriteLine("Hello from Task"));
    await task;
    ```

## Task Fundamentals <a name="task-fundamentals"></a>

1. **Task States**

    ```csharp
    // Task states
    Created → WaitingToRun → Running → [WaitingForChildren] → RanToCompletion/Faulted/Canceled
    ```

2. **Basic Task Properties**

    ```csharp
    Task task = Task.Run(() => { });
    // Essential properties
    task.Status           // TaskStatus enum
    task.IsCompleted      // Completion status
    task.IsFaulted       // Error state
    task.IsCanceled      // Cancellation state
    task.Exception       // AggregateException
    task.Id              // Unique identifier
    ```

## Task States and Lifecycle <a name="task-states-and-lifecycle"></a>

Tasks go through various states during their lifecycle:

```csharp
public class TaskStateDemo
{
    public static async Task DemonstrateTaskStates()
    {
        var task = new Task(() => Thread.Sleep(2000)); // Created state

        Console.WriteLine($"Initial state: {task.Status}"); // Created

        task.Start(); // WaitingToRun → Running
        Console.WriteLine($"After Start: {task.Status}"); // Running

        await Task.Delay(1000);
        Console.WriteLine($"During execution: {task.Status}"); // Running

        await task;
        Console.WriteLine($"After completion: {task.Status}"); // RanToCompletion

        // Task states include:
        // Created → WaitingToRun → Running → RanToCompletion
        // Alternative endings: Faulted (on exception) or Canceled (on cancellation)
    }
}
```

## Task Creation & Management <a name="task-creation"></a>

1. **Creation Methods**

    ```csharp
    // Method 1: Task.Run
    Task task1 = Task.Run(() => Console.WriteLine("Task 1"));

    // Method 2: Task constructor
    Task task2 = new Task(() => Console.WriteLine("Task 2"));
    task2.Start();

    // Method 3: Task.Factory
    Task task3 = Task.Factory.StartNew(() => Console.WriteLine("Task 3"));

    // Method 4: Async/Await pattern
    public async Task AsyncMethod()
    {
        await Task.Delay(1000);
        Console.WriteLine("Async Task");
    }
    ```

2. **Tasks with Return Values**

    ```csharp
    // Task<TResult>
    Task<int> calculationTask = Task.Run(() => {
        return 42;
    });
    int result = await calculationTask;

    // Using ContinueWith
    Task<string> processTask = calculationTask.ContinueWith(t => 
        $"Result was: {t.Result}");
    ```

3. **Task Continuation**

    ```csharp
    Task.Run(() => "First")
        .ContinueWith(t => Console.WriteLine(t.Result))
        .ContinueWith(t => Console.WriteLine("Done"));

    // Conditional continuation
    task.ContinueWith(t => { }, 
        TaskContinuationOptions.OnlyOnRanToCompletion);
    ```

## Advanced Task Concepts <a name="advanced-task-concepts"></a>

1. **Task Coordination**

    ```csharp
    // WhenAll - wait for multiple tasks
    Task[] tasks = new[] 
    {
        Task.Run(() => Console.WriteLine("Task 1")),
        Task.Run(() => Console.WriteLine("Task 2"))
    };
    await Task.WhenAll(tasks);

    // WhenAny - wait for first completion
    Task completedTask = await Task.WhenAny(tasks);
    ```

2. **Cancellation Support**

    ```csharp
    using var cts = new CancellationTokenSource();
    var token = cts.Token;

    var task = Task.Run(() => {
        while (!token.IsCancellationRequested)
        {
            // Work here
        }
    }, token);
    ```

3. **Exception Handling**

    ```csharp
    try
    {
        await Task.Run(() => throw new Exception("Task error"));
    }
    catch (Exception ex)
    {
        // Handle exception
    }

    // Multiple exceptions
    try
    {
        Task[] tasks = new[] {
            Task.Run(() => throw new Exception("Error 1")),
            Task.Run(() => throw new Exception("Error 2"))
        };
        await Task.WhenAll(tasks);
    }
    catch (AggregateException ae)
    {
        foreach (var ex in ae.InnerExceptions)
        {
            // Handle each exception
        }
    }
    ```

4. **Task Scheduling**

    ```csharp
    // Custom scheduler
    TaskScheduler scheduler = TaskScheduler.Current;
    await Task.Factory.StartNew(
        () => Console.WriteLine("Custom scheduled task"),
        CancellationToken.None,
        TaskCreationOptions.None,
        scheduler);
    ```

5. **Custom Task Scheduler with Priority Support**

    ```csharp
    public class PriorityTaskScheduler : TaskScheduler
    {
        private readonly ConcurrentDictionary<int, ConcurrentQueue<Task>> _taskQueues;
        private readonly Thread[] _workerThreads;
        private readonly CancellationTokenSource _cancellation;

        public PriorityTaskScheduler(int workerCount)
        {
            _taskQueues = new ConcurrentDictionary<int, ConcurrentQueue<Task>>();
            _workerThreads = new Thread[workerCount];
            _cancellation = new CancellationTokenSource();

            // Initialize queues for different priorities
            for (int i = 0; i < 5; i++) // 5 priority levels
            {
                _taskQueues[i] = new ConcurrentQueue<Task>();
            }

            // Initialize and start worker threads
            for (int i = 0; i < workerCount; i++)
            {
                _workerThreads[i] = new Thread(WorkerThreadProc)
                {
                    IsBackground = true,
                    Name = $"PriorityWorker{i}"
                };
                _workerThreads[i].Start();
            }
        }

        // Implementation methods...
    }
    ```

6. Background/Foreground Tasks

    ```csharp
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class TaskPriorityDemo
    {
        public static async Task DemonstratePriorities()
        {
            // High Priority Thread (affects only the thread, not the task)
            var highPriorityThread = new Thread(() =>
            {
                Task.Run(() =>
                {
                    // This line has no effect on the task's priority
                    Console.WriteLine("Task running on thread pool thread with normal priority");
                });
            });
            highPriorityThread.Priority = ThreadPriority.Highest;
            highPriorityThread.Start();

            // Background Task (default)
            var backgroundTask = Task.Run(() =>
            {
                Console.WriteLine("Background task running on thread pool thread with normal priority");
            });

            // Foreground Task
            var foregroundThread = new Thread(() =>
            {
                Task.Run(() =>
                {
                    // This line has no effect on the task's background status
                    Console.WriteLine("Task running on thread pool thread with normal priority");
                });
            });
            foregroundThread.IsBackground = false;
            foregroundThread.Start();

            // Wait for all tasks to complete
            await Task.WhenAll(backgroundTask);
        }

        public static void Main()
        {
            DemonstratePriorities().GetAwaiter().GetResult();
        }
    }
    ```

## Best Practices <a name="task-best-practices"></a>

1. **General Guidelines**

    ```csharp
    // Proper async method naming
    public async Task DoWorkAsync()
    {
        await Task.Delay(100);
    }

    // Avoid void async methods (except event handlers)
    public async void ButtonClick(object sender, EventArgs e)
    {
        await DoWorkAsync();
    }
    ```

2. **Performance Considerations**

    ```csharp
    // ConfigureAwait for non-UI contexts
    await Task.Run(() => { })
        .ConfigureAwait(false);

    // Task caching for common operations
    private static readonly Task<int> CachedTask = 
        Task.FromResult(42);
    ```

3. **Resource Management**

    ```csharp
    public async Task ProcessWithResourcesAsync()
    {
        using var resource = new SomeDisposableResource();
        try
        {
            await Task.Delay(100);
            await ProcessResourceAsync(resource);
        }
        catch (Exception ex)
        {
            // Log/handle exception
        }
    }
    ```
