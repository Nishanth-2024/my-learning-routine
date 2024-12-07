# Create and Run Application - Console

1. Pick a Root Folder and open it in terminal
2. Check for `dotnet` command line tool

    <details>
      <summary><code>dotnet</code></summary>

      <br/>

      ```console
      > dotnet

      Usage: dotnet [options]
      Usage: dotnet [path-to-application]

      Options:
        -h|--help         Display help.
        --info            Display .NET information.
        --list-sdks       Display the installed SDKs.
        --list-runtimes   Display the installed runtimes.

      path-to-application:
        The path to an application .dll file to execute.
      ```

    </details>

3. Common Application templates for .Net App

    <details>
      <summary><code>dotnet new</code></summary>

      <br/>

      ```console
      > dotnet new

      The 'dotnet new' command creates a .NET project based on a template.

      Common templates are:
      Template Name   Short Name  Language    Tags
      --------------  ----------  ----------  ----------------------
      Blazor Web App  blazor      [C#]        Web/Blazor/WebAssembly
      Class Library   classlib    [C#],F#,VB  Common/Library
      Console App     console     [C#],F#,VB  Common/Console

      An example would be:
        dotnet new console

      Display template options with:
        dotnet new console -h
      Display all installed templates with:
        dotnet new list
      Display templates available on NuGet.org with:
        dotnet new search web
      ```

    </details>

4. Available Application templates in current dev machine

    <details>
      <summary><code>dotnet new list</code></summary>

      <br/>

      ```console
      > dotnet new list
      These templates matched your input:

      Template Name                                 Short Name                  Language    Tags
      --------------------------------------------  --------------------------  ----------  --------------------------------
      API Controller                                apicontroller               [C#]        Web/ASP.NET
      ASP.NET Core Empty                            web                         [C#],F#     Web/Empty
      ASP.NET Core gRPC Service                     grpc                        [C#]        Web/gRPC/API/Service
      ASP.NET Core Web API                          webapi                      [C#],F#     Web/WebAPI/Web API/API/Service
      ASP.NET Core Web API (native AOT)             webapiaot                   [C#]        Web/Web API/API/Service
      ASP.NET Core Web App (Model-View-Controller)  mvc                         [C#],F#     Web/MVC
      ASP.NET Core Web App (Razor Pages)            webapp,razor                [C#]        Web/MVC/Razor Pages
      ASP.NET Core with Angular                     angular                     [C#]        Web/MVC/SPA
      ASP.NET Core with React.js                    react                       [C#]        Web/MVC/SPA
      Blazor Server App                             blazorserver                [C#]        Web/Blazor
      Blazor Server App Empty                       blazorserver-empty          [C#]        Web/Blazor/Empty
      Blazor Web App                                blazor                      [C#]        Web/Blazor/WebAssembly
      Blazor WebAssembly App Empty                  blazorwasm-empty            [C#]        Web/Blazor/WebAssembly/PWA/Empty
      Blazor WebAssembly Standalone App             blazorwasm                  [C#]        Web/Blazor/WebAssembly/PWA
      Class Library                                 classlib                    [C#],F#,VB  Common/Library
      Console App                                   console                     [C#],F#,VB  Common/Console
      dotnet gitignore file                         gitignore,.gitignore                    Config
      Dotnet local tool manifest file               tool-manifest                           Config
      EditorConfig file                             editorconfig,.editorconfig              Config
      global.json file                              globaljson,global.json                  Config
      MSBuild Directory.Build.props file            buildprops                              MSBuild/props
      MSBuild Directory.Build.targets file          buildtargets                            MSBuild/props
      MSTest Playwright Test Project                mstest-playwright           [C#]        Test/MSTest/Playwright
      MSTest Test Project                           mstest                      [C#],F#,VB  Test/MSTest
      MVC Controller                                mvccontroller               [C#]        Web/ASP.NET
      MVC ViewImports                               viewimports                 [C#]        Web/ASP.NET
      MVC ViewStart                                 viewstart                   [C#]        Web/ASP.NET
      NuGet Config                                  nugetconfig,nuget.config                Config
      NUnit 3 Test Item                             nunit-test                  [C#],F#,VB  Test/NUnit
      NUnit 3 Test Project                          nunit                       [C#],F#,VB  Test/NUnit
      NUnit Playwright Test Project                 nunit-playwright            [C#]        Test/NUnit/Playwright
      Protocol Buffer File                          proto                                   Web/gRPC
      Razor Class Library                           razorclasslib               [C#]        Web/Razor/Library
      Razor Component                               razorcomponent              [C#]        Web/ASP.NET
      Razor Page                                    page                        [C#]        Web/ASP.NET
      Razor View                                    view                        [C#]        Web/ASP.NET
      Solution File                                 sln,solution                            Solution
      Web Config                                    webconfig                               Config
      Worker Service                                worker                      [C#],F#     Common/Worker/Web
      xUnit Test Project                            xunit                       [C#],F#,VB  Test/xUnit
      ```

    </details>

