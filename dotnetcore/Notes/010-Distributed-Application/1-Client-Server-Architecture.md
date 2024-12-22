# Client-Server Architecture

![Client Server Architecture or Distributed Application][Distributed App]

- Client Application runs on User/Client's devices
- Client connects to Server
- Server proforms major operations like connecting to DB securely and retrieves information to suply back to client

## Asynchronous Code

**_Note:_**

> - Operation taking more than 50 ms must be done asynchronously
> - Asynchronous on client is required for Responsiveness
> - Asynchronous on server is required for Scalibility

Example - Digital Library Application:

- Repository Classes Must always return Task so as to not block Main Thread of the webserver and compelling it to be idle and wait for DB operation to finish in another thread
- Use `async` and `await` to accomodate `Task`

**_Note:_**

- `wait` and `await` are different.
- `await` implies,
  - webserver reqlenquishes the Thread for some other task without disconnecting TCP.
  - once DB returns the data, webserver get backs a thread from threadpool to return data to client.

```csharp
class ControllerClass: ControllerBase
{
  // ...initialise repository with connection to DB
  // ...initialise logger to log any errors
  // ...more configurations constructor properites
  [HttpPost]
  public async Task<List<Book>> ListOfBooks([FromBody] string author)
  {
    return await _repository.GetBooks(author);
  }
}
```

## Blocking and Non-Blocking Waits

- Simulate Delay and exception when writing hardcoded db functions before connecting to actual DB
- Thread.Delay is not blocking
- Thread.Sleep is blocking

### CPU-Bound vs. I/O-Bound Operations

- **CPU-Bound Operations**:
  - Tasks limited by the processing power of the CPU.
  - Examples: Complex calculations, data processing, image processing.
  - Best handled using parallel constructs like `Parallel.For`, `Parallel.ForEach`, and `Task.Run`.

- **I/O-Bound Operations**:
  - Tasks limited by the speed of external systems (e.g., disk I/O, network I/O, database queries).
  - Examples: File uploads/downloads, database queries, network requests.
  - Best handled using asynchronous programming with `async` and `await`.

### Compute Operation vs. I/O Operation

- **Compute Operation (CPU Operation)**:
  - Involves intensive CPU processing.
  - Examples: Mathematical computations, data encryption, image rendering.

- **I/O Operation**:
  - Involves input/output operations with external systems.
  - Examples: Reading/writing files, network communication, database access.

### Key Points

- **I/O-Bound Operations**: Regardless of being long-running or short-lived, should be run in a task using asynchronous programming to avoid blocking threads.
- **CPU Operation and Compute Operation**: These terms are often used interchangeably to refer to tasks that require significant CPU processing power.

By following these best practices and understanding the differences between CPU-bound and I/O-bound operations, you can ensure efficient and scalable application performance. Let me know if you have any more questions!

[//]: # "Comments"
[Distributed App]: ./Distributed-App.jpg
