using DotNetBungieAPI.OpenApi.CodeGeneration;

namespace DotNetBungieAPI.OpenApi.CSharp;

public class JsonSerializationContextAdditionalFileGenerator : AdditionalFileGenerator
{
    public override string FileNameAndExtension => "DotNetBungieAPIJsonSerializationContext.cs";

    public override async Task WriteFile(Models.OpenApi openApiModel)
    {
        await WriteLineAsync("namespace DotNetBungieAPI.Generated.Models;");
        await WriteLineAsync();
        
        foreach (var (typeName, typeSchema) in openApiModel.Components.Schemas)
        {
            if (typeSchema.Type is "object" && (typeSchema.Properties is null || !typeSchema.Properties.Any()))
                continue;
            await WriteLineAsync($"[JsonSerializable(typeof({typeName}))]");
        }
            
        await WriteLineAsync("public partial class DotNetBungieAPIJsonSerializationContext : JsonSerializerContext { }");
    }
}