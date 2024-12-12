using System.CommandLine;
using System.CommandLine.NamingConventionBinder;


/*    
    
# Vitu CLI Usage Guide

## Commands Overview

### `build`
Compiles a Vitu project.
- **Options**:
  - `--backend`: Specify the backend (e.g., `v`, `go`).
  - `--os`: Target operating system.
  - `--arch`: Target architecture.
  - `--debug`, `--release`: Build mode.

### `run`
Runs a Vitu program directly.
- Behaves similarly to `go run`.

### `test`
Runs tests for a Vitu project.
- **Options**:
  - `--backend`: Specify the backend for tests.

### `fmt`
Formats Vitu source code.
- **Options**:
  - `--style`: Choose formatting style (`ascii` or `unicode`).

### `get`
Downloads and installs modules.
- **Options**:
  - `module@version`: Install a specific version.
  - Supports both global and project-local installation.

### `doc`
Displays documentation for a module or symbol.
- **Features**:
  - Supports Markdown formatting.

### `clean`
Removes build artifacts and temporary files.
- No options available.

### `version`
Prints the Vitu version.
- Includes supported backends and build metadata (e.g., commit hash, build date).

### `env`
Displays environment information.
- **Features**:
  - Backend-specific configuration.
  - Paths to installed modules or libraries.
  - Current OS and architecture.

### `transpile`
Transpiles Vitu code to other languages.
- **Features**:
  - Specify the target language backend.

## Example Usage

```sh
# Build a project for the `v` backend in release mode
vitu build --backend v --release

# Run a Vitu program
vitu run main.v2

# Format code with Unicode style
vitu fmt --style unicode

# Install a module globally
vitu get mymodule@1.2.3

# Clean build artifacts
vitu clean

# Display documentation for a module
vitu doc mymodule

# Transpile code to Go
vitu transpile --backend go
```

## Notes
- Commands and options may expand in future versions.
- Use `vitu help <command>` for detailed usage.

*/

var rootCommand = new RootCommand("Vitu Compiler");

var buildCommand = new Command("build", "Compiles a Vitu project")
{
    new Option<string>("--backend", "Specify the backend (e.g., `v`, `go`)"),
    new Option<string>("--os", "Target operating system"),
    new Option<string>("--arch", "Target architecture"),
    new Option<bool>("--debug", "Build in debug mode"),
    new Option<bool>("--release", "Build in release mode")
};
buildCommand.Handler = CommandHandler.Create<string, string, string, bool, bool>((backend, os, arch, debug, release) =>
{
    Console.WriteLine($"Building project with backend: {backend}, OS: {os}, Arch: {arch}, Debug: {debug}, Release: {release}");
    // Build logic here
});

var runCommand = new Command("run", "Runs a Vitu program directly")
{
    new Argument<string>("filename", "The Vitu source file to run")
};
runCommand.Handler = CommandHandler.Create<string>((filename) =>
{
    Console.WriteLine($"Running file: {filename}");
    // Run logic here
});

var testCommand = new Command("test", "Runs tests for a Vitu project")
{
    new Option<string>("--backend", "Specify the backend for tests")
};
testCommand.Handler = CommandHandler.Create<string>((backend) =>
{
    Console.WriteLine($"Testing with backend: {backend}");
    // Test logic here
});

var fmtCommand = new Command("fmt", "Formats Vitu source code")
{
    new Option<string>("--style", "Choose formatting style (`ascii` or `unicode`)")
};
fmtCommand.Handler = CommandHandler.Create<string>((style) =>
{
    Console.WriteLine($"Formatting with style: {style}");
    // Format logic here
});

var getCommand = new Command("get", "Downloads and installs modules")
{
    new Argument<string>("module@version", "Install a specific version")
};
getCommand.Handler = CommandHandler.Create<string>((moduleVersion) =>
{
    Console.WriteLine($"Installing module: {moduleVersion}");
    // Get logic here
});

var docCommand = new Command("doc", "Displays documentation for a module or symbol")
{
    new Argument<string>("moduleOrSymbol", "The module or symbol to display documentation for")
};
docCommand.Handler = CommandHandler.Create<string>((moduleOrSymbol) =>
{
    Console.WriteLine($"Displaying documentation for: {moduleOrSymbol}");
    // Doc logic here
});

var cleanCommand = new Command("clean", "Removes build artifacts and temporary files");
cleanCommand.Handler = CommandHandler.Create(() =>
{
    Console.WriteLine("Cleaning build artifacts and temporary files");
    // Clean logic here
});

var versionCommand = new Command("version", "Prints the Vitu version");
versionCommand.Handler = CommandHandler.Create(() =>
{
    Console.WriteLine("Vitu Compiler Version 0.0.1");
    // Version logic here
});

var envCommand = new Command("env", "Displays environment information");
envCommand.Handler = CommandHandler.Create(() =>
{
    Console.WriteLine("Displaying environment information");
    // Env logic here
});

var transpileCommand = new Command("transpile", "Transpiles Vitu code to other languages")
{
    new Option<string>("--backend", "Specify the target language backend")
};
transpileCommand.Handler = CommandHandler.Create<string>((backend) =>
{
    Console.WriteLine($"Transpiling to backend: {backend}");
    // Transpile logic here
});

rootCommand.AddCommand(buildCommand);
rootCommand.AddCommand(runCommand);
rootCommand.AddCommand(testCommand);
rootCommand.AddCommand(fmtCommand);
rootCommand.AddCommand(getCommand);
rootCommand.AddCommand(docCommand);
rootCommand.AddCommand(cleanCommand);
rootCommand.AddCommand(versionCommand);
rootCommand.AddCommand(envCommand);
rootCommand.AddCommand(transpileCommand);

return rootCommand.Invoke(args);