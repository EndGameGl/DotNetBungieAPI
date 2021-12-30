using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Progression;

public sealed class DestinyProgressionLevelRequirementDefinition
{

    [JsonPropertyName("requirementCurve")]
    public List<Interpolation.InterpolationPointFloat> RequirementCurve { get; init; }

    [JsonPropertyName("progressionHash")]
    public uint ProgressionHash { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
