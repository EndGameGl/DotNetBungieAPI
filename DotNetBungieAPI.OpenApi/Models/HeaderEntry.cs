using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class HeaderEntry
{
    [JsonPropertyName("description")]
    public required string Description { get; init; }

    [JsonPropertyName("required")]
    public required bool Required { get; init; }

    [JsonPropertyName("allowEmptyValue")]
    public required bool AllowEmptyValue { get; init; }

    [JsonPropertyName("schema")]
    public required Dictionary<string, string> Schema { get; init; }
}
