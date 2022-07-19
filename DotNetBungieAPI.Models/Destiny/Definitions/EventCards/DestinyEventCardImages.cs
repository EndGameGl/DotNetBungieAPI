namespace DotNetBungieAPI.Models.Destiny.Definitions.EventCards;

public sealed record DestinyEventCardImages
{
    [JsonPropertyName("unownedCardSleeveImagePath")]
    public string UnownedCardSleeveImagePath { get; init; }

    [JsonPropertyName("unownedCardSleeveWrapImagePath")]
    public string UnownedCardSleeveWrapImagePath { get; init; }

    [JsonPropertyName("cardIncompleteImagePath")]
    public string CardIncompleteImagePath { get; init; }

    [JsonPropertyName("cardCompleteImagePath")]
    public string CardCompleteImagePath { get; init; }

    [JsonPropertyName("cardCompleteWrapImagePath")]
    public string CardCompleteWrapImagePath { get; init; }

    [JsonPropertyName("progressIconImagePath")]
    public string ProgressIconImagePath { get; init; }

    [JsonPropertyName("themeBackgroundImagePath")]
    public string ThemeBackgroundImagePath { get; init; }
}