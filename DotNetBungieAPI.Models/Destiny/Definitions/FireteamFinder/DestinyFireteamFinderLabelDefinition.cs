using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;

namespace DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

[DestinyDefinition(DefinitionsEnum.DestinyFireteamFinderLabelDefinition)]
public sealed record DestinyFireteamFinderLabelDefinition
    : IDestinyDefinition,
        IDisplayProperties,
        IDeepEquatable<DestinyFireteamFinderLabelDefinition>
{
    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("descendingSortPriority")]
    public int DescendingSortPriority { get; init; }

    [JsonPropertyName("groupHash")]
    public DefinitionHashPointer<DestinyFireteamFinderLabelGroupDefinition> Group { get; init; } =
        DefinitionHashPointer<DestinyFireteamFinderLabelGroupDefinition>.Empty;

    [JsonPropertyName("allowInFields")]
    public FireteamFinderLabelFieldType AllowInFields { get; init; }

    public DefinitionsEnum DefinitionEnumValue =>
        DefinitionsEnum.DestinyFireteamFinderLabelDefinition;

    [JsonPropertyName("blacklisted")]
    public bool Blacklisted { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }

    public bool DeepEquals(DestinyFireteamFinderLabelDefinition other)
    {
        return other != null
            && AllowInFields == other.AllowInFields
            && DescendingSortPriority == other.DescendingSortPriority
            && DisplayProperties.DeepEquals(other.DisplayProperties)
            && Group.DeepEquals(other.Group)
            && Blacklisted == other.Blacklisted
            && Hash == other.Hash
            && Index == other.Index
            && Redacted == other.Redacted;
    }
}
