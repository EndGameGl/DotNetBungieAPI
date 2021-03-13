using NetBungieApi.Destiny.Profile.Components.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NetBungieApi.Destiny.Profile
{
    public class DestinyPublicVendorsResponse
    {
        private DestinyProfileComponent<DestinyVendorGroupComponent> _vendorGroups;
        private DestinyProfileComponent<Dictionary<uint, DestinyPublicVendorComponent>> _vendors;
        private DestinyProfileComponent<Dictionary<uint, DestinyVendorCategoriesComponent>> _categories;
        private DestinyProfileComponent<Dictionary<uint, PublicDestinyVendorSaleItemSetComponent>> _sales;

        [JsonConstructor]
        internal DestinyPublicVendorsResponse(
            DestinyProfileComponent<DestinyVendorGroupComponent> vendorGroups,
            DestinyProfileComponent<Dictionary<uint, DestinyPublicVendorComponent>> vendors,
            DestinyProfileComponent<Dictionary<uint, DestinyVendorCategoriesComponent>> categories,
            DestinyProfileComponent<Dictionary<uint, PublicDestinyVendorSaleItemSetComponent>> sales)
        {
            _vendorGroups = vendorGroups;
            _vendors = vendors;
            _categories = categories;
            _sales = sales;
        }
        public bool TryGetVendorGroups(out DestinyProfileComponent<DestinyVendorGroupComponent> data)
        {
            data = _vendorGroups;
            return data != null;
        }
        public bool TryGetVendors(out DestinyProfileComponent<Dictionary<uint, DestinyPublicVendorComponent>> data)
        {
            data = _vendors;
            return data != null;
        }
        public bool TryGetCategories(out DestinyProfileComponent<Dictionary<uint, DestinyVendorCategoriesComponent>> data)
        {
            data = _categories;
            return data != null;
        }
        public bool TryGetSales(out DestinyProfileComponent<Dictionary<uint, PublicDestinyVendorSaleItemSetComponent>> data)
        {
            data = _sales;
            return data != null;
        }
    }
}
