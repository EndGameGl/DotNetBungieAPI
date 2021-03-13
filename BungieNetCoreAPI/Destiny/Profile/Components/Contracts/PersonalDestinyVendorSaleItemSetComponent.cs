using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Profile.Components.Contracts
{
    public class PersonalDestinyVendorSaleItemSetComponent
    {
        public ReadOnlyDictionary<uint, DestinyVendorSaleItemComponent> SaleItems { get; }

        [JsonConstructor]
        internal PersonalDestinyVendorSaleItemSetComponent(Dictionary<uint, DestinyVendorSaleItemComponent> saleItems)
        {
            SaleItems = saleItems.AsReadOnlyDictionaryOrEmpty();
        }
    }
}
