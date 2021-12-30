using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Records;

public sealed class DestinyRecordComponent
{

    [JsonPropertyName("state")]
    public Destiny.DestinyRecordState State { get; init; }

    [JsonPropertyName("objectives")]
    public List<Destiny.Quests.DestinyObjectiveProgress> Objectives { get; init; }

    [JsonPropertyName("intervalObjectives")]
    public List<Destiny.Quests.DestinyObjectiveProgress> IntervalObjectives { get; init; }

    [JsonPropertyName("intervalsRedeemedCount")]
    public int IntervalsRedeemedCount { get; init; }

    [JsonPropertyName("completedCount")]
    public int? CompletedCount { get; init; }

    [JsonPropertyName("rewardVisibilty")]
    public List<bool> RewardVisibilty { get; init; }
}
