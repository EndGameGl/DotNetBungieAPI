using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Vendors;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Locations
{
    [DestinyDefinition(type: DefinitionsEnum.DestinyLocationDefinition, presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyLocationDefinition : IDestinyDefinition
    {
        public List<LocationRelease> LocationReleases { get; }
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyLocationDefinition(List<LocationRelease> locationReleases, uint vendorHash, bool blacklisted, uint hash, int index, bool redacted)
        {
            LocationReleases = locationReleases;
            Vendor = new DefinitionHashPointer<DestinyVendorDefinition>(vendorHash, DefinitionsEnum.DestinyVendorDefinition);
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
