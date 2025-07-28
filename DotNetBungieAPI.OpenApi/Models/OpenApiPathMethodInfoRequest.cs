using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class OpenApiPathMethodInfoRequest
{
    [JsonPropertyName("content")]
    public required Dictionary<string, OpenApiPathMethodInfoRequestContent> Content { get; init; }

    [JsonPropertyName("required")]
    public required bool Required { get; init; }
}
