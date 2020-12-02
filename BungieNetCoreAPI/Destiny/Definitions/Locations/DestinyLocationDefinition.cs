using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Vendors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.Locations
{
    [DestinyDefinition("DestinyLocationDefinition")]
    public class DestinyLocationDefinition : DestinyDefinition
    {
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; }
        [JsonConstructor]
        private DestinyLocationDefinition(uint vendorHash, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            Vendor = new DefinitionHashPointer<DestinyVendorDefinition>(vendorHash, "DestinyVendorDefinition");
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
