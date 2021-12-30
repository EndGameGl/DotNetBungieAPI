using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public sealed class DestinyLeaderboardEntry
{

    [JsonPropertyName("rank")]
    public int Rank { get; init; }

    [JsonPropertyName("player")]
    public Destiny.HistoricalStats.DestinyPlayer Player { get; init; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; init; }

    [JsonPropertyName("value")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValue Value { get; init; }
}
