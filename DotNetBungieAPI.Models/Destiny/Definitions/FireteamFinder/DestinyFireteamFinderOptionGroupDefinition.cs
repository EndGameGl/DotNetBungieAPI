using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;

namespace DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

[DestinyDefinition(DefinitionsEnum.DestinyFireteamFinderOptionGroupDefinition)]
public sealed record DestinyFireteamFinderOptionGroupDefinition
    : IDestinyDefinition,
        IDisplayProperties,
        IDeepEquatable<DestinyFireteamFinderOptionGroupDefinition>
{
    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("descendingSortPriority")]
    public int DescendingSortPriority { get; init; }

    public DefinitionsEnum DefinitionEnumValue =>
        DefinitionsEnum.DestinyFireteamFinderOptionGroupDefinition;

    [JsonPropertyName("blacklisted")]
    public bool Blacklisted { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }

    public bool DeepEquals(DestinyFireteamFinderOptionGroupDefinition other)
    {
        return other != null
            && DescendingSortPriority == other.DescendingSortPriority
            && DisplayProperties.DeepEquals(other.DisplayProperties)
            && Blacklisted == other.Blacklisted
            && Hash == other.Hash
            && Index == other.Index
            && Redacted == other.Redacted;
    }
}
