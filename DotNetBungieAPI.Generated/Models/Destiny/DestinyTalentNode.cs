using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny;

public sealed class DestinyTalentNode
{

    [JsonPropertyName("nodeIndex")]
    public int NodeIndex { get; init; }

    [JsonPropertyName("nodeHash")]
    public uint NodeHash { get; init; }

    [JsonPropertyName("state")]
    public Destiny.DestinyTalentNodeState State { get; init; }

    [JsonPropertyName("isActivated")]
    public bool IsActivated { get; init; }

    [JsonPropertyName("stepIndex")]
    public int StepIndex { get; init; }

    [JsonPropertyName("materialsToUpgrade")]
    public List<Destiny.Definitions.DestinyMaterialRequirement> MaterialsToUpgrade { get; init; }

    [JsonPropertyName("activationGridLevel")]
    public int ActivationGridLevel { get; init; }

    [JsonPropertyName("progressPercent")]
    public float ProgressPercent { get; init; }

    [JsonPropertyName("hidden")]
    public bool Hidden { get; init; }

    [JsonPropertyName("nodeStatsBlock")]
    public Destiny.DestinyTalentNodeStatBlock NodeStatsBlock { get; init; }
}
