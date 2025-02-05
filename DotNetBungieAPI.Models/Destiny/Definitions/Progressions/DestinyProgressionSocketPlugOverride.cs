using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using DotNetBungieAPI.Models.Destiny.Definitions.SocketTypes;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Progressions;

/// <summary>
///     The information for how progression item definitions should override a given socket with custom plug data.
/// </summary>
public sealed record DestinyProgressionSocketPlugOverride
{
    [JsonPropertyName("socketTypeHash")]
    public DefinitionHashPointer<DestinySocketTypeDefinition> SocketType { get; init; } =
        DefinitionHashPointer<DestinySocketTypeDefinition>.Empty;

    [JsonPropertyName("overrideSingleItemHash")]
    public DefinitionHashPointer<DestinyInventoryItemDefinition> OverrideSingleItem { get; init; } =
        DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
}
