namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Craftables;

public class DestinyCraftablesComponent
{
    /// <summary>
    ///     A map of craftable item hashes to craftable item state components.
    /// </summary>
    [Destiny2DefinitionDictionaryKey<Destiny.Definitions.DestinyInventoryItemDefinition>("Destiny.Definitions.DestinyInventoryItemDefinition")]
    [JsonPropertyName("craftables")]
    public Dictionary<uint, Destiny.Components.Craftables.DestinyCraftableComponent> Craftables { get; set; }

    /// <summary>
    ///     The hash for the root presentation node definition of craftable item categories.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>("Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition")]
    [JsonPropertyName("craftingRootNodeHash")]
    public uint? CraftingRootNodeHash { get; set; }
}
