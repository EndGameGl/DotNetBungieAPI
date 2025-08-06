using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class Contact
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("email")]
    public required string Email { get; init; }
}
