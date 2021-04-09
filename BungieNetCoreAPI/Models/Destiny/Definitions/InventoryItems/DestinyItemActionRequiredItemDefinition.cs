using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// The definition of an item and quantity required in a character's inventory in order to perform an action.
    /// </summary>
    public sealed record DestinyItemActionRequiredItemDefinition : IDeepEquatable<DestinyItemActionRequiredItemDefinition>
    {
        [JsonPropertyName("count")]
        public int Count { get; init; }
        [JsonPropertyName("itemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
        [JsonPropertyName("deleteOnAction")]
        public bool DeleteOnAction { get; init; }

        public bool DeepEquals(DestinyItemActionRequiredItemDefinition other)
        {
            return other != null &&
                   Count == other.Count &&
                   Item.DeepEquals(other.Item) &&
                   DeleteOnAction == other.DeleteOnAction;
        }
    }
}
