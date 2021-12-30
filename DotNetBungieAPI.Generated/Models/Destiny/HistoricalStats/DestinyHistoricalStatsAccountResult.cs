using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public sealed class DestinyHistoricalStatsAccountResult
{

    [JsonPropertyName("mergedDeletedCharacters")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsWithMerged MergedDeletedCharacters { get; init; }

    [JsonPropertyName("mergedAllCharacters")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsWithMerged MergedAllCharacters { get; init; }

    [JsonPropertyName("characters")]
    public List<Destiny.HistoricalStats.DestinyHistoricalStatsPerCharacter> Characters { get; init; }
}
