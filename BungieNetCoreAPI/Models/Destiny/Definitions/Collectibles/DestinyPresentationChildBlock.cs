using NetBungieAPI.Models.Destiny.Definitions.PresentationNodes;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Collectibles
{
    public sealed record DestinyPresentationChildBlock : IDeepEquatable<DestinyPresentationChildBlock>
    {
        [JsonPropertyName("presentationNodeType")]
        public DestinyPresentationNodeType PresentationNodeType { get; init; }

        [JsonPropertyName("parentPresentationNodeHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyPresentationNodeDefinition>>
            ParentPresentationNodes { get; init; } =
            Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyPresentationNodeDefinition>>();

        [JsonPropertyName("displayStyle")] public DestinyPresentationDisplayStyle DisplayStyle { get; init; }

        public bool DeepEquals(DestinyPresentationChildBlock other)
        {
            return other != null &&
                   PresentationNodeType == other.PresentationNodeType &&
                   ParentPresentationNodes.DeepEqualsReadOnlyCollections(other.ParentPresentationNodes) &&
                   DisplayStyle == other.DisplayStyle;
        }
    }
}