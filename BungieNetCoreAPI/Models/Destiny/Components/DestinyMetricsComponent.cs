using NetBungieAPI.Models.Destiny.Definitions.PresentationNodes;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyMetricsComponent
    {
        [JsonPropertyName("metrics")]
        public ReadOnlyDictionary<uint, DestinyMetricComponent> Metrics { get; init; } = Defaults.EmptyReadOnlyDictionary<uint, DestinyMetricComponent>();
        [JsonPropertyName("metricsRootNodeHash")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> MetricRootNode { get; init; } = DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;
    }
}
