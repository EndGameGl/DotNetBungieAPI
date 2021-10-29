using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;
using DotNetBungieAPI.Models.Destiny.Definitions.PresentationNodes;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyPresentationNodesComponent
    {
        [JsonPropertyName("nodes")]
        public
            ReadOnlyDictionary<DefinitionHashPointer<DestinyPresentationNodeDefinition>,
                DestinyPresentationNodeComponent> Nodes { get; init; } =
            ReadOnlyDictionaries<DefinitionHashPointer<DestinyPresentationNodeDefinition>,
                DestinyPresentationNodeComponent>.Empty;
    }
}