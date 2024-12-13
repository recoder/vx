namespace Compiler;

public class BuildConfiguration
{
    private const string DEFAULT_BACKEND = "v";

#if WINDOWS
    private const string DEFAULT_OS = "windows";
#elif LINUX
    private const string DEFAULT_OS = "linux";
#elif OSX
    private const string DEFAULT_OS = "osx";
#else
    private const string DEFAULT_OS = "";
#endif

#if X64
    private const string DEFAULT_ARCH = "x64";
#elif X86
    private const string DEFAULT_ARCH = "x86";
#else
    private const string DEFAULT_ARCH = "";
#endif
    
    public        string Backend            { get; set; } = DEFAULT_BACKEND;
    public        string TargetOS           { get; set; } = DEFAULT_OS;
    public        string TargetArchitecture { get; set; } = DEFAULT_ARCH;
    public        bool   Debug              { get; set; } = false;
    public        bool   Release            { get; set; } = false;
    
}

public class BuildJob
{
    public BuildConfiguration Configuration   { get; set; }
    public string             SourceFile      { get; set; }
    public string             TargetDirectory { get; set; }
}
