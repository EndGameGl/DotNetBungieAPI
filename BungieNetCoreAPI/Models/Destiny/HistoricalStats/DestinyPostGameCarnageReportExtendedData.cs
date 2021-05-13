using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyPostGameCarnageReportExtendedData
    {
        /// <summary>
        /// List of weapons and their perspective values.
        /// </summary>
        [JsonPropertyName("weapons")]
        public ReadOnlyCollection<DestinyHistoricalWeaponStats> Weapons { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyHistoricalWeaponStats>();

        /// <summary>
        /// Collection of stats for the player in this activity.
        /// </summary>
        [JsonPropertyName("values")]
        public ReadOnlyDictionary<string, DestinyHistoricalStatsValue> Values { get; init; } =
            Defaults.EmptyReadOnlyDictionary<string, DestinyHistoricalStatsValue>();
    }
}