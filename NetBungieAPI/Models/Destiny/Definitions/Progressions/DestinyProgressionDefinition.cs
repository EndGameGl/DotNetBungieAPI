using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;
using NetBungieAPI.Models.Destiny.Definitions.Factions;

namespace NetBungieAPI.Models.Destiny.Definitions.Progressions
{
    /// <summary>
    ///     A "Progression" in Destiny is best explained by an example.
    ///     <para />
    ///     A Character's "Level" is a progression: it has Experience that can be earned, levels that can be gained, and is
    ///     evaluated and displayed at various points in the game. A Character's "Faction Reputation" is also a progression for
    ///     much the same reason.
    ///     <para />
    ///     Progression is used by a variety of systems, and the definition of a Progression will generally only be useful if
    ///     combining with live data (such as a character's DestinyCharacterProgressionComponent.progressions property, which
    ///     holds that character's live Progression states).
    ///     <para />
    ///     Fundamentally, a Progression measures your "Level" by evaluating the thresholds in its Steps (one step per level,
    ///     except for the last step which can be repeated indefinitely for "Levels" that have no ceiling) against the total
    ///     earned "progression points"/experience. (for simplicity purposes, we will henceforth refer to earned progression
    ///     points as experience, though it need not be a mechanic that in any way resembles Experience in a traditional
    ///     sense).
    ///     <para />
    ///     Earned experience is calculated in a variety of ways, determined by the Progression's scope. These go from looking
    ///     up a stored value to performing exceedingly obtuse calculations. This is why we provide live data in
    ///     DestinyCharacterProgressionComponent.progressions, so you don't have to worry about those.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyProgressionDefinition)]
    public sealed record DestinyProgressionDefinition : IDestinyDefinition, IDeepEquatable<DestinyProgressionDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        /// <summary>
        ///     The "Scope" of the progression indicates the source of the progression's live data.
        /// </summary>
        [JsonPropertyName("scope")]
        public DestinyProgressionScope Scope { get; init; }

        /// <summary>
        ///     If this is True, then the progression doesn't have a maximum level.
        /// </summary>
        [JsonPropertyName("repeatLastStep")]
        public bool RepeatLastStep { get; init; }

        /// <summary>
        ///     If there's a description of how to earn this progression in the local config, this will be that localized
        ///     description.
        /// </summary>
        [JsonPropertyName("source")]
        public string Source { get; init; }

        /// <summary>
        ///     Progressions are divided into Steps, which roughly equate to "Levels" in the traditional sense of a Progression.
        ///     Notably, the last step can be repeated indefinitely if repeatLastStep is true, meaning that the calculation for
        ///     your level is not as simple as comparing your current progress to the max progress of the steps.
        /// </summary>
        [JsonPropertyName("steps")]
        public ReadOnlyCollection<ProgressionStep> Steps { get; init; } =
            Defaults.EmptyReadOnlyCollection<ProgressionStep>();

        /// <summary>
        ///     If true, the Progression is something worth showing to users.
        ///     <para />
        ///     If false, BNet isn't going to show it. But that doesn't mean you can't.
        /// </summary>
        [JsonPropertyName("visible")]
        public bool Visible { get; init; }

        /// <summary>
        ///     If the value exists, this is the hash identifier for the Faction that owns this Progression.
        ///     <para />
        ///     This is purely for convenience, if you're looking at a progression and want to know if and who it's related to in
        ///     terms of Faction Reputation.
        /// </summary>
        [JsonPropertyName("factionHash")]
        public DefinitionHashPointer<DestinyFactionDefinition> Faction { get; init; } =
            DefinitionHashPointer<DestinyFactionDefinition>.Empty;

        /// <summary>
        ///     The #RGB string value for the color related to this progression, if there is one.
        /// </summary>
        [JsonPropertyName("color")]
        public DestinyColor Color { get; init; }

        /// <summary>
        ///     For progressions that have it, this is the rank icon we use in the Companion, displayed above the progressions'
        ///     rank value.
        /// </summary>
        [JsonPropertyName("rankIcon")]
        public DestinyResource RankIcon { get; init; }

        [JsonPropertyName("rewardItems")]
        public ReadOnlyCollection<DestinyProgressionRewardItemQuantity> RewardItems { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyProgressionRewardItemQuantity>();

        [JsonPropertyName("progressToNextStepScaling")]
        public int ProgressToNextStepScaling { get; init; }

        [JsonPropertyName("storageMappingIndex")]
        public int StorageMappingIndex { get; init; }

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

        public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyProgressionDefinition;
        [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")] public uint Hash { get; init; }
        [JsonPropertyName("index")] public int Index { get; init; }
        [JsonPropertyName("redacted")] public bool Redacted { get; init; }

        public void MapValues()
        {
            foreach (var item in RewardItems) item.Item.TryMapValue();

            foreach (var step in Steps)
            foreach (var item in step.RewardItems)
                item.Item.TryMapValue();

            Faction.TryMapValue();
        }

        public void SetPointerLocales(BungieLocales locale)
        {
            foreach (var item in RewardItems) item.Item.SetLocale(locale);

            foreach (var step in Steps)
            foreach (var item in step.RewardItems)
                item.Item.SetLocale(locale);

            Faction.SetLocale(locale);
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}