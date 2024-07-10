namespace DotNetBungieAPI.Models.Destiny.Definitions.PresentationNodes;

/// <summary>
///     As/if presentation nodes begin to host more entities as children, these lists will be added to. One list property
///     exists per type of entity that can be treated as a child of this presentation node, and each holds the identifier
///     of the entity and any associated information needed to display the UI for that entity (if anything)
/// </summary>
public sealed record DestinyPresentationNodeChildrenBlock
    : IDeepEquatable<DestinyPresentationNodeChildrenBlock>
{
    [JsonPropertyName("presentationNodes")]
    public ReadOnlyCollection<DestinyPresentationNodeChildEntry> PresentationNodes { get; init; } =
        ReadOnlyCollections<DestinyPresentationNodeChildEntry>.Empty;

    [JsonPropertyName("collectibles")]
    public ReadOnlyCollection<DestinyPresentationNodeCollectibleChildEntry> Collectibles { get; init; } =
        ReadOnlyCollections<DestinyPresentationNodeCollectibleChildEntry>.Empty;

    [JsonPropertyName("records")]
    public ReadOnlyCollection<DestinyPresentationNodeRecordChildEntry> Records { get; init; } =
        ReadOnlyCollections<DestinyPresentationNodeRecordChildEntry>.Empty;

    [JsonPropertyName("metrics")]
    public ReadOnlyCollection<DestinyPresentationNodeMetricChildEntry> Metrics { get; init; } =
        ReadOnlyCollections<DestinyPresentationNodeMetricChildEntry>.Empty;

    [JsonPropertyName("craftables")]
    public ReadOnlyCollection<DestinyPresentationNodeCraftableChildEntry> Craftables { get; init; } =
        ReadOnlyCollections<DestinyPresentationNodeCraftableChildEntry>.Empty;

    public bool DeepEquals(DestinyPresentationNodeChildrenBlock other)
    {
        return other != null
            && Collectibles.DeepEqualsReadOnlyCollections(other.Collectibles)
            && Metrics.DeepEqualsReadOnlyCollections(other.Metrics)
            && PresentationNodes.DeepEqualsReadOnlyCollections(other.PresentationNodes)
            && Records.DeepEqualsReadOnlyCollections(other.Records)
            && Craftables.DeepEqualsReadOnlyCollections(other.Craftables);
    }
}
