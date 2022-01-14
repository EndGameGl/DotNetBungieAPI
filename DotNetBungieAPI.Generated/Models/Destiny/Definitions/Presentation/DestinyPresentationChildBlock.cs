namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

public sealed class DestinyPresentationChildBlock
{

    [JsonPropertyName("presentationNodeType")]
    public Destiny.DestinyPresentationNodeType PresentationNodeType { get; init; }

    [JsonPropertyName("parentPresentationNodeHashes")]
    public List<uint> ParentPresentationNodeHashes { get; init; } // DestinyPresentationNodeDefinition

    [JsonPropertyName("displayStyle")]
    public Destiny.DestinyPresentationDisplayStyle DisplayStyle { get; init; }
}
