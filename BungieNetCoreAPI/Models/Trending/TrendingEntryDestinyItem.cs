using NetBungieAPI.Destiny.Definitions.InventoryItems;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Trending
{
    public class TrendingEntryDestinyItem
    {
        [JsonPropertyName("itemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; }
    }
}
