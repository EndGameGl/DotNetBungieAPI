using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

public sealed class DestinyMilestoneChallengeActivity
{

    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; init; }

    [JsonPropertyName("challenges")]
    public List<Destiny.Challenges.DestinyChallengeStatus> Challenges { get; init; }

    [JsonPropertyName("modifierHashes")]
    public List<uint> ModifierHashes { get; init; }

    [JsonPropertyName("booleanActivityOptions")]
    public Dictionary<uint, bool> BooleanActivityOptions { get; init; }

    [JsonPropertyName("loadoutRequirementIndex")]
    public int? LoadoutRequirementIndex { get; init; }

    [JsonPropertyName("phases")]
    public List<Destiny.Milestones.DestinyMilestoneActivityPhase> Phases { get; init; }
}
