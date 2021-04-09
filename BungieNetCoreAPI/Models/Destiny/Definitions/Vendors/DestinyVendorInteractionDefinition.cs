using NetBungieAPI.Models.Destiny.Definitions.Common;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Vendors
{
    public sealed record DestinyVendorInteractionDefinition : IDeepEquatable<DestinyVendorInteractionDefinition>
    {
        [JsonPropertyName("interactionIndex")]
        public int InteractionIndex { get; init; }
        [JsonPropertyName("replies")]
        public ReadOnlyCollection<DestinyVendorInteractionReplyDefinition> Replies { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyVendorInteractionReplyDefinition>();
        [JsonPropertyName("vendorCategoryIndex")]
        public int VendorCategoryIndex { get; init; }
        [JsonPropertyName("questlineItemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> QuestlineItem { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
        [JsonPropertyName("sackInteractionList")]
        public ReadOnlyCollection<DestinyVendorInteractionSackEntryDefinition> SackInteractionList { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyVendorInteractionSackEntryDefinition>();
        [JsonPropertyName("uiInteractionType")]
        public uint UiInteractionType { get; init; }
        [JsonPropertyName("interactionType")]
        public VendorInteractionType InteractionType { get; init; }
        [JsonPropertyName("rewardBlockLabel")]
        public string RewardBlockLabel { get; init; }
        [JsonPropertyName("rewardVendorCategoryIndex")]
        public int RewardVendorCategoryIndex { get; init; }
        [JsonPropertyName("flavorLineOne")]
        public string FlavorLineOne { get; init; }
        [JsonPropertyName("flavorLineTwo")]
        public string FlavorLineTwo { get; init; }
        [JsonPropertyName("headerDisplayProperties")]
        public DestinyDisplayPropertiesDefinition HeaderDisplayProperties { get; init; }
        [JsonPropertyName("instructions")]
        public string Instructions { get; init; }

        public bool DeepEquals(DestinyVendorInteractionDefinition other)
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
