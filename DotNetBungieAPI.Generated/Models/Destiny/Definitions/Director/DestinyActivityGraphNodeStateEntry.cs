namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Director;

/// <summary>
///     Represents a single state that a graph node might end up in. Depending on what's going on in the game, graph nodes could be shown in different ways or even excluded from view entirely.
/// </summary>
public class DestinyActivityGraphNodeStateEntry : IDeepEquatable<DestinyActivityGraphNodeStateEntry>
{
    [JsonPropertyName("state")]
    public Destiny.DestinyGraphNodeState State { get; set; }

    public bool DeepEquals(DestinyActivityGraphNodeStateEntry? other)
    {
        return other is not null &&
               State == other.State;
    }
}