using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Director;

public sealed class DestinyActivityGraphNodeStateEntry
{

    [JsonPropertyName("state")]
    public Destiny.DestinyGraphNodeState State { get; init; }
}
