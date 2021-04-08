using NetBungieAPI.Destiny.Definitions.VendorGroups;
using NetBungieAPI.Destiny.Definitions.Vendors;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyVendorGroup
    {
        public DefinitionHashPointer<DestinyVendorGroupDefinition> VendorGroup { get; init; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyVendorDefinition>> Vendors { get; init; }
        [JsonConstructor]
        internal DestinyVendorGroup(uint vendorGroupHash, uint[] vendorHashes)
        {
            VendorGroup = new DefinitionHashPointer<DestinyVendorGroupDefinition>(vendorGroupHash, DefinitionsEnum.DestinyVendorGroupDefinition);
            Vendors = vendorHashes.DefinitionsAsReadOnlyOrEmpty<DestinyVendorDefinition>(DefinitionsEnum.DestinyVendorDefinition);
        }
    }
}
