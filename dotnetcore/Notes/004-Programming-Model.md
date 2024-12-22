# Programming Model of .NET

## Common Type System Programming Model - CTS

- **All Types Inherit `System.Object`**:
  - This is the root of the type hierarchy in .NET.

- **Value and Reference Types**:
  - **Value Types**:
    - Objects of Value Types are created on the **Thread Stack**.
    - Examples: `int`, `byte`, `char`, `short`, `float`, `long`, `double`, `decimal`, `bool`.
    - **Structs**: Custom value type implementations.
  - **Reference Types**:
    - Objects of Reference Types are created on the **Process Heap**.
    - Examples: `string`, arrays.
    - **Classes**: Custom reference type implementations.
    - **Arrays**: Arrays of both value and reference types are created on the **Process Heap**.

- **Interfaces and Delegates**:
  - **Interfaces**:
    - Help in achieving *loose coupling*.
  - **Delegates**:
    - Provide a way to achieve *callbacks*.
    - **Events**: Special types of delegates with registration and unregistration facilities.

- **Fields, Methods, and Properties**:
  - **Static Members**:
    - Fields, methods, and properties that belong to the type itself, not to any specific instance.
    - Only one instance exists for the entire application.
  - **Non-Static Members**:
    - Methods and properties have `this` as the first parameter.
    - `this`:
      - Is temporary and does not exist on the object itself.
      - Exists within the method or property and ceases to exist when the method ends.

- **Generics**:
  - Introduced in *.NET 2.0*.
  - Allow for type-safe data structures without the need for casting or boxing.
  - Can be used with implementations, abstractions, and delegates.

- **Type Safety**:
  - Ensures that code adheres to type rules, preventing type errors and enhancing security and reliability.

- **Object-Oriented Model**:
  - Supports object-oriented programming principles, including inheritance, encapsulation, and polymorphism.

- **Cross-Language Integration**:
  - Provides a common set of data types that all .NET languages understand, enabling interoperability between languages like C#, VB.NET, and F#.
