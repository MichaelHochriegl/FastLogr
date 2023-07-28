using System.Runtime.CompilerServices;

namespace FastLogr.Generator.Tests.Verify;

public class VerifyModuleInitializer
{
    [ModuleInitializer]
    public static void Init()
    {
        VerifySourceGenerators.Initialize();
    }
}