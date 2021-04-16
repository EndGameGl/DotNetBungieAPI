using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyHistoricalWeaponStatsData
    {
        [JsonPropertyName("weapons")]
        public ReadOnlyCollection<DestinyHistoricalWeaponStats> Weapons { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyHistoricalWeaponStats>();
    }
}
