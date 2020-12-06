using BungieNetCoreAPI.Destiny.Definitions.Vendors;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Milestones
{
    public class MilestoneVendor
    {
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; }

        [JsonConstructor]
        private MilestoneVendor(uint vendorHash)
        {
            Vendor = new DefinitionHashPointer<DestinyVendorDefinition>(vendorHash, "DestinyVendorDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
        }
    }
}
