namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyHistoricalStatsAccountResult
{
    [JsonPropertyName("mergedDeletedCharacters")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsWithMerged? MergedDeletedCharacters { get; set; }

    [JsonPropertyName("mergedAllCharacters")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsWithMerged? MergedAllCharacters { get; set; }

    [JsonPropertyName("characters")]
    public List<Destiny.HistoricalStats.DestinyHistoricalStatsPerCharacter> Characters { get; set; }
}
