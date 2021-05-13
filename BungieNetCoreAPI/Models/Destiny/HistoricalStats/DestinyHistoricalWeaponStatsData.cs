using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyHistoricalWeaponStatsData
    {
        /// <summary>
        /// List of weapons and their perspective values.
        /// </summary>
        [JsonPropertyName("weapons")]
        public ReadOnlyCollection<DestinyHistoricalWeaponStats> Weapons { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyHistoricalWeaponStats>();
    }
}