namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyHistoricalStatsWithMerged : IDeepEquatable<DestinyHistoricalStatsWithMerged>
{
    [JsonPropertyName("results")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod> Results { get; set; }

    [JsonPropertyName("merged")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod Merged { get; set; }

    public bool DeepEquals(DestinyHistoricalStatsWithMerged? other)
    {
        return other is not null &&
               Results.DeepEqualsDictionary(other.Results) &&
               (Merged is not null ? Merged.DeepEquals(other.Merged) : other.Merged is null);
    }
}