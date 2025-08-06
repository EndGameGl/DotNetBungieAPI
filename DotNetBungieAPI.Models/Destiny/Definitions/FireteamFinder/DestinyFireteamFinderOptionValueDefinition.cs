namespace DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

public sealed class DestinyFireteamFinderOptionValueDefinition
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; init; }

    [JsonPropertyName("value")]
    public uint Value { get; init; }

    [JsonPropertyName("flags")]
    public Destiny.FireteamFinderOptionValueFlags Flags { get; init; }
}
