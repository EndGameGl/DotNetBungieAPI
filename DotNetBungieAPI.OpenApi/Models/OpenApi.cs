using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class OpenApi
{
    [JsonPropertyName("swagger")]
    public string Swagger { get; init; }

    [JsonPropertyName("info")]
    public OpenApiInfo Info { get; init; }

    [JsonPropertyName("servers")]
    public List<UrlWithDescription> Servers { get; init; }

    [JsonPropertyName("paths")]
    public Dictionary<string, OpenApiPath> Paths { get; init; }

    [JsonPropertyName("components")]
    public OpenApiComponents Components { get; init; }

    [JsonPropertyName("tags")]
    public List<Tag> Tags { get; init; }

    [JsonPropertyName("externalDocs")]
    public UrlWithDescription ExternalDocs { get; init; }
}
