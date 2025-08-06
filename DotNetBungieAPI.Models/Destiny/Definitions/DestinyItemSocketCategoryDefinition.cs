namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     Sockets are grouped into categories in the UI. These define which category and which sockets are under that category.
/// </summary>
public sealed class DestinyItemSocketCategoryDefinition
{
    /// <summary>
    ///     The hash for the Socket Category: a quick way to go get the header display information for the category. Use it to look up DestinySocketCategoryDefinition info.
    /// </summary>
    [JsonPropertyName("socketCategoryHash")]
    public DefinitionHashPointer<Destiny.Definitions.Sockets.DestinySocketCategoryDefinition> SocketCategoryHash { get; init; }

    /// <summary>
    ///     Use these indexes to look up the sockets in the "sockets.socketEntries" property on the item definition. These are the indexes under the category, in game-rendered order.
    /// </summary>
    [JsonPropertyName("socketIndexes")]
    public int[]? SocketIndexes { get; init; }
}
