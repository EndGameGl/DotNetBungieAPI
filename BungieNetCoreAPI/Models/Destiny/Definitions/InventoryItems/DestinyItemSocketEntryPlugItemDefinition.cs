using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// The definition of a known, reusable plug that can be applied to a socket.
    /// </summary>
    public class DestinyItemSocketEntryPlugItemDefinition : IDeepEquatable<DestinyItemSocketEntryPlugItemDefinition>
    {
        [JsonPropertyName("defaultVisible")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> PlugItem { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

        public bool DeepEquals(DestinyItemSocketEntryPlugItemDefinition other)
        {
            return other != null && PlugItem.DeepEquals(other.PlugItem);
        }
    }
}
