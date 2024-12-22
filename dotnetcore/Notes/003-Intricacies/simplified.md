# Simplified

.Net Fwk and .NET Core comes with CLR & FCL

- Common Language RUntime
- Framework Class Library

## FCL

.Net Fwk - 2002

- FCL
  - WinForm and WPF - Desktop GUI Apps
  - WCF
  - ASP.Net
    - Web Form - No AJAX
    - MVC and Web API
  - File IO
  - DB IO
  - Sicket IO ...

.Net Core

- FCL
   x WinForm and WPF - Desktop GUI Apps
  - ASP.Net Core
    - MVC and Web API
  - File IO
  - DB IO
  - Sicket IO ...

AJAX - 1996 MSft

jessie James garret - Adoptive ...

Script manager / Update panel - patch ajax

2010 - MVC

- separated client and server

### MVC - Model View Controller

`Controller` is similar to `Web API`

View is not CLient side in MVC - It is server side

Anything apart from VIew and Controller is a model

## CLR

- Loads the .net assembly (dll) and executes it
- dll contains code in Microsoft Intermediate language
- CLR uses JIT compiler to compile dll into executable code for OS

CLR watches the stack trace
declaration / definition

.Net Core DLL contains 5 sections

- metadata declarations
- Headers
- MSIL code
- Resource Section

Reading metadata declarations in runtime is called Reflection - Class Name: Type
`Asembly.GetType()`

MSIL Code compiles to Machine code via 'JIT Compilation'
