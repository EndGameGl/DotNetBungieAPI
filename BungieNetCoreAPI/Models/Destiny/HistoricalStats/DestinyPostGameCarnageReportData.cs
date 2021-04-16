using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyPostGameCarnageReportData
    {
        [JsonPropertyName("period")]
        public DateTime Period { get; init; }
        [JsonPropertyName("startingPhaseIndex")]
        public int? StartingPhaseIndex { get; init; }
        [JsonPropertyName("activityDetails")]
        public DestinyHistoricalStatsActivity ActivityDetails { get; init; }

        [JsonPropertyName("entries")]
        public ReadOnlyCollection<DestinyPostGameCarnageReportEntry> Entries { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyPostGameCarnageReportEntry>();

        [JsonPropertyName("teams")]
        public ReadOnlyCollection<DestinyPostGameCarnageReportTeamEntry> Teams { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyPostGameCarnageReportTeamEntry>();
    }
}
