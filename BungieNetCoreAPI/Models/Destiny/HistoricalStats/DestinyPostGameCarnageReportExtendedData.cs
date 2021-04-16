using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyPostGameCarnageReportExtendedData
    {
        [JsonPropertyName("weapons")]
        public ReadOnlyCollection<DestinyHistoricalWeaponStats> Weapons { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyHistoricalWeaponStats>();

        [JsonPropertyName("values")]
        public ReadOnlyDictionary<string, DestinyHistoricalStatsValue> Values { get; init; } =
            Defaults.EmptyReadOnlyDictionary<string, DestinyHistoricalStatsValue>();
    }
}
