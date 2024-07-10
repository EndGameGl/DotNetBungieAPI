using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

namespace DotNetBungieAPI.Models.Trending;

public class TrendingEntryDestinyItem
{
    [JsonPropertyName("itemHash")]
    public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; }
}
