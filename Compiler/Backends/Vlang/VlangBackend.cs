namespace Compiler.Backends.Vlang;

public class VlangBackend : Backend, IBackend
{
    public TranspilingResult Transpile(BuildJob job)
    {
        var inputFilePath = job.SourceFile;

        var inputStream = new StreamReader(inputFilePath);

        var ast = ParseSourceCode(inputStream);

        Analyze(ast);

        var outputFilePath = Path.Combine(job.TargetDirectory, "output.v");

        var outputStream = new StreamWriter(outputFilePath);

        GenerateOutput(ast, outputStream);

        return new TranspilingResult() { OutputFilePath = outputFilePath };
    }

    public BuildResult Build(TranspilingResult transpile)
    {
        var vlang = new VlangRunner();

        var process = vlang.Run([transpile.OutputFilePath]);

        var output = process.StandardOutput.ReadToEnd();
        Console.WriteLine(output);

        return new BuildResult();
    }

    public int Run(TranspilingResult transpile)
    {
        var vlang = new VlangRunner();

        var process = vlang.Run(["run", transpile.OutputFilePath]);

        var output = process.StandardOutput.ReadToEnd();
        Console.WriteLine(output);
        
        return process.ExitCode;
    }

    // implementation details

    private object ParseSourceCode(StreamReader input)
    {
        // Placeholder for actual parsing logic
        return new { };
    }

    private void Analyze(object ast)
    {
        // Placeholder for actual AST analysis logic
    }

    private void GenerateOutput(object ast, StreamWriter outputStream)
    {
        const string hello = """
                             fn main() {
                                 println("Hello, World!");
                             }
                             """;

        outputStream.Write(hello);

        outputStream.Flush();
    }
}
