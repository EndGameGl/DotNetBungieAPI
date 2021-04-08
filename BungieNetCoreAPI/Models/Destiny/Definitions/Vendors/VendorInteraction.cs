using NetBungieAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.Vendors
{
    public class VendorInteraction : IDeepEquatable<VendorInteraction>
    {
        public int InteractionIndex { get; init; }
        public ReadOnlyCollection<VendorInteractionReply> Replies { get; init; }
        public int VendorCategoryIndex { get; init; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> QuestlineItem { get; init; }
        public ReadOnlyCollection<VendorInteractionSack> SackInteractionList { get; init; }
        public uint UiInteractionType { get; init; }
        public VendorInteractionType InteractionType { get; init; }
        public string RewardBlockLabel { get; init; }
        public int RewardVendorCategoryIndex { get; init; }
        public string FlavorLineOne { get; init; }
        public string FlavorLineTwo { get; init; }
        public DestinyDisplayPropertiesDefinition HeaderDisplayProperties { get; init; }
        public string Instructions { get; init; }

        [JsonConstructor]
        internal VendorInteraction(string flavorLineOne, string flavorLineTwo, DestinyDisplayPropertiesDefinition headerDisplayProperties, string instructions,
            int interactionIndex, VendorInteractionType interactionType, uint questlineItemHash, VendorInteractionReply[] replies, string rewardBlockLabel, 
            int rewardVendorCategoryIndex, VendorInteractionSack[] sackInteractionList, uint uiInteractionType, int vendorCategoryIndex)
        {
            FlavorLineOne = flavorLineOne;
            FlavorLineTwo = flavorLineTwo;
            HeaderDisplayProperties = headerDisplayProperties;
            Instructions = instructions;
            InteractionIndex = interactionIndex;
            InteractionType = interactionType;
            QuestlineItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(questlineItemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            Replies = replies.AsReadOnlyOrEmpty();
            RewardBlockLabel = rewardBlockLabel;
            RewardVendorCategoryIndex = rewardVendorCategoryIndex;
            SackInteractionList = sackInteractionList.AsReadOnlyOrEmpty();
            UiInteractionType = uiInteractionType;
            VendorCategoryIndex = vendorCategoryIndex;
        }

        public bool DeepEquals(VendorInteraction other)
        {
            return other != null &&
                   InteractionIndex == other.InteractionIndex &&
                   Replies.DeepEqualsReadOnlyCollections(other.Replies) &&
                   VendorCategoryIndex == other.VendorCategoryIndex &&
                   QuestlineItem.DeepEquals(other.QuestlineItem) &&
                   SackInteractionList.DeepEqualsReadOnlyCollections(other.SackInteractionList) &&
                   UiInteractionType == other.UiInteractionType &&
                   InteractionType == other.InteractionType &&
                   RewardBlockLabel == other.RewardBlockLabel &&
                   RewardVendorCategoryIndex == other.RewardVendorCategoryIndex &&
                   FlavorLineOne == other.FlavorLineOne &&
                   FlavorLineTwo == other.FlavorLineTwo &&
                   HeaderDisplayProperties.DeepEquals(other.HeaderDisplayProperties) &&
                   Instructions == other.Instructions;
        }
    }
}
