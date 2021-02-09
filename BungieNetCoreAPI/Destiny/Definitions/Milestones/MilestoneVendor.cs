using BungieNetCoreAPI.Destiny.Definitions.Vendors;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Milestones
{
    public class MilestoneVendor : IDeepEquatable<MilestoneVendor>
    {
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; }

        [JsonConstructor]
        internal MilestoneVendor(uint vendorHash)
        {
            Vendor = new DefinitionHashPointer<DestinyVendorDefinition>(vendorHash, DefinitionsEnum.DestinyVendorDefinition);
        }

        public bool DeepEquals(MilestoneVendor other)
        {
            return other != null && Vendor.DeepEquals(other.Vendor);
        }
    }
}
