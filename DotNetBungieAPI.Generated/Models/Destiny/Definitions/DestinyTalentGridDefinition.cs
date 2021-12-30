using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyTalentGridDefinition
{

    [JsonPropertyName("maxGridLevel")]
    public int MaxGridLevel { get; init; }

    [JsonPropertyName("gridLevelPerColumn")]
    public int GridLevelPerColumn { get; init; }

    [JsonPropertyName("progressionHash")]
    public uint ProgressionHash { get; init; }

    [JsonPropertyName("nodes")]
    public List<Destiny.Definitions.DestinyTalentNodeDefinition> Nodes { get; init; }

    [JsonPropertyName("exclusiveSets")]
    public List<Destiny.Definitions.DestinyTalentNodeExclusiveSetDefinition> ExclusiveSets { get; init; }

    [JsonPropertyName("independentNodeIndexes")]
    public List<int> IndependentNodeIndexes { get; init; }

    [JsonPropertyName("groups")]
    public Dictionary<uint, Destiny.Definitions.DestinyTalentExclusiveGroup> Groups { get; init; }

    [JsonPropertyName("nodeCategories")]
    public List<Destiny.Definitions.DestinyTalentNodeCategory> NodeCategories { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
