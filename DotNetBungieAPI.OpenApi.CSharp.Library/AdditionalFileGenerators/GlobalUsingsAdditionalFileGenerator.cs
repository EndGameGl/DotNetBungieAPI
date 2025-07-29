using DotNetBungieAPI.OpenApi.CodeGeneration;

namespace DotNetBungieAPI.OpenApi.CSharp.Library.AdditionalFileGenerators;

public class GlobalUsingsAdditionalFileGenerator : AdditionalFileGenerator
{
    private const string GlobalUsingsText =
        """
        global using System.Text.Json.Serialization;

        namespace DotNetBungieAPI.Generated.Models;
        """;

    public override string FileNameAndExtension => "GlobalUsings.cs";

    public override async Task WriteFile(Models.OpenApi openApiModel)
    {
        await WriteAsync(GlobalUsingsText);
    }
}
