using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Definitions.ProgressionLevelRequirements;

namespace NetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    /// <summary>
    ///     An item's "Quality" determines its calculated stats. The Level at which the item spawns is combined with its
    ///     "qualityLevel" along with some additional calculations to determine the value of those stats.
    ///     <para />
    ///     In Destiny 2, most items don't have default item levels and quality, making this property less useful: these
    ///     apparently are almost always determined by the complex mechanisms of the Reward system rather than statically. They
    ///     are still provided here in case they are still useful for people. This also contains some information about
    ///     Infusion.
    /// </summary>
    public sealed record DestinyItemQualityBlockDefinition : IDeepEquatable<DestinyItemQualityBlockDefinition>
    {
        /// <summary>
        ///     The latest version available for this item.
        /// </summary>
        [JsonPropertyName("currentVersion")]
        public uint CurrentVersion { get; init; }

        /// <summary>
        ///     Icon overlays to denote the item version and power cap status.
        /// </summary>
        [JsonPropertyName("displayVersionWatermarkIcons")]
        public ReadOnlyCollection<DestinyResource> DisplayVersionWatermarkIcons { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyResource>();

        /// <summary>
        ///     If any one of these hashes matches any value in another item's infusionCategoryHashes, the two can infuse with each
        ///     other.
        /// </summary>
        [JsonPropertyName("infusionCategoryHashes")]
        public ReadOnlyCollection<uint> InfusionCategoryHashes { get; init; } =
            Defaults.EmptyReadOnlyCollection<uint>();

        /// <summary>
        ///     The "base" defined level of an item. This is a list because, in theory, each Expansion could define its own base
        ///     level for an item.
        ///     <para />
        ///     In practice, not only was that never done in Destiny 1, but now this isn't even populated at all. When it's not
        ///     populated, the level at which it spawns has to be inferred by Reward information, of which BNet receives an
        ///     imperfect view and will only be reliable on instanced data as a result.
        /// </summary>
        [JsonPropertyName("itemLevels")]
        public ReadOnlyCollection<int> ItemLevels { get; init; } = Defaults.EmptyReadOnlyCollection<int>();

        /// <summary>
        ///     An item can refer to pre-set level requirements. They are defined in DestinyProgressionLevelRequirementDefinition
        /// </summary>
        [JsonPropertyName("progressionLevelRequirementHash")]
        public DefinitionHashPointer<DestinyProgressionLevelRequirementDefinition>
            ProgressionLevelRequirement { get; init; } =
            DefinitionHashPointer<DestinyProgressionLevelRequirementDefinition>.Empty;

        /// <summary>
        ///     QualityLevel is used in combination with the item's level to calculate stats like Attack and Defense. It plays a
        ///     role in that calculation, but not nearly as large as itemLevel does.
        /// </summary>
        [JsonPropertyName("qualityLevel")]
        public int QualityLevel { get; init; }

        /// <summary>
        ///     The list of versions available for this item.
        /// </summary>
        [JsonPropertyName("versions")]
        public ReadOnlyCollection<DestinyItemVersionDefinition> Versions { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyItemVersionDefinition>();

        public bool DeepEquals(DestinyItemQualityBlockDefinition other)
        {
            return other != null &&
                   CurrentVersion == other.CurrentVersion &&
                   DisplayVersionWatermarkIcons.DeepEqualsReadOnlySimpleCollection(other
                       .DisplayVersionWatermarkIcons) &&
                   InfusionCategoryHashes.DeepEqualsReadOnlySimpleCollection(other.InfusionCategoryHashes) &&
                   ItemLevels.DeepEqualsReadOnlySimpleCollection(other.ItemLevels) &&
                   ProgressionLevelRequirement.DeepEquals(other.ProgressionLevelRequirement) &&
                   QualityLevel == other.QualityLevel &&
                   Versions.DeepEqualsReadOnlyCollections(other.Versions);
        }
    }
}