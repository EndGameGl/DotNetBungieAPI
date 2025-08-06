namespace DotNetBungieAPI.Models.Destiny.Definitions;

public sealed class DestinyItemCraftingBlockBonusPlugDefinition
{
    [JsonPropertyName("socketTypeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Sockets.DestinySocketTypeDefinition> SocketTypeHash { get; init; }

    [JsonPropertyName("plugItemHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyInventoryItemDefinition> PlugItemHash { get; init; }
}
