using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public sealed class DestinyPostGameCarnageReportEntry
{

    [JsonPropertyName("standing")]
    public int Standing { get; init; }

    [JsonPropertyName("score")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValue Score { get; init; }

    [JsonPropertyName("player")]
    public Destiny.HistoricalStats.DestinyPlayer Player { get; init; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; init; }

    [JsonPropertyName("values")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue> Values { get; init; }

    [JsonPropertyName("extended")]
    public Destiny.HistoricalStats.DestinyPostGameCarnageReportExtendedData Extended { get; init; }
}
