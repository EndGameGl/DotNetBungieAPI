using NetBungieAPI.Models.Destiny.Definitions.SocketTypes;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    public sealed record DestinyItemIntrinsicSocketEntryDefinition : IDeepEquatable<DestinyItemIntrinsicSocketEntryDefinition>
    {
        [JsonPropertyName("defaultVisible")]
        public bool DefaultVisible { get; init; }
        [JsonPropertyName("plugItemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> PlugItem { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
        [JsonPropertyName("socketTypeHash")]
        public DefinitionHashPointer<DestinySocketTypeDefinition> SocketType { get; init; } = DefinitionHashPointer<DestinySocketTypeDefinition>.Empty;

        public bool DeepEquals(DestinyItemIntrinsicSocketEntryDefinition other)
        {
            return other != null &&
                   DefaultVisible == other.DefaultVisible &&
                   PlugItem.DeepEquals(other.PlugItem) &&
                   SocketType.DeepEquals(other.SocketType);
        }
    }
}
