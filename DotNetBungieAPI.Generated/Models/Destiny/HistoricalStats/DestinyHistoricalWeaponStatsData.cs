namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyHistoricalWeaponStatsData
{
    /// <summary>
    ///     List of weapons and their perspective values.
    /// </summary>
    [JsonPropertyName("weapons")]
    public List<Destiny.HistoricalStats.DestinyHistoricalWeaponStats> Weapons { get; set; }
}
