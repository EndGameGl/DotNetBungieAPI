using NetBungieApi.Destiny.Definitions.PresentationNodes;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Definitions.Collectibles
{
    public class CollectiblePresentationInfo : IDeepEquatable<CollectiblePresentationInfo>
    {
        public PresentationNodeType PresentationNodeType { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyPresentationNodeDefinition>> ParentPresentationNodes { get; }
        public PresentationDisplayStyle DisplayStyle { get; }
        internal CollectiblePresentationInfo(PresentationNodeType presentationNodeType, uint[] parentPresentationNodeHashes, PresentationDisplayStyle displayStyle)
        {
            PresentationNodeType = presentationNodeType;
            ParentPresentationNodes = parentPresentationNodeHashes.DefinitionsAsReadOnlyOrEmpty<DestinyPresentationNodeDefinition>(DefinitionsEnum.DestinyPresentationNodeDefinition);
            DisplayStyle = displayStyle;
        }

        public bool DeepEquals(CollectiblePresentationInfo other)
        {
            return other != null &&
                PresentationNodeType == other.PresentationNodeType &&
                ParentPresentationNodes.DeepEqualsReadOnlyCollections(other.ParentPresentationNodes) &&
                DisplayStyle == other.DisplayStyle;
        }
    }
}
