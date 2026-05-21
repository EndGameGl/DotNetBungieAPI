using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class EnumValue
{
    [JsonPropertyName("numericValue")]
    public required long NumericValue { get; init; }

    [JsonPropertyName("identifier")]
    public required string Identifier { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }
}
