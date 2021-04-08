using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// The definition of a known, reusable plug that can be applied to a socket.
    /// </summary>
    public class InventoryItemSocketsBlockSocketEntryReusablePlugItem : IDeepEquatable<InventoryItemSocketsBlockSocketEntryReusablePlugItem>
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> PlugItem { get; init; }

        [JsonConstructor]
        internal InventoryItemSocketsBlockSocketEntryReusablePlugItem(uint plugItemHash)
        {
            PlugItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(plugItemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
        }

        public bool DeepEquals(InventoryItemSocketsBlockSocketEntryReusablePlugItem other)
        {
            return other != null && PlugItem.DeepEquals(other.PlugItem);
        }
    }
}
