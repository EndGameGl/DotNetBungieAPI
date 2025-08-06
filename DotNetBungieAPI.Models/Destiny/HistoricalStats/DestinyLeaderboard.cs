namespace DotNetBungieAPI.Models.Destiny.HistoricalStats;

public sealed class DestinyLeaderboard
{
    [JsonPropertyName("statId")]
    public string StatId { get; init; }

    [JsonPropertyName("entries")]
    public Destiny.HistoricalStats.DestinyLeaderboardEntry[]? Entries { get; init; }
}
