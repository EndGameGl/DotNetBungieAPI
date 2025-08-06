using DotNetBungieAPI.OpenApi.CodeGeneration;

namespace DotNetBungieAPI.OpenApi.CSharp.Library.AdditionalFileGenerators;

public class GlobalUsingsAdditionalFileGenerator : AdditionalFileGenerator
{
    private const string GlobalUsingsText = """
        global using System.Text.Json.Serialization;
        global using DotNetBungieAPI.Models.Attributes;
        """;

    public override string FileNameAndExtension => "GlobalUsings.cs";
    public override string Location => "Models";

    public override async Task WriteFile(Models.OpenApi openApiModel)
    {
        await WriteAsync(GlobalUsingsText);
    }
}
