using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

public sealed class DestinyMilestoneActivityCompletionStatus
{

    [JsonPropertyName("completed")]
    public bool Completed { get; init; }

    [JsonPropertyName("phases")]
    public List<Destiny.Milestones.DestinyMilestoneActivityPhase> Phases { get; init; }
}
