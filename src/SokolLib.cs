using CppSharp;
using CppSharp.AST;
using CppSharp.Generators;

public class SokolLib : ILibrary
{
    /// Setup the driver options here.
    public void Setup(Driver driver)
    {
        var options = driver.Options;
        options.GeneratorKind = GeneratorKind.CSharp;
        var module = options.AddModule("Sokol");
        module.IncludeDirs.Add(@"C:\Users\kyle\Workspace\fips-workspace\sokol");
        module.Headers.Add("sokol_app.h");
        module.Headers.Add("sokol_gfx.h");
        module.LibraryDirs.Add(@"C:\Users\kyle\Workspace\fips-workspace\fips-deploy\sokol-samples\sapp-win64-vscode-debug");
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