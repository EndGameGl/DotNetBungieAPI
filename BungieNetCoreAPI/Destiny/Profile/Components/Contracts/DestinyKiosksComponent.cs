using NetBungieAPI.Destiny.Definitions.Vendors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyKiosksComponent
    {
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyVendorDefinition>, object[]> KioskItems { get; }
        [JsonConstructor]
        internal DestinyKiosksComponent(Dictionary<uint, object[]> kioskItems)
        {
            KioskItems = kioskItems.AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<DestinyVendorDefinition, object[]>(DefinitionsEnum.DestinyVendorDefinition);
        }
    }
}
