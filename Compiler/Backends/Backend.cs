namespace Compiler.Backends;

public interface IBackend
{
    TranspilingResult Transpile(BuildJob job);
    
    BuildResult Build(TranspilingResult transpile);
    
    void Run(TranspilingResult transpile);
}

public class BuildResult
{
}

public class TranspilingResult
{
    public string OutputFilePath { get; set; } = "";
}

public class Backend
{
}