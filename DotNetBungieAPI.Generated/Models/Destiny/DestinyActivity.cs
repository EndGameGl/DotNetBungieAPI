using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny;

public sealed class DestinyActivity
{

    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; init; }

    [JsonPropertyName("isNew")]
    public bool IsNew { get; init; }

    [JsonPropertyName("canLead")]
    public bool CanLead { get; init; }

    [JsonPropertyName("canJoin")]
    public bool CanJoin { get; init; }

    [JsonPropertyName("isCompleted")]
    public bool IsCompleted { get; init; }

    [JsonPropertyName("isVisible")]
    public bool IsVisible { get; init; }

    [JsonPropertyName("displayLevel")]
    public int? DisplayLevel { get; init; }

    [JsonPropertyName("recommendedLight")]
    public int? RecommendedLight { get; init; }

    [JsonPropertyName("difficultyTier")]
    public Destiny.DestinyActivityDifficultyTier DifficultyTier { get; init; }

    [JsonPropertyName("challenges")]
    public List<Destiny.Challenges.DestinyChallengeStatus> Challenges { get; init; }

    [JsonPropertyName("modifierHashes")]
    public List<uint> ModifierHashes { get; init; }

    [JsonPropertyName("booleanActivityOptions")]
    public Dictionary<uint, bool> BooleanActivityOptions { get; init; }

    [JsonPropertyName("loadoutRequirementIndex")]
    public int? LoadoutRequirementIndex { get; init; }
}
