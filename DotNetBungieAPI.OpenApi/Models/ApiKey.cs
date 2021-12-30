using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class ApiKey
{
    [JsonPropertyName("type")] public string Type { get; init; }

    [JsonPropertyName("description")] public string Description { get; init; }

    [JsonPropertyName("name")] public string Name { get; init; }

    [JsonPropertyName("in")] public string In { get; init; }
}