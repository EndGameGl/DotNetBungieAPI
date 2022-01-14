namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public sealed class DestinyLeaderboard
{

    [JsonPropertyName("statId")]
    public string StatId { get; init; }

    [JsonPropertyName("entries")]
    public List<Destiny.HistoricalStats.DestinyLeaderboardEntry> Entries { get; init; }
}
