using System.Diagnostics;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

[DebuggerDisplay("{GetReferencedPath()}")]
public class OpenApiComponentReference : IOpenApiComponentSchema
{
    [JsonPropertyName("$ref")]
    public required string Reference { get; init; }

    public string GetReferencedPath() => Path.GetFileName(Reference);
}
