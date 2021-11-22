namespace DotNetBungieAPI.Models.Destiny.Definitions.ActivityGraphs
{
    /// <summary>
    ///     Represents a single state that a graph node might end up in. Depending on what's going on in the game, graph nodes
    ///     could be shown in different ways or even excluded from view entirely.
    /// </summary>
    public sealed record DestinyActivityGraphNodeStateEntry : IDeepEquatable<DestinyActivityGraphNodeStateEntry>
    {
        [JsonPropertyName("state")] public DestinyGraphNodeState State { get; init; }

        public bool DeepEquals(DestinyActivityGraphNodeStateEntry other)
        {
            return other != null && State == other.State;
        }
    }
}