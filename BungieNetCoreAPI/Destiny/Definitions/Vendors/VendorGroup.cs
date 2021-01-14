using BungieNetCoreAPI.Destiny.Definitions.VendorGroups;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    public class VendorGroup
    {
        public DefinitionHashPointer<DestinyVendorGroupDefinition> Group { get; }

        [JsonConstructor]
        private VendorGroup(uint vendorGroupHash)
        {
            Group = new DefinitionHashPointer<DestinyVendorGroupDefinition>(vendorGroupHash, "DestinyVendorGroupDefinition");
        }
    }
}
