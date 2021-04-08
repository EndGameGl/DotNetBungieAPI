using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.PresentationNodes
{
    /// <summary>
    /// As/if presentation nodes begin to host more entities as children, these lists will be added to. One list property exists per type of entity that can be treated as a child of this presentation node, and each holds the identifier of the entity and any associated information needed to display the UI for that entity (if anything)
    /// </summary>
    public sealed record DestinyPresentationNodeChildrenBlock : IDeepEquatable<DestinyPresentationNodeChildrenBlock>
    {
        [JsonPropertyName("presentationNodes")]
        public ReadOnlyCollection<DestinyPresentationNodeChildEntry> PresentationNodes { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyPresentationNodeChildEntry>();
        [JsonPropertyName("collectibles")]
        public ReadOnlyCollection<DestinyPresentationNodeCollectibleChildEntry> Collectibles { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyPresentationNodeCollectibleChildEntry>();
        [JsonPropertyName("records")]
        public ReadOnlyCollection<DestinyPresentationNodeRecordChildEntry> Records { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyPresentationNodeRecordChildEntry>();
        [JsonPropertyName("metrics")]
        public ReadOnlyCollection<DestinyPresentationNodeMetricChildEntry> Metrics { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyPresentationNodeMetricChildEntry>();

        public bool DeepEquals(DestinyPresentationNodeChildrenBlock other)
        {
            return other != null &&
                   Collectibles.DeepEqualsReadOnlyCollections(other.Collectibles) &&
                   Metrics.DeepEqualsReadOnlyCollections(other.Metrics) &&
                   PresentationNodes.DeepEqualsReadOnlyCollections(other.PresentationNodes) &&
                   Records.DeepEqualsReadOnlyCollections(other.Records);
        }
    }
}
