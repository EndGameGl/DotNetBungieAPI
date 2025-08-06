namespace DotNetBungieAPI.Models.Tokens;

public sealed class CollectibleDefinitions
{
    [JsonPropertyName("CollectibleDefinition")]
    public Destiny.Definitions.Collectibles.DestinyCollectibleDefinition? CollectibleDefinition { get; init; }

    [JsonPropertyName("DestinyInventoryItemDefinition")]
    public Destiny.Definitions.DestinyInventoryItemDefinition? DestinyInventoryItemDefinition { get; init; }
}
