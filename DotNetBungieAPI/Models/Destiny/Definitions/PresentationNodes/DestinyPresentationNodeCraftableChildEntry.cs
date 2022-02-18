using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

namespace DotNetBungieAPI.Models.Destiny.Definitions.PresentationNodes;

public sealed record DestinyPresentationNodeCraftableChildEntry : IDeepEquatable<DestinyPresentationNodeCraftableChildEntry>
{
    [JsonPropertyName("craftableItemHash")]
    public DefinitionHashPointer<DestinyInventoryItemDefinition> CraftableItem { get; init; } =
        DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

    /// <summary>
    ///     Use this value to sort the presentation node children in ascending order.
    /// </summary>
    [JsonPropertyName("nodeDisplayPriority")]
    public uint NodeDisplayPriority { get; init; }

    public bool DeepEquals(DestinyPresentationNodeCraftableChildEntry other)
    {
        return other is not null &&
               CraftableItem.DeepEquals(other.CraftableItem) &&
               NodeDisplayPriority == other.NodeDisplayPriority;
    }
}