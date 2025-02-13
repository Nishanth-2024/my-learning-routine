#!/bin/sh

# Clean and rebuild (in Debug configuration)

# Remove Implementation build artifacts
rm -rf ./Implementations/bin
rm -rf ./Implementations/obj

# Remove Tests build artifacts
rm -rf ./Tests/bin
rm -rf ./Tests/obj

rm -rf $PWD/Tests/TestResults

dotnet clean
dotnet build -c Debug

# Run tests with coverage (from the Tests directory)
cd Tests || exit 1  # Change directory to Tests, exit if fails
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
