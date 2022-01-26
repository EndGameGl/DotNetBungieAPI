namespace DotNetBungieAPI.Generated.Models.User;

public class UserSearchPrefixRequest : IDeepEquatable<UserSearchPrefixRequest>
{
    [JsonPropertyName("displayNamePrefix")]
    public string DisplayNamePrefix { get; set; }

    public bool DeepEquals(UserSearchPrefixRequest? other)
    {
        return other is not null &&
               DisplayNamePrefix == other.DisplayNamePrefix;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(UserSearchPrefixRequest? other)
    {
        if (other is null) return;
        if (DisplayNamePrefix != other.DisplayNamePrefix)
        {
            DisplayNamePrefix = other.DisplayNamePrefix;
            OnPropertyChanged(nameof(DisplayNamePrefix));
        }
    }
}