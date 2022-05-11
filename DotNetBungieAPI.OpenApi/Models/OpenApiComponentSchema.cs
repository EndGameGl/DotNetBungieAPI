using System.Diagnostics;
using System.Text.Json.Serialization;
using DotNetBungieAPI.OpenApi.Extensions;

namespace DotNetBungieAPI.OpenApi.Models;

public class OpenApiComponentSchema
{
    [JsonPropertyName("enum")] public List<string>? Enum { get; init; }

    [JsonPropertyName("type")] public string Type { get; init; }

    [JsonPropertyName("format")] public string? Format { get; init; }

    [JsonPropertyName("x-enum-values")] public List<EnumValue>? EnumValues { get; init; }

    [JsonPropertyName("x-enum-is-bitmask")]
    public bool EnumIsBitmask { get; init; }

    [JsonPropertyName("x-enum-reference")] public OpenApiComponentSchema? EnumReference { get; init; }

    [JsonPropertyName("$ref")] public string? TypeReference { get; init; }

    [JsonPropertyName("description")] public string? Description { get; init; }

    [JsonPropertyName("items")] public OpenApiComponentSchema? Items { get; init; }

    [JsonPropertyName("properties")] public Dictionary<string, OpenApiComponentSchema>? Properties { get; init; }

    [JsonPropertyName("nullable")] public bool Nullable { get; init; }

    [JsonPropertyName("additionalProperties")]
    public OpenApiComponentSchema? AdditionalProperties { get; init; }

    [JsonPropertyName("x-dictionary-key")] public OpenApiComponentSchema? DictionaryKey { get; init; }

    [JsonPropertyName("x-mapped-definition")]
    public OpenApiComponentSchema? MappedDefinition { get; init; }

    [JsonPropertyName("allOf")] public List<OpenApiComponentSchema> AllOf { get; init; }

    [JsonPropertyName("x-destiny-component-type-dependency")]
    public string DestinyComponentTypeDependency { get; init; }
}