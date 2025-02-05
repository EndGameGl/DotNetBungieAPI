﻿using DotNetBungieAPI.Models.Destiny.Quests;

namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DestinyRecordComponent
{
    [JsonPropertyName("state")]
    public DestinyRecordState State { get; init; }

    [JsonPropertyName("objectives")]
    public ReadOnlyCollection<DestinyObjectiveProgress> Objectives { get; init; } =
        ReadOnlyCollection<DestinyObjectiveProgress>.Empty;

    [JsonPropertyName("intervalObjectives")]
    public ReadOnlyCollection<DestinyObjectiveProgress> IntervalObjectives { get; init; } =
        ReadOnlyCollection<DestinyObjectiveProgress>.Empty;

    [JsonPropertyName("intervalsRedeemedCount")]
    public int IntervalsRedeemedCount { get; init; }

    /// <summary>
    ///     If available, this is the number of times this record has been completed. For example, the number of times a seal
    ///     title has been gilded.
    /// </summary>
    [JsonPropertyName("completedCount")]
    public int? CompletedCount { get; init; }

    /// <summary>
    ///     If available, a list that describes which reward rewards should be shown (true) or hidden (false). This property is
    ///     for regular record rewards, and not for interval objective rewards.
    /// </summary>
    [JsonPropertyName("rewardVisibilty")]
    public ReadOnlyCollection<bool> RewardVisibilty { get; init; } =
        ReadOnlyCollection<bool>.Empty;
}
