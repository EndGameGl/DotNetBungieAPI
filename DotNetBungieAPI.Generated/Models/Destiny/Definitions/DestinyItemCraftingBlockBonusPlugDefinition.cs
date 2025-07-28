namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyItemCraftingBlockBonusPlugDefinition
{
    [Destiny2Definition<Destiny.Definitions.Sockets.DestinySocketTypeDefinition>("Destiny.Definitions.Sockets.DestinySocketTypeDefinition")]
    [JsonPropertyName("socketTypeHash")]
    public uint SocketTypeHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.DestinyInventoryItemDefinition>("Destiny.Definitions.DestinyInventoryItemDefinition")]
    [JsonPropertyName("plugItemHash")]
    public uint PlugItemHash { get; set; }
}
