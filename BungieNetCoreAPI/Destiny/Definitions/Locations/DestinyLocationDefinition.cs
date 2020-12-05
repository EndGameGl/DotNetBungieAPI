using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Vendors;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Locations
{
    [DestinyDefinition("DestinyLocationDefinition")]
    public class DestinyLocationDefinition : DestinyDefinition
    {
        public List<LocationRelease> LocationReleases { get; }
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; }

        [JsonConstructor]
        private DestinyLocationDefinition(List<LocationRelease> locationReleases, uint vendorHash, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            LocationReleases = locationReleases;
            Vendor = new DefinitionHashPointer<DestinyVendorDefinition>(vendorHash, "DestinyVendorDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
