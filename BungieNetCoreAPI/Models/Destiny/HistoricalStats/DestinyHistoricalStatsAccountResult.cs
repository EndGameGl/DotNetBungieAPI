using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyHistoricalStatsAccountResult
    {
        [JsonPropertyName("mergedDeletedCharacters")]
        public DestinyHistoricalStatsWithMerged MergedDeletedCharacters { get; init; }
        [JsonPropertyName("mergedAllCharacters")]
        public DestinyHistoricalStatsWithMerged MergedAllCharacters { get; init; }

        [JsonPropertyName("characters")]
        public ReadOnlyCollection<DestinyHistoricalStatsPerCharacter> Characters { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyHistoricalStatsPerCharacter>();
    }
}
