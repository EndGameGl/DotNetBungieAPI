using DotNetBungieAPI.Models.Destiny.Definitions.Vendors;

namespace DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

/// <summary>
///     Represents that a vendor could sell this item, and provides a quick link to that vendor and sale item.
///     <para />
///     Note that we do not and cannot make a guarantee that the vendor will ever* actually* sell this item, only that the
///     Vendor has a definition that indicates it *could* be sold.
///     <para />
///     Note also that a vendor may sell the same item in multiple "ways", which means there may be multiple
///     vendorItemIndexes for a single Vendor hash.
/// </summary>
public sealed record DestinyItemVendorSourceReference : IDeepEquatable<DestinyItemVendorSourceReference>
{
    /// <summary>
    ///     The vendor that may sell this item.
    /// </summary>
    [JsonPropertyName("vendorHash")]
    public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; init; } =
        DefinitionHashPointer<DestinyVendorDefinition>.Empty;

    /// <summary>
    ///     The Vendor sale item indexes that represent the sale information for this item. The same vendor may sell an item in
    ///     multiple "ways", hence why this is a list. (for instance, a weapon may be "sold" as a reward in a quest, for
    ///     Glimmer, and for Masterwork Cores: each of those ways would be represented by a different vendor sale item with a
    ///     different index)
    /// </summary>
    [JsonPropertyName("vendorItemIndexes")]
    public ReadOnlyCollection<int> VendorItemIndexes { get; init; } = ReadOnlyCollections<int>.Empty;

    public bool DeepEquals(DestinyItemVendorSourceReference other)
    {
        return other != null &&
               Vendor.DeepEquals(other.Vendor) &&
               VendorItemIndexes.DeepEqualsReadOnlySimpleCollection(other.VendorItemIndexes);
    }
}