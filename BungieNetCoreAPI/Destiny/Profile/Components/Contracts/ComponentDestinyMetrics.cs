using BungieNetCoreAPI.Destiny.Definitions.PresentationNodes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class ComponentDestinyMetrics
    {
        public ReadOnlyDictionary<uint, DestinyMetricComponent> Metrics { get; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> MetricRootNode { get; }

        [JsonConstructor]
        internal ComponentDestinyMetrics(Dictionary<uint, DestinyMetricComponent> metrics, uint metricsRootNodeHash)
        {
            Metrics = metrics.AsReadOnlyDictionaryOrEmpty();
            MetricRootNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(metricsRootNodeHash, DefinitionsEnum.DestinyPresentationNodeDefinition);
        }
    }
}
