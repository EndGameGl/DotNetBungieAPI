using DotNetBungieAPI.Models.Destiny.Definitions.SocketCategories;

namespace DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

/// <summary>
///     Sockets are grouped into categories in the UI. These define which category and which sockets are under that
///     category.
/// </summary>
public sealed record DestinyItemSocketCategoryDefinition
    : IDeepEquatable<DestinyItemSocketCategoryDefinition>
{
    /// <summary>
    ///     DestinySocketCategoryDefinition for the Socket Category: a quick way to go get the header display information for
    ///     the category.
    /// </summary>
    [JsonPropertyName("socketCategoryHash")]
    public DefinitionHashPointer<DestinySocketCategoryDefinition> SocketCategory { get; init; } =
        DefinitionHashPointer<DestinySocketCategoryDefinition>.Empty;

    /// <summary>
    ///     Use these indexes to look up the sockets in the "sockets.socketEntries" property on the item definition. These are
    ///     the indexes under the category, in game-rendered order.
    /// </summary>
    [JsonPropertyName("socketIndexes")]
    public ReadOnlyCollection<int> SocketIndexes { get; init; } = ReadOnlyCollection<int>.Empty;

    public bool DeepEquals(DestinyItemSocketCategoryDefinition other)
    {
        return other != null
            && SocketCategory.DeepEquals(other.SocketCategory)
            && SocketIndexes.DeepEqualsReadOnlySimpleCollection(other.SocketIndexes);
    }
}
