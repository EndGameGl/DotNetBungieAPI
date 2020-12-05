using BungieNetCoreAPI.Destiny.Definitions.SocketCategories;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemSocketsBlockSocketCategory
    {
        public DefinitionHashPointer<DestinySocketCategoryDefinition> SocketCategory { get; }
        public List<int> SocketIndexes { get; }

        [JsonConstructor]
        private InventoryItemSocketsBlockSocketCategory(uint socketCategoryHash, List<int> socketIndexes)
        {
            SocketCategory = new DefinitionHashPointer<DestinySocketCategoryDefinition>(socketCategoryHash, "DestinySocketCategoryDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            SocketIndexes = socketIndexes;
        }
    }
}
