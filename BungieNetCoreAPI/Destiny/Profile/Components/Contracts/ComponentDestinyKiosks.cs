using BungieNetCoreAPI.Destiny.Definitions.Vendors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class ComponentDestinyKiosks
    {
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyVendorDefinition>, object[]> KioskItems { get; }
        [JsonConstructor]
        internal ComponentDestinyKiosks(Dictionary<uint, object[]> kioskItems)
        {
            KioskItems = kioskItems.AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<DestinyVendorDefinition, object[]>(DefinitionsEnum.DestinyVendorDefinition);
        }
    }
}
