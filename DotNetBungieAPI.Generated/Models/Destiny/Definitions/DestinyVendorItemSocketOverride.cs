using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     The information for how the vendor purchase should override a given socket with custom plug data.
/// </summary>
public sealed class DestinyVendorItemSocketOverride
{

    /// <summary>
    ///     If this is populated, the socket will be overridden with a specific plug.
    /// <para />
    ///     If this isn't populated, it's being overridden by something more complicated that is only known by the Game Server and God, which means we can't tell you in advance what it'll be.
    /// </summary>
    [JsonPropertyName("singleItemHash")]
    public uint? SingleItemHash { get; init; } // DestinyInventoryItemDefinition

    /// <summary>
    ///     If this is greater than -1, the number of randomized plugs on this socket will be set to this quantity instead of whatever it's set to by default.
    /// </summary>
    [JsonPropertyName("randomizedOptionsCount")]
    public int RandomizedOptionsCount { get; init; }

    /// <summary>
    ///     This appears to be used to select which socket ultimately gets the override defined here.
    /// </summary>
    [JsonPropertyName("socketTypeHash")]
    public uint SocketTypeHash { get; init; } // DestinySocketTypeDefinition
}
