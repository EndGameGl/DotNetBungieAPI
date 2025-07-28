using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class OpenApiOAuth2Flow
{
    [JsonPropertyName("authorizationUrl")]
    public required string AuthorizationUrl { get; init; }

    [JsonPropertyName("tokenUrl")]
    public required string TokenUrl { get; init; }

    [JsonPropertyName("refreshUrl")]
    public required string RefreshUrl { get; init; }

    [JsonPropertyName("scopes")]
    public required Dictionary<string, string> Scopes { get; init; }
}
