using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class VendorReceiptsDataComponent
    {
        public ReadOnlyCollection<DestinyVendorReceipt> Receipts { get; }

        [JsonConstructor]
        internal VendorReceiptsDataComponent(DestinyVendorReceipt[] receipts)
        {
            Receipts = receipts.AsReadOnlyOrEmpty();
        }
    }
}
