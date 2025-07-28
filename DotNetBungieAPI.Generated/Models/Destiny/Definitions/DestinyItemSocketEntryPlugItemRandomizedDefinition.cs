namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyItemSocketEntryPlugItemRandomizedDefinition
{
    [JsonPropertyName("craftingRequirements")]
    public Destiny.Definitions.DestinyPlugItemCraftingRequirements? CraftingRequirements { get; set; }

    /// <summary>
    ///     Indicates if the plug can be rolled on the current version of the item. For example, older versions of weapons may have plug rolls that are no longer possible on the current versions.
    /// </summary>
    [JsonPropertyName("currentlyCanRoll")]
    public bool CurrentlyCanRoll { get; set; }

    /// <summary>
    ///     The hash identifier of a DestinyInventoryItemDefinition representing the plug that can be inserted.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyInventoryItemDefinition>("Destiny.Definitions.DestinyInventoryItemDefinition")]
    [JsonPropertyName("plugItemHash")]
    public uint PlugItemHash { get; set; }
}
