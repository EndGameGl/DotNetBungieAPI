using BungieNetCoreAPI.Destiny.Profile.Components.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Profile
{
    public class DestinyVendorResponse
    {
        private DestinyProfileComponent<DestinyVendorComponent> _vendor;
        private DestinyProfileComponent<DestinyVendorCategoriesComponent> _categories;
        private DestinyProfileComponent<Dictionary<uint, DestinyVendorSaleItemComponent>> _sales;
        private DestinyItemSetComponent _itemComponents;
        private DestinyProfileComponent<DestinyCurrenciesComponent> _currencyLookups;

        [JsonConstructor]
        internal DestinyVendorResponse(
            DestinyProfileComponent<DestinyVendorComponent> vendor,
            DestinyProfileComponent<DestinyVendorCategoriesComponent> categories,
            DestinyProfileComponent<Dictionary<uint, DestinyVendorSaleItemComponent>> sales,
            DestinyItemSetComponent itemComponents,
            DestinyProfileComponent<DestinyCurrenciesComponent> currencyLookups)
        {
            _vendor = vendor;
            _categories = categories;
            _sales = sales;
            _itemComponents = itemComponents;
            _currencyLookups = currencyLookups;
        }

        public bool TryGetVendor(out DestinyProfileComponent<DestinyVendorComponent> data)
        {
            data = _vendor;
            return data != null;
        }
        public bool TryGetCategories(out DestinyProfileComponent<DestinyVendorCategoriesComponent> data)
        {
            data = _categories;
            return data != null;
        }
        public bool TryGetSales(out DestinyProfileComponent<Dictionary<uint, DestinyVendorSaleItemComponent>> data)
        {
            data = _sales;
            return data != null;
        }
        public bool TryGetItemComponents(out DestinyItemSetComponent data)
        {
            data = _itemComponents;
            return data != null;
        }
        public bool TryGetCurrencyLookups(out DestinyProfileComponent<DestinyCurrenciesComponent> data)
        {
            data = _currencyLookups;
            return data != null;
        }
    }
}
