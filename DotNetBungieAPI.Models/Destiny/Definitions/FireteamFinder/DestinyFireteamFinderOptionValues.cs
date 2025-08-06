namespace DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

public sealed class DestinyFireteamFinderOptionValues
{
    [JsonPropertyName("optionalNull")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? OptionalNull { get; init; }

    [JsonPropertyName("optionalFormatString")]
    public string OptionalFormatString { get; init; }

    [JsonPropertyName("displayFormatType")]
    public Destiny.FireteamFinderOptionDisplayFormat DisplayFormatType { get; init; }

    [JsonPropertyName("type")]
    public Destiny.FireteamFinderOptionValueProviderType Type { get; init; }

    [JsonPropertyName("valueDefinitions")]
    public Destiny.Definitions.FireteamFinder.DestinyFireteamFinderOptionValueDefinition[]? ValueDefinitions { get; init; }
}
