namespace DotNetBungieAPI.Models.Destiny.HistoricalStats;

public sealed class DestinyHistoricalWeaponStatsData
{
    /// <summary>
    ///     List of weapons and their perspective values.
    /// </summary>
    [JsonPropertyName("weapons")]
    public Destiny.HistoricalStats.DestinyHistoricalWeaponStats[]? Weapons { get; init; }
}
