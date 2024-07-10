using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class OpenApiComponents
{
    [JsonPropertyName("schemas")]
    public Dictionary<string, OpenApiComponentSchema> Schemas { get; init; }

    [JsonPropertyName("responses")]
    public Dictionary<string, OpenApiComponentResponse> Responses { get; init; }

    [JsonPropertyName("headers")]
    public Dictionary<string, HeaderEntry> Headers { get; init; }

    [JsonPropertyName("securitySchemes")]
    public SecuritySchemes SecuritySchemes { get; init; }
}
