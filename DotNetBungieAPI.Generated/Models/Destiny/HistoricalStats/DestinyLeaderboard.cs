namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyLeaderboard
{
    [JsonPropertyName("statId")]
    public string StatId { get; set; }

    [JsonPropertyName("entries")]
    public Destiny.HistoricalStats.DestinyLeaderboardEntry[]? Entries { get; set; }
}
