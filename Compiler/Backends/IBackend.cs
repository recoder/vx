namespace Compiler;

public interface IBackend
{
    void Transpile(BuildJob job);
}
