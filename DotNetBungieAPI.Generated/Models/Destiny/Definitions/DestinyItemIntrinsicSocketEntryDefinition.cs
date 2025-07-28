namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Represents a socket that has a plug associated with it intrinsically. This is useful for situations where the weapon needs to have a visual plug/Mod on it, but that plug/Mod should never change.
/// </summary>
public class DestinyItemIntrinsicSocketEntryDefinition
{
    /// <summary>
    ///     Indicates the plug that is intrinsically inserted into this socket.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyInventoryItemDefinition>("Destiny.Definitions.DestinyInventoryItemDefinition")]
    [JsonPropertyName("plugItemHash")]
    public uint PlugItemHash { get; set; }

    /// <summary>
    ///     Indicates the type of this intrinsic socket.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.Sockets.DestinySocketTypeDefinition>("Destiny.Definitions.Sockets.DestinySocketTypeDefinition")]
    [JsonPropertyName("socketTypeHash")]
    public uint SocketTypeHash { get; set; }

    /// <summary>
    ///     If true, then this socket is visible in the item's "default" state. If you have an instance, you should always check the runtime state, as that can override this visibility setting: but if you're looking at the item on a conceptual level, this property can be useful for hiding data such as legacy sockets - which remain defined on items for infrastructure purposes, but can be confusing for users to see.
    /// </summary>
    [JsonPropertyName("defaultVisible")]
    public bool DefaultVisible { get; set; }
}
