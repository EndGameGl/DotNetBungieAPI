namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyPostGameCarnageReportExtendedData : IDeepEquatable<DestinyPostGameCarnageReportExtendedData>
{
    /// <summary>
    ///     List of weapons and their perspective values.
    /// </summary>
    [JsonPropertyName("weapons")]
    public List<Destiny.HistoricalStats.DestinyHistoricalWeaponStats> Weapons { get; set; }

    /// <summary>
    ///     Collection of stats for the player in this activity.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue> Values { get; set; }

    public bool DeepEquals(DestinyPostGameCarnageReportExtendedData? other)
    {
        return other is not null &&
               Weapons.DeepEqualsList(other.Weapons) &&
               Values.DeepEqualsDictionary(other.Values);
    }
}