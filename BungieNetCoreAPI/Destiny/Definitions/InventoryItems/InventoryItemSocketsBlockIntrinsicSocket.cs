using BungieNetCoreAPI.Destiny.Definitions.SocketTypes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemSocketsBlockIntrinsicSocket
    {
        public bool DefaultVisible { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> PlugItem { get; }
        public DefinitionHashPointer<DestinySocketTypeDefinition> SocketType { get; }

        [JsonConstructor]
        private InventoryItemSocketsBlockIntrinsicSocket(bool defaultVisible, uint plugItemHash, uint socketTypeHash)
        {
            DefaultVisible = defaultVisible;
            PlugItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(plugItemHash, "DestinyInventoryItemDefinition");
            SocketType = new DefinitionHashPointer<DestinySocketTypeDefinition>(socketTypeHash, "DestinySocketTypeDefinition");
        }
    }
}
