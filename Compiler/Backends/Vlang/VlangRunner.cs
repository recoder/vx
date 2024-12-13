namespace Compiler.Backends.Vlang;

public class VlangRunner
{
    public Process Run(string[] args)
    {
        var vlangRoot = DetectVlangRoot();

        var vlangExecutable = Path.Combine(vlangRoot, "v");

        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName               = vlangExecutable,
                Arguments              = string.Join(" ", args),
                RedirectStandardOutput = true,
                RedirectStandardError  = true,
                UseShellExecute        = false,
                CreateNoWindow         = true
            }
        };

        process.Start();
        process.WaitForExit();

        if (process.ExitCode != 0)
        {
            var error = process.StandardError.ReadToEnd();
            throw new InvalidOperationException($"Build failed: {error}");
        }
        
        return process;
    }
    
    private string DetectVlangRoot()
    {
        var vlangRoot = Environment.GetEnvironmentVariable("VLANG_ROOT");
        if (string.IsNullOrEmpty(vlangRoot))
        {
            throw new InvalidOperationException("VLANG_ROOT environment variable is not set.");
        }
        
        // we might autodetect the root in the future
        
        return vlangRoot;
    }
}
