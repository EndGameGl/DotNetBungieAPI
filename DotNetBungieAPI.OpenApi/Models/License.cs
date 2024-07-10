using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class License
{
    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("url")]
    public string Url { get; init; }
}
