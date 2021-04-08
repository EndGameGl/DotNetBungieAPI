using NetBungieAPI.Attributes;
using NetBungieAPI.Destiny.Definitions.Unlocks;
using Newtonsoft.Json;
using System;

namespace NetBungieAPI.Models.Destiny.Definitions.Seasons
{
    [DestinyDefinition(DefinitionsEnum.DestinySeasonDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinySeasonDefinition : IDestinyDefinition, IDeepEquatable<DestinySeasonDefinition>
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> ArtifactItem { get; init; }
        public string BackgroundImagePath { get; init; }
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        public int SeasonNumber { get; init; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> SealPresentationNode { get; init; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> SeasonalChallengesPresentationNode { get; init; }
        public DefinitionHashPointer<DestinySeasonPassDefinition> SeasonPass { get; init; }     
        public DefinitionHashPointer<DestinyProgressionDefinition> SeasonPassProgression { get; init; }
        public DefinitionHashPointer<DestinyUnlockDefinition> SeasonPassUnlock { get; init; }
        public string StartTimeInSeconds { get; init; }
        public DateTime? StartDate { get; init; }
        public DateTime? EndDate { get; init; }
        public SeasonPreview Preview { get; init; }
        public bool Blacklisted { get; init; }
        public uint Hash { get; init; }
        public int Index { get; init; }
        public bool Redacted { get; init; }

        [JsonConstructor]
        internal DestinySeasonDefinition(DestinyDisplayPropertiesDefinition displayProperties, int seasonNumber, uint seasonPassProgressionHash, uint seasonPassUnlockHash,
            string startTimeInSeconds, uint? sealPresentationNodeHash, uint? seasonPassHash, DateTime? startDate, DateTime? endDate, string backgroundImagePath,
            uint artifactItemHash, uint? seasonalChallengesPresentationNodeHash, SeasonPreview preview, bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            SeasonNumber = seasonNumber;
            SeasonPassProgression = new DefinitionHashPointer<DestinyProgressionDefinition>(seasonPassProgressionHash, DefinitionsEnum.DestinyProgressionDefinition);
            SeasonPassUnlock = new DefinitionHashPointer<DestinyUnlockDefinition>(seasonPassUnlockHash, DefinitionsEnum.DestinyUnlockDefinition);
            StartTimeInSeconds = startTimeInSeconds;
            SealPresentationNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(sealPresentationNodeHash, DefinitionsEnum.DestinyPresentationNodeDefinition);
            SeasonPass = new DefinitionHashPointer<DestinySeasonPassDefinition>(seasonPassHash, DefinitionsEnum.DestinySeasonPassDefinition);
            SeasonalChallengesPresentationNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(seasonalChallengesPresentationNodeHash, DefinitionsEnum.DestinyPresentationNodeDefinition);
            StartDate = startDate;
            EndDate = endDate;
            BackgroundImagePath = backgroundImagePath;
            ArtifactItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(artifactItemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            Preview = preview;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

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
