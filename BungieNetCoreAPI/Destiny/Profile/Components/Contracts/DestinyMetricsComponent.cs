using NetBungieApi.Destiny.Definitions.PresentationNodes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Profile.Components.Contracts
{
    public class DestinyMetricsComponent
    {
        public ReadOnlyDictionary<uint, DestinyMetricComponent> Metrics { get; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> MetricRootNode { get; }

        [JsonConstructor]
        internal DestinyMetricsComponent(Dictionary<uint, DestinyMetricComponent> metrics, uint metricsRootNodeHash)
        {
            Metrics = metrics.AsReadOnlyDictionaryOrEmpty();
            MetricRootNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(metricsRootNodeHash, DefinitionsEnum.DestinyPresentationNodeDefinition);
        }
    }
}
