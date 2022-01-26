namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyHistoricalStatsAccountResult : IDeepEquatable<DestinyHistoricalStatsAccountResult>
{
    [JsonPropertyName("mergedDeletedCharacters")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsWithMerged MergedDeletedCharacters { get; set; }

    [JsonPropertyName("mergedAllCharacters")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsWithMerged MergedAllCharacters { get; set; }

    [JsonPropertyName("characters")]
    public List<Destiny.HistoricalStats.DestinyHistoricalStatsPerCharacter> Characters { get; set; }

    public bool DeepEquals(DestinyHistoricalStatsAccountResult? other)
    {
        return other is not null &&
               (MergedDeletedCharacters is not null ? MergedDeletedCharacters.DeepEquals(other.MergedDeletedCharacters) : other.MergedDeletedCharacters is null) &&
               (MergedAllCharacters is not null ? MergedAllCharacters.DeepEquals(other.MergedAllCharacters) : other.MergedAllCharacters is null) &&
               Characters.DeepEqualsList(other.Characters);
    }
}