using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Definitions.Metrics;

namespace NetBungieAPI.Models.Destiny.Definitions.PresentationNodes
{
    public sealed record
        DestinyPresentationNodeMetricChildEntry : IDeepEquatable<DestinyPresentationNodeMetricChildEntry>
    {
        [JsonPropertyName("metricHash")]
        public DefinitionHashPointer<DestinyMetricDefinition> Metric { get; init; } =
            DefinitionHashPointer<DestinyMetricDefinition>.Empty;

        public bool DeepEquals(DestinyPresentationNodeMetricChildEntry other)
        {
            return other != null && Metric.DeepEquals(other.Metric);
        }
    }
}