using CppSharp;
using CppSharp.AST;
using CppSharp.Generators;

public class SokolLib : ILibrary
{
    /// Setup the driver options here.
    public void Setup(Driver driver)
    {
        Console.WriteLine("setting up generator");
        var options = driver.Options;
        options.GeneratorKind = GeneratorKind.CSharp;
        var module = options.AddModule("Sokol");
        // module.IncludeDirs.Add(@"C:\Users\kyle\Workspace\fips-workspace\sokol");
        module.IncludeDirs.Add(@"\Users\kyle\Workspace\sokol-csharp\sokol_libs");
        module.Headers.Add("sokol_app.h");
        module.Headers.Add("sokol_gfx.h");
        module.Headers.Add("sokol_glue.h");
        // module.LibraryDirs.Add(@"C:\Users\kyle\Workspace\fips-workspace\fips-deploy\sokol-samples\sapp-win64-vscode-debug");
        module.LibraryDirs.Add(@"\Users\kyle\Workspace\sokol-csharp");
        module.Libraries.Add("sokol-dll.dll");
    }

    /// Setup your passes here.
    public void SetupPasses(Driver driver)
    {

    }

    /// Do transformations that should happen before passes are processed.
    public void Preprocess(Driver driver, ASTContext ctx)
    {

    }

    /// Do transformations that should happen after passes are processed.
    public void Postprocess(Driver driver, ASTContext ctx)
    {

    }
}