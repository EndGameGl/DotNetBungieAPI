using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public sealed class DestinyPostGameCarnageReportTeamEntry
{

    [JsonPropertyName("teamId")]
    public int TeamId { get; init; }

    [JsonPropertyName("standing")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValue Standing { get; init; }

    [JsonPropertyName("score")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValue Score { get; init; }

    [JsonPropertyName("teamName")]
    public string TeamName { get; init; }
}
