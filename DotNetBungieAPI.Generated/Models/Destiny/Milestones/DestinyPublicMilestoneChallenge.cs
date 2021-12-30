using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

public sealed class DestinyPublicMilestoneChallenge
{

    [JsonPropertyName("objectiveHash")]
    public uint ObjectiveHash { get; init; }

    [JsonPropertyName("activityHash")]
    public uint? ActivityHash { get; init; }
}
