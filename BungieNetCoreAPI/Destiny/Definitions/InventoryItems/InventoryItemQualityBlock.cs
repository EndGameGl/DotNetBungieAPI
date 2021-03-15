using NetBungieAPI.Destiny.Definitions.ProgressionLevelRequirements;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// An item's "Quality" determines its calculated stats. The Level at which the item spawns is combined with its "qualityLevel" along with some additional calculations to determine the value of those stats.
    /// <para/>
    /// In Destiny 2, most items don't have default item levels and quality, making this property less useful: these apparently are almost always determined by the complex mechanisms of the Reward system rather than statically. They are still provided here in case they are still useful for people. This also contains some information about Infusion.
    /// </summary>
    public class InventoryItemQualityBlock : IDeepEquatable<InventoryItemQualityBlock>
    {
        /// <summary>
        /// The latest version available for this item.
        /// </summary>
        public uint CurrentVersion { get; }
        /// <summary>
        /// Icon overlays to denote the item version and power cap status.
        /// </summary>
        public ReadOnlyCollection<string> DisplayVersionWatermarkIcons { get; }
        [Obsolete("DEPRECATED: Items can now have multiple infusion categories. Please use infusionCategoryHashes instead.")]
        public uint InfusionCategoryHash { get; }
        /// <summary>
        /// If any one of these hashes matches any value in another item's infusionCategoryHashes, the two can infuse with each other.
        /// </summary>
        public ReadOnlyCollection<uint> InfusionCategoryHashes { get; }
        public string InfusionCategoryName { get; }
        /// <summary>
        /// The "base" defined level of an item. This is a list because, in theory, each Expansion could define its own base level for an item.
        /// <para/>
        /// In practice, not only was that never done in Destiny 1, but now this isn't even populated at all. When it's not populated, the level at which it spawns has to be inferred by Reward information, of which BNet receives an imperfect view and will only be reliable on instanced data as a result.
        /// </summary>
        public ReadOnlyCollection<int> ItemLevels { get; }
        /// <summary>
        /// An item can refer to pre-set level requirements. They are defined in DestinyProgressionLevelRequirementDefinition
        /// </summary>
        public DefinitionHashPointer<DestinyProgressionLevelRequirementDefinition> ProgressionLevelRequirement { get; }
        /// <summary>
        /// qualityLevel is used in combination with the item's level to calculate stats like Attack and Defense. It plays a role in that calculation, but not nearly as large as itemLevel does.
        /// </summary>
        public int QualityLevel { get; }
        /// <summary>
        /// The list of versions available for this item.
        /// </summary>
        public ReadOnlyCollection<InventoryItemQualityBlockVersion> Versions { get; }

        [JsonConstructor]
        internal InventoryItemQualityBlock(uint currentVersion, string[] displayVersionWatermarkIcons, uint infusionCategoryHash, uint[] infusionCategoryHashes,
            string infusionCategoryName, int[] itemLevels, uint progressionLevelRequirementHash, int qualityLevel, InventoryItemQualityBlockVersion[] versions)
        {
            CurrentVersion = currentVersion;
            DisplayVersionWatermarkIcons = displayVersionWatermarkIcons.AsReadOnlyOrEmpty();
            InfusionCategoryHash = infusionCategoryHash;
            InfusionCategoryHashes = infusionCategoryHashes.AsReadOnlyOrEmpty();
            InfusionCategoryName = infusionCategoryName;
            ItemLevels = itemLevels.AsReadOnlyOrEmpty();
            ProgressionLevelRequirement = new DefinitionHashPointer<DestinyProgressionLevelRequirementDefinition>(progressionLevelRequirementHash, DefinitionsEnum.DestinyProgressionLevelRequirementDefinition);
            QualityLevel = qualityLevel;
            Versions = versions.AsReadOnlyOrEmpty();
        }

        public bool DeepEquals(InventoryItemQualityBlock other)
        {
            return other != null &&
                   CurrentVersion == other.CurrentVersion &&
                   DisplayVersionWatermarkIcons.DeepEqualsReadOnlySimpleCollection(other.DisplayVersionWatermarkIcons) &&
                   InfusionCategoryHash == other.InfusionCategoryHash &&
                   InfusionCategoryHashes.DeepEqualsReadOnlySimpleCollection(other.InfusionCategoryHashes) &&
                   InfusionCategoryName == other.InfusionCategoryName &&
                   ItemLevels.DeepEqualsReadOnlySimpleCollection(other.ItemLevels) &&
                   ProgressionLevelRequirement.DeepEquals(other.ProgressionLevelRequirement) &&
                   QualityLevel == other.QualityLevel &&
                   Versions.DeepEqualsReadOnlyCollections(other.Versions);
        }
    }
}
