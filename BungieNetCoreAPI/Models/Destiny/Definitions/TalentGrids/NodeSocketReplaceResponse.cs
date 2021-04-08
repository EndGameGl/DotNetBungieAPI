using NetBungieAPI.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Destiny.Definitions.SocketTypes;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.TalentGrids
{
    public class NodeSocketReplaceResponse : IDeepEquatable<NodeSocketReplaceResponse>
    {
        public DefinitionHashPointer<DestinySocketTypeDefinition> SocketType { get; init; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> PlugItem { get; init; }

        [JsonConstructor]
        internal NodeSocketReplaceResponse(uint socketTypeHash, uint plugItemHash)
        {
            SocketType = new DefinitionHashPointer<DestinySocketTypeDefinition>(socketTypeHash, DefinitionsEnum.DestinySocketTypeDefinition);
            PlugItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(plugItemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
        }

        public bool DeepEquals(NodeSocketReplaceResponse other)
        {
            return other != null &&
                   SocketType.DeepEquals(other.SocketType) &&
                   PlugItem.DeepEquals(other.PlugItem);
        }
    }
}
