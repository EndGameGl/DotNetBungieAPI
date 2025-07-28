using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class OpenApiInfo
{
    [JsonPropertyName("title")]
    public required string Title { get; init; }

    [JsonPropertyName("description")]
    public required string Description { get; init; }

    [JsonPropertyName("termsOfService")]
    public required string TermsOfService { get; init; }

    [JsonPropertyName("contact")]
    public required Contact Contact { get; init; }

    [JsonPropertyName("license")]
    public required License License { get; init; }

    [JsonPropertyName("version")]
    public required string Version { get; init; }
}
