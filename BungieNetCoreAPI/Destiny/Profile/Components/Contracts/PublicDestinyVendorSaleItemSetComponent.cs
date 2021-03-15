using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class PublicDestinyVendorSaleItemSetComponent
    {
        public ReadOnlyDictionary<uint, DestinyPublicVendorSaleItemComponent> SaleItems { get; }

        [JsonConstructor]
        internal PublicDestinyVendorSaleItemSetComponent(Dictionary<uint, DestinyPublicVendorSaleItemComponent> saleItems)
        {
            SaleItems = saleItems.AsReadOnlyDictionaryOrEmpty();
        }
    }
}
