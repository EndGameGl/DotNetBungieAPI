namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Inventory;

public class DestinyMaterialRequirementState
{
    /// <summary>
    ///     The hash identifier of the material required. Use it to look up the material's DestinyInventoryItemDefinition.
    /// </summary>
    [JsonPropertyName("itemHash")]
    public uint? ItemHash { get; set; }

    /// <summary>
    ///     The amount of the material required.
    /// </summary>
    [JsonPropertyName("count")]
    public int? Count { get; set; }

    /// <summary>
    ///     A value for the amount of a (possibly virtual) material on some scope. For example: Dawning cookie baking material requirements.
    /// </summary>
    [JsonPropertyName("stackSize")]
    public int? StackSize { get; set; }
}
