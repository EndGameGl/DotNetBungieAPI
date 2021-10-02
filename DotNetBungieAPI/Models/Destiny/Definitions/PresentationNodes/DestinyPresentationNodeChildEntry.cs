using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Definitions.PresentationNodes
{
    public sealed record DestinyPresentationNodeChildEntry : IDeepEquatable<DestinyPresentationNodeChildEntry>
    {
        [JsonPropertyName("presentationNodeHash")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> PresentationNode { get; init; } =
            DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

        public bool DeepEquals(DestinyPresentationNodeChildEntry other)
        {
            return other != null && PresentationNode.DeepEquals(other.PresentationNode);
        }
    }
}