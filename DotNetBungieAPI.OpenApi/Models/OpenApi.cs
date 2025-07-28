using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class OpenApi
{
    [JsonPropertyName("openapi")]
    public required string OpenApiVersion { get; init; }

    [JsonPropertyName("info")]
    public required OpenApiInfo Info { get; init; }

    [JsonPropertyName("servers")]
    public required UrlWithDescription[] Servers { get; init; }

    [JsonPropertyName("paths")]
    public required Dictionary<string, OpenApiPath> Paths { get; init; }

    [JsonPropertyName("components")]
    public required OpenApiComponents Components { get; init; }

    [JsonPropertyName("tags")]
    public required Tag[] Tags { get; init; }

    [JsonPropertyName("externalDocs")]
    public required UrlWithDescription ExternalDocs { get; init; }
}
