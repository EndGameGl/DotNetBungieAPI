using NetBungieAPI.Destiny.Definitions.SocketCategories;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemSocketsBlockSocketCategory : IDeepEquatable<InventoryItemSocketsBlockSocketCategory>
    {
        public DefinitionHashPointer<DestinySocketCategoryDefinition> SocketCategory { get; }
        public ReadOnlyCollection<int> SocketIndexes { get; }

        [JsonConstructor]
        internal InventoryItemSocketsBlockSocketCategory(uint socketCategoryHash, int[] socketIndexes)
        {
            SocketCategory = new DefinitionHashPointer<DestinySocketCategoryDefinition>(socketCategoryHash, DefinitionsEnum.DestinySocketCategoryDefinition);
            SocketIndexes = socketIndexes.AsReadOnlyOrEmpty();
        }

        public bool DeepEquals(InventoryItemSocketsBlockSocketCategory other)
        {
            return other != null &&
                   SocketCategory.DeepEquals(other.SocketCategory) &&
                   SocketIndexes.DeepEqualsReadOnlySimpleCollection(other.SocketIndexes);
        }
    }
}
