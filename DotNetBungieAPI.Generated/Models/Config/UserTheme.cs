namespace DotNetBungieAPI.Generated.Models.Config;

public class UserTheme : IDeepEquatable<UserTheme>
{
    [JsonPropertyName("userThemeId")]
    public int UserThemeId { get; set; }

    [JsonPropertyName("userThemeName")]
    public string UserThemeName { get; set; }

    [JsonPropertyName("userThemeDescription")]
    public string UserThemeDescription { get; set; }

    public bool DeepEquals(UserTheme? other)
    {
        return other is not null &&
               UserThemeId == other.UserThemeId &&
               UserThemeName == other.UserThemeName &&
               UserThemeDescription == other.UserThemeDescription;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(UserTheme? other)
    {
        if (other is null) return;
        if (UserThemeId != other.UserThemeId)
        {
            UserThemeId = other.UserThemeId;
            OnPropertyChanged(nameof(UserThemeId));
        }
        if (UserThemeName != other.UserThemeName)
        {
            UserThemeName = other.UserThemeName;
            OnPropertyChanged(nameof(UserThemeName));
        }
        if (UserThemeDescription != other.UserThemeDescription)
        {
            UserThemeDescription = other.UserThemeDescription;
            OnPropertyChanged(nameof(UserThemeDescription));
        }
    }
}