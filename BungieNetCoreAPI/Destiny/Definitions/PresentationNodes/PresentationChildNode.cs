using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.PresentationNodes
{
    /// <summary>
    /// As/if presentation nodes begin to host more entities as children, these lists will be added to. One list property exists per type of entity that can be treated as a child of this presentation node, and each holds the identifier of the entity and any associated information needed to display the UI for that entity (if anything)
    /// </summary>
    public class PresentationChildNode : IDeepEquatable<PresentationChildNode>
    {
        public ReadOnlyCollection<PresentationChildNodeCollectible> Collectibles { get; }
        public ReadOnlyCollection<PresentationChildNodeMetric> Metrics { get; }
        public ReadOnlyCollection<PresentationChildNodePresentationNode> PresentationNodes { get; }
        public ReadOnlyCollection<PresentationChildNodeRecord> Records { get; }

        [JsonConstructor]
        internal PresentationChildNode(PresentationChildNodeCollectible[] collectibles, PresentationChildNodeMetric[] metrics, 
            PresentationChildNodePresentationNode[] presentationNodes, PresentationChildNodeRecord[] records)
        {
            Collectibles = collectibles.AsReadOnlyOrEmpty();
            Metrics = metrics.AsReadOnlyOrEmpty();
            PresentationNodes = presentationNodes.AsReadOnlyOrEmpty();
            Records = records.AsReadOnlyOrEmpty();
        }

        public bool DeepEquals(PresentationChildNode other)
        {
            return other != null &&
                   Collectibles.DeepEqualsReadOnlyCollections(other.Collectibles) &&
                   Metrics.DeepEqualsReadOnlyCollections(other.Metrics) &&
                   PresentationNodes.DeepEqualsReadOnlyCollections(other.PresentationNodes) &&
                   Records.DeepEqualsReadOnlyCollections(other.Records);
        }
    }
}
