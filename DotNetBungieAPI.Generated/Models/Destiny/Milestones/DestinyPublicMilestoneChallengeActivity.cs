using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

public sealed class DestinyPublicMilestoneChallengeActivity
{

    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; init; }

    [JsonPropertyName("challengeObjectiveHashes")]
    public List<uint> ChallengeObjectiveHashes { get; init; }

    [JsonPropertyName("modifierHashes")]
    public List<uint> ModifierHashes { get; init; }

    [JsonPropertyName("loadoutRequirementIndex")]
    public int? LoadoutRequirementIndex { get; init; }

    [JsonPropertyName("phaseHashes")]
    public List<uint> PhaseHashes { get; init; }

    [JsonPropertyName("booleanActivityOptions")]
    public Dictionary<uint, bool> BooleanActivityOptions { get; init; }
}
