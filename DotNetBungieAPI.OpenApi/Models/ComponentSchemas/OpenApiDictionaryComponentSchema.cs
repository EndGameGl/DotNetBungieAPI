using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

public class OpenApiDictionaryComponentSchema : IOpenApiComponentSchema, IHasDescription, IMappedDefinition
{
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    [JsonPropertyName("additionalProperties")]
    public required IOpenApiComponentSchema AdditionalProperties { get; init; }

    [JsonPropertyName("x-mapped-definition")]
    public OpenApiComponentReference? MappedDefinition { get; init; }

    [JsonPropertyName("x-dictionary-key")]
    public required IOpenApiComponentSchema DictionaryKey { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }
}
