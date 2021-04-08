using NetBungieAPI.Destiny.Definitions.PresentationNodes;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.Records
{
    public class RecordPresentationInfo : IDeepEquatable<RecordPresentationInfo>
    {
        public PresentationNodeType PresentationNodeType { get; init; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyPresentationNodeDefinition>> ParentPresentationNodes { get; init; }
        public PresentationDisplayStyle DisplayStyle { get; init; }

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
