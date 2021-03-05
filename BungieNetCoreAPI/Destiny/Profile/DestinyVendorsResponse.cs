using BungieNetCoreAPI.Destiny.Profile.Components.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Profile
{
    public class DestinyVendorsResponse
    {
        [JsonConstructor]
        internal DestinyVendorsResponse(
            DestinyProfileComponent<DestinyVendorGroupComponent> vendorGroups,
            DestinyProfileComponent<Dictionary<uint, DestinyVendorComponent>> vendors,
            DestinyProfileComponent<Dictionary<uint, DestinyVendorCategoriesComponent>> categories)
        {

        }
    }
}
