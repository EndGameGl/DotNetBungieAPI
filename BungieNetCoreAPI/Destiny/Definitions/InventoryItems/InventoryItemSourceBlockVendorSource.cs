using NetBungieAPI.Destiny.Definitions.Vendors;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// Represents that a vendor could sell this item, and provides a quick link to that vendor and sale item.
    /// <para/>
    /// Note that we do not and cannot make a guarantee that the vendor will ever* actually* sell this item, only that the Vendor has a definition that indicates it *could* be sold.
    /// <para/>
    /// Note also that a vendor may sell the same item in multiple "ways", which means there may be multiple vendorItemIndexes for a single Vendor hash.
    /// </summary>
    public class InventoryItemSourceBlockVendorSource : IDeepEquatable<InventoryItemSourceBlockVendorSource>
    {
        /// <summary>
        /// The vendor that may sell this item.
        /// </summary>
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; }
        /// <summary>
        /// The Vendor sale item indexes that represent the sale information for this item. The same vendor may sell an item in multiple "ways", hence why this is a list. (for instance, a weapon may be "sold" as a reward in a quest, for Glimmer, and for Masterwork Cores: each of those ways would be represented by a different vendor sale item with a different index)
        /// </summary>
        public ReadOnlyCollection<int> VendorItemIndexes { get; }

        [JsonConstructor]
        internal InventoryItemSourceBlockVendorSource(uint vendorHash, int[] vendorItemIndexes)
        {
            Vendor = new DefinitionHashPointer<DestinyVendorDefinition>(vendorHash, DefinitionsEnum.DestinyVendorDefinition);
            VendorItemIndexes = vendorItemIndexes.AsReadOnlyOrEmpty();
        }

        public bool DeepEquals(InventoryItemSourceBlockVendorSource other)
        {
            return other != null &&
                   Vendor.DeepEquals(other.Vendor) &&
                   VendorItemIndexes.DeepEqualsReadOnlySimpleCollection(other.VendorItemIndexes);
        }
    }
}
