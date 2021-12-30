using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Director;

public sealed class DestinyActivityGraphDefinition
{

    [JsonPropertyName("nodes")]
    public List<Destiny.Definitions.Director.DestinyActivityGraphNodeDefinition> Nodes { get; init; }

    [JsonPropertyName("artElements")]
    public List<Destiny.Definitions.Director.DestinyActivityGraphArtElementDefinition> ArtElements { get; init; }

    [JsonPropertyName("connections")]
    public List<Destiny.Definitions.Director.DestinyActivityGraphConnectionDefinition> Connections { get; init; }

    [JsonPropertyName("displayObjectives")]
    public List<Destiny.Definitions.Director.DestinyActivityGraphDisplayObjectiveDefinition> DisplayObjectives { get; init; }

    [JsonPropertyName("displayProgressions")]
    public List<Destiny.Definitions.Director.DestinyActivityGraphDisplayProgressionDefinition> DisplayProgressions { get; init; }

    [JsonPropertyName("linkedGraphs")]
    public List<Destiny.Definitions.Director.DestinyLinkedGraphDefinition> LinkedGraphs { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
