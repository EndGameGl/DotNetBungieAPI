using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

public class OpenApiStringComponentSchema : IOpenApiComponentSchema, IHasDescription, ICanBeNullable
{
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("format")]
    public string? Format { get; init; }
    
    [JsonPropertyName("nullable")]
    public bool? Nullable { get; init; }
}