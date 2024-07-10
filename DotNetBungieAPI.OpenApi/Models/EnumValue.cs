using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class EnumValue
{
    [JsonPropertyName("numericValue")]
    public string NumericValue { get; init; }

    [JsonPropertyName("identifier")]
    public string Identifier { get; init; }

    [JsonPropertyName("description")]
    public string Description { get; init; }
}
