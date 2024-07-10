namespace DotNetBungieAPI.Models.Destiny.HistoricalStats;

public sealed record DestinyHistoricalStatsAccountResult
{
    [JsonPropertyName("mergedDeletedCharacters")]
    public DestinyHistoricalStatsWithMerged MergedDeletedCharacters { get; init; }

    [JsonPropertyName("mergedAllCharacters")]
    public DestinyHistoricalStatsWithMerged MergedAllCharacters { get; init; }

    [JsonPropertyName("characters")]
    public ReadOnlyCollection<DestinyHistoricalStatsPerCharacter> Characters { get; init; } =
        ReadOnlyCollections<DestinyHistoricalStatsPerCharacter>.Empty;
}
