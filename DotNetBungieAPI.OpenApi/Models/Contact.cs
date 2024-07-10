using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class Contact
{
    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("url")]
    public string Url { get; init; }

    [JsonPropertyName("email")]
    public string Email { get; init; }
}
