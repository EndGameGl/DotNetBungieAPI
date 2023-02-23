using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;
using DotNetBungieAPI.Models.Destiny.Definitions.PresentationNodes;

namespace DotNetBungieAPI.Models.Destiny.Definitions.GuardianRanks;

[DestinyDefinition(DefinitionsEnum.DestinyGuardianRankDefinition)]
public sealed record DestinyGuardianRankDefinition : IDestinyDefinition, IDeepEquatable<DestinyGuardianRankDefinition>
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyGuardianRankDefinition;

    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("rankNumber")]
    public int RankNumber { get; init; }

    [JsonPropertyName("presentationNodeHash")]
    public DefinitionHashPointer<DestinyPresentationNodeDefinition> PresentationNodeHash { get; init; } = DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

    [JsonPropertyName("foregroundImagePath")]
    public string ForegroundImagePath { get; init; }

    [JsonPropertyName("overlayImagePath")]
    public string OverlayImagePath { get; init; }

    [JsonPropertyName("overlayMaskImagePath")]
    public string OverlayMaskImagePath { get; init; }

    [JsonPropertyName("blacklisted")]
    public bool Blacklisted { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }

    public bool DeepEquals(DestinyGuardianRankDefinition other)
    {
        return other is not null &&
               DisplayProperties.DeepEquals(other.DisplayProperties) &&
               RankNumber == other.RankNumber &&
               PresentationNodeHash.DeepEquals(other.PresentationNodeHash) &&
               ForegroundImagePath == other.ForegroundImagePath &&
               OverlayImagePath == other.OverlayImagePath &&
               OverlayMaskImagePath == other.OverlayMaskImagePath &&
               Blacklisted == other.Blacklisted &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }
}
