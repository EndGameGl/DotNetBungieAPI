namespace DotNetBungieAPI.Models.Destiny.Definitions.Seasons;

public sealed class DestinySeasonPassImages
{
    [JsonPropertyName("iconImagePath")]
    public string IconImagePath { get; init; }

    [JsonPropertyName("themeBackgroundImagePath")]
    public string ThemeBackgroundImagePath { get; init; }
}
