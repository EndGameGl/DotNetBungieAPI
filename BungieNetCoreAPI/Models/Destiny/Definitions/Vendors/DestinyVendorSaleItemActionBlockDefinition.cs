using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Vendors
{
    public sealed record DestinyVendorSaleItemActionBlockDefinition : IDeepEquatable<DestinyVendorSaleItemActionBlockDefinition>
    {
        [JsonPropertyName("executeSeconds")]
        public double ExecuteSeconds { get; init; }
        [JsonPropertyName("isPositive")]
        public bool IsPositive { get; init; }

        public bool DeepEquals(DestinyVendorSaleItemActionBlockDefinition other)
        {
            return other != null &&
                   ExecuteSeconds == other.ExecuteSeconds &&
                   IsPositive == other.IsPositive;
        }
    }
}
