namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     The definition of a known, reusable plug that can be applied to a socket.
/// </summary>
public class DestinyItemSocketEntryPlugItemDefinition
{
    /// <summary>
    ///     The hash identifier of a DestinyInventoryItemDefinition representing the plug that can be inserted.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyInventoryItemDefinition>("Destiny.Definitions.DestinyInventoryItemDefinition")]
    [JsonPropertyName("plugItemHash")]
    public uint PlugItemHash { get; set; }
}
