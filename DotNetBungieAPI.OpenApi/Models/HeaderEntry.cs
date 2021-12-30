using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class HeaderEntry
{
    [JsonPropertyName("description")] public string Description { get; init; }

    [JsonPropertyName("required")] public bool Required { get; init; }

    [JsonPropertyName("allowEmptyValue")] public bool AllowEmptyValue { get; init; }

    [JsonPropertyName("schema")] public Dictionary<string, string> Schema { get; init; }
}