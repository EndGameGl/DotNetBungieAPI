using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyTalentNodeDefinition
{

    [JsonPropertyName("nodeIndex")]
    public int NodeIndex { get; init; }

    [JsonPropertyName("nodeHash")]
    public uint NodeHash { get; init; }

    [JsonPropertyName("row")]
    public int Row { get; init; }

    [JsonPropertyName("column")]
    public int Column { get; init; }

    [JsonPropertyName("prerequisiteNodeIndexes")]
    public List<int> PrerequisiteNodeIndexes { get; init; }

    [JsonPropertyName("binaryPairNodeIndex")]
    public int BinaryPairNodeIndex { get; init; }

    [JsonPropertyName("autoUnlocks")]
    public bool AutoUnlocks { get; init; }

    [JsonPropertyName("lastStepRepeats")]
    public bool LastStepRepeats { get; init; }

    [JsonPropertyName("isRandom")]
    public bool IsRandom { get; init; }

    [JsonPropertyName("randomActivationRequirement")]
    public Destiny.Definitions.DestinyNodeActivationRequirement RandomActivationRequirement { get; init; }

    [JsonPropertyName("isRandomRepurchasable")]
    public bool IsRandomRepurchasable { get; init; }

    [JsonPropertyName("steps")]
    public List<Destiny.Definitions.DestinyNodeStepDefinition> Steps { get; init; }

    [JsonPropertyName("exclusiveWithNodeHashes")]
    public List<uint> ExclusiveWithNodeHashes { get; init; }

    [JsonPropertyName("randomStartProgressionBarAtProgression")]
    public int RandomStartProgressionBarAtProgression { get; init; }

    [JsonPropertyName("layoutIdentifier")]
    public string LayoutIdentifier { get; init; }

    [JsonPropertyName("groupHash")]
    public uint? GroupHash { get; init; }

    [JsonPropertyName("loreHash")]
    public uint? LoreHash { get; init; }

    [JsonPropertyName("nodeStyleIdentifier")]
    public string NodeStyleIdentifier { get; init; }

    [JsonPropertyName("ignoreForCompletion")]
    public bool IgnoreForCompletion { get; init; }
}
