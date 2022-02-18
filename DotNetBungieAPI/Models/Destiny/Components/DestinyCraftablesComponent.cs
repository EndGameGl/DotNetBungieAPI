using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using DotNetBungieAPI.Models.Destiny.Definitions.PresentationNodes;

namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DestinyCraftablesComponent
{
    /// <summary>
    ///     A map of craftable item hashes to craftable item state components.
    /// </summary>
    [JsonPropertyName("craftables")]
    public ReadOnlyDictionary<DefinitionHashPointer<DestinyInventoryItemDefinition>, DestinyCraftableComponent>
        Craftables { get; init; } =
        ReadOnlyDictionaries<DefinitionHashPointer<DestinyInventoryItemDefinition>, DestinyCraftableComponent>.Empty;

    /// <summary>
    ///     The hash for the root presentation node definition of craftable item categories.
    /// </summary>
    [JsonPropertyName("craftingRootNodeHash")]
    public DefinitionHashPointer<DestinyPresentationNodeDefinition> CraftingRootNode { get; init; }
        = DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;
}