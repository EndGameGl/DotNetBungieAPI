using BungieNetCoreAPI.Destiny.Definitions.ProgressionLevelRequirements;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemQualityBlock
    {
        public int CurrentVersion { get; }
        public List<string> DisplayVersionWatermarkIcons { get; }
        public uint InfusionCategoryHash { get; }
        public List<uint> InfusionCategoryHashes { get; }
        public string InfusionCategoryName { get; }
        public List<object> ItemLevels { get; }
        public DefinitionHashPointer<DestinyProgressionLevelRequirementDefinition> ProgressionLevelRequirement { get; }
        public int QualityLevel { get; }
        public List<InventoryItemQualityBlockVersion> Versions { get; }

        [JsonConstructor]
        private InventoryItemQualityBlock(int currentVersion, List<string> displayVersionWatermarkIcons, uint infusionCategoryHash, List<uint> infusionCategoryHashes,
            string infusionCategoryName, List<object> itemLevels, uint progressionLevelRequirementHash, int qualityLevel, List<InventoryItemQualityBlockVersion> versions)
        {
            CurrentVersion = currentVersion;
            DisplayVersionWatermarkIcons = displayVersionWatermarkIcons;
            InfusionCategoryHash = infusionCategoryHash;
            InfusionCategoryHashes = infusionCategoryHashes;
            InfusionCategoryName = infusionCategoryName;
            ItemLevels = itemLevels;
            ProgressionLevelRequirement = new DefinitionHashPointer<DestinyProgressionLevelRequirementDefinition>(progressionLevelRequirementHash, "DestinyProgressionLevelRequirementDefinition");
            QualityLevel = qualityLevel;
            Versions = versions;
        }
    }
}
