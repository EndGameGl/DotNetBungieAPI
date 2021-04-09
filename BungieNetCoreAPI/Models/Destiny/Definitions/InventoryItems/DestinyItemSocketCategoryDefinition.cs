using NetBungieAPI.Models.Destiny.Definitions.SocketCategories;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    public sealed record DestinyItemSocketCategoryDefinition : IDeepEquatable<DestinyItemSocketCategoryDefinition>
    {
        [JsonPropertyName("socketCategoryHash")]
        public DefinitionHashPointer<DestinySocketCategoryDefinition> SocketCategory { get; init; } = DefinitionHashPointer<DestinySocketCategoryDefinition>.Empty;
        [JsonPropertyName("socketIndexes")]
        public ReadOnlyCollection<int> SocketIndexes { get; init; } = Defaults.EmptyReadOnlyCollection<int>();

        public bool DeepEquals(DestinyItemSocketCategoryDefinition other)
        {
            return other != null &&
                   SocketCategory.DeepEquals(other.SocketCategory) &&
                   SocketIndexes.DeepEqualsReadOnlySimpleCollection(other.SocketIndexes);
        }
    }
}
