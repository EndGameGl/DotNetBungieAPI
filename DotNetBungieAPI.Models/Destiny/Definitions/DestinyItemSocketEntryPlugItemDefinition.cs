namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     The definition of a known, reusable plug that can be applied to a socket.
/// </summary>
public sealed class DestinyItemSocketEntryPlugItemDefinition
{
    /// <summary>
    ///     The hash identifier of a DestinyInventoryItemDefinition representing the plug that can be inserted.
    /// </summary>
    [JsonPropertyName("plugItemHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyInventoryItemDefinition> PlugItemHash { get; init; }
}
