# Setup

- ***Create Solution:*** `dotnet new sln -o MySolution.sln`

- ***Create Project:*** `dotnet new console -o MyProject`

- ***Add Project to Solution:*** `dotnet sln MySolution.sln add MyProject/MyProject.csproj`

- ***Create Tests Project:*** `dotnet new xunit -o MyTests`

- ***Add Tests Project to Solution:*** `dotnet sln MySolution.sln add MyTests/MyTests.csproj`

- ***Add Project as reference to Tests Project:*** `dotnet add MyTests/MyTests.csproj reference MyProject/MyProject.csproj`

- My Tests

  ```C#
  // MyTests/MyTests.cs
  using Xunit;
  using MyProject; // Important: Use the correct namespace of your main project

  namespace MyTests // Important: Use the correct namespace of your test project
  {
      public class MyTestsClass // Give a descriptive name to your test class
      {
          [Fact]
          public void TestAdd()
          {
              Assert.Equal(5, Program.Add(2, 3)); // Example: Test a method in your main project.  Adjust the namespace and class/method names accordingly.
          }
      }
  }
  ```

- ***Add Coverage Collector Packages to Tests Project:*** `cd MyTests; dotnet add package coverlet.collector; dotnet add package reportgenerator; cd ..;`

- coverage collector script for easy running

  ```sh
  #!/bin/sh

  # Clean and rebuild (in Debug configuration)
  rm -rf ./MyProject/bin
  rm -rf ./MyProject/obj
  rm -rf ./MyTests/bin
  rm -rf ./MyTests/obj
  rm -rf ./MyTests/TestResults

  dotnet clean
  dotnet build -c Debug

  # Run tests with coverage (from the MyTests directory)
  cd MyTests || exit 1
  dotnet test --collect:"XPlat Code Coverage"
  if [ $? -ne 0 ]; then  # Check if tests passed
    echo "Tests failed!"
    exit 1
  fi

  # Create timestamped directory for report
  timestamp=$(date +"%Y-%m-%d-%H-%M-%S")
  report_dir="$PWD/coveragereport/$timestamp"
  mkdir -p "$report_dir" # Create directory and any parent directories if they don't exist

  # Find the coverage.cobertura.xml file (handles changing GUIDs)
  coverage_file=$(find "$PWD/TestResults" -name "coverage.cobertura.xml")

  # Generate coverage report
  if [ -n "$coverage_file" ]; then  # Check if coverage file was found
      reportgenerator "$coverage_file" -reports:"$coverage_file" -targetdir:"$report_dir" -reporttypes:Html
      if [ $? -ne 0 ]; then  # Check if report generation succeeded
          echo "Report generation failed!"
          exit 1
      fi
  else
      echo "coverage.cobertura.xml file not found!"
      exit 1
  fi


  # Open the report (platform-specific)
  if command -v open >/dev/null 2>&1; then  # Check if 'open' command exists (macOS)
    open "$report_dir/index.htm"
  elif command -v xdg-open >/dev/null 2>&1; then  # Check if 'xdg-open' exists (Linux)
    xdg-open "$report_dir/index.htm"
  fi

  cd .. || exit 1  # Return to root project directory
  ```

- add these test reports to .gitignore

  ```.gitignore
  # custom configured locations
  TestResults
  coveragereport
  ```