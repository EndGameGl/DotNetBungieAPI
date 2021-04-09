using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny
{
    public record DestinyItemQuantity : IDeepEquatable<DestinyItemQuantity>
    {
        [JsonPropertyName("itemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

        [JsonPropertyName("itemInstanceId")]
        public long? ItemInstanceId { get; init; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; init; }

        public bool DeepEquals(DestinyItemQuantity other)
        {
            return other != null &&
                Item.DeepEquals(other.Item) &&
                Quantity == other.Quantity &&
                ItemInstanceId == other.ItemInstanceId;
        }
    }
}
