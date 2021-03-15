using NetBungieAPI.Destiny.Definitions.Metrics;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.PresentationNodes
{
    public class PresentationChildNodeMetric : IDeepEquatable<PresentationChildNodeMetric>
    {
        public DefinitionHashPointer<DestinyMetricDefinition> Metric { get; }

        [JsonConstructor]
        internal PresentationChildNodeMetric(uint metricHash)
        {
            Metric = new DefinitionHashPointer<DestinyMetricDefinition>(metricHash, DefinitionsEnum.DestinyCollectibleDefinition);
        }

        public bool DeepEquals(PresentationChildNodeMetric other)
        {
            return other != null && Metric.DeepEquals(other.Metric);
        }
    }
}
