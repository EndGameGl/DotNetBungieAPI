using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;
using DotNetBungieAPI.Models.Destiny.Quests;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyRecordComponent
    {
        [JsonPropertyName("state")] public DestinyRecordState State { get; init; }

        [JsonPropertyName("objectives")]
        public ReadOnlyCollection<DestinyObjectiveProgress> Objectives { get; init; } =
            ReadOnlyCollections<DestinyObjectiveProgress>.Empty;

        [JsonPropertyName("intervalObjectives")]
        public ReadOnlyCollection<DestinyObjectiveProgress> IntervalObjectives { get; init; } =
            ReadOnlyCollections<DestinyObjectiveProgress>.Empty;

        [JsonPropertyName("intervalsRedeemedCount")]
        public int IntervalsRedeemedCount { get; init; }

        /// <summary>
        ///     If available, this is the number of times this record has been completed. For example, the number of times a seal title has been gilded.
        /// </summary>
        [JsonPropertyName("completedCount")]
        public int? CompletedCount { get; init; }

        /// <summary>
        ///     If available, a list that describes which reward rewards should be shown (true) or hidden (false). This property is
        ///     for regular record rewards, and not for interval objective rewards.
        /// </summary>
        [JsonPropertyName("rewardVisibilty")]
        public ReadOnlyCollection<bool> RewardVisibilty { get; init; } = ReadOnlyCollections<bool>.Empty;
    }
}