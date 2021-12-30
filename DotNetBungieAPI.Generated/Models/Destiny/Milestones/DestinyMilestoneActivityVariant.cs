using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

public sealed class DestinyMilestoneActivityVariant
{

    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; init; }

    [JsonPropertyName("completionStatus")]
    public Destiny.Milestones.DestinyMilestoneActivityCompletionStatus CompletionStatus { get; init; }

    [JsonPropertyName("activityModeHash")]
    public uint? ActivityModeHash { get; init; }

    [JsonPropertyName("activityModeType")]
    public int? ActivityModeType { get; init; }
}
