using NetBungieAPI.Destiny.Definitions.Vendors;
using Newtonsoft.Json;
using System;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyPublicVendorComponent
    {
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; init; }
        public DateTime NextRefreshDate { get; init; }
        public bool IsEnabled { get; init; }

        [JsonConstructor]
        internal DestinyPublicVendorComponent(uint vendorHash, DateTime nextRefreshDate, bool enabled)
        {
            Vendor = new DefinitionHashPointer<DestinyVendorDefinition>(vendorHash, DefinitionsEnum.DestinyVendorDefinition);
            NextRefreshDate = nextRefreshDate;
            IsEnabled = enabled;
        }
    }
}
