# Threading in .NET

1. [Quick Overview (TLDR)](#quick-overview)
2. [Detailed Threading Concepts](#detailed-concepts)
    - [Thread Fundamentals](#thread-fundamentals)
    - [Thread Properties & States](#thread-properties-states)
    - [Thread Creation & Management](#thread-creation)
    - [Synchronization Mechanisms](#synchronization)
    - [Advanced Concepts](#advanced-concepts)
3. [Best Practices & Guidelines](#best-practices)
    - [Modern Threading Approaches](#modern-approaches)
    - [Debugging & Performance](#debugging-performance)

## Quick Overview (TLDR) <a name="quick-overview"></a>

- **What is a Thread?**
  - Basic unit of program execution
  - Independent execution path within a process
  - Has its own stack but shares process resources
  - **Foreground vs Background Threads**:
    - Foreground threads keep the application running until they complete.
    - Background threads do not prevent the application from terminating.

- **Key Concepts**
  - Thread creation and management
  - Thread synchronization
  - Thread safety
  - Modern alternatives (Tasks, async/await)

- **Common Use Cases**
  - UI responsiveness
  - Parallel processing
  - Background operations
  - I/O operations

## Detailed Threading Concepts <a name="detailed-concepts"></a>

### Thread Fundamentals <a name="thread-fundamentals"></a>

1. **Basic Structure**

    ```csharp
    // Basic thread creation
    Thread thread = new Thread(() => 
    {
        Console.WriteLine("Thread is running");
    });

    // Start the thread
    thread.Start();

    // Wait for thread completion
    thread.Join();
    ```

2. **Thread Components**

   - Program Counter
   - Stack
   - Register Set
   - Thread ID

### Thread Properties & States <a name="thread-properties-states"></a>

1. **Properties**

    ```csharp
    Thread thread = new Thread(() => Console.WriteLine("Hello"));
    // Essential properties
    thread.IsAlive       // Thread running status
    thread.IsBackground  // Background/Foreground status
    thread.Name          // Thread identifier (debugging)
    thread.Priority      // Execution priority
    thread.ManagedThreadId  // Unique ID

    // Additional properties
    thread.ThreadState   // Current thread state
    thread.CurrentCulture // Culture info
    thread.ApartmentState // COM apartment state
    ```

2. **States Diagram**

    ```generic
    Unstarted → Running → [WaitSleepJoin] → Stopped
                    ↑___________________↓
    ```

### Thread Creation & Management <a name="thread-creation"></a>

1. **Creation Methods**

    ```csharp
    // Method 1: Traditional approach
    public void WorkMethod() { /* work */ }
    Thread thread1 = new Thread(new ThreadStart(WorkMethod));

    // Method 2: Lambda expression
    Thread thread2 = new Thread(() => {
        Console.WriteLine("Work in progress");
    });

    // Method 3: ThreadPool (managed thread pool)
    ThreadPool.QueueUserWorkItem(state => {
        Console.WriteLine("Pool work");
    });
    ```

2. **Advanced Thread Management**

    ```csharp
    // Thread with parameters
    ParameterizedThreadStart pts = new ParameterizedThreadStart(obj => {
        string parameter = obj as string;
        Console.WriteLine($"Parameter: {parameter}");
    });
    Thread paramThread = new Thread(pts);
    paramThread.Start("Hello");
    ```

### Synchronization Mechanisms <a name="synchronization"></a>

1. **Lock Statement**

    ```csharp
    private static object _lock = new object();
    public void ThreadSafeMethod()
    {
        lock (_lock)
        {
            // Critical section
        }
    }
    ```

2. **Monitor Class**

    ```csharp
    private static object _monitor = new object();
    public void UsingMonitor()
    {
        Monitor.Enter(_monitor);
        try
        {
            // Critical section
        }
        finally
        {
            Monitor.Exit(_monitor);
        }
    }
    ```

3. **Other Mechanisms**

    ```csharp
    // Mutex
    using (var mutex = new Mutex(false, "UniqueMutexName"))
    {
        mutex.WaitOne();
        try
        {
            // Critical section
        }
        finally
        {
            mutex.ReleaseMutex();
        }
    }

    // Semaphore
    using (var semaphore = new SemaphoreSlim(1, 1))
    {
        await semaphore.WaitAsync();
        try
        {
            // Critical section
        }
        finally
        {
            semaphore.Release();
        }
    }
    ```

### Advanced Concepts <a name="advanced-concepts"></a>

1. **Thread Affinity**

    - Thread to CPU core relationships
    - UI thread considerations in Windows applications
    - COM apartment threading models

2. **Thread Local Storage**

    ```csharp
    // Thread-local variable
    [ThreadStatic]
    private static int _threadData;

    // ThreadLocal<T> usage
    private static ThreadLocal<int> _threadLocal = 
        new ThreadLocal<int>(() => Thread.CurrentThread.ManagedThreadId);
    ```

3. **Thread Culture**

    ```csharp
    // Setting thread culture
    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
    ```

4. **Cooperative Cancellation**

    ```csharp
    using var cts = new CancellationTokenSource();
    var token = cts.Token;

    var thread = new Thread(() => {
        while (!token.IsCancellationRequested)
        {
            // Work here
            Thread.Sleep(100);
        }
    });
    ```

## Best Practices & Guidelines <a name="best-practices"></a>

1. **General Guidelines**

    - Prefer TPL and async/await over raw threads
    - Avoid Thread.Abort()
    - Use ThreadPool for short-lived operations
    - Always handle exceptions within threads
    - Implement proper cancellation mechanisms

2. **Resource Management**

    ```csharp
    // Proper resource cleanup
    public void ThreadWithCleanup()
    {
        using var resource = new SomeDisposableResource();
        try
        {
            // Thread work
        }
        catch (Exception ex)
        {
            // Log/handle exception
        }
    }
    ```

3. **Thread Pool Best Practices**

    - Keep work items short-lived
    - Avoid blocking operations
    - Don't use Thread.Sleep in pool threads
    - Consider using MaxDegreeOfParallelism

4. **Synchronization Guidelines**

    - Keep locked sections as short as possible
    - Avoid calling unknown code in locks
    - Always release resources in finally blocks
    - Use appropriate synchronization mechanisms

### Modern Threading Approaches <a name="modern-approaches"></a>

1. **Task Parallel Library (TPL)**

    ```csharp
    // Basic Task
    Task task = Task.Run(() => {
        Console.WriteLine("Task running");
    });

    // Async/Await Pattern
    public async Task DoWorkAsync()
    {
        await Task.Delay(1000);
        await Task.Run(() => {
            Console.WriteLine("Async work");
        });
    }
    ```

2. **Performance Considerations**

    - Thread Pool vs New Threads
    - Context Switching Overhead
    - Memory Usage Optimization
    - CPU Utilization Patterns

### Debugging & Performance <a name="debugging-performance"></a>

1. **Debugging Tools**

    ```csharp
    // Debug logging
    Debug.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}: Starting work");

    // Performance tracking
    Stopwatch sw = Stopwatch.StartNew();
    // ... thread work ...
    sw.Stop();
    Console.WriteLine($"Operation took: {sw.ElapsedMilliseconds}ms");
    ```

1. **Visual Studio Tools**

    - Thread Window (Debug → Windows → Threads)
    - Parallel Stacks
    - Performance Profiler
    - Concurrency Visualizer
