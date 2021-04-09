using NetBungieAPI.Models.Destiny.Quests;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyRecordComponent
    {
        [JsonPropertyName("state")]
        public DestinyRecordState State { get; init; }
        [JsonPropertyName("objectives")]
        public ReadOnlyCollection<DestinyObjectiveProgress> Objectives { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyObjectiveProgress>();
        [JsonPropertyName("intervalObjectives")]
        public ReadOnlyCollection<DestinyObjectiveProgress> IntervalObjectives { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyObjectiveProgress>();
        [JsonPropertyName("intervalsRedeemedCount")]
        public int IntervalsRedeemedCount { get; init; }
    }
}
