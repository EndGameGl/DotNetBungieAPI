namespace DotNetBungieAPI.Models.Destiny.Components.Presentation;

public sealed class DestinyPresentationNodesComponent
{
    [JsonPropertyName("nodes")]
    public Dictionary<DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>, Destiny.Components.Presentation.DestinyPresentationNodeComponent>? Nodes { get; init; }
}
