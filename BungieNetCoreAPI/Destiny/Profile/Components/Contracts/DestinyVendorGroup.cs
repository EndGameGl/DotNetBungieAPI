using BungieNetCoreAPI.Destiny.Definitions.VendorGroups;
using BungieNetCoreAPI.Destiny.Definitions.Vendors;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyVendorGroup
    {
        public DefinitionHashPointer<DestinyVendorGroupDefinition> VendorGroup { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyVendorDefinition>> Vendors { get; }
        [JsonConstructor]
        internal DestinyVendorGroup(uint vendorGroupHash, uint[] vendorHashes)
        {
            VendorGroup = new DefinitionHashPointer<DestinyVendorGroupDefinition>(vendorGroupHash, DefinitionsEnum.DestinyVendorGroupDefinition);
            Vendors = vendorHashes.DefinitionsAsReadOnlyOrEmpty<DestinyVendorDefinition>(DefinitionsEnum.DestinyVendorDefinition);
        }
    }
}
