using BungieNetCoreAPI.Destiny.Definitions.ItemCategories;
using BungieNetCoreAPI.Destiny.Definitions.MaterialRequirementSets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemPlugBlock
    {
        public uint ActionRewardItemOverrideHash { get; }
        public uint ActionRewardSiteHash { get; }
        public int AlternatePlugStyle { get; }
        public string AlternateUiPlugLabel { get; }
        public bool ApplyStatsToSocketOwnerItem { get; }
        public DefinitionHashPointer<DestinyMaterialRequirementSetDefinition> EnabledMaterialRequirement { get; }
        public List<InventoryItemPlugBlockRule> EnabledRules { get; }
        public DefinitionHashPointer<DestinyMaterialRequirementSetDefinition> InsertionMaterialRequirement { get; }
        public List<InventoryItemPlugBlockRule> InsertionRules { get; }
        public bool IsDummyPlug { get; }
        public bool OnActionRecreateSelf { get; }
        public int PlugAvailability { get; }
        public DefinitionHashPointer<DestinyItemCategoryDefinition> PlugCategory { get; }
        public string PlugCategoryIdentifier { get; }
        public int PlugStyle { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> PreviewItemOverride { get; }
        public string UiPlugLabel { get; }

        [JsonConstructor]
        private InventoryItemPlugBlock(uint actionRewardItemOverrideHash, uint actionRewardSiteHash, int alternatePlugStyle, string alternateUiPlugLabel,
            bool applyStatsToSocketOwnerItem, uint enabledMaterialRequirementHash, List<InventoryItemPlugBlockRule> enabledRules, uint insertionMaterialRequirementHash,
            List<InventoryItemPlugBlockRule> insertionRules, bool isDummyPlug, bool onActionRecreateSelf, int plugAvailability, uint plugCategoryHash, string plugCategoryIdentifier,
            int plugStyle, uint previewItemOverrideHash, string uiPlugLabel)
        {
            ActionRewardItemOverrideHash = actionRewardItemOverrideHash;
            ActionRewardItemOverrideHash = actionRewardSiteHash;
            AlternatePlugStyle = alternatePlugStyle;
            AlternateUiPlugLabel = alternateUiPlugLabel;
            ApplyStatsToSocketOwnerItem = applyStatsToSocketOwnerItem;
            EnabledMaterialRequirement = new DefinitionHashPointer<DestinyMaterialRequirementSetDefinition>(enabledMaterialRequirementHash, "DestinyMaterialRequirementSetDefinition");
            EnabledRules = enabledRules;
            InsertionMaterialRequirement = new DefinitionHashPointer<DestinyMaterialRequirementSetDefinition>(insertionMaterialRequirementHash, "DestinyMaterialRequirementSetDefinition");
            InsertionRules = insertionRules;
            IsDummyPlug = isDummyPlug;
            OnActionRecreateSelf = onActionRecreateSelf;
            PlugAvailability = plugAvailability;
            PlugCategory = new DefinitionHashPointer<DestinyItemCategoryDefinition>(plugCategoryHash, "DestinyItemCategoryDefinition");
            PlugCategoryIdentifier = plugCategoryIdentifier;
            PlugStyle = plugStyle;
            PreviewItemOverride = new DefinitionHashPointer<DestinyInventoryItemDefinition>(previewItemOverrideHash, "DestinyInventoryItemDefinition");
            UiPlugLabel = uiPlugLabel;
        }
    }
}
