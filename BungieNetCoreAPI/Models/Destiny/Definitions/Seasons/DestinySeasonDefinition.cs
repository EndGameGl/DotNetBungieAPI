using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Models.Destiny.Definitions.PresentationNodes;
using NetBungieAPI.Models.Destiny.Definitions.Progressions;
using NetBungieAPI.Models.Destiny.Definitions.SeasonPasses;
using NetBungieAPI.Models.Destiny.Definitions.Unlocks;
using System;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Seasons
{
    [DestinyDefinition(DefinitionsEnum.DestinySeasonDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public sealed record DestinySeasonDefinition : IDestinyDefinition, IDeepEquatable<DestinySeasonDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        [JsonPropertyName("backgroundImagePath")]
        public string BackgroundImagePath { get; init; }
        [JsonPropertyName("seasonNumber")]
        public int SeasonNumber { get; init; }
        [JsonPropertyName("startDate")]
        public DateTime? StartDate { get; init; }
        [JsonPropertyName("endDate")]
        public DateTime? EndDate { get; init; }
        [JsonPropertyName("seasonPassHash")]
        public DefinitionHashPointer<DestinySeasonPassDefinition> SeasonPass { get; init; } = DefinitionHashPointer<DestinySeasonPassDefinition>.Empty;
        [JsonPropertyName("seasonPassProgressionHash")]
        public DefinitionHashPointer<DestinyProgressionDefinition> SeasonPassProgression { get; init; } = DefinitionHashPointer<DestinyProgressionDefinition>.Empty;
        [JsonPropertyName("artifactItemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> ArtifactItem { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
        [JsonPropertyName("sealPresentationNodeHash")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> SealPresentationNode { get; init; } = DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;
        [JsonPropertyName("seasonalChallengesPresentationNodeHash")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> SeasonalChallengesPresentationNode { get; init; } = DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;
        [JsonPropertyName("seasonPassUnlockHash")]
        public DefinitionHashPointer<DestinyUnlockDefinition> SeasonPassUnlock { get; init; } = DefinitionHashPointer<DestinyUnlockDefinition>.Empty;
        [JsonPropertyName("startTimeInSeconds")]
        public string StartTimeInSeconds { get; init; }
        [JsonPropertyName("preview")]
        public DestinySeasonPreviewDefinition Preview { get; init; }
        [JsonPropertyName("blacklisted")]
        public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")]
        public uint Hash { get; init; }
        [JsonPropertyName("index")]
        public int Index { get; init; }
        [JsonPropertyName("redacted")]
        public bool Redacted { get; init; }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}";
        }

        public void MapValues()
        {
            ArtifactItem.TryMapValue();
            SealPresentationNode.TryMapValue();
            SeasonalChallengesPresentationNode.TryMapValue();
            SeasonPass.TryMapValue();
            SeasonPassProgression.TryMapValue();
            SeasonPassUnlock.TryMapValue();
        }

        public bool DeepEquals(DestinySeasonDefinition other)
        {
            return other != null &&
                   ArtifactItem.DeepEquals(other.ArtifactItem) &&
                   BackgroundImagePath == other.BackgroundImagePath &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   SeasonNumber == other.SeasonNumber &&
                   SealPresentationNode.DeepEquals(other.SealPresentationNode) &&
                   SeasonalChallengesPresentationNode.DeepEquals(other.SeasonalChallengesPresentationNode) &&
                   SeasonPass.DeepEquals(other.SeasonPass) &&
                   SeasonPassProgression.DeepEquals(other.SeasonPassProgression) &&
                   SeasonPassUnlock.DeepEquals(other.SeasonPassUnlock) &&
                   StartTimeInSeconds == other.StartTimeInSeconds &&
                   StartDate == other.StartDate &&
                   EndDate == other.EndDate &&
                   Preview.DeepEquals(other.Preview) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
    }
}
