namespace DotNetBungieAPI.Models.Destiny.HistoricalStats;

public sealed class DestinyPostGameCarnageReportTeamEntry
{
    /// <summary>
    ///     Integer ID for the team.
    /// </summary>
    [JsonPropertyName("teamId")]
    public int TeamId { get; init; }

    /// <summary>
    ///     Team's standing relative to other teams.
    /// </summary>
    [JsonPropertyName("standing")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValue? Standing { get; init; }

    /// <summary>
    ///     Score earned by the team
    /// </summary>
    [JsonPropertyName("score")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValue? Score { get; init; }

    /// <summary>
    ///     Alpha or Bravo
    /// </summary>
    [JsonPropertyName("teamName")]
    public string TeamName { get; init; }
}
