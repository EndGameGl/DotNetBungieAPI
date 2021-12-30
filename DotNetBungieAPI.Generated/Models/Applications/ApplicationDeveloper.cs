using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Applications;

public sealed class ApplicationDeveloper
{

    [JsonPropertyName("role")]
    public Applications.DeveloperRole Role { get; init; }

    [JsonPropertyName("apiEulaVersion")]
    public int ApiEulaVersion { get; init; }

    [JsonPropertyName("user")]
    public User.UserInfoCard User { get; init; }
}
