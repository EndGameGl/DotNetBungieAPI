namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyPostGameCarnageReportData : IDeepEquatable<DestinyPostGameCarnageReportData>
{
    /// <summary>
    ///     Date and time for the activity.
    /// </summary>
    [JsonPropertyName("period")]
    public DateTime Period { get; set; }

    /// <summary>
    ///     If this activity has "phases", this is the phase at which the activity was started.
    /// </summary>
    [JsonPropertyName("startingPhaseIndex")]
    public int? StartingPhaseIndex { get; set; }

    /// <summary>
    ///     Details about the activity.
    /// </summary>
    [JsonPropertyName("activityDetails")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsActivity ActivityDetails { get; set; }

    /// <summary>
    ///     Collection of players and their data for this activity.
    /// </summary>
    [JsonPropertyName("entries")]
    public List<Destiny.HistoricalStats.DestinyPostGameCarnageReportEntry> Entries { get; set; }

    /// <summary>
    ///     Collection of stats for the player in this activity.
    /// </summary>
    [JsonPropertyName("teams")]
    public List<Destiny.HistoricalStats.DestinyPostGameCarnageReportTeamEntry> Teams { get; set; }

    public bool DeepEquals(DestinyPostGameCarnageReportData? other)
    {
        return other is not null &&
               Period == other.Period &&
               StartingPhaseIndex == other.StartingPhaseIndex &&
               (ActivityDetails is not null ? ActivityDetails.DeepEquals(other.ActivityDetails) : other.ActivityDetails is null) &&
               Entries.DeepEqualsList(other.Entries) &&
               Teams.DeepEqualsList(other.Teams);
    }
}