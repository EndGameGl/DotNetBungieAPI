using DotNetBungieAPI.Models.Destiny.Definitions.PresentationNodes;

namespace DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

/// <summary>
///     The metrics available for display and selection on an item.
/// </summary>
public sealed record DestinyItemMetricBlockDefinition
    : IDeepEquatable<DestinyItemMetricBlockDefinition>
{
    /// <summary>
    ///     Any DestinyPresentationNodeDefinition entry that can be used to list available metrics. Any metric listed directly
    ///     below these nodes, or in any of these nodes' children will be made available for selection.
    /// </summary>
    [JsonPropertyName("availableMetricCategoryNodeHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyPresentationNodeDefinition>
    > AvailableMetricCategoryNodes { get; init; } =
        ReadOnlyCollections<DefinitionHashPointer<DestinyPresentationNodeDefinition>>.Empty;

    public bool DeepEquals(DestinyItemMetricBlockDefinition other)
    {
        return other != null
            && AvailableMetricCategoryNodes.DeepEqualsReadOnlyCollections(
                other.AvailableMetricCategoryNodes
            );
    }
}
