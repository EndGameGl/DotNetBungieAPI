namespace DotNetBungieAPI.Models.Destiny.Components.Craftables;

public sealed class DestinyCraftablesComponent
{
    /// <summary>
    ///     A map of craftable item hashes to craftable item state components.
    /// </summary>
    [JsonPropertyName("craftables")]
    public Dictionary<DefinitionHashPointer<Destiny.Definitions.DestinyInventoryItemDefinition>, Destiny.Components.Craftables.DestinyCraftableComponent>? Craftables { get; init; }

    /// <summary>
    ///     The hash for the root presentation node definition of craftable item categories.
    /// </summary>
    [JsonPropertyName("craftingRootNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> CraftingRootNodeHash { get; init; }
}
