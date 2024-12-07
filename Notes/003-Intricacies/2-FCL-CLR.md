# FCL and CLR

- [FCL and CLR](#fcl-and-clr)
  - [Framework Class Library (FCL)](#framework-class-library-fcl)
    - [FCL - .NET Framework](#fcl---net-framework)
    - [.NET Core](#net-core)
  - [Common Language Runtime (CLR)](#common-language-runtime-clr)
    - [.NET Framework CLR](#net-framework-clr)
    - [.NET Core CLR (CoreCLR)](#net-core-clr-coreclr)
    - [.Net Core DLL](#net-core-dll)

---

.Net - FCL & CLR ![dotnet FCL CLR Image][DotNet-FCL-CLR-Image]

## Framework Class Library (FCL)

The **Framework Class Library (FCL)** is a vast collection of reusable classes, interfaces, and value types (that are tightly integrated with the **Common Language Runtime (CLR).**) that provide a wide range of functionalities for building applications.

### FCL - .NET Framework

Key components include:

- **Collections:** Lists, dictionaries, queues, etc.
- **File I/O**: Classes for reading from and writing to files.
- **Socket I/O**: Classes for network communication.
- **Networking:** Working with network protocols and services.
- **Data Access:** Connecting to databases and manipulating data.
- **XML Processing:** Parsing and manipulating XML data.
- **Threading:** Creating and managing threads.
- **WCF (Windows Communication Foundation)**: For building service-oriented applications.
- **WinForms (Windows Forms)**: For creating desktop applications.
- **WPF (Windows Presentation Foundation)**: For building rich desktop applications.
- **ASP.NET**: Including WebForms, MVC, and WebAPI for building web applications and services.

### .NET Core

In .NET Core, the **Framework Class Library (FCL)** also provides a comprehensive set of functionalities, but with some differences compared to the .NET Framework:

- **Collections:** Lists, dictionaries, queues, etc.
- **File I/O:** Fully supported.
- **Socket I/O**: Fully supported.
- **Networking:** Working with network protocols and services.
- **Data Access:** Connecting to databases and manipulating data.
- **XML Processing:** Parsing and manipulating XML data.
- **Threading:** Creating and managing threads.
- **ASP.NET Core:** Includes MVC and WebAPI, but not WebForms.
- **WCF:** *Limited support*, primarily through community projects like `CoreWCF`.
- **WinForms and WPF:** **(Windows Only)** Initially not included, but later added in .NET Core 3.0 and beyond as part of Windows Desktop Packs. *However, these are Windows-only and **not supported on Linux or macOS***.

Key Differences in .NET Framework and .Net Core Core for FCL

- **Modularity**: .NET Core's libraries are modular, allowing you to include only the packages you need, leading to smaller and more efficient applications.
- **Cross-Platform**: Both CoreFX (the FCL in .NET Core) and CoreCLR are designed to work seamlessly across multiple platforms, unlike the .NET Framework, which is Windows-only.
- **Modernized Compilers**: .NET Core uses the Roslyn compiler for C# and VB, and the F# compiler for F#. These compilers are faster and provide richer tooling support.

In summary, while the FCL in both .NET Framework and .NET Core provides a robust set of functionalities, .NET Core's FCL is more modular and cross-platform, with some differences in the availability of specific technologies like WCF, WinForms, WPF, and WebForms.

## Common Language Runtime (CLR)

**The Common Language Runtime (CLR)** is the execution engine for .NET applications. It provides a managed execution environment, handling tasks such as `memory management`, `garbage collection`, `exception handling`, and `security`. The CLR ensures that .NET applications run smoothly and efficiently.

Key Features of CLR (Common to Both `.NET Framework` and `.NET Core`):

- **Function Calls:** CLR is in posession of Stack Trace.
- **Memory Management:** Automatic allocation and deallocation of memory.
- **Garbage Collection:** Reclaims memory occupied by objects that are no longer in use.
- **Type Safety:** Ensures that code accesses only the types it is allowed to.
- **Exception Handling:** Provides a structured way to handle runtime errors.
- **Security:** Enforces code access security and role-based security.
- **Just-In-Time (JIT) Compilation:** Converts Intermediate Language (IL) code to native machine code at runtime.
- **Cross-Language Interoperability:** Allows objects written in different languages to interact seamlessly.
- **Metadata and Reflection:** Uses metadata to locate and load classes, lay out instances in memory, resolve method invocations, and enforce security.

### .NET Framework CLR

- **Platform:** Windows-only.
- **Versioning:** The .NET Framework CLR versions are tied to specific versions of the .NET Framework. For example, .NET Framework 4.8 uses CLR version 4.01.
- **Deployment:** Typically installed as part of the Windows operating system. Applications target a specific version of the .NET Framework.
- **APIs:** Includes Windows-specific APIs, such as those for Windows Forms and WPF.

### .NET Core CLR (CoreCLR)

- **Platform:** Cross-platform, running on Windows, Linux, and macOS.
- **Versioning:** .NET Core and later versions (including .NET 5+) have a single product version, meaning there's no separate CLR version.
- **Deployment:** Applications can be self-contained, including the runtime and libraries they depend on, or framework-dependent, relying on a shared runtime installation.
- **Modularity:** Designed to be lightweight and modular, allowing developers to include only the necessary components.
- **Performance:** Optimized for performance and scalability, suitable for cloud and server workloads.
- **Modern Features:** Includes enhancements and modern features not available in the .NET Framework CLR, such as improved JIT compilation and support for new language features.

### .Net Core DLL

A .NET Core DLL (Dynamic Link Library) is essentially an assembly, which is a compiled code library used for deployment, versioning, and security in .NET applications. Here's a breakdown of its composition:

-- **Code:** The actual compiled code that the Common Language Runtime (CLR) executes. This code is written in a .NET-supported language like C# or VB.NET.
-- **Assembly Manifest:** This is a metadata section that contains information about the assembly, such as its name, version, culture, and public key token. It also includes a list of all the files that make up the assembly and the types and resources it exposes.
-- **Metadata:** Information about the types defined in the assembly, including classes, interfaces, enums, and their members (methods, properties, events, etc.). This metadata is used by the CLR for type checking, security, and other purposes.
-- **Intermediate Language (IL) Code:** The code in a .NET assembly is compiled into an intermediate language (IL), which is then just-in-time (JIT) compiled to native code when the application runs.
-- **Resources:** Any additional data that the assembly needs, such as images, strings, and other files. These resources can be embedded within the assembly or linked as separate files.
-- **References:** Information about other assemblies that this assembly depends on. This includes both .NET Framework/Core libraries and third-party libraries.

Assemblies in .NET Core can be either static (stored on disk) or dynamic (created at runtime). They are the fundamental units of deployment and versioning in .NET applications12.

[//]: # (Comments)
  [DotNet-FCL-CLR-Image]: DotNet-FCL-CLR.png
