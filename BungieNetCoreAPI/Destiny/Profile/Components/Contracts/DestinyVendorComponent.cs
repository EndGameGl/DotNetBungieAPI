using NetBungieAPI.Destiny.Definitions.Vendors;
using Newtonsoft.Json;
using System;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyVendorComponent
    {
        public bool CanPurchase { get; }
        public DestinyProgression Progression { get; }
        public int VendorLocationIndex { get; }
        public int? SeasonalRank { get; }
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; }
        public DateTime NextRefreshDate { get; }
        public bool IsEnabled { get; }

        [JsonConstructor]
        internal DestinyVendorComponent(bool canPurchase, DestinyProgression progression, int vendorLocationIndex, int? seasonalRank, uint vendorHash,
            DateTime nextRefreshDate, bool enabled)
        {
            CanPurchase = canPurchase;
            Progression = progression;
            VendorLocationIndex = vendorLocationIndex;
            SeasonalRank = seasonalRank;
            Vendor = new DefinitionHashPointer<DestinyVendorDefinition>(vendorHash, DefinitionsEnum.DestinyVendorDefinition);
            NextRefreshDate = nextRefreshDate;
            IsEnabled = enabled;
        }
    }
}
