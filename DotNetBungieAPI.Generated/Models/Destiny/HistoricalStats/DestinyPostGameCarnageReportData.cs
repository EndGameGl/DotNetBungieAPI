using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public sealed class DestinyPostGameCarnageReportData
{

    [JsonPropertyName("period")]
    public DateTime Period { get; init; }

    [JsonPropertyName("startingPhaseIndex")]
    public int? StartingPhaseIndex { get; init; }

    [JsonPropertyName("activityDetails")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsActivity ActivityDetails { get; init; }

    [JsonPropertyName("entries")]
    public List<Destiny.HistoricalStats.DestinyPostGameCarnageReportEntry> Entries { get; init; }

    [JsonPropertyName("teams")]
    public List<Destiny.HistoricalStats.DestinyPostGameCarnageReportTeamEntry> Teams { get; init; }
}
