using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

namespace DotNetBungieAPI.Models.Destiny.Definitions.SocketTypes;

/// <summary>
///     Defines a plug "Category" that is allowed to be plugged into a socket of this type.
///     <para />
///     This should be compared against a given plug item's DestinyInventoryItemDefinition.plug.plugCategoryHash, which
///     indicates the plug item's category.
/// </summary>
public sealed record DestinyPlugWhitelistEntryDefinition : IDeepEquatable<DestinyPlugWhitelistEntryDefinition>
{
    /// <summary>
    ///     The hash identifier of the Plug Category to compare against the plug item's plug.plugCategoryHash.
    ///     <para />
    ///     Note that this does NOT relate to any Definition in itself, it is only used for comparison purposes.
    /// </summary>
    [JsonPropertyName("categoryHash")]
    public uint CategoryHash { get; init; }

    /// <summary>
    ///     The string identifier for the category, which is here mostly for debug purposes.
    /// </summary>
    [JsonPropertyName("categoryIdentifier")]
    public string CategoryIdentifier { get; init; }

    /// <summary>
    ///     The list of all plug items (DestinyInventoryItemDefinition) that the socket may randomly be populated with when
    ///     reinitialized.
    ///     <para />
    ///     Which ones you should actually show are determined by the plug being inserted into the socket, and the socket’s
    ///     type.
    ///     <para />
    ///     When you inspect the plug that could go into a Masterwork Socket, look up the socket type of the socket being
    ///     inspected and find the DestinySocketTypeDefinition.
    ///     <para />
    ///     Then, look at the Plugs that can fit in that socket. Find the Whitelist in the DestinySocketTypeDefinition that
    ///     matches the plug item’s categoryhash.
    ///     <para />
    ///     That whitelist entry will potentially have a new “reinitializationPossiblePlugHashes” property.If it does, that
    ///     means we know what it will roll if you try to insert this plug into this socket.
    /// </summary>
    [JsonPropertyName("reinitializationPossiblePlugHashes")]
    public ReadOnlyCollection<DefinitionHashPointer<DestinyInventoryItemDefinition>> ReinitializationPossiblePlugs { get; init; } =
        ReadOnlyCollections<DefinitionHashPointer<DestinyInventoryItemDefinition>>.Empty;

    public bool DeepEquals(DestinyPlugWhitelistEntryDefinition other)
    {
        return other != null &&
               CategoryHash == other.CategoryHash &&
               CategoryIdentifier == other.CategoryIdentifier &&
               ReinitializationPossiblePlugs.DeepEqualsReadOnlyCollections(other.ReinitializationPossiblePlugs);
    }
}