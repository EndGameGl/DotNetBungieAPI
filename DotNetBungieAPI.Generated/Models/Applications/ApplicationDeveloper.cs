namespace DotNetBungieAPI.Generated.Models.Applications;

public class ApplicationDeveloper : IDeepEquatable<ApplicationDeveloper>
{
    [JsonPropertyName("role")]
    public Applications.DeveloperRole Role { get; set; }

    [JsonPropertyName("apiEulaVersion")]
    public int ApiEulaVersion { get; set; }

    [JsonPropertyName("user")]
    public User.UserInfoCard User { get; set; }

    public bool DeepEquals(ApplicationDeveloper? other)
    {
        return other is not null &&
               Role == other.Role &&
               ApiEulaVersion == other.ApiEulaVersion &&
               (User is not null ? User.DeepEquals(other.User) : other.User is null);
    }
}