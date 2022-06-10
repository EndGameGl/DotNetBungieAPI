namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Records;

public class DestinyRecordComponent
{
    [JsonPropertyName("state")]
    public Destiny.DestinyRecordState State { get; set; }

    [JsonPropertyName("objectives")]
    public List<Destiny.Quests.DestinyObjectiveProgress> Objectives { get; set; }

    [JsonPropertyName("intervalObjectives")]
    public List<Destiny.Quests.DestinyObjectiveProgress> IntervalObjectives { get; set; }

    [JsonPropertyName("intervalsRedeemedCount")]
    public int IntervalsRedeemedCount { get; set; }

    /// <summary>
    ///     If available, this is the number of times this record has been completed. For example, the number of times a seal title has been gilded.
    /// </summary>
    [JsonPropertyName("completedCount")]
    public int CompletedCount { get; set; }

    /// <summary>
    ///     If available, a list that describes which reward rewards should be shown (true) or hidden (false). This property is for regular record rewards, and not for interval objective rewards.
    /// </summary>
    [JsonPropertyName("rewardVisibilty")]
    public List<bool> RewardVisibilty { get; set; }
}
