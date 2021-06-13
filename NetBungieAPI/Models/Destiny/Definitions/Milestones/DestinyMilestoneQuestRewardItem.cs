using NetBungieAPI.Models.Destiny.Definitions.Vendors;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Milestones
{
    /// <summary>
    /// A subclass of DestinyItemQuantity, that provides not just the item and its quantity but also information that BNet can - at some point - use internally to provide more robust runtime information about the item's qualities.
    /// </summary>
    public sealed record DestinyMilestoneQuestRewardItem : DestinyItemQuantity,
        IDeepEquatable<DestinyMilestoneQuestRewardItem>
    {
        /// <summary>
        /// The quest reward item *may* be associated with a vendor. If so, this is that vendor. Use this hash to look up the DestinyVendorDefinition.
        /// </summary>
        [JsonPropertyName("vendorHash")]
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; init; } =
            DefinitionHashPointer<DestinyVendorDefinition>.Empty;

        /// <summary>
        /// The quest reward item *may* be associated with a vendor. If so, this is the index of the item being sold, which we can use at runtime to find instanced item information for the reward item.
        /// </summary>
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