namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.FireteamFinder;

public class DestinyFireteamFinderOptionValueDefinition
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; set; }

    [JsonPropertyName("value")]
    public uint? Value { get; set; }

    [JsonPropertyName("flags")]
    public Destiny.FireteamFinderOptionValueFlags? Flags { get; set; }
}
