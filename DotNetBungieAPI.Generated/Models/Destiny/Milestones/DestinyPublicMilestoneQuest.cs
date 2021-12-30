using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

public sealed class DestinyPublicMilestoneQuest
{

    [JsonPropertyName("questItemHash")]
    public uint QuestItemHash { get; init; }

    [JsonPropertyName("activity")]
    public Destiny.Milestones.DestinyPublicMilestoneActivity Activity { get; init; }

    [JsonPropertyName("challenges")]
    public List<Destiny.Milestones.DestinyPublicMilestoneChallenge> Challenges { get; init; }
}
