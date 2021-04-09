using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;
using NetBungieAPI.Models.Destiny.Definitions.Factions;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Progressions
{
    [DestinyDefinition(DefinitionsEnum.DestinyProgressionDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public sealed record DestinyProgressionDefinition : IDestinyDefinition, IDeepEquatable<DestinyProgressionDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        /// <summary>
        /// The "Scope" of the progression indicates the source of the progression's live data.
        /// </summary>
        [JsonPropertyName("scope")]
        public DestinyProgressionScope Scope { get; init; }
        /// <summary>
        /// If this is True, then the progression doesn't have a maximum level.
        /// </summary>
        [JsonPropertyName("repeatLastStep")]
        public bool RepeatLastStep { get; init; }
        /// <summary>
        /// If there's a description of how to earn this progression in the local config, this will be that localized description.
        /// </summary>
        [JsonPropertyName("source")]
        public string Source { get; init; }
        /// <summary>
        /// Progressions are divided into Steps, which roughly equate to "Levels" in the traditional sense of a Progression. Notably, the last step can be repeated indefinitely if repeatLastStep is true, meaning that the calculation for your level is not as simple as comparing your current progress to the max progress of the steps.
        /// </summary>
        [JsonPropertyName("steps")]
        public ReadOnlyCollection<ProgressionStep> Steps { get; init; } = Defaults.EmptyReadOnlyCollection<ProgressionStep>();
        /// <summary>
        /// If true, the Progression is something worth showing to users.
        /// <para/>
        /// If false, BNet isn't going to show it. But that doesn't mean you can't.
        /// </summary>
        [JsonPropertyName("visible")]
        public bool Visible { get; init; }
        [JsonPropertyName("factionHash")]
        public DefinitionHashPointer<DestinyFactionDefinition> Faction { get; init; } = DefinitionHashPointer<DestinyFactionDefinition>.Empty;
        [JsonPropertyName("color")]
        public DestinyColor Color { get; init; }
        [JsonPropertyName("rankIcon")]
        public string RankIcon { get; init; }
        [JsonPropertyName("rewardItems")]
        public ReadOnlyCollection<DestinyProgressionRewardItemQuantity> RewardItems { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyProgressionRewardItemQuantity>();
        [JsonPropertyName("progressToNextStepScaling")]
        public int ProgressToNextStepScaling { get; init; }
        [JsonPropertyName("storageMappingIndex")]
        public int StorageMappingIndex { get; init; }  
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
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }

        public bool DeepEquals(DestinyProgressionDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   (Color != null ? Color.DeepEquals(other.Color) : other.Color == null) &&
                   ProgressToNextStepScaling == other.ProgressToNextStepScaling &&
                   RankIcon == other.RankIcon &&
                   RepeatLastStep == other.RepeatLastStep &&
                   RewardItems.DeepEqualsReadOnlyCollections(other.RewardItems) &&
                   Scope == other.Scope &&
                   StorageMappingIndex == other.StorageMappingIndex &&
                   Visible == other.Visible &&
                   Steps.DeepEqualsReadOnlyCollections(other.Steps) &&
                   Source == other.Source &&
                   Faction.DeepEquals(other.Faction) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
        public void MapValues()
        {
            foreach (var item in RewardItems)
            {
                item.Item.TryMapValue();
            }
            foreach (var step in Steps)
            {
                foreach (var item in step.RewardItems)
                {
                    item.Item.TryMapValue();
                }
            }
            Faction.TryMapValue();
        }
    }
}
