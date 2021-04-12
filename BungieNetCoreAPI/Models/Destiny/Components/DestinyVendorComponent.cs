using System;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Definitions.Vendors;
using NetBungieAPI.Models.Destiny.Progressions;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyVendorComponent
    {
        [JsonPropertyName("data")] 
        public bool CanPurchase { get; init; }
        [JsonPropertyName("data")] 
        public DestinyProgression Progression { get; init; }
        [JsonPropertyName("data")] 
        public int VendorLocationIndex { get; init; }
        [JsonPropertyName("data")] 
        public int? SeasonalRank { get; init; }

        [JsonPropertyName("data")]
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; init; } =
            DefinitionHashPointer<DestinyVendorDefinition>.Empty;

        [JsonPropertyName("data")] 
        public DateTime NextRefreshDate { get; init; }
        [JsonPropertyName("data")] 
        public bool IsEnabled { get; init; }
    }
}