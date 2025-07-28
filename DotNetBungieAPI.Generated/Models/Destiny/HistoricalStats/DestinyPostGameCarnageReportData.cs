namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyPostGameCarnageReportData
{
    /// <summary>
    ///     Date and time for the activity.
    /// </summary>
    [JsonPropertyName("period")]
    public DateTime Period { get; set; }

    /// <summary>
    ///     If this activity has "phases", this is the phase at which the activity was started. This value is only valid for activities before the Beyond Light expansion shipped. Subsequent activities will not have a valid value here.
    /// </summary>
    [JsonPropertyName("startingPhaseIndex")]
    public int? StartingPhaseIndex { get; set; }

    /// <summary>
    ///     True if the activity was started from the beginning, if that information is available and the activity was played post Witch Queen release.
    /// </summary>
    [JsonPropertyName("activityWasStartedFromBeginning")]
    public bool? ActivityWasStartedFromBeginning { get; set; }

    /// <summary>
    ///     Difficulty tier index value for the activity.
    /// </summary>
    [JsonPropertyName("activityDifficultyTier")]
    public int? ActivityDifficultyTier { get; set; }

    /// <summary>
    ///     Collection of player-selected skull hashes active for the activity.
    /// </summary>
    [JsonPropertyName("selectedSkullHashes")]
    public uint[]? SelectedSkullHashes { get; set; }

    /// <summary>
    ///     Details about the activity.
    /// </summary>
    [JsonPropertyName("activityDetails")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsActivity? ActivityDetails { get; set; }

    /// <summary>
    ///     Collection of players and their data for this activity.
    /// </summary>
    [JsonPropertyName("entries")]
    public Destiny.HistoricalStats.DestinyPostGameCarnageReportEntry[]? Entries { get; set; }

    /// <summary>
    ///     Collection of stats for the player in this activity.
    /// </summary>
    [JsonPropertyName("teams")]
    public Destiny.HistoricalStats.DestinyPostGameCarnageReportTeamEntry[]? Teams { get; set; }
}
