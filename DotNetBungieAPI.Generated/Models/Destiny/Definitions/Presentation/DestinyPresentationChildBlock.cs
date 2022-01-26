namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

public class DestinyPresentationChildBlock : IDeepEquatable<DestinyPresentationChildBlock>
{
    [JsonPropertyName("presentationNodeType")]
    public Destiny.DestinyPresentationNodeType PresentationNodeType { get; set; }

    [JsonPropertyName("parentPresentationNodeHashes")]
    public List<uint> ParentPresentationNodeHashes { get; set; }

    [JsonPropertyName("displayStyle")]
    public Destiny.DestinyPresentationDisplayStyle DisplayStyle { get; set; }

    public bool DeepEquals(DestinyPresentationChildBlock? other)
    {
        return other is not null &&
               PresentationNodeType == other.PresentationNodeType &&
               ParentPresentationNodeHashes.DeepEqualsListNaive(other.ParentPresentationNodeHashes) &&
               DisplayStyle == other.DisplayStyle;
    }
}