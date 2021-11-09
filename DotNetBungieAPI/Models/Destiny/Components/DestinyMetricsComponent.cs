using DotNetBungieAPI.Models.Destiny.Definitions.PresentationNodes;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyMetricsComponent
    {
        [JsonPropertyName("metrics")]
        public ReadOnlyDictionary<uint, DestinyMetricComponent> Metrics { get; init; } =
            ReadOnlyDictionaries<uint, DestinyMetricComponent>.Empty;

        [JsonPropertyName("metricsRootNodeHash")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> MetricRootNode { get; init; } =
            DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;
    }
}