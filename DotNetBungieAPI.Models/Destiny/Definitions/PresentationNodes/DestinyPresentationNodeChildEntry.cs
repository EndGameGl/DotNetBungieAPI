namespace DotNetBungieAPI.Models.Destiny.Definitions.PresentationNodes;

public sealed record DestinyPresentationNodeChildEntry
    : IDeepEquatable<DestinyPresentationNodeChildEntry>
{
    [JsonPropertyName("presentationNodeHash")]
    public DefinitionHashPointer<DestinyPresentationNodeDefinition> PresentationNode { get; init; } =
        DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

    /// <summary>
    ///     Use this value to sort the presentation node children in ascending order.
    /// </summary>
    [JsonPropertyName("nodeDisplayPriority")]
    public uint NodeDisplayPriority { get; init; }

    public bool DeepEquals(DestinyPresentationNodeChildEntry other)
    {
        return other is not null
            && PresentationNode.DeepEquals(other.PresentationNode)
            && NodeDisplayPriority == other.NodeDisplayPriority;
    }
}
