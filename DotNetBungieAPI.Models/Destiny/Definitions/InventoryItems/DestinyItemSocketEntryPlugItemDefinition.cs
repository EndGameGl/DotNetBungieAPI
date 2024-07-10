namespace DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

/// <summary>
///     The definition of a known, reusable plug that can be applied to a socket.
/// </summary>
public class DestinyItemSocketEntryPlugItemDefinition
    : IDeepEquatable<DestinyItemSocketEntryPlugItemDefinition>
{
    /// <summary>
    ///     DestinyInventoryItemDefinition representing the plug that can be inserted.
    /// </summary>
    [JsonPropertyName("plugItemHash")]
    public DefinitionHashPointer<DestinyInventoryItemDefinition> PlugItem { get; init; } =
        DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

    public bool DeepEquals(DestinyItemSocketEntryPlugItemDefinition other)
    {
        return other != null && PlugItem.DeepEquals(other.PlugItem);
    }
}
