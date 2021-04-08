using NetBungieAPI.Attributes;
using NetBungieAPI.Destiny.Definitions.Factions;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Models.Destiny.Definitions.Progressions
{
    /// <summary>
    /// A "Progression" in Destiny is best explained by an example.
    /// <para/>
    /// A Character's "Level" is a progression: it has Experience that can be earned, levels that can be gained, and is evaluated and displayed at various points in the game. A Character's "Faction Reputation" is also a progression for much the same reason.
    /// <para/>
    /// Progression is used by a variety of systems, and the definition of a Progression will generally only be useful if combining with live data (such as a character's DestinyCharacterProgressionComponent.progressions property, which holds that character's live Progression states).
    /// <para/>
    /// Fundamentally, a Progression measures your "Level" by evaluating the thresholds in its Steps(one step per level, except for the last step which can be repeated indefinitely for "Levels" that have no ceiling) against the total earned "progression points"/experience. (for simplicity purposes, we will henceforth refer to earned progression points as experience, though it need not be a mechanic that in any way resembles Experience in a traditional sense).
    /// <para/>
    /// Earned experience is calculated in a variety of ways, determined by the Progression's scope. These go from looking up a stored value to performing exceedingly obtuse calculations. This is why we provide live data in DestinyCharacterProgressionComponent.progressions, so you don't have to worry about those.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyProgressionDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyProgressionDefinition : IDestinyDefinition, IDeepEquatable<DestinyProgressionDefinition>
    {
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        public DestinyColor Color { get; init; }
        public int ProgressToNextStepScaling { get; init; }
        public string RankIcon { get; init; }
        /// <summary>
        /// If this is True, then the progression doesn't have a maximum level.
        /// </summary>
        public bool RepeatLastStep { get; init; }
        public ReadOnlyCollection<ProgressionReward> RewardItems { get; init; }
        /// <summary>
        /// The "Scope" of the progression indicates the source of the progression's live data.
        /// </summary>
        public ProgressionScope Scope { get; init; }
        public int StorageMappingIndex { get; init; }
        /// <summary>
        /// If true, the Progression is something worth showing to users.
        /// <para/>
        /// If false, BNet isn't going to show it. But that doesn't mean you can't.
        /// </summary>
        public bool Visible { get; init; }
        /// <summary>
        /// Progressions are divided into Steps, which roughly equate to "Levels" in the traditional sense of a Progression. Notably, the last step can be repeated indefinitely if repeatLastStep is true, meaning that the calculation for your level is not as simple as comparing your current progress to the max progress of the steps.
        /// </summary>
        public ReadOnlyCollection<ProgressionStep> Steps { get; init; }
        /// <summary>
        /// If there's a description of how to earn this progression in the local config, this will be that localized description.
        /// </summary>
        public string Source { get; init; }
        public DefinitionHashPointer<DestinyFactionDefinition> Faction { get; init; }
        public bool Blacklisted { get; init; }
        public uint Hash { get; init; }
        public int Index { get; init; }
        public bool Redacted { get; init; }

        [JsonConstructor]
        internal DestinyProgressionDefinition(DestinyDisplayPropertiesDefinition displayProperties, DestinyColor color, int progressToNextStepScaling, string rankIcon,
            bool repeatLastStep, ProgressionReward[] rewardItems, ProgressionScope scope, int storageMappingIndex, bool visible, ProgressionStep[] steps,
            string source, uint? factionHash, bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            Color = color;
            ProgressToNextStepScaling = progressToNextStepScaling;
            RankIcon = rankIcon;
            RepeatLastStep = repeatLastStep;
            RewardItems = rewardItems.AsReadOnlyOrEmpty();
            Scope = scope;
            StorageMappingIndex = storageMappingIndex;
            Visible = visible;
            Steps = steps.AsReadOnlyOrEmpty();
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
            Source = source;
            Faction = new DefinitionHashPointer<DestinyFactionDefinition>(factionHash, DefinitionsEnum.DestinyFactionDefinition);
        }

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
