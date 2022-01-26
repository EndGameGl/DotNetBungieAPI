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

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(ApplicationDeveloper? other)
    {
        if (other is null) return;
        if (Role != other.Role)
        {
            Role = other.Role;
            OnPropertyChanged(nameof(Role));
        }
        if (ApiEulaVersion != other.ApiEulaVersion)
        {
            ApiEulaVersion = other.ApiEulaVersion;
            OnPropertyChanged(nameof(ApiEulaVersion));
        }
        if (!User.DeepEquals(other.User))
        {
            User.Update(other.User);
            OnPropertyChanged(nameof(User));
        }
    }
}