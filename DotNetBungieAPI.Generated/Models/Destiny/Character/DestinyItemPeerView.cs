namespace DotNetBungieAPI.Generated.Models.Destiny.Character;

/// <summary>
///     Bare minimum summary information for an item, for the sake of 3D rendering the item.
/// </summary>
public sealed class DestinyItemPeerView
{

    /// <summary>
    ///     The hash identifier of the item in question. Use it to look up the DestinyInventoryItemDefinition of the item for static rendering data.
    /// </summary>
    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; init; } // DestinyInventoryItemDefinition

    /// <summary>
    ///     The list of dyes that have been applied to this item.
    /// </summary>
    [JsonPropertyName("dyes")]
    public List<Destiny.DyeReference> Dyes { get; init; }
}
