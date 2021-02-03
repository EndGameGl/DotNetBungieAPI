using BungieNetCoreAPI.Destiny.Definitions.ProgressionLevelRequirements;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// An item's "Quality" determines its calculated stats. The Level at which the item spawns is combined with its "qualityLevel" along with some additional calculations to determine the value of those stats.
    /// <para/>
    /// In Destiny 2, most items don't have default item levels and quality, making this property less useful: these apparently are almost always determined by the complex mechanisms of the Reward system rather than statically. They are still provided here in case they are still useful for people. This also contains some information about Infusion.
    /// </summary>
    public class InventoryItemQualityBlock
    {
        public int CurrentVersion { get; }
        public ReadOnlyCollection<string> DisplayVersionWatermarkIcons { get; }
        public uint InfusionCategoryHash { get; }
        public ReadOnlyCollection<uint> InfusionCategoryHashes { get; }
        public string InfusionCategoryName { get; }
        public ReadOnlyCollection<object> ItemLevels { get; }
        public DefinitionHashPointer<DestinyProgressionLevelRequirementDefinition> ProgressionLevelRequirement { get; }
        public int QualityLevel { get; }
        public ReadOnlyCollection<InventoryItemQualityBlockVersion> Versions { get; }

        [JsonConstructor]
        internal InventoryItemQualityBlock(int currentVersion, string[] displayVersionWatermarkIcons, uint infusionCategoryHash, uint[] infusionCategoryHashes,
            string infusionCategoryName, object[] itemLevels, uint progressionLevelRequirementHash, int qualityLevel, InventoryItemQualityBlockVersion[] versions)
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
    }
}
