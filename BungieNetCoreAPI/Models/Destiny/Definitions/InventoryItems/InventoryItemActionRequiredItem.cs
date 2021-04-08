using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// The definition of an item and quantity required in a character's inventory in order to perform an action.
    /// </summary>
    public class InventoryItemActionRequiredItem : IDeepEquatable<InventoryItemActionRequiredItem>
    {
        public int Count { get; init; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; }
        public bool DeleteOnAction { get; init; }

        [JsonConstructor]
        internal InventoryItemActionRequiredItem(int count, uint itemHash, bool deleteOnAction)
        {
            Count = count;
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            DeleteOnAction = deleteOnAction;
        }

        public bool DeepEquals(InventoryItemActionRequiredItem other)
        {
            return other != null &&
                   Count == other.Count &&
                   Item.DeepEquals(other.Item) &&
                   DeleteOnAction == other.DeleteOnAction;
        }
    }
}
