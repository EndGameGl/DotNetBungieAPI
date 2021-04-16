using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyPostGameCarnageReportEntry
    {
        [JsonPropertyName("standing")]
        public int Standing { get; init; }
        [JsonPropertyName("score")]
        public DestinyHistoricalStatsValue Score { get; init; }
        [JsonPropertyName("player")]
        public DestinyPlayer Player { get; init; }
        [JsonPropertyName("characterId")]
        public long CharacterId { get; init; }
        [JsonPropertyName("values")]
        public ReadOnlyDictionary<string, DestinyHistoricalStatsValue> Values { get; init; } =
            Defaults.EmptyReadOnlyDictionary<string, DestinyHistoricalStatsValue>();
        [JsonPropertyName("extended")]
        public DestinyPostGameCarnageReportExtendedData ExtendedData { get; init; }
    }
}
