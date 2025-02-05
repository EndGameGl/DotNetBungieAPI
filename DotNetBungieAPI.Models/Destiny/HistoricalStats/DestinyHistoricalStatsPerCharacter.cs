namespace DotNetBungieAPI.Models.Destiny.HistoricalStats;

public sealed record DestinyHistoricalStatsPerCharacter
{
    [JsonPropertyName("characterId")]
    public long CharacterId { get; init; }

    [JsonPropertyName("deleted")]
    public bool IsDeleted { get; init; }

    [JsonPropertyName("results")]
    public ReadOnlyDictionary<string, DestinyHistoricalStatsByPeriod> Results { get; init; } =
        ReadOnlyDictionary<string, DestinyHistoricalStatsByPeriod>.Empty;

    [JsonPropertyName("merged")]
    public DestinyHistoricalStatsByPeriod Merged { get; init; }
}
