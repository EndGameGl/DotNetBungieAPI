using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class ComponentVendorReceiptsData
    {
        public ReadOnlyCollection<DestinyVendorReceipt> Receipts { get; }

        [JsonConstructor]
        internal ComponentVendorReceiptsData(DestinyVendorReceipt[] receipts)
        {
            Receipts = receipts.AsReadOnlyOrEmpty();
        }
    }
}
