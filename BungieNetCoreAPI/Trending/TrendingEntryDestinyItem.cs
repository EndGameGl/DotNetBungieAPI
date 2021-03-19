using NetBungieAPI.Destiny;
using NetBungieAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;

namespace NetBungieAPI.Trending
{
    public class TrendingEntryDestinyItem
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }

        [JsonConstructor]
        internal TrendingEntryDestinyItem(uint itemHash)
        {
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
        }
    }
}
