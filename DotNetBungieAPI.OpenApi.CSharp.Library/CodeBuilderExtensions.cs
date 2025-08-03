using DotNetBungieAPI.OpenApi.CSharp.Library.AdditionalFileGenerators;

namespace DotNetBungieAPI.OpenApi.CSharp.Library;

public static class CodeBuilderExtensions
{
    public static async Task BuildCSharpExtendedDefinitions(this CodeBuilder codeBuilder)
    {
        await codeBuilder.BuildDefinitions(
            new CSharpExtendedClassGenerator(),
            null,
            new GlobalUsingsAdditionalFileGenerator(),
            new DefinitionsEnumFileGenerator(),
            new BungieResponseAdditionalFileGenerator(),
            new IDestinyDefinitionInterfaceFileGenerator(),
            new DefinitionHashPointerFileGenerator(),
            new JsonSerializationContextAdditionalFileGenerator(),
            new DefinitionHashPointerFileGenerator()
        );
    }
}
