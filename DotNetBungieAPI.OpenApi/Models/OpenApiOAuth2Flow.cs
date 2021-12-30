using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class OpenApiOAuth2Flow
{
    [JsonPropertyName("authorizationUrl")] public string AuthorizationUrl { get; init; }

    [JsonPropertyName("tokenUrl")] public string TokenUrl { get; init; }
    
    [JsonPropertyName("refreshUrl")] public string RefreshUrl { get; init; }
    
    [JsonPropertyName("scopes")] public Dictionary<string, string> Scopes { get; init; }
}