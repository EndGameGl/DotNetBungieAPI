namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     If defined, the item has at least one socket.
/// </summary>
public sealed class DestinyItemSocketBlockDefinition
{

    /// <summary>
    ///     This was supposed to be a string that would give per-item details about sockets. In practice, it turns out that all this ever has is the localized word "details". ... that's lame, but perhaps it will become something cool in the future.
    /// </summary>
    [JsonPropertyName("detail")]
    public string Detail { get; init; }

    /// <summary>
    ///     Each non-intrinsic (or mutable) socket on an item is defined here. Check inside for more info.
    /// </summary>
    [JsonPropertyName("socketEntries")]
    public List<Destiny.Definitions.DestinyItemSocketEntryDefinition> SocketEntries { get; init; }

    /// <summary>
    ///     Each intrinsic (or immutable/permanent) socket on an item is defined here, along with the plug that is permanently affixed to the socket.
    /// </summary>
    [JsonPropertyName("intrinsicSockets")]
    public List<Destiny.Definitions.DestinyItemIntrinsicSocketEntryDefinition> IntrinsicSockets { get; init; }

    /// <summary>
    ///     A convenience property, that refers to the sockets in the "sockets" property, pre-grouped by category and ordered in the manner that they should be grouped in the UI. You could form this yourself with the existing data, but why would you want to? Enjoy life man.
    /// </summary>
    [JsonPropertyName("socketCategories")]
    public List<Destiny.Definitions.DestinyItemSocketCategoryDefinition> SocketCategories { get; init; }
}
