namespace DotNetBungieAPI.Models.Config;

public sealed record UserTheme
{
    [JsonPropertyName("userThemeId")] public int UserThemeId { get; init; }

    [JsonPropertyName("userThemeName")] public string UserThemeName { get; init; }

    [JsonPropertyName("userThemeDescription")]
    public string UserThemeDescription { get; init; }
}