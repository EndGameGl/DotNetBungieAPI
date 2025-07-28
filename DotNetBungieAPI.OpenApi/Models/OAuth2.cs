using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class OAuth2
{
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    [JsonPropertyName("description")]
    public required string Description { get; init; }

    [JsonPropertyName("flows")]
    public required Dictionary<string, OpenApiOAuth2Flow> Flows { get; init; }
}
