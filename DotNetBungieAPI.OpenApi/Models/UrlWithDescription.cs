using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class UrlWithDescription
{
    [JsonPropertyName("description")]
    public required string Description { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }
}
