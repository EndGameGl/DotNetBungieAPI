using BungieNetCoreAPI.Destiny.Profile.Components.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Profile
{
    public class DestinyVendorsResponse
    {
        private DestinyProfileComponent<DestinyVendorGroupComponent> _vendorGroups;
        private DestinyProfileComponent<Dictionary<uint, DestinyVendorComponent>> _vendors;
        private DestinyProfileComponent<Dictionary<uint, DestinyVendorCategoriesComponent>> _categories;
        private DestinyProfileComponent<Dictionary<uint, PersonalDestinyVendorSaleItemSetComponent>> _sales;
        private Dictionary<uint, DestinyItemSetComponent> _itemComponents;
        private DestinyProfileComponent<DestinyCurrenciesComponent> _currencyLookups;

        [JsonConstructor]
        internal DestinyVendorsResponse(
            DestinyProfileComponent<DestinyVendorGroupComponent> vendorGroups,
            DestinyProfileComponent<Dictionary<uint, DestinyVendorComponent>> vendors,
            DestinyProfileComponent<Dictionary<uint, DestinyVendorCategoriesComponent>> categories,
            DestinyProfileComponent<Dictionary<uint, PersonalDestinyVendorSaleItemSetComponent>> sales,
            Dictionary<uint, DestinyItemSetComponent> itemComponents,
            DestinyProfileComponent<DestinyCurrenciesComponent> currencyLookups)
        {
            _vendorGroups = vendorGroups;
            _vendors = vendors;
            _categories = categories;
            _sales = sales;
            _itemComponents = itemComponents;
            _currencyLookups = currencyLookups;
        }
        public bool TryGetVendorGroups(out DestinyProfileComponent<DestinyVendorGroupComponent> data)
        {
            data = _vendorGroups;
            return data != null;
        }
        public bool TryGetVendors(out DestinyProfileComponent<Dictionary<uint, DestinyVendorComponent>> data)
        {
            data = _vendors;
            return data != null;
        }
        public bool TryGetCategories(out DestinyProfileComponent<Dictionary<uint, DestinyVendorCategoriesComponent>> data)
        {
            data = _categories;
            return data != null;
        }
        public bool TryGetSales(out DestinyProfileComponent<Dictionary<uint, PersonalDestinyVendorSaleItemSetComponent>> data)
        {
            data = _sales;
            return data != null;
        }
        public bool TryGetItemComponents(out Dictionary<uint, DestinyItemSetComponent> data)
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
