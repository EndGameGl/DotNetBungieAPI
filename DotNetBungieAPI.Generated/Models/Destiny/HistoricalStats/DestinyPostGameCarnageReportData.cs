using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public sealed class DestinyPostGameCarnageReportData
{

    /// <summary>
    ///     Date and time for the activity.
    /// </summary>
    [JsonPropertyName("period")]
    public DateTime Period { get; init; }

    /// <summary>
    ///     If this activity has "phases", this is the phase at which the activity was started.
    /// </summary>
    [JsonPropertyName("startingPhaseIndex")]
    public int? StartingPhaseIndex { get; init; }

    /// <summary>
    ///     Details about the activity.
    /// </summary>
    [JsonPropertyName("activityDetails")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsActivity ActivityDetails { get; init; }

    /// <summary>
    ///     Collection of players and their data for this activity.
    /// </summary>
    [JsonPropertyName("entries")]
    public List<Destiny.HistoricalStats.DestinyPostGameCarnageReportEntry> Entries { get; init; }

    /// <summary>
    ///     Collection of stats for the player in this activity.
    /// </summary>
    [JsonPropertyName("teams")]
    public List<Destiny.HistoricalStats.DestinyPostGameCarnageReportTeamEntry> Teams { get; init; }
}
