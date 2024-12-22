# Delegates, Callbacks, and Yield in .NET

## Delegates

- **Definition**: A delegate is a type that safely encapsulates a method, similar to a function pointer in C and C++.
- **Usage**: Delegates are used to pass methods as arguments to other methods. They are commonly used for implementing callbacks and event handling.
- **Syntax**:

  ```csharp
  public delegate void MyDelegate(string message);
  ```

- **Instantiation**:

  ```csharp
  MyDelegate del = new MyDelegate(MethodName);
  del("Hello World");
  ```

- **Multicast Delegates**: Delegates can be combined using the `+` operator to call multiple methods.

  ```csharp
  del += AnotherMethod;
  del("Hello Again");
  ```

- **Conversion to Class**:
  - Delegates are reference types and are derived from the `System.Delegate` class.
  - At runtime, they are indeed converted into instances of a class that inherits from `System.Delegate`.

## Callbacks

- **Definition**: A callback is a method passed as an argument to another method, which is then invoked inside the outer method to complete some kind of routine or action.
- **Usage**: Callbacks are often used in asynchronous programming to handle the completion of tasks.
- **Example**:

  ```csharp
  public delegate void CallbackDelegate(int result);

  public void ProcessData(int input, CallbackDelegate callback)
  {
      int result = input * 2;
      callback(result);
  }

  public void ResultHandler(int result)
  {
      Console.WriteLine("Result: " + result);
  }

  ProcessData(5, ResultHandler);
  ```

## Yield

- **Definition**: The `yield` keyword is used in an iterator method to provide a value to the enumerator object or to signal the end of iteration.
- **Usage**:
  - Methods that use `yield` return `IEnumerable` or `IEnumerator`.
  - These methods are called iterators.
- **Syntax**:

  ```csharp
  public IEnumerable<int> GetNumbers()
  {
      yield return 1;
      yield return 2;
      yield return 3;
  }
  ```

- **Generator Functions**:
  - Methods using `yield` are often referred to as generator functions.
  - They allow for lazy evaluation, meaning the values are generated on-the-fly as they are needed

  [2](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/yield)[3](https://stackoverflow.blog/2022/06/15/c-ienumerable-yield-return-and-lazy-evaluation/).

- **Example**:

  ```csharp
  foreach (int number in GetNumbers())
  {
      Console.WriteLine(number);
  }
  ```

## Additional Information

- **Delegates Conversion**: The conversion of delegates into classes at runtime is handled by the .NET runtime itself. This process involves creating an instance of a class that inherits from `System.Delegate`.
- **Yield and IEnumerable**: When a method uses `yield`, it must return `IEnumerable` or `IEnumerator`. This is because the method is transformed into a state machine that keeps track of the current position in the iteration.

## References

- [Using Delegates in .Net]
- [Using Yield]
- [`yield return` statement]

[//]:# (Comments)
  [Using Delegates in .Net]: <https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/using-delegates>
  [Using Yield]: <https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/yield>
  [`yield return` statement]: <https://www.milanjovanovic.tech/blog/csharp-yield-return-statement>
