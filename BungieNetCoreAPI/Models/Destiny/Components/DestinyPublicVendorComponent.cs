using System;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Definitions.Vendors;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyPublicVendorComponent
    {
        [JsonPropertyName("vendorHash")] 
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; init; } = DefinitionHashPointer<DestinyVendorDefinition>.Empty;
        [JsonPropertyName("nextRefreshDate")] 
        public DateTime NextRefreshDate { get; init; }
        [JsonPropertyName("enabled")]
        public bool IsEnabled { get; init; }
    }
}