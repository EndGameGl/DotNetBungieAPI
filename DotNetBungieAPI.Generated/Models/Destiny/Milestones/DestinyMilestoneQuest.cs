using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

public sealed class DestinyMilestoneQuest
{

    [JsonPropertyName("questItemHash")]
    public uint QuestItemHash { get; init; }

    [JsonPropertyName("status")]
    public Destiny.Quests.DestinyQuestStatus Status { get; init; }

    [JsonPropertyName("activity")]
    public Destiny.Milestones.DestinyMilestoneActivity Activity { get; init; }

    [JsonPropertyName("challenges")]
    public List<Destiny.Challenges.DestinyChallengeStatus> Challenges { get; init; }
}
