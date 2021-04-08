using NetBungieAPI.Destiny.Definitions.Vendors;
using Newtonsoft.Json;
using System;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyVendorComponent
    {
        public bool CanPurchase { get; init; }
        public DestinyProgression Progression { get; init; }
        public int VendorLocationIndex { get; init; }
        public int? SeasonalRank { get; init; }
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; init; }
        public DateTime NextRefreshDate { get; init; }
        public bool IsEnabled { get; init; }

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
