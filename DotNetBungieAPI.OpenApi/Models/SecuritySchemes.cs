using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class SecuritySchemes
{
    [JsonPropertyName("apiKey")]
    public required ApiKey ApiKey { get; init; }

    [JsonPropertyName("oauth2")]
    public required OAuth2 OAuth2 { get; init; }
}
