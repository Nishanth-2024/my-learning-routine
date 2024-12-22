# .NET Compliant Languages and Common Language Specification (CLS)

## .NET Compliant Languages

- **Definition**: .NET compliant languages are those that adhere to the Common Language Specification (CLS) defined by the .NET ecosystem. This ensures interoperability between different .NET languages and allows them to use the .NET libraries and runtime.
- **Examples**: C#, F#, Visual Basic, and many others.
- **Compatibility**: These languages can compile to the Common Intermediate Language (CIL) and run on the Common Language Runtime (CLR), making them compatible with .NET Framework, .NET Core, and .NET 5 and later versions.

## Common Language Specification (CLS)

- **Purpose**: The CLS is a set of rules and guidelines that .NET languages must follow to ensure interoperability. It defines a common set of features that all .NET languages can use, enabling them to work together seamlessly.
- **Key Points**:
  - **Language Independence**: Allows developers to write code in multiple languages that can interoperate within the .NET ecosystem.
  - **Cross-Language Interoperability**: Ensures that components written in one .NET language can be used by other .NET languages.
  - **CLSCompliant Attribute**: Developers can mark their code with the `[CLSCompliant(true)]` attribute to ensure it adheres to CLS rules.

## CLS Compliance Rules

- **Public Interface**: Only the public interface of a component needs to be CLS-compliant. Private implementations do not have to conform to CLS.
- **Data Types**: Certain data types, like unsigned integers (except `Byte`), are not CLS-compliant. For example, `UInt16` is not CLS-compliant, but `Int16` is.
- **Naming Conventions**: CLS-compliant code must follow specific naming conventions to avoid conflicts between case-sensitive and case-insensitive languages.

## .Net Primitive DataTypes

### .NET Primitive Data Types and Their Representations

Here's the updated table with checkboxes for CLS compliance:

| C# Keyword | .NET Type        | Description                                                      | CLS-Compliant |
|------------|------------------|------------------------------------------------------------------|---------------|
| `bool`     | `System.Boolean` | Represents a Boolean value (`true` or `false`).                  | ✅ |
| `byte`     | `System.Byte`    | Represents an 8-bit unsigned integer.                            | ✅ |
| `char`     | `System.Char`    | Represents a single 16-bit Unicode character.                    | ✅ |
| `decimal`  | `System.Decimal` | Represents a 128-bit precise decimal value.                      | ✅ |
| `double`   | `System.Double`  | Represents a double-precision floating-point number.             | ✅ |
| `float`    | `System.Single`  | Represents a single-precision floating-point number.             | ✅ |
| `int`      | `System.Int32`   | Represents a 32-bit signed integer.                              | ✅ |
| `uint`     | `System.UInt32`  | Represents a 32-bit unsigned integer.                            | 🚫 |
| `long`     | `System.Int64`   | Represents a 64-bit signed integer.                              | ✅ |
| `ulong`    | `System.UInt64`  | Represents a 64-bit unsigned integer.                            | 🚫 |
| `short`    | `System.Int16`   | Represents a 16-bit signed integer.                              | ✅ |
| `ushort`   | `System.UInt16`  | Represents a 16-bit unsigned integer.                            | 🚫 |
| `object`   | `System.Object`  | The base type from which all other types derive.                 | ✅ |
| `string`   | `System.String`  | Represents a sequence of Unicode characters.                     | ✅ |
| `sbyte`    | `System.SByte`   | Represents an 8-bit signed integer.                              | 🚫 |
| `Array`    | `System.Array`   | Represents a fixed-size collection of elements of the same type. | ✅ |

## References

- [.Net Standard - Language Independence]
- [Dotnet Tutorials CLS]

[//]:# (Comments)

  [.Net Standard - Language Independence]: <https://learn.microsoft.com/en-us/dotnet/standard/language-independence>
  [Dotnet Tutorials CLS]: <https://dotnettutorials.net/lesson/common-language-specification/>.