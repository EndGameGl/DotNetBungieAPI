using DotNetBungieAPI.Models.Destiny.Definitions.SocketTypes;

namespace DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

public sealed record DestinyItemCraftingBlockBonusPlugDefinition
    : IDeepEquatable<DestinyItemCraftingBlockBonusPlugDefinition>
{
    [JsonPropertyName("socketTypeHash")]
    public DefinitionHashPointer<DestinySocketTypeDefinition> SocketType { get; init; } =
        DefinitionHashPointer<DestinySocketTypeDefinition>.Empty;

    [JsonPropertyName("plugItemHash")]
    public DefinitionHashPointer<DestinyInventoryItemDefinition> PlugItem { get; init; } =
        DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

    public bool DeepEquals(DestinyItemCraftingBlockBonusPlugDefinition other)
    {
        return other is not null
            && SocketType.DeepEquals(other.SocketType)
            && PlugItem.DeepEquals(other.PlugItem);
    }
}
