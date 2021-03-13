using NetBungieApi.Destiny.Definitions.ItemCategories;
using NetBungieApi.Destiny.Definitions.MaterialRequirementSets;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// If an item is a Plug, its DestinyInventoryItemDefinition.plug property will be populated with an instance of one of these bad boys.
    /// <para/>
    /// This gives information about when it can be inserted, what the plug's category is (and thus whether it is compatible with a socket... see DestinySocketTypeDefinition for information about Plug Categories and socket compatibility), whether it is enabled and other Plug info.
    /// </summary>
    public class InventoryItemPlugBlock : IDeepEquatable<InventoryItemPlugBlock>
    {
        public uint ActionRewardItemOverrideHash { get; }
        public uint ActionRewardSiteHash { get; }
        /// <summary>
        /// The alternate plug of the plug: only applies when the item is in states that only the server can know about and control, unfortunately. See AlternateUiPlugLabel for the related label info.
        /// </summary>
        public PlugUiStyles AlternatePlugStyle { get; }
        /// <summary>
        /// If the plug meets certain state requirements, it may have an alternative label applied to it. This is the alternative label that will be applied in such a situation.
        /// </summary>
        public string AlternateUiPlugLabel { get; }
        public bool ApplyStatsToSocketOwnerItem { get; }
        /// <summary>
        /// It's not enough for the plug to be inserted. It has to be enabled as well. For it to be enabled, it may require materials. This is the hash identifier for the DestinyMaterialRequirementSetDefinition for those requirements, if there is one.
        /// </summary>
        public DefinitionHashPointer<DestinyMaterialRequirementSetDefinition> EnabledMaterialRequirement { get; }
        /// <summary>
        /// The rules around whether the plug, once inserted, is enabled and providing its benefits.
        /// <para/>
        /// The live data DestinyItemPlugComponent.enableFailIndexes will be an index into this array, so you can pull out the failure strings appropriate for the user.
        /// </summary>
        public ReadOnlyCollection<InventoryItemPlugBlockRule> EnabledRules { get; }
        /// <summary>
        /// If inserting this plug requires materials, this is the DestinyMaterialRequirementSetDefinition for those requirements.
        /// </summary>
        public DefinitionHashPointer<DestinyMaterialRequirementSetDefinition> InsertionMaterialRequirement { get; }
        /// <summary>
        /// The rules around when this plug can be inserted into a socket, aside from the socket's individual restrictions.
        /// <para/>
        /// The live data DestinyItemPlugComponent.insertFailIndexes will be an index into this array, so you can pull out the failure strings appropriate for the user.
        /// </summary>
        public ReadOnlyCollection<InventoryItemPlugBlockRule> InsertionRules { get; }
        /// <summary>
        /// If TRUE, this plug is used for UI display purposes only, and doesn't have any interesting effects of its own.
        /// </summary>
        public bool IsDummyPlug { get; }
        /// <summary>
        /// If you successfully socket the item, this will determine whether or not you get "refunded" on the plug.
        /// </summary>
        public bool OnActionRecreateSelf { get; }
        /// <summary>
        /// Indicates the rules about when this plug can be used. 
        /// </summary>
        public PlugAvailabilityMode PlugAvailability { get; }
        public DefinitionHashPointer<DestinyItemCategoryDefinition> PlugCategory { get; }
        /// <summary>
        /// The string identifier for the plug's category. Use the socket's DestinySocketTypeDefinition.plugWhitelist to determine whether this plug can be inserted into the socket.
        /// </summary>
        public string PlugCategoryIdentifier { get; }
        public PlugUiStyles PlugStyle { get; }
        /// <summary>
        /// In the game, if you're inspecting a plug item directly, this will be the item shown with the plug attached.
        /// </summary>
        public DefinitionHashPointer<DestinyInventoryItemDefinition> PreviewItemOverride { get; }
        /// <summary>
        /// Plugs can have arbitrary, UI-defined identifiers that the UI designers use to determine the style applied to plugs. Unfortunately, we have neither a definitive list of these labels nor advance warning of when new labels might be applied or how that relates to how they get rendered. If you want to, you can refer to known labels to change your own styles: but know that new ones can be created arbitrarily, and we have no way of associating the labels with any specific UI style guidance... you'll have to piece that together on your end. Or do what we do, and just show plugs more generically, without specialized styles.
        /// </summary>
        public string UiPlugLabel { get; }
        /// <summary>
        /// If this is populated, it will have the override data to be applied when this plug is applied to an item.
        /// </summary>
        public InventoryItemPlugBlockParentItemOverride ParentItemOverride { get; }
        /// <summary>
        /// IF not null, this plug provides Energy capacity to the item in which it is socketed. In Armor 2.0 for example, is implemented in a similar way to Masterworks, where visually it's a single area of the UI being clicked on to "Upgrade" to higher energy levels, but it's actually socketing new plugs.
        /// </summary>
        public InventoryItemPlugBlockEnergyCapacity EnergyCapacity { get; }
        /// <summary>
        /// IF not null, this plug has an energy cost. This contains the details of that cost.
        /// </summary>
        public InventoryItemPlugBlockEnergyCost EnergyCost { get; }

        [JsonConstructor]
        internal InventoryItemPlugBlock(uint actionRewardItemOverrideHash, uint actionRewardSiteHash, PlugUiStyles alternatePlugStyle, string alternateUiPlugLabel,
            bool applyStatsToSocketOwnerItem, uint enabledMaterialRequirementHash, InventoryItemPlugBlockRule[] enabledRules, uint insertionMaterialRequirementHash,
            InventoryItemPlugBlockRule[] insertionRules, bool isDummyPlug, bool onActionRecreateSelf, PlugAvailabilityMode plugAvailability, uint plugCategoryHash, 
            string plugCategoryIdentifier, PlugUiStyles plugStyle, uint previewItemOverrideHash, string uiPlugLabel, InventoryItemPlugBlockParentItemOverride parentItemOverride,
            InventoryItemPlugBlockEnergyCapacity energyCapacity, InventoryItemPlugBlockEnergyCost energyCost)
        {
            ActionRewardItemOverrideHash = actionRewardItemOverrideHash;
            ActionRewardItemOverrideHash = actionRewardSiteHash;
            AlternatePlugStyle = alternatePlugStyle;
            AlternateUiPlugLabel = alternateUiPlugLabel;
            ApplyStatsToSocketOwnerItem = applyStatsToSocketOwnerItem;
            EnabledMaterialRequirement = new DefinitionHashPointer<DestinyMaterialRequirementSetDefinition>(enabledMaterialRequirementHash, DefinitionsEnum.DestinyMaterialRequirementSetDefinition);
            EnabledRules = enabledRules.AsReadOnlyOrEmpty();
            InsertionMaterialRequirement = new DefinitionHashPointer<DestinyMaterialRequirementSetDefinition>(insertionMaterialRequirementHash, DefinitionsEnum.DestinyMaterialRequirementSetDefinition);
            InsertionRules = insertionRules.AsReadOnlyOrEmpty();
            IsDummyPlug = isDummyPlug;
            OnActionRecreateSelf = onActionRecreateSelf;
            PlugAvailability = plugAvailability;
            PlugCategory = new DefinitionHashPointer<DestinyItemCategoryDefinition>(plugCategoryHash, DefinitionsEnum.DestinyItemCategoryDefinition);
            PlugCategoryIdentifier = plugCategoryIdentifier;
            PlugStyle = plugStyle;
            PreviewItemOverride = new DefinitionHashPointer<DestinyInventoryItemDefinition>(previewItemOverrideHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            UiPlugLabel = uiPlugLabel;
            ParentItemOverride = parentItemOverride;
            EnergyCapacity = energyCapacity;
            EnergyCost = energyCost;
        }

        public bool DeepEquals(InventoryItemPlugBlock other)
        {
            return other != null &&
                   ActionRewardItemOverrideHash == other.ActionRewardItemOverrideHash &&
                   ActionRewardSiteHash == other.ActionRewardSiteHash &&
                   AlternatePlugStyle == other.AlternatePlugStyle &&
                   AlternateUiPlugLabel == other.AlternateUiPlugLabel &&
                   ApplyStatsToSocketOwnerItem == other.ApplyStatsToSocketOwnerItem &&
                   EnabledMaterialRequirement.DeepEquals(other.EnabledMaterialRequirement) &&
                   EnabledRules.DeepEqualsReadOnlyCollections(other.EnabledRules) &&
                   InsertionMaterialRequirement.DeepEquals(other.InsertionMaterialRequirement) &&
                   InsertionRules.DeepEqualsReadOnlyCollections(other.InsertionRules) &&
                   IsDummyPlug == other.IsDummyPlug &&
                   OnActionRecreateSelf == other.OnActionRecreateSelf &&
                   PlugAvailability == other.PlugAvailability &&
                   PlugCategory.DeepEquals(other.PlugCategory) &&
                   PlugCategoryIdentifier == other.PlugCategoryIdentifier &&
                   PlugStyle == other.PlugStyle &&
                   PreviewItemOverride.DeepEquals(other.PreviewItemOverride) &&
                   UiPlugLabel == other.UiPlugLabel &&
                   (ParentItemOverride != null ? ParentItemOverride.DeepEquals(other.ParentItemOverride) : other.ParentItemOverride == null) &&
                   (EnergyCapacity != null ? EnergyCapacity.DeepEquals(other.EnergyCapacity) : other.EnergyCapacity == null) &&
                   (EnergyCost != null ? EnergyCost.DeepEquals(other.EnergyCost) : other.EnergyCost == null);
        }
    }
}
