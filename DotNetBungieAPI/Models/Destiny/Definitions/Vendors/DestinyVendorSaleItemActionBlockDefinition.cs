using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Vendors
{
    /// <summary>
    ///     Not terribly useful, some basic cooldown interaction info.
    /// </summary>
    public sealed record
        DestinyVendorSaleItemActionBlockDefinition : IDeepEquatable<DestinyVendorSaleItemActionBlockDefinition>
    {
        [JsonPropertyName("executeSeconds")] public double ExecuteSeconds { get; init; }
        [JsonPropertyName("isPositive")] public bool IsPositive { get; init; }

        public bool DeepEquals(DestinyVendorSaleItemActionBlockDefinition other)
        {
            return other != null &&
                   ExecuteSeconds == other.ExecuteSeconds &&
                   IsPositive == other.IsPositive;
        }
    }
}