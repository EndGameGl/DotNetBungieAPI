namespace DotNetBungieAPI.Models.Config;

public sealed class UserTheme
{
    [JsonPropertyName("userThemeId")]
    public int UserThemeId { get; init; }

    [JsonPropertyName("userThemeName")]
    public string UserThemeName { get; init; }

    [JsonPropertyName("userThemeDescription")]
    public string UserThemeDescription { get; init; }
}
