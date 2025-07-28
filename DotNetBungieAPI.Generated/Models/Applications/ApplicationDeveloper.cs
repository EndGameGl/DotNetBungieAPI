namespace DotNetBungieAPI.Generated.Models.Applications;

public class ApplicationDeveloper
{
    [JsonPropertyName("role")]
    public Applications.DeveloperRole Role { get; set; }

    [JsonPropertyName("apiEulaVersion")]
    public int ApiEulaVersion { get; set; }

    [JsonPropertyName("user")]
    public User.UserInfoCard? User { get; set; }
}
