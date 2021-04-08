using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class PersonalDestinyVendorSaleItemSetComponent
    {
        public ReadOnlyDictionary<uint, DestinyVendorSaleItemComponent> SaleItems { get; init; }

        [JsonConstructor]
        internal PersonalDestinyVendorSaleItemSetComponent(Dictionary<uint, DestinyVendorSaleItemComponent> saleItems)
        {
            SaleItems = saleItems.AsReadOnlyDictionaryOrEmpty();
        }
    }
}
