using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public sealed class DestinyHistoricalWeaponStatsData
{

    [JsonPropertyName("weapons")]
    public List<Destiny.HistoricalStats.DestinyHistoricalWeaponStats> Weapons { get; init; }
}
