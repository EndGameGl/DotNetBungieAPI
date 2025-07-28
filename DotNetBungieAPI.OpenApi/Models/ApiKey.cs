using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class ApiKey
{
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    [JsonPropertyName("description")]
    public required string Description { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("in")]
    public required string In { get; init; }
}
