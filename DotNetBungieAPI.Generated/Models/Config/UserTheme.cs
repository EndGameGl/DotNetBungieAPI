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
}