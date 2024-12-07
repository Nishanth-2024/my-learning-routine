# Multi-Threading in .Net

## Thread Stack and Process Heap in .NET

![Thread Stack & Process Heap]

### Thread Stack

- **Definition**: The stack is a region of memory that stores temporary variables created by each function (including the main function). It operates on a Last In, First Out (LIFO) basis.
- **Characteristics**:
  - **Automatic Memory Management**: Memory is automatically allocated and deallocated as functions are called and return.
  - **Fast Access**: Access to stack memory is very fast.
  - **Size Limitation**: The size of the stack is limited and can lead to stack overflow if too much memory is used.
  - **Storage**: Stores value types (e.g., int, double) and references to objects (not the objects themselves).

### Process Heap

- **Definition**: The heap is a region of memory used for dynamic memory allocation where blocks of memory are allocated and freed in an arbitrary order.
- **Characteristics**:
  - **Manual Memory Management**: Memory must be manually allocated and deallocated.
  - **Flexible Size**: The heap can grow and shrink dynamically as needed.
  - **Slower Access**: Access to heap memory is slower compared to stack memory.
  - **Storage**: Stores reference types (e.g., objects, arrays).

## Thread Pool

- **Definition:** A thread pool is a collection of pre-instantiated, reusable threads that can be used to execute tasks.
- **Characteristics:**
  - **Efficient Resource Management:** Reduces the overhead of creating and destroying threads by reusing existing ones.
  - **Automatic Scaling:** The thread pool can dynamically adjust the number of threads based on workload.
  - **Use Cases:** Ideal for scenarios with many short-lived tasks, such as handling multiple web requests.

## Background and Foreground Threads

### Foreground Threads

- **Definition:** Foreground threads keep the application running until they complete their execution.
- **Characteristics:**
  - **Blocking:** The application will not terminate until all foreground threads have finished.
  - **Use Cases:** Suitable for tasks that must complete before the application exits.

### Background Threads

- **Definition:** Background threads do not prevent the application from terminating. They are automatically terminated when all foreground threads have finished.
- **Characteristics:**
  - **Non-Blocking:** The application can exit even if background threads are still running.
  - **Use Cases:** Suitable for tasks that can be safely terminated when the application exits, such as logging or background data processing.

## Generic Multi-Threading Scenarios

- **Parallel Data Processing**: Splitting large datasets into smaller chunks and processing them concurrently to improve performance.
- **Responsive UIs**: Keeping the user interface responsive by performing long-running tasks (e.g., file I/O, network requests) on background threads.
- **Real-Time Systems**: Handling multiple real-time tasks simultaneously, such as in gaming or robotics.

## Multi-Threading in WebAPI Scenarios

- **Handling Concurrent Requests**: Using asynchronous programming to handle multiple HTTP requests simultaneously without blocking the main thread.
- **Background Processing**: Offloading tasks like sending emails, processing files, or updating databases to background threads to keep the API responsive.
- **Rate Limiting and Throttling**: Managing the rate of incoming requests to prevent server overload by processing requests in parallel batches.

## Using Thread vs. Task Classes

### Threads

- **Definition**: A thread is a lower-level construct that represents a single path of execution within a process.
- **Characteristics**:
  - **Manual Control**: Requires explicit creation, management, and synchronization.
  - **Resource Intensive**: Consumes more system resources and has higher overhead.
  - **Use Cases**: Suitable for scenarios requiring fine-grained control over thread execution and lifecycle.

### Tasks

- **Definition**: A task is a higher-level abstraction provided by the Task Parallel Library (TPL) for running code asynchronously.
- **Characteristics**:
  - **Automatic Management**: Uses the thread pool for efficient resource management.
  - **Lightweight**: Consumes fewer resources compared to threads.
  - **Asynchronous Programming**: Supports async/await for easier asynchronous code.
  - **Use Cases**: Ideal for I/O-bound operations, parallel processing, and scenarios where responsiveness is critical.

### Key Differences

- **Abstraction Level**: Tasks provide a higher-level abstraction, making them easier to use and manage.
- **Resource Management**: Tasks leverage the thread pool, reducing the overhead of creating and destroying threads.
- **Programming Model**: Tasks integrate seamlessly with async/await, simplifying asynchronous programming.

## Handling Background and Foreground Modes with Task and Thread

- Threads
  - Foreground Mode: By default, threads are foreground threads. You can set a thread to background mode using the IsBackground property.

    ```C#
    Thread thread = new Thread(SomeMethod);
    thread.IsBackground = true; // Set to background mode
    thread.Start();
    ```

- Tasks
  - Background Mode: Tasks run on thread pool threads, which are background threads by default. This means they do not prevent the application from exiting.

    `Task.Run(() => SomeMethod());`

### Main Method and Thread Modes

- Main Method: The main method runs on a foreground thread. When the main method completes, the application will exit unless there are other foreground threads still running.

  ```C#
  static void Main(string[] args)
  {
      Thread backgroundThread = new Thread(SomeMethod);
      backgroundThread.IsBackground = true;
      backgroundThread.Start();
      // Application will exit after Main completes, even if backgroundThread is still running
  }
  ```

## Blocking vs. Non-Blocking Threads

TODO: Revisit for better understanding and better notes. This notes is not exactly correct for `Blocking vs. Non-Blocking Threads`

Blocking Threads

- **Definition:** A blocking thread waits for an operation to complete before continuing execution.
- **Characteristics:**
  - **Synchronous:** Operations are performed sequentially, one after the other.
  - **Use Cases:** Suitable for tasks that must be completed before proceeding to the next step.

Non-Blocking Threads

- **Definition:** A non-blocking thread does not wait for an operation to complete and can continue executing other tasks.
- **Characteristics:**
  - **Asynchronous:** Operations can be performed concurrently, improving responsiveness.
  - **Use Cases:** Ideal for I/O-bound operations, such as network requests or file I/O, where waiting for completion would waste resources.

[//]: # (Comments)

  [Thread Stack & Process Heap]: ./Multi-Threading-1.png
