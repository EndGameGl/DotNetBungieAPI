using DotNetBungieAPI.Models.Destiny.Definitions.Common;

namespace DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

public sealed record DestinyFireteamFinderOptionValueDefinition
{
    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("value")]
    public uint Value { get; init; }

    [JsonPropertyName("flags")]
    public FireteamFinderOptionValueFlags Flags { get; init; }
}
