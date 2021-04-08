using NetBungieAPI.Models.Destiny.Definitions.Vendors;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Milestones
{
    /// <summary>
    /// A subclass of DestinyItemQuantity, that provides not just the item and its quantity but also information that BNet can - at some point - use internally to provide more robust runtime information about the item's qualities.
    /// </summary>
    public sealed record DestinyMilestoneQuestRewardItem : DestinyItemQuantity, IDeepEquatable<DestinyMilestoneQuestRewardItem>
    {
        [JsonPropertyName("vendorHash")]
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; init; }

        [JsonPropertyName("vendorItemIndex")]
        public int? VendorItemIndex { get; init; }

        public bool DeepEquals(DestinyMilestoneQuestRewardItem other)
        {
            return other != null &&
                   Item.DeepEquals(other.Item) &&
                   Quantity == other.Quantity &&
                   ItemInstanceId == other.ItemInstanceId &&
                   Vendor.DeepEquals(other.Vendor) &&
                   VendorItemIndex == other.VendorItemIndex;
        }
    }
}
