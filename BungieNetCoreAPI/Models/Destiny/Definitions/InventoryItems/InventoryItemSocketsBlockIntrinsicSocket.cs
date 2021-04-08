using NetBungieAPI.Destiny.Definitions.SocketTypes;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemSocketsBlockIntrinsicSocket : IDeepEquatable<InventoryItemSocketsBlockIntrinsicSocket>
    {
        public bool DefaultVisible { get; init; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> PlugItem { get; init; }
        public DefinitionHashPointer<DestinySocketTypeDefinition> SocketType { get; init; }

        [JsonConstructor]
        private InventoryItemSocketsBlockIntrinsicSocket(bool defaultVisible, uint plugItemHash, uint socketTypeHash)
        {
            DefaultVisible = defaultVisible;
            PlugItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(plugItemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            SocketType = new DefinitionHashPointer<DestinySocketTypeDefinition>(socketTypeHash, DefinitionsEnum.DestinySocketTypeDefinition);
        }

        public bool DeepEquals(InventoryItemSocketsBlockIntrinsicSocket other)
        {
            return other != null &&
                   DefaultVisible == other.DefaultVisible &&
                   PlugItem.DeepEquals(other.PlugItem) &&
                   SocketType.DeepEquals(other.SocketType);
        }
    }
}
