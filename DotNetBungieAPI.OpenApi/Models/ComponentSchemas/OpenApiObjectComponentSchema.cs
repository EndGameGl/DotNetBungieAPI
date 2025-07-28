using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

public class OpenApiObjectComponentSchema : IOpenApiComponentSchema, IHasDescription
{
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    [JsonPropertyName("properties")]
    public required Dictionary<string, IOpenApiComponentSchema> Properties { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("x-destiny-component-type-dependency")]
    public string? DestinyComponentTypeDependency { get; init; }
    
    [JsonPropertyName("x-mobile-manifest-name")]
    public string? MobileManifestName { get; init; }
}
