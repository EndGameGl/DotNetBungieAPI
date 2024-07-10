using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

namespace DotNetBungieAPI.Models.Destiny.Character;

/// <summary>
///     Bare minimum summary information for an item, for the sake of 3D rendering the item.
/// </summary>
public sealed record DestinyItemPeerView
{
    /// <summary>
    ///     The hash identifier of the item in question. Use it to look up the DestinyInventoryItemDefinition of the item for
    ///     static rendering data.
    /// </summary>
    [JsonPropertyName("itemHash")]
    public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; } =
        DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

    /// <summary>
    ///     The list of dyes that have been applied to this item.
    /// </summary>
    [JsonPropertyName("dyes")]
    public ReadOnlyCollection<DyeReference> Dyes { get; init; } =
        ReadOnlyCollections<DyeReference>.Empty;
}
