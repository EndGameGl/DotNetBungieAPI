using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

public class OpenApiIntegerComponentSchema : IOpenApiComponentSchema, IHasDescription, IMappedDefinition, ICanBeNullable
{
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("format")]
    public required string Format { get; init; }

    [JsonPropertyName("x-mapped-definition")]
    public OpenApiComponentReference? MappedDefinition { get; init; }

    [JsonPropertyName("nullable")]
    public bool? Nullable { get; init; }
}
