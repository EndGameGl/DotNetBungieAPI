using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Quests;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyRecordComponent
    {
        [JsonPropertyName("state")] public DestinyRecordState State { get; init; }

        [JsonPropertyName("objectives")]
        public ReadOnlyCollection<DestinyObjectiveProgress> Objectives { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyObjectiveProgress>();

        [JsonPropertyName("intervalObjectives")]
        public ReadOnlyCollection<DestinyObjectiveProgress> IntervalObjectives { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyObjectiveProgress>();

        [JsonPropertyName("intervalsRedeemedCount")]
        public int IntervalsRedeemedCount { get; init; }

        /// <summary>
        ///     If available, a list that describes which reward rewards should be shown (true) or hidden (false). This property is
        ///     for regular record rewards, and not for interval objective rewards.
        /// </summary>
        [JsonPropertyName("rewardVisibilty")]
        public ReadOnlyCollection<bool> RewardVisibilty { get; init; } = Defaults.EmptyReadOnlyCollection<bool>();
    }
}