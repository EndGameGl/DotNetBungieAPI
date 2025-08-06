namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     The information for how progression item definitions should override a given socket with custom plug data.
/// </summary>
public sealed class DestinyProgressionSocketPlugOverride
{
    [JsonPropertyName("socketTypeHash")]
    public uint SocketTypeHash { get; init; }

    [JsonPropertyName("overrideSingleItemHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyInventoryItemDefinition>? OverrideSingleItemHash { get; init; }
}
