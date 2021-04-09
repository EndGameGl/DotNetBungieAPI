using NetBungieAPI.Models.Destiny.Definitions.PresentationNodes;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyPresentationNodesComponent
    {
        [JsonPropertyName("nodes")]
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyPresentationNodeDefinition>, DestinyPresentationNodeComponent> Nodes { get; init; } = Defaults.EmptyReadOnlyDictionary<DefinitionHashPointer<DestinyPresentationNodeDefinition>, DestinyPresentationNodeComponent>();
    }
}
