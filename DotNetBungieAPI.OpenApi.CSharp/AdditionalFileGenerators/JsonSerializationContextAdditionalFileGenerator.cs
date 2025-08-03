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

        foreach (var (typeName, typeSchema) in openApiModel.Components.Schemas.OrderBy(x => x.Key))
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

        foreach (var (typeName, responseType) in openApiModel.Components.Responses)
        {
            var type = ((OpenApiObjectComponentSchema)responseType.Schema).Properties["Response"].GetCSharpType();
            await WriteLineAsync($"[JsonSerializable(typeof(ApiResponse<{type}>))]");
        }
        
        await WriteLineAsync(
            """
            [JsonSourceGenerationOptions(
                NumberHandling = JsonNumberHandling.AllowReadingFromString,
                AllowTrailingCommas = false, 
                DictionaryKeyPolicy = JsonKnownNamingPolicy.Unspecified,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            )]
            """);
        
        await WriteLineAsync(
            "public partial class DotNetBungieAPIJsonSerializationContext : JsonSerializerContext { }"
        );
    }
}
