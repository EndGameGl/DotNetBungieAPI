using DotNetBungieAPI.Models.Destiny.Definitions.PlugSets;
using DotNetBungieAPI.Models.Destiny.Definitions.SocketTypes;

namespace DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

/// <summary>
///     The definition information for a specific socket on an item. This will determine how the socket behaves in-game.
/// </summary>
public sealed record DestinyItemSocketEntryDefinition
    : IDeepEquatable<DestinyItemSocketEntryDefinition>
{
    /// <summary>
    ///     If true, then this socket is visible in the item's "default" state. If you have an instance, you should always
    ///     check the runtime state, as that can override this visibility setting: but if you're looking at the item on a
    ///     conceptual level, this property can be useful for hiding data such as legacy sockets - which remain defined on
    ///     items for infrastructure purposes, but can be confusing for users to see.
    /// </summary>
    [JsonPropertyName("defaultVisible")]
    public bool DefaultVisible { get; init; }

    /// <summary>
    ///     If this is true, the perks provided by this socket shouldn't be shown in the item's tooltip. This might be useful
    ///     if it's providing a hidden bonus, or if the bonus is less important than other benefits on the item.
    /// </summary>
    [JsonPropertyName("hidePerksInItemTooltip")]
    public bool HidePerksInItemTooltip { get; init; }

    [JsonPropertyName("overridesUiAppearance")]
    public bool OverridesUiAppearance { get; init; }

    /// <summary>
    ///     Indicates where you should go to get plugs for this socket. This will affect how you populate your UI, as well as
    ///     what plugs are valid for this socket. It's an alternative to having to check for the existence of certain
    ///     properties (reusablePlugItems for example) to infer where plugs should come from.
    /// </summary>
    [JsonPropertyName("plugSources")]
    public SocketPlugSources PlugSources { get; init; }

    /// <summary>
    ///     If this is true, then the socket will not be initialized with a plug if the item is purchased from a Vendor.
    ///     <para />
    ///     Remember that Vendors are much more than conceptual vendors: they include "Collection Kiosks" and other entities.
    ///     See DestinyVendorDefinition for more information.
    /// </summary>
    [JsonPropertyName("preventInitializationOnVendorPurchase")]
    public bool PreventInitializationOnVendorPurchase { get; init; }

    [JsonPropertyName("preventInitializationWhenVersioning")]
    public bool PreventInitializationWhenVersioning { get; init; }

    /// <summary>
    ///     This is a list of pre-determined plugs that can *always* be plugged into this socket, without the character having
    ///     the plug in their inventory.
    ///     <para />
    ///     If this list is populated, you will not be allowed to plug an arbitrary item in the socket: you will only be able
    ///     to choose from one of these reusable plugs.
    /// </summary>
    [JsonPropertyName("reusablePlugItems")]
    public ReadOnlyCollection<DestinyItemSocketEntryPlugItemDefinition> ReusablePlugItems { get; init; } =
        ReadOnlyCollection<DestinyItemSocketEntryPlugItemDefinition>.Empty;

    /// <summary>
    ///     If this socket's plugs come from a reusable DestinyPlugSetDefinition, this is the identifier for that set. We added
    ///     this concept to reduce some major duplication that's going to come from sockets as replacements for what was once
    ///     implemented as large sets of items and kiosks (like Emotes).
    ///     <para />
    ///     As of Shadowkeep, these will come up much more frequently and be driven by game content rather than custom
    ///     curation.
    /// </summary>
    [JsonPropertyName("reusablePlugSetHash")]
    public DefinitionHashPointer<DestinyPlugSetDefinition> ReusablePlugSet { get; init; } =
        DefinitionHashPointer<DestinyPlugSetDefinition>.Empty;

    /// <summary>
    ///     If a valid hash, this is the hash identifier for the DestinyInventoryItemDefinition representing the Plug that will
    ///     be initially inserted into the item on item creation. Otherwise, this Socket will either start without a plug
    ///     inserted, or will have one randomly inserted.
    /// </summary>
    [JsonPropertyName("singleInitialItemHash")]
    public DefinitionHashPointer<DestinyInventoryItemDefinition> SingleInitialItem { get; init; } =
        DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

    /// <summary>
    ///     All sockets have a type, and this is the hash identifier for this particular type. Use it to look up the
    ///     DestinySocketTypeDefinition: read there for more information on how socket types affect the behavior of the socket.
    /// </summary>
    [JsonPropertyName("socketTypeHash")]
    public DefinitionHashPointer<DestinySocketTypeDefinition> SocketType { get; init; } =
        DefinitionHashPointer<DestinySocketTypeDefinition>.Empty;

    /// <summary>
    ///     This field replaces "randomizedPlugItems" as of Shadowkeep launch. If a socket has randomized plugs, this is a
    ///     pointer to the set of plugs that could be used, as defined in DestinyPlugSetDefinition.
    ///     <para />
    ///     If Empty, the item has no randomized plugs.
    /// </summary>
    [JsonPropertyName("randomizedPlugSetHash")]
    public DefinitionHashPointer<DestinyPlugSetDefinition> RandomizedPlugSet { get; init; } =
        DefinitionHashPointer<DestinyPlugSetDefinition>.Empty;

    public bool DeepEquals(DestinyItemSocketEntryDefinition other)
    {
        return other != null
            && DefaultVisible == other.DefaultVisible
            && HidePerksInItemTooltip == other.HidePerksInItemTooltip
            && OverridesUiAppearance == other.OverridesUiAppearance
            && PlugSources == other.PlugSources
            && PreventInitializationOnVendorPurchase == other.PreventInitializationOnVendorPurchase
            && PreventInitializationWhenVersioning == other.PreventInitializationWhenVersioning
            && ReusablePlugItems.DeepEqualsReadOnlyCollection(other.ReusablePlugItems)
            && ReusablePlugSet.DeepEquals(other.ReusablePlugSet)
            && SingleInitialItem.DeepEquals(other.SingleInitialItem)
            && SocketType.DeepEquals(other.SocketType)
            && RandomizedPlugSet.DeepEquals(other.RandomizedPlugSet);
    }

    public override string ToString()
    {
        return $"{PlugSources}";
    }
}
