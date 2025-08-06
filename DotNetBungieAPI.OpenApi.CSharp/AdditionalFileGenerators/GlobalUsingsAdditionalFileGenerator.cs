using DotNetBungieAPI.OpenApi.CodeGeneration;

namespace DotNetBungieAPI.OpenApi.CSharp.AdditionalFileGenerators;

public class GlobalUsingsAdditionalFileGenerator : AdditionalFileGenerator
{
    private const string GlobalUsingsText = """
        global using System.Text.Json.Serialization;
        """;

    public override string FileNameAndExtension => "GlobalUsings.cs";
    public override string Location => string.Empty;

    public override async Task WriteFile(Models.OpenApi openApiModel)
    {
        await WriteAsync(GlobalUsingsText);
    }
}
