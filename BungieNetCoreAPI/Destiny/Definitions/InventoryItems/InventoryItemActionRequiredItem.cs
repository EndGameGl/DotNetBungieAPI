using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// The definition of an item and quantity required in a character's inventory in order to perform an action.
    /// </summary>
    public class InventoryItemActionRequiredItem : IDeepEquatable<InventoryItemActionRequiredItem>
    {
        public int Count { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }
        public bool DeleteOnAction { get; }

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
