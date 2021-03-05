using BungieNetCoreAPI.Destiny.Definitions.Vendors;
using Newtonsoft.Json;
using System;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyPublicVendorComponent
    {
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; }
        public DateTime NextRefreshDate { get; }
        public bool IsEnabled { get; }

        [JsonConstructor]
        internal DestinyPublicVendorComponent(uint vendorHash, DateTime nextRefreshDate, bool enabled)
        {
            Vendor = new DefinitionHashPointer<DestinyVendorDefinition>(vendorHash, DefinitionsEnum.DestinyVendorDefinition);
            NextRefreshDate = nextRefreshDate;
            IsEnabled = enabled;
        }
    }
}
