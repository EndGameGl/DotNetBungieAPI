using System.Text.Json.Serialization;
using DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

namespace DotNetBungieAPI.OpenApi.Models;

public class OpenApiComponents
{
    [JsonPropertyName("schemas")]
    public required Dictionary<string, IOpenApiComponentSchema> Schemas { get; init; }

    [JsonPropertyName("responses")]
    public required Dictionary<string, OpenApiComponentResponse> Responses { get; init; }

    [JsonPropertyName("headers")]
    public required Dictionary<string, HeaderEntry> Headers { get; init; }

    [JsonPropertyName("securitySchemes")]
    public required SecuritySchemes SecuritySchemes { get; init; }
}
