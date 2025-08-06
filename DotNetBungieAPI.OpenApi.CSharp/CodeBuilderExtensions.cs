using DotNetBungieAPI.OpenApi.CSharp.AdditionalFileGenerators;

namespace DotNetBungieAPI.OpenApi.CSharp;

public static class CodeBuilderExtensions
{
    public static async Task BuildCSharpDefinitions(this CodeBuilder codeBuilder)
    {
        await codeBuilder.BuildDefinitions(
            new CSharpClassGenerator(),
            [new CSharpMethodGroupGenerator()],
            [
                new GlobalUsingsAdditionalFileGenerator(),
                new JsonSerializationContextAdditionalFileGenerator(),
                new ApiResponseAdditionalFileGenerator(),
                new IDestinyDefinitionInterfaceFileGenerator(),
            ]
        );
    }
}
