using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class OAuth2
{
    [JsonPropertyName("type")]
    public string Type { get; init; }

    [JsonPropertyName("description")]
    public string Description { get; init; }

    [JsonPropertyName("flows")]
    public Dictionary<string, OpenApiOAuth2Flow> Flows { get; init; }
}
