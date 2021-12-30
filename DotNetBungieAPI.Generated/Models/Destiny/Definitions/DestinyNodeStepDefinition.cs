using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyNodeStepDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("stepIndex")]
    public int StepIndex { get; init; }

    [JsonPropertyName("nodeStepHash")]
    public uint NodeStepHash { get; init; }

    [JsonPropertyName("interactionDescription")]
    public string InteractionDescription { get; init; }

    [JsonPropertyName("damageType")]
    public Destiny.DamageType DamageType { get; init; }

    [JsonPropertyName("damageTypeHash")]
    public uint? DamageTypeHash { get; init; }

    [JsonPropertyName("activationRequirement")]
    public Destiny.Definitions.DestinyNodeActivationRequirement ActivationRequirement { get; init; }

    [JsonPropertyName("canActivateNextStep")]
    public bool CanActivateNextStep { get; init; }

    [JsonPropertyName("nextStepIndex")]
    public int NextStepIndex { get; init; }

    [JsonPropertyName("isNextStepRandom")]
    public bool IsNextStepRandom { get; init; }

    [JsonPropertyName("perkHashes")]
    public List<uint> PerkHashes { get; init; }

    [JsonPropertyName("startProgressionBarAtProgress")]
    public int StartProgressionBarAtProgress { get; init; }

    [JsonPropertyName("statHashes")]
    public List<uint> StatHashes { get; init; }

    [JsonPropertyName("affectsQuality")]
    public bool AffectsQuality { get; init; }

    [JsonPropertyName("stepGroups")]
    public Destiny.Definitions.DestinyTalentNodeStepGroups StepGroups { get; init; }

    [JsonPropertyName("affectsLevel")]
    public bool AffectsLevel { get; init; }

    [JsonPropertyName("socketReplacements")]
    public List<Destiny.Definitions.DestinyNodeSocketReplaceResponse> SocketReplacements { get; init; }
}
