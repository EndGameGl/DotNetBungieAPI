using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class OpenApiPathMethodInfoRequest
{
    [JsonPropertyName("content")]
    public Dictionary<string, OpenApiPathMethodInfoRequestContent> Content { get; set; }

    [JsonPropertyName("required")]
    public bool Required { get; set; }
}
