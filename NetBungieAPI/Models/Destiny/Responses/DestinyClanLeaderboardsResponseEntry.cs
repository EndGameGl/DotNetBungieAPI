using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.HistoricalStats;

namespace NetBungieAPI.Models.Destiny.Responses
{
    public sealed record DestinyClanLeaderboardsResponseEntry
    {
        [JsonPropertyName("rank")]
        public int Rank { get; init; }
        [JsonPropertyName("player")]
        public DestinyPlayer Player { get; init; }
        [JsonPropertyName("characterId")]
        public long CharacterId { get; init; }
        [JsonPropertyName("value")]
        public DestinyHistoricalStatsValue Value { get; init; }
    }
}