using DotNetBungieAPI.OpenApi.CSharp.Library.AdditionalFileGenerators;

namespace DotNetBungieAPI.OpenApi.CSharp.Library;

public static class CodeBuilderExtensions
{
    public static async Task BuildCSharpExtendedDefinitions(this CodeBuilder codeBuilder)
    {
        await codeBuilder.BuildDefinitions(
            new CSharpExtendedClassGenerator(),
            [new CSharpExtendedMethodGroupGenerator(), new CSharpExtendedImplMethodGroupGenerator()],
            [
                new GlobalUsingsAdditionalFileGenerator(),
                new DefinitionsEnumFileGenerator(),
                new BungieResponseAdditionalFileGenerator(),
                new IDestinyDefinitionInterfaceFileGenerator(),
                new DefinitionHashPointerFileGenerator(),
                new JsonSerializationContextAdditionalFileGenerator(),
                new DefinitionHashPointerFileGenerator(),
                new DefinitionHashPointerConverterFactoryFileGenerator(),
                new DestinyDefinitionAttributeFileGenerator(),
                new DefinitionsEnumExtensionsFileGenerator(),
                new BungieLocaleExtensionsFileGenerator(),
                new BungieLocaleFileGenerator(),
            ]
        );
    }
}
