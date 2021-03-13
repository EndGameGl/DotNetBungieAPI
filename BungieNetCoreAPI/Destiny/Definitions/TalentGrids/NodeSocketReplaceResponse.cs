using NetBungieApi.Destiny.Definitions.InventoryItems;
using NetBungieApi.Destiny.Definitions.SocketTypes;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.TalentGrids
{
    public class NodeSocketReplaceResponse : IDeepEquatable<NodeSocketReplaceResponse>
    {
        public DefinitionHashPointer<DestinySocketTypeDefinition> SocketType { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> PlugItem { get; }

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
