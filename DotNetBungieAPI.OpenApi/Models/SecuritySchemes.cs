using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class SecuritySchemes
{
    [JsonPropertyName("apiKey")] public ApiKey ApiKey { get; init; }

    [JsonPropertyName("oauth2")] public OAuth2 OAuth2 { get; init; }
}