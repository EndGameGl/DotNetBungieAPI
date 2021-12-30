using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Artifacts;

public sealed class DestinyArtifactTierDefinition
{

    [JsonPropertyName("tierHash")]
    public uint TierHash { get; init; }

    [JsonPropertyName("displayTitle")]
    public string DisplayTitle { get; init; }

    [JsonPropertyName("progressRequirementMessage")]
    public string ProgressRequirementMessage { get; init; }

    [JsonPropertyName("items")]
    public List<Destiny.Definitions.Artifacts.DestinyArtifactTierItemDefinition> Items { get; init; }

    [JsonPropertyName("minimumUnlockPointsUsedRequirement")]
    public int MinimumUnlockPointsUsedRequirement { get; init; }
}
