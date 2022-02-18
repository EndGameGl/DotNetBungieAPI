namespace DotNetBungieAPI.Models.Destiny.HistoricalStats;

public sealed record DestinyPostGameCarnageReportData
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
    [Obsolete("Use ActivityWasStartedFromBeginning instead")]
    public int? StartingPhaseIndex { get; init; }

    /// <summary>
    ///     True if the activity was started from the beginning, if that information is available.
    /// </summary>
    [JsonPropertyName("activityWasStartedFromBeginning")]
    public bool? ActivityWasStartedFromBeginning { get; set; }
    
    /// <summary>
    ///     Details about the activity.
    /// </summary>
    [JsonPropertyName("activityDetails")]
    public DestinyHistoricalStatsActivity ActivityDetails { get; init; }

    /// <summary>
    ///     Collection of players and their data for this activity.
    /// </summary>
    [JsonPropertyName("entries")]
    public ReadOnlyCollection<DestinyPostGameCarnageReportEntry> Entries { get; init; } =
        ReadOnlyCollections<DestinyPostGameCarnageReportEntry>.Empty;

    /// <summary>
    ///     Collection of stats for the player in this activity.
    /// </summary>
    [JsonPropertyName("teams")]
    public ReadOnlyCollection<DestinyPostGameCarnageReportTeamEntry> Teams { get; init; } =
        ReadOnlyCollections<DestinyPostGameCarnageReportTeamEntry>.Empty;
}