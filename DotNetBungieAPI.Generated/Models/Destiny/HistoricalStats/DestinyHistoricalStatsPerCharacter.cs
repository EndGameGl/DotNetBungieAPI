namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyHistoricalStatsPerCharacter : IDeepEquatable<DestinyHistoricalStatsPerCharacter>
{
    [JsonPropertyName("characterId")]
    public long CharacterId { get; set; }

    [JsonPropertyName("deleted")]
    public bool Deleted { get; set; }

    [JsonPropertyName("results")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod> Results { get; set; }

    [JsonPropertyName("merged")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod Merged { get; set; }

    public bool DeepEquals(DestinyHistoricalStatsPerCharacter? other)
    {
        return other is not null &&
               CharacterId == other.CharacterId &&
               Deleted == other.Deleted &&
               Results.DeepEqualsDictionary(other.Results) &&
               (Merged is not null ? Merged.DeepEquals(other.Merged) : other.Merged is null);
    }
}