using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    /// <summary>
    ///     The definition of an item and quantity required in a character's inventory in order to perform an action.
    /// </summary>
    public sealed record
        DestinyItemActionRequiredItemDefinition : IDeepEquatable<DestinyItemActionRequiredItemDefinition>
    {
        /// <summary>
        ///     The minimum quantity of the item you have to have.
        /// </summary>
        [JsonPropertyName("count")]
        public int Count { get; init; }

        /// <summary>
        ///     DestinyInventoryItemDefinition you need to have
        /// </summary>
        [JsonPropertyName("itemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; } =
            DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

        /// <summary>
        ///     If true, the item/quantity will be deleted from your inventory when the action is performed. Otherwise, you'll
        ///     retain these required items after the action is complete.
        /// </summary>
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