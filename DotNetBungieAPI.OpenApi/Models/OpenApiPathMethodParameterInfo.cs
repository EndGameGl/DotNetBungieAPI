using System.Diagnostics;
using System.Text.Json.Serialization;
using DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

namespace DotNetBungieAPI.OpenApi.Models;

[DebuggerDisplay("[{In}] {Name}")]
public class OpenApiPathMethodParameterInfo
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("in")]
    public required string In { get; init; }

    [JsonPropertyName("description")]
    public required string Description { get; init; }

    [JsonPropertyName("required")]
    public bool? Required { get; init; }
    
    [JsonPropertyName("deprecated")]
    public bool? Deprecated { get; init; }

    [JsonPropertyName("schema")]
    public required IOpenApiComponentSchema Schema { get; init; }
}
