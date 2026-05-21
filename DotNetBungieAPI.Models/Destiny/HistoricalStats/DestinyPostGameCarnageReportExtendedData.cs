namespace DotNetBungieAPI.Models.Destiny.HistoricalStats;

public sealed class DestinyPostGameCarnageReportExtendedData
{
    /// <summary>
    ///     List of weapons and their perspective values.
    /// </summary>
    [JsonPropertyName("weapons")]
    public Destiny.HistoricalStats.DestinyHistoricalWeaponStats[]? Weapons { get; init; }

    /// <summary>
    ///     Collection of stats for the player in this activity.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue>? Values { get; init; }

    /// <summary>
    ///     Collection of stats from the player scoreboard in this activity.
    /// </summary>
    [JsonPropertyName("scoreboardValues")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue>? ScoreboardValues { get; init; }
}
