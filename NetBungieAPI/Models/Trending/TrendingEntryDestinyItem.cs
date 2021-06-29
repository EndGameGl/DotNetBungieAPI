using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;

namespace NetBungieAPI.Models.Trending
{
    public class TrendingEntryDestinyItem
    {
        [JsonPropertyName("itemHash")] public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; }
    }
}