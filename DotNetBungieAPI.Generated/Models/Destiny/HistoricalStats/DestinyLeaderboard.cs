namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyLeaderboard : IDeepEquatable<DestinyLeaderboard>
{
    [JsonPropertyName("statId")]
    public string StatId { get; set; }

    [JsonPropertyName("entries")]
    public List<Destiny.HistoricalStats.DestinyLeaderboardEntry> Entries { get; set; }

    public bool DeepEquals(DestinyLeaderboard? other)
    {
        return other is not null &&
               StatId == other.StatId &&
               Entries.DeepEqualsList(other.Entries);
    }
}