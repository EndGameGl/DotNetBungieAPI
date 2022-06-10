namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Craftables;

public class DestinyCraftablesComponent
{
    /// <summary>
    ///     A map of craftable item hashes to craftable item state components.
    /// </summary>
    [JsonPropertyName("craftables")]
    public Dictionary<uint, Destiny.Components.Craftables.DestinyCraftableComponent> Craftables { get; set; }

    /// <summary>
    ///     The hash for the root presentation node definition of craftable item categories.
    /// </summary>
    [JsonPropertyName("craftingRootNodeHash")]
    public uint CraftingRootNodeHash { get; set; }
}