5. Create a new console app in either of following ways
   1. In a folder named App1 with the name matching the folder name
      1. `mkdir App1; cd App1; dotnet new console`
   2. With Name App1 in a folder matching Project Name
      1. `dotnet new console -n App1`
   3. In new subfolder called App1 with project name matching folder name
      1. `dotnet new console -o App1`
   4. Project Name is App1Name and Folder Name is App1
      1. `dotnet new console -o App1 -n App1Name`
6. To add a `.gitignore` file
   - `dotnet new gitignore`
7. Run the application `dotnet run`
   1. Disable `ImplicitUsings` from .csproj file for tougher but better learning experience
      - Open the `.csproj` file.
      - Add or modify `ImplicitUsings` tag:

         ```xml
         <ImplicitUsings>disable</ImplicitUsings>
         ```



### What to Safely Ignore in .gitignore

- **Build Artifacts**: `bin/`, `obj/`
- **User-Specific Files**: `.vs/`, `*.user`, `*.suo`
- **Logs and Temporary Files**: `*.log`, `*.tmp`
- **IDE Settings**: `.vscode/`, `.idea/`

### What Not to Ignore

- **Source Code**: `*.cs`, `*.fs`, `*.vb`
- **Configuration Files**: `appsettings.json`, `.csproj`, `.fsproj`, `.vbproj`
- **Documentation**: `README.md`, `LICENSE`

This should help you get started quickly and manage your project files effectively. If you need more details, just let me know!

## .Net Helpful Commands

1. **Create a new solution**:

   ```bash
   dotnet new sln -n MySolution
   ```

   This command creates a new solution file named `MySolution.sln`.

2. **Create a new console application**:

   ```bash
   dotnet new console -n MyConsoleApp
   ```

   This command creates a new console application project named `MyConsoleApp`.

3. **Create a new class library**:

   ```bash
   dotnet new classlib -n MyLibrary
   ```

   This command creates a new class library project named `MyLibrary`.

4. **Add a project to a solution**:

   ```bash
   dotnet sln MySolution.sln add MyConsoleApp/MyConsoleApp.csproj
   ```

   This command adds the `MyConsoleApp` project to the `MySolution.sln` solution file.

5. **Remove a project from a solution**:

   ```bash
   dotnet sln MySolution.sln remove MyConsoleApp/MyConsoleApp.csproj
   ```

   This command removes the `MyConsoleApp` project from the `MySolution.sln` solution file.

6. **Build a project**:

   ```bash
   dotnet build MyConsoleApp
   ```

   This command builds the `MyConsoleApp` project.

7. **Run a project**:

   ```bash
   dotnet run --project MyConsoleApp
   ```

   This command runs the `MyConsoleApp` project.

8. **Test a project**:

   ```bash
   dotnet test MyTestProject
   ```

   This command runs tests in the `MyTestProject`.

9. **Publish a project**:

   ```bash
   dotnet publish MyConsoleApp -c Release -o ./publish
   ```

   This command publishes the `MyConsoleApp` project in release configuration to the `./publish` directory.

These commands should help you manage your .NET projects and solutions effectively on macOS.
