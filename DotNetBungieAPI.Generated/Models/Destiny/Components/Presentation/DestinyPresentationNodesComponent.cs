namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Presentation;

public class DestinyPresentationNodesComponent
{
    [Destiny2DefinitionDictionaryKey<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>("Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition")]
    [JsonPropertyName("nodes")]
    public Dictionary<uint, Destiny.Components.Presentation.DestinyPresentationNodeComponent> Nodes { get; set; }
}
