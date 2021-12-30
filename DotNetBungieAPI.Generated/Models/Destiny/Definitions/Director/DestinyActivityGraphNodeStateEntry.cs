using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Director;

/// <summary>
///     Represents a single state that a graph node might end up in. Depending on what's going on in the game, graph nodes could be shown in different ways or even excluded from view entirely.
/// </summary>
public sealed class DestinyActivityGraphNodeStateEntry
{

    [JsonPropertyName("state")]
    public Destiny.DestinyGraphNodeState State { get; init; }
}
