using NetBungieAPI.Destiny.Definitions.VendorGroups;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Vendors
{
    public class VendorGroup : IDeepEquatable<VendorGroup>
    {
        public DefinitionHashPointer<DestinyVendorGroupDefinition> Group { get; init; }

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
