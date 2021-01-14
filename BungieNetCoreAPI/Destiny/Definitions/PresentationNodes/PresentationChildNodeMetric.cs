using BungieNetCoreAPI.Destiny.Definitions.Metrics;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.PresentationNodes
{
    public class PresentationChildNodeMetric
    {
        public DefinitionHashPointer<DestinyMetricDefinition> Metric { get; }

        [JsonConstructor]
        private PresentationChildNodeMetric(uint metricHash)
        {
            Metric = new DefinitionHashPointer<DestinyMetricDefinition>(metricHash, "DestinyCollectibleDefinition");
        }
    }
}
