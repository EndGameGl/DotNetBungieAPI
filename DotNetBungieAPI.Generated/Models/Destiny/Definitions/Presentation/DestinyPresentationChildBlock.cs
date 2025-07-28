namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

public class DestinyPresentationChildBlock
{
    [JsonPropertyName("presentationNodeType")]
    public Destiny.DestinyPresentationNodeType PresentationNodeType { get; set; }

    [Destiny2Definition<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>("Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition")]
    [JsonPropertyName("parentPresentationNodeHashes")]
    public uint[]? ParentPresentationNodeHashes { get; set; }

    [JsonPropertyName("displayStyle")]
    public Destiny.DestinyPresentationDisplayStyle DisplayStyle { get; set; }
}
