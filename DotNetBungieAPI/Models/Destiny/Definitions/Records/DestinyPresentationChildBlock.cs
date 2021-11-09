using DotNetBungieAPI.Models.Destiny.Definitions.PresentationNodes;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Records
{
    public sealed record DestinyPresentationChildBlock : IDeepEquatable<DestinyPresentationChildBlock>
    {
        [JsonPropertyName("presentationNodeType")]
        public DestinyPresentationNodeType PresentationNodeType { get; init; }

        [JsonPropertyName("parentPresentationNodeHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyPresentationNodeDefinition>>
            ParentPresentationNodes
        { get; init; } =
            ReadOnlyCollections<DefinitionHashPointer<DestinyPresentationNodeDefinition>>.Empty;

        [JsonPropertyName("displayStyle")] public DestinyPresentationNodeType DisplayStyle { get; init; }

        public bool DeepEquals(DestinyPresentationChildBlock other)
        {
            return other != null &&
                   PresentationNodeType == other.PresentationNodeType &&
                   ParentPresentationNodes.DeepEqualsReadOnlyCollections(other.ParentPresentationNodes) &&
                   DisplayStyle == other.DisplayStyle;
        }
    }
}