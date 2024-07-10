namespace DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

public sealed record DestinyFireteamFinderOptionValuesDefinition
{
    [JsonPropertyName("displayFormatType")]
    public int DisplayFormatType { get; init; }

    [JsonPropertyName("optionalFormatString")]
    public string OptionalFormatString { get; init; }

    [JsonPropertyName("type")]
    public int Type { get; init; }
}
