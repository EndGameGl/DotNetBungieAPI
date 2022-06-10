namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

public class DestinyPresentationChildBlock
{
    [JsonPropertyName("presentationNodeType")]
    public Destiny.DestinyPresentationNodeType PresentationNodeType { get; set; }

    [JsonPropertyName("parentPresentationNodeHashes")]
    public List<uint> ParentPresentationNodeHashes { get; set; }

    [JsonPropertyName("displayStyle")]
    public Destiny.DestinyPresentationDisplayStyle DisplayStyle { get; set; }
}
