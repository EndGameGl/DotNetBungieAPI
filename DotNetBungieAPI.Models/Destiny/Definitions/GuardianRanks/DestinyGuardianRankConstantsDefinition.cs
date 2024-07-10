using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;
using DotNetBungieAPI.Models.Destiny.Definitions.PresentationNodes;

namespace DotNetBungieAPI.Models.Destiny.Definitions.GuardianRanks;

[DestinyDefinition(DefinitionsEnum.DestinyGuardianRankConstantsDefinition)]
public sealed record DestinyGuardianRankConstantsDefinition
    : IDestinyDefinition,
        IDisplayProperties,
        IDeepEquatable<DestinyGuardianRankConstantsDefinition>
{
    public DefinitionsEnum DefinitionEnumValue =>
        DefinitionsEnum.DestinyGuardianRankConstantsDefinition;

    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("rankCount")]
    public int RankCount { get; init; }

    [JsonPropertyName("guardianRankHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyGuardianRankDefinition>
    > GuardianRanks { get; init; } =
        ReadOnlyCollections<DefinitionHashPointer<DestinyGuardianRankDefinition>>.Empty;

    [JsonPropertyName("rootNodeHash")]
    public DefinitionHashPointer<DestinyPresentationNodeDefinition> RootNode { get; init; } =
        DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

    [JsonPropertyName("iconBackgrounds")]
    public DestinyGuardianRankIconBackgroundsDefinition IconBackgrounds { get; init; }

    [JsonPropertyName("blacklisted")]
    public bool Blacklisted { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }

    public bool DeepEquals(DestinyGuardianRankConstantsDefinition other)
    {
        return other is not null
            && DisplayProperties.DeepEquals(other.DisplayProperties)
            && RankCount == other.RankCount
            && GuardianRanks.DeepEqualsReadOnlyCollections(other.GuardianRanks)
            && RootNode.DeepEquals(other.RootNode)
            && IconBackgrounds.DeepEquals(other.IconBackgrounds)
            && Blacklisted == other.Blacklisted
            && Hash == other.Hash
            && Index == other.Index
            && Redacted == other.Redacted;
    }
}
