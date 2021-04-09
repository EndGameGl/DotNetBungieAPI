using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Models.Destiny.Definitions.SocketTypes;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Vendors
{
    public sealed record DestinyVendorItemSocketOverride : IDeepEquatable<DestinyVendorItemSocketOverride>
    {
        [JsonPropertyName("singleItemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> SingleItem { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
        [JsonPropertyName("randomizedOptionsCount")]
        public int RandomizedOptionsCount { get; init; }
        [JsonPropertyName("socketTypeHash")]
        public DefinitionHashPointer<DestinySocketTypeDefinition> SocketType { get; init; } = DefinitionHashPointer<DestinySocketTypeDefinition>.Empty;

        public bool DeepEquals(DestinyVendorItemSocketOverride other)
        {
            return other != null &&
                   SingleItem.DeepEquals(other.SingleItem) &&
                   RandomizedOptionsCount == other.RandomizedOptionsCount &&
                   SocketType.DeepEquals(other.SocketType);
        }
    }
}
