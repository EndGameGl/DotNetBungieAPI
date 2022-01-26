namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Presentation;

public class DestinyPresentationNodesComponent : IDeepEquatable<DestinyPresentationNodesComponent>
{
    [JsonPropertyName("nodes")]
    public Dictionary<uint, Destiny.Components.Presentation.DestinyPresentationNodeComponent> Nodes { get; set; }

    public bool DeepEquals(DestinyPresentationNodesComponent? other)
    {
        return other is not null &&
               Nodes.DeepEqualsDictionary(other.Nodes);
    }
}