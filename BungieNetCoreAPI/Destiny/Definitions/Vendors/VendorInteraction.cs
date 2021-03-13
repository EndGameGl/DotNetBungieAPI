using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    public class VendorInteraction : IDeepEquatable<VendorInteraction>
    {
        public int InteractionIndex { get; }
        public ReadOnlyCollection<VendorInteractionReply> Replies { get; }
        public int VendorCategoryIndex { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> QuestlineItem { get; }
        public ReadOnlyCollection<VendorInteractionSack> SackInteractionList { get; }
        public uint UiInteractionType { get; }
        public VendorInteractionType InteractionType { get; }
        public string RewardBlockLabel { get; }
        public int RewardVendorCategoryIndex { get; }
        public string FlavorLineOne { get; }
        public string FlavorLineTwo { get; }
        public DestinyDefinitionDisplayProperties HeaderDisplayProperties { get; }
        public string Instructions { get; }

        [JsonConstructor]
        internal VendorInteraction(string flavorLineOne, string flavorLineTwo, DestinyDefinitionDisplayProperties headerDisplayProperties, string instructions,
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
