using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.PresentationNodes
{
    public class PresentationChildNode
    {
        public List<PresentationChildNodeCollectible> Collectibles { get; }
        public List<PresentationChildNodeMetric> Metrics { get; }
        public List<PresentationChildNodePresentationNode> PresentationNodes { get; }
        public List<PresentationChildNodeRecord> Records { get; }

        [JsonConstructor]
        private PresentationChildNode(List<PresentationChildNodeCollectible> collectibles, List<PresentationChildNodeMetric> metrics, 
            List<PresentationChildNodePresentationNode> presentationNodes, List<PresentationChildNodeRecord> records)
        {
            Collectibles = collectibles;
            Metrics = metrics;
            PresentationNodes = presentationNodes;
            Records = records;
        }
    }
}
