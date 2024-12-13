using Compiler.Backends;
using Compiler.Backends.Vlang;

namespace Compiler;

public class VituCompiler
{
    public static string Version => "0.0.0";

    public void Transpile(BuildJob job)
    {
        // transpile = parse + compile + optimize + generate

        var backend = CreateBackend(job.Configuration.Backend);

        try
        {
            var r = backend.Transpile(job);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void Build(BuildJob job)
    {
        // build = transpile + compile + link
        
        var backend = CreateBackend(job.Configuration.Backend);
        
        try
        {
            var r = backend.Build(backend.Transpile(job));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void Run(BuildJob job)
    {
        // run = build + execute
        
        var backend = CreateBackend(job.Configuration.Backend);
        
        try
        {
            backend.Run(backend.Transpile(job));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void Test(BuildJob job)
    {
        throw new NotImplementedException();
    }

    public void Format(string style)
    {
        throw new NotImplementedException();
    }

    public void Clean()
    {
        throw new NotImplementedException();
    }
    
    private IBackend CreateBackend(string configurationBackend)
    {
        return configurationBackend switch
        {
            "v" => new VlangBackend(),
            _   => throw new NotImplementedException()
        };
    }
}