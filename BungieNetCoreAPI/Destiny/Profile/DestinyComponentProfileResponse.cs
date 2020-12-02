using BungieNetCoreAPI.Destiny.Profile.Components;
using BungieNetCoreAPI.Destiny.Profile.Components.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Profile
{
    public class DestinyComponentProfileResponse
    {
        public List<IProfileComponent> Components { get; }

        [JsonConstructor]
        private DestinyComponentProfileResponse(DestinyProfileComponent<ComponentProfileData> profile, DestinyProfileComponent<ComponentVendorReceiptsData> vendorReceipts)
        {
            Components = new List<IProfileComponent>();
            if (profile != null)
                Components.Add(profile);
            if (vendorReceipts != null)
                Components.Add(vendorReceipts);
        }
        public bool TryGetComponent<T>(out T component)
        {
            var componentData = (DestinyProfileComponent<T>)Components.FirstOrDefault(x => x is DestinyProfileComponent<T>);
            component = componentData.Data;
            return component != null;
        }
    }
}
