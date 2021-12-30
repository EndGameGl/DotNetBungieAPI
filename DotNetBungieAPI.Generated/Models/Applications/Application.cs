using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Applications;

public sealed class Application
{

    [JsonPropertyName("applicationId")]
    public int ApplicationId { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("redirectUrl")]
    public string RedirectUrl { get; init; }

    [JsonPropertyName("link")]
    public string Link { get; init; }

    [JsonPropertyName("scope")]
    public long Scope { get; init; }

    [JsonPropertyName("origin")]
    public string Origin { get; init; }

    [JsonPropertyName("status")]
    public Applications.ApplicationStatus Status { get; init; }

    [JsonPropertyName("creationDate")]
    public DateTime CreationDate { get; init; }

    [JsonPropertyName("statusChanged")]
    public DateTime StatusChanged { get; init; }

    [JsonPropertyName("firstPublished")]
    public DateTime FirstPublished { get; init; }

    [JsonPropertyName("team")]
    public List<Applications.ApplicationDeveloper> Team { get; init; }

    [JsonPropertyName("overrideAuthorizeViewName")]
    public string OverrideAuthorizeViewName { get; init; }
}
