namespace DotNetBungieAPI.Models.Destiny.HistoricalStats;

public sealed class DestinyPostGameCarnageReportData
{
    /// <summary>
    ///     Date and time for the activity.
    /// </summary>
    [JsonPropertyName("period")]
    public DateTime Period { get; init; }

    /// <summary>
    ///     If this activity has "phases", this is the phase at which the activity was started. This value is only valid for activities before the Beyond Light expansion shipped. Subsequent activities will not have a valid value here.
    /// </summary>
    [JsonPropertyName("startingPhaseIndex")]
    public int? StartingPhaseIndex { get; init; }

    /// <summary>
    ///     True if the activity was started from the beginning, if that information is available and the activity was played post Witch Queen release.
    /// </summary>
    [JsonPropertyName("activityWasStartedFromBeginning")]
    public bool? ActivityWasStartedFromBeginning { get; init; }

    /// <summary>
    ///     Difficulty tier index value for the activity.
    /// </summary>
    [JsonPropertyName("activityDifficultyTier")]
    public int? ActivityDifficultyTier { get; init; }

    /// <summary>
    ///     Collection of player-selected skull hashes active for the activity.
    /// </summary>
    [JsonPropertyName("selectedSkullHashes")]
    public uint[]? SelectedSkullHashes { get; init; }

    /// <summary>
    ///     Details about the activity.
    /// </summary>
    [JsonPropertyName("activityDetails")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsActivity? ActivityDetails { get; init; }

    /// <summary>
    ///     Collection of players and their data for this activity.
    /// </summary>
    [JsonPropertyName("entries")]
    public Destiny.HistoricalStats.DestinyPostGameCarnageReportEntry[]? Entries { get; init; }

    /// <summary>
    ///     Collection of stats for the player in this activity.
    /// </summary>
    [JsonPropertyName("teams")]
    public Destiny.HistoricalStats.DestinyPostGameCarnageReportTeamEntry[]? Teams { get; init; }
}
