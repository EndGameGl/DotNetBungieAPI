using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyPostGameCarnageReportTeamEntry
    {
        [JsonPropertyName("teamId")]
        public int TeamId { get; init; }
        [JsonPropertyName("standing")]
        public DestinyHistoricalStatsValue Standing { get; init; }
        [JsonPropertyName("score")]
        public DestinyHistoricalStatsValue Score { get; init; }
        [JsonPropertyName("teamName")]
        public string TeamName { get; init; }
    }
}
