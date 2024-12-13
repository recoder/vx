namespace Compiler.Backends.Vlang;

public class VlangBackend : IBackend
{
    public TranspilingResult Transpile(BuildJob job)
    {
        return new TranspilingResult();
    }

    public BuildResult Build(TranspilingResult transpile)
    {
        return new BuildResult();
    }

    public void Run(TranspilingResult transpile)
    {
        throw new NotImplementedException();
    }
}
