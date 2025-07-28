namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyPostGameCarnageReportExtendedData
{
    /// <summary>
    ///     List of weapons and their perspective values.
    /// </summary>
    [JsonPropertyName("weapons")]
    public Destiny.HistoricalStats.DestinyHistoricalWeaponStats[]? Weapons { get; set; }

    /// <summary>
    ///     Collection of stats for the player in this activity.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue>? Values { get; set; }
}
