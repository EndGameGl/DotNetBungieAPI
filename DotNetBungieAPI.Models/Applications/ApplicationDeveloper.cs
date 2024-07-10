using DotNetBungieAPI.Models.User;

namespace DotNetBungieAPI.Models.Applications;

public sealed record ApplicationDeveloper
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("role")]
    public DeveloperRole Role { get; init; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("apiEulaVersion")]
    public int ApiEulaVersion { get; init; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("user")]
    public UserInfoCard User { get; init; }
}
