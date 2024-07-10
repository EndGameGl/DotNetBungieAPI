namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.FireteamFinder;

public class DestinyFireteamFinderOptionValues
{
    [JsonPropertyName("optionalNull")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? OptionalNull { get; set; }

    [JsonPropertyName("optionalFormatString")]
    public string? OptionalFormatString { get; set; }

    [JsonPropertyName("displayFormatType")]
    public Destiny.FireteamFinderOptionDisplayFormat? DisplayFormatType { get; set; }

    [JsonPropertyName("type")]
    public Destiny.FireteamFinderOptionValueProviderType? Type { get; set; }

    [JsonPropertyName("valueDefinitions")]
    public List<Destiny.Definitions.FireteamFinder.DestinyFireteamFinderOptionValueDefinition> ValueDefinitions { get; set; }
}
