namespace DotNetBungieAPI.Models.Destiny.Definitions.ActivityGraphs;

/// <summary>
///     Nodes can have different visual states. This object represents a single visual state ("highlight type") that a node
///     can be in, and the unlock expression condition to determine whether it should be set.
/// </summary>
public sealed record DestinyActivityGraphNodeFeaturingStateDefinition
    : IDeepEquatable<DestinyActivityGraphNodeFeaturingStateDefinition>
{
    /// <summary>
    ///     The node can be highlighted in a variety of ways - the game iterates through these and finds the first
    ///     FeaturingState that is valid at the present moment given the Game, Account, and Character state, and renders the
    ///     node in that state.
    /// </summary>
    [JsonPropertyName("highlightType")]
    public ActivityGraphNodeHighlightType HighlightType { get; init; }

    public bool DeepEquals(DestinyActivityGraphNodeFeaturingStateDefinition other)
    {
        return other != null && HighlightType == other.HighlightType;
    }
}