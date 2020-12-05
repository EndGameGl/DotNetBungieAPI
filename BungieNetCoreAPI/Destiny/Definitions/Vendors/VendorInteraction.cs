using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    public class VendorInteraction
    {
        public string FlavorLineOne { get; }
        public string FlavorLineTwo { get; }
        public DestinyDefinitionDisplayProperties HeaderDisplayProperties { get; }
        public string Instructions { get; }
        public int InteractionIndex { get; }
        public VendorInteractionType InteractionType { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> QuestlineItem { get; }
        public List<VendorInteractionReply> Replies { get; }
        public string RewardBlockLabel { get; }
        public int RewardVendorCategoryIndex { get; }
        public List<VendorInteractionSack> SackInteractionList { get; }
        public uint UiInteractionType { get; }
        public int VendorCategoryIndex { get; }

        [JsonConstructor]
        private VendorInteraction(string flavorLineOne, string flavorLineTwo, DestinyDefinitionDisplayProperties headerDisplayProperties, string instructions,
            int interactionIndex, VendorInteractionType interactionType, uint questlineItemHash, List<VendorInteractionReply> replies, string rewardBlockLabel, 
            int rewardVendorCategoryIndex, List<VendorInteractionSack> sackInteractionList, uint uiInteractionType, int vendorCategoryIndex)
        {
            FlavorLineOne = flavorLineOne;
            FlavorLineTwo = flavorLineTwo;
            HeaderDisplayProperties = headerDisplayProperties;
            Instructions = instructions;
            InteractionIndex = interactionIndex;
            InteractionType = interactionType;
            QuestlineItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(questlineItemHash, "DestinyInventoryItemDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            Replies = replies;
            RewardBlockLabel = rewardBlockLabel;
            RewardVendorCategoryIndex = rewardVendorCategoryIndex;
            SackInteractionList = sackInteractionList;
            UiInteractionType = uiInteractionType;
            VendorCategoryIndex = vendorCategoryIndex;
        }
    }
}
