using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// Some items are "sacks" - they can be "opened" to produce other items. This is information related to its sack status, mostly UI strings. Engrams are an example of items that are considered to be "Sacks".
    /// </summary>
    public class InventoryItemSackBlock : IDeepEquatable<InventoryItemSackBlock>
    {
        /// <summary>
        /// A description of what will happen when you open the sack. As far as I can tell, this is blank currently. Unknown whether it will eventually be populated with useful info.
        /// </summary>
        public string DetailAction { get; init; }
        /// <summary>
        /// The localized name of the action being performed when you open the sack.
        /// </summary>
        public string OpenAction { get; init; }
        public int SelectItemCount { get; init; }
        public string VendorSackType { get; init; }
        public bool OpenOnAcquire { get; init; }

        [JsonConstructor]
        internal InventoryItemSackBlock(string detailAction, string openAction, int selectItemCount, string vendorSackType, bool openOnAcquire)
        {
            DetailAction = detailAction;
            OpenAction = openAction;
            SelectItemCount = selectItemCount;
            VendorSackType = vendorSackType;
            OpenOnAcquire = openOnAcquire;
        }

        public bool DeepEquals(InventoryItemSackBlock other)
        {
            return other != null &&
                   DetailAction == other.DetailAction &&
                   OpenAction == other.OpenAction &&
                   SelectItemCount == other.SelectItemCount &&
                   VendorSackType == other.VendorSackType &&
                   OpenOnAcquire == other.OpenOnAcquire;
        }
    }
}
