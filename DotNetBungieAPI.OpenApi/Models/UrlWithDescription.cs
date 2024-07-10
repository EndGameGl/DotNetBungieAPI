using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class UrlWithDescription
{
    [JsonPropertyName("description")]
    public string Description { get; init; }

    [JsonPropertyName("url")]
    public string Url { get; init; }
}
