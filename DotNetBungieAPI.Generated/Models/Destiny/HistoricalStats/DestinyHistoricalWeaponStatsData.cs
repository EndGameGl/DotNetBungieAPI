namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyHistoricalWeaponStatsData : IDeepEquatable<DestinyHistoricalWeaponStatsData>
{
    /// <summary>
    ///     List of weapons and their perspective values.
    /// </summary>
    [JsonPropertyName("weapons")]
    public List<Destiny.HistoricalStats.DestinyHistoricalWeaponStats> Weapons { get; set; }

    public bool DeepEquals(DestinyHistoricalWeaponStatsData? other)
    {
        return other is not null &&
               Weapons.DeepEqualsList(other.Weapons);
    }
}