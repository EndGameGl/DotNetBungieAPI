namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     The definition of an item and quantity required in a character's inventory in order to perform an action.
/// </summary>
public sealed class DestinyItemActionRequiredItemDefinition
{

    /// <summary>
    ///     The minimum quantity of the item you have to have.
    /// </summary>
    [JsonPropertyName("count")]
    public int Count { get; init; }

    /// <summary>
    ///     The hash identifier of the item you need to have. Use it to look up the DestinyInventoryItemDefinition for more info.
    /// </summary>
    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; init; } // DestinyInventoryItemDefinition

    /// <summary>
    ///     If true, the item/quantity will be deleted from your inventory when the action is performed. Otherwise, you'll retain these required items after the action is complete.
    /// </summary>
    [JsonPropertyName("deleteOnAction")]
    public bool DeleteOnAction { get; init; }
}
