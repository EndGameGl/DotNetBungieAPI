namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     The information for how progression item definitions should override a given socket with custom plug data.
/// </summary>
public class DestinyProgressionSocketPlugOverride
{
    [JsonPropertyName("socketTypeHash")]
    public uint SocketTypeHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.DestinyInventoryItemDefinition>("Destiny.Definitions.DestinyInventoryItemDefinition")]
    [JsonPropertyName("overrideSingleItemHash")]
    public uint? OverrideSingleItemHash { get; set; }
}
