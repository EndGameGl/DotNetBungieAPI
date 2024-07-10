using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class OpenApiInfo
{
    [JsonPropertyName("title")]
    public string Title { get; init; }

    [JsonPropertyName("description")]
    public string Description { get; init; }

    [JsonPropertyName("termsOfService")]
    public string TermsOfService { get; init; }

    [JsonPropertyName("contact")]
    public Contact Contact { get; init; }

    [JsonPropertyName("license")]
    public License License { get; init; }

    [JsonPropertyName("version")]
    public string Version { get; init; }
}
