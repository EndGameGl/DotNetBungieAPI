using BungieNetCoreAPI.Destiny.Profile.Components;
using BungieNetCoreAPI.Destiny.Profile.Components.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Profile
{
    public class DestinyComponentProfileResponse
    {
        public ReadOnlyDictionary<DestinyComponentType, IProfileComponent> Components { get; }

        [JsonConstructor]
        internal DestinyComponentProfileResponse(
            DestinyProfileComponent<ComponentProfileData> profile,
            DestinyProfileComponent<ComponentVendorReceiptsData> vendorReceipts,
            DestinyProfileComponent<ComponentDestinyInventory> profileInventory,
            DestinyProfileComponent<ComponentDestinyInventory> profileCurrencies,
            DestinyProfileComponent<ComponentDestinyProfileProgression> profileProgression)
        {
            var components = new Dictionary<DestinyComponentType, IProfileComponent>();

            if (profile != null)
                components.Add(DestinyComponentType.Profiles, profile);
            if (vendorReceipts != null)
                components.Add(DestinyComponentType.VendorReceipts, vendorReceipts);
            if (profileInventory != null)
                components.Add(DestinyComponentType.ProfileInventories, profileInventory);
            if (profileCurrencies != null)
                components.Add(DestinyComponentType.ProfileCurrencies, profileCurrencies);
            if (profileProgression != null)
                components.Add(DestinyComponentType.ProfileProgression, profileProgression);

            Components = new ReadOnlyDictionary<DestinyComponentType, IProfileComponent>(components);
        }

        public bool TryGetComponent<T>(DestinyComponentType type, out T component)
        {
            component = default;
            if (Components.TryGetValue(type, out var foundComponent))
            {
                component = ((DestinyProfileComponent<T>)foundComponent).Data;
                return true;
            }
            else
                return false;
        }

        public bool TryGetComponent<T>(out T component)
        {
            var componentData = (DestinyProfileComponent<T>)Components.Values.FirstOrDefault(x => x is DestinyProfileComponent<T>);
            component = componentData.Data;
            return component != null;
        }
    }
}
