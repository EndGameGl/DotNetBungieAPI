using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Models.Destiny.Definitions.SocketTypes;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.TalentGrids
{
    public sealed record DestinyNodeSocketReplaceResponse : IDeepEquatable<DestinyNodeSocketReplaceResponse>
    {
        [JsonPropertyName("socketTypeHash")]
        public DefinitionHashPointer<DestinySocketTypeDefinition> SocketType { get; init; } = DefinitionHashPointer<DestinySocketTypeDefinition>.Empty;
        [JsonPropertyName("plugItemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> PlugItem { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

        public bool DeepEquals(DestinyNodeSocketReplaceResponse other)
        {
            return other != null &&
                   SocketType.DeepEquals(other.SocketType) &&
                   PlugItem.DeepEquals(other.PlugItem);
        }
    }
}
