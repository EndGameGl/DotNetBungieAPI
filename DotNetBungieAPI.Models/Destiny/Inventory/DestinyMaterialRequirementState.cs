using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

namespace DotNetBungieAPI.Models.Destiny.Inventory;

public sealed record DestinyMaterialRequirementState
{
    /// <summary>
    ///     The hash identifier of the material required. 
    /// </summary>
    [JsonPropertyName("itemHash")]
    public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; set; }

    /// <summary>
    ///     The amount of the material required.
    /// </summary>
    [JsonPropertyName("count")]
    public int Count { get; set; }

    /// <summary>
    ///     A value for the amount of a (possibly virtual) material on some scope. For example: Dawning cookie baking material requirements.
    /// </summary>
    [JsonPropertyName("stackSize")]
    public int StackSize { get; set; }
}
