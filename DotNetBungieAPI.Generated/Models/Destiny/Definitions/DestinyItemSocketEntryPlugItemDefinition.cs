namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     The definition of a known, reusable plug that can be applied to a socket.
/// </summary>
public class DestinyItemSocketEntryPlugItemDefinition : IDeepEquatable<DestinyItemSocketEntryPlugItemDefinition>
{
    /// <summary>
    ///     The hash identifier of a DestinyInventoryItemDefinition representing the plug that can be inserted.
    /// </summary>
    [JsonPropertyName("plugItemHash")]
    public uint PlugItemHash { get; set; }

    public bool DeepEquals(DestinyItemSocketEntryPlugItemDefinition? other)
    {
        return other is not null &&
               PlugItemHash == other.PlugItemHash;
    }
}