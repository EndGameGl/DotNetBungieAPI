using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Challenges;

public sealed class DestinyChallengeStatus
{

    [JsonPropertyName("objective")]
    public Destiny.Quests.DestinyObjectiveProgress Objective { get; init; }
}
