using DotNetBungieAPI.Models.Destiny.Definitions.SocketTypes;

namespace DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

/// <summary>
///     Represents a socket that has a plug associated with it intrinsically. This is useful for situations where the
///     weapon needs to have a visual plug/Mod on it, but that plug/Mod should never change.
/// </summary>
public sealed record
    DestinyItemIntrinsicSocketEntryDefinition : IDeepEquatable<DestinyItemIntrinsicSocketEntryDefinition>
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
    ///     Indicates the plug that is intrinsically inserted into this socket.
    /// </summary>
    [JsonPropertyName("plugItemHash")]
    public DefinitionHashPointer<DestinyInventoryItemDefinition> PlugItem { get; init; } =
        DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

    /// <summary>
    ///     Indicates the type of this intrinsic socket.
    /// </summary>
    [JsonPropertyName("socketTypeHash")]
    public DefinitionHashPointer<DestinySocketTypeDefinition> SocketType { get; init; } =
        DefinitionHashPointer<DestinySocketTypeDefinition>.Empty;

    public bool DeepEquals(DestinyItemIntrinsicSocketEntryDefinition other)
    {
        return other != null &&
               DefaultVisible == other.DefaultVisible &&
               PlugItem.DeepEquals(other.PlugItem) &&
               SocketType.DeepEquals(other.SocketType);
    }
}