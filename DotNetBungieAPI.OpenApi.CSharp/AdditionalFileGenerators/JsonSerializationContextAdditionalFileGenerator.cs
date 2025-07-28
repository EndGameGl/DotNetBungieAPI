using DotNetBungieAPI.OpenApi.CodeGeneration;
using DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

namespace DotNetBungieAPI.OpenApi.CSharp.AdditionalFileGenerators;

public class JsonSerializationContextAdditionalFileGenerator : AdditionalFileGenerator
{
    public override string FileNameAndExtension => "DotNetBungieAPIJsonSerializationContext.cs";

    public override async Task WriteFile(Models.OpenApi openApiModel)
    {
        await WriteLineAsync("namespace DotNetBungieAPI.Generated.Models;");
        await WriteLineAsync();

        foreach (var (typeName, typeSchema) in openApiModel.Components.Schemas)
        {
            if (
                typeSchema
                is OpenApiObjectMultiTypeComponentSchema
                    or OpenApiObjectComponentSchema
                    or OpenApiEnumComponentSchema
            )
            {
                await WriteLineAsync($"[JsonSerializable(typeof({typeName}))]");
            }
        }

        await WriteLineAsync(
            "public partial class DotNetBungieAPIJsonSerializationContext : JsonSerializerContext { }"
        );
    }
}
