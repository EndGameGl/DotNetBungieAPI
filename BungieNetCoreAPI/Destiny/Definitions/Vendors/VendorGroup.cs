using NetBungieApi.Destiny.Definitions.VendorGroups;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.Vendors
{
    public class VendorGroup : IDeepEquatable<VendorGroup>
    {
        public DefinitionHashPointer<DestinyVendorGroupDefinition> Group { get; }

        [JsonConstructor]
        internal VendorGroup(uint vendorGroupHash)
        {
            Group = new DefinitionHashPointer<DestinyVendorGroupDefinition>(vendorGroupHash, DefinitionsEnum.DestinyVendorGroupDefinition);
        }

        public bool DeepEquals(VendorGroup other)
        {
            return other != null &&
                   Group.DeepEquals(other.Group);
        }
    }
}
