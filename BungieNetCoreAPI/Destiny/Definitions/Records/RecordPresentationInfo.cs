using NetBungieApi.Destiny.Definitions.PresentationNodes;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Definitions.Records
{
    public class RecordPresentationInfo : IDeepEquatable<RecordPresentationInfo>
    {
        public PresentationNodeType PresentationNodeType { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyPresentationNodeDefinition>> ParentPresentationNodes { get; }
        public PresentationDisplayStyle DisplayStyle { get; }

        [JsonConstructor]
        internal RecordPresentationInfo(PresentationNodeType presentationNodeType, uint[] parentPresentationNodeHashes, PresentationDisplayStyle displayStyle)
        {
            PresentationNodeType = presentationNodeType;
            ParentPresentationNodes = parentPresentationNodeHashes.DefinitionsAsReadOnlyOrEmpty<DestinyPresentationNodeDefinition>(DefinitionsEnum.DestinyPresentationNodeDefinition);
            DisplayStyle = displayStyle;
        }

        public bool DeepEquals(RecordPresentationInfo other)
        {
            return other != null &&
                   PresentationNodeType == other.PresentationNodeType &&
                   ParentPresentationNodes.DeepEqualsReadOnlyCollections(other.ParentPresentationNodes) &&
                   DisplayStyle == other.DisplayStyle;
        }
    }
}
