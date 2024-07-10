using DotNetBungieAPI.Models.Destiny.Definitions.Collectibles;
using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

namespace DotNetBungieAPI.Models.Tokens;

public sealed record CollectibleDefinitions
{
    [JsonPropertyName("CollectibleDefinition")]
    public DestinyCollectibleDefinition CollectibleDefinition { get; init; }

    [JsonPropertyName("DestinyInventoryItemDefinition")]
    public DestinyInventoryItemDefinition DestinyInventoryItemDefinition { get; init; }
}
