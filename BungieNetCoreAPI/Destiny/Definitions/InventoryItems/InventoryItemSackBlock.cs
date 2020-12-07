using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemSackBlock
    {
        public string DetailAction { get; }
        public string OpenAction { get; }
        public int SelectItemCount { get; }
        public string VendorSackType { get; }
        public bool OpenOnAcquire { get; }

        [JsonConstructor]
        private InventoryItemSackBlock(string detailAction, string openAction, int selectItemCount, string vendorSackType, bool openOnAcquire)
        {
            DetailAction = detailAction;
            OpenAction = openAction;
            SelectItemCount = selectItemCount;
            VendorSackType = vendorSackType;
            OpenOnAcquire = openOnAcquire;
        }
    }
}
