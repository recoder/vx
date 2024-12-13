using Compiler.Backends;
using Compiler.Backends.Vlang;

namespace Compiler;

public class VituCompiler
{
    public static string Version => "0.0.0";

    public int Transpile(BuildJob job)
    {
        // transpile = parse + compile + optimize + generate
        try
        {
            var backend = CreateBackend(job.Configuration.Backend);

            backend.Transpile(job);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return 1;
        }
        
        return 0;
    }

    public int Build(BuildJob job)
    {
        // build = transpile + compile + link
        try
        {

            var backend = CreateBackend(job.Configuration.Backend);

            var r = backend.Build(backend.Transpile(job));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return 1;
        }
        
        return 0;
    }

    public int Run(BuildJob job)
    {
        // run = build + execute
        try
        {
            var backend = CreateBackend(job.Configuration.Backend);

            return backend.Run(backend.Transpile(job));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return -1; 
    }

    public int Test(BuildJob job)
    {
        throw new NotImplementedException();
    }

    public int Format(string style)
    {
        throw new NotImplementedException();
    }

    public int Clean()
    {
        throw new NotImplementedException();
    }

    public int Env()
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
