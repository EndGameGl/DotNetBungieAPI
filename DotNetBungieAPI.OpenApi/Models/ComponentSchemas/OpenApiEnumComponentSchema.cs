using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

public class OpenApiEnumComponentSchema : IOpenApiComponentSchema, IHasDescription
{
    [JsonPropertyName("enum")]
    public required string[] Enum { get; init; }

    [JsonPropertyName("type")]
    public required string Type { get; init; }

    [JsonPropertyName("format")]
    public string? Format { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("x-enum-values")]
    public required EnumValue[] EnumValues { get; init; }

    [JsonPropertyName("x-enum-is-bitmask")]
    public required bool EnumIsBitmask { get; init; }
}
