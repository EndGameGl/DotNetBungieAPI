namespace DotNetBungieAPI.Models.Destiny.Components.Records;

public sealed class DestinyRecordComponent
{
    [JsonPropertyName("state")]
    public Destiny.DestinyRecordState State { get; init; }

    [JsonPropertyName("objectives")]
    public Destiny.Quests.DestinyObjectiveProgress[]? Objectives { get; init; }

    [JsonPropertyName("intervalObjectives")]
    public Destiny.Quests.DestinyObjectiveProgress[]? IntervalObjectives { get; init; }

    [JsonPropertyName("intervalsRedeemedCount")]
    public int IntervalsRedeemedCount { get; init; }

    /// <summary>
    ///     If available, this is the number of times this record has been completed. For example, the number of times a seal title has been gilded.
    /// </summary>
    [JsonPropertyName("completedCount")]
    public int? CompletedCount { get; init; }

    /// <summary>
    ///     If available, a list that describes which reward rewards should be shown (true) or hidden (false). This property is for regular record rewards, and not for interval objective rewards.
    /// </summary>
    [JsonPropertyName("rewardVisibilty")]
    public bool[]? RewardVisibilty { get; init; }
}
