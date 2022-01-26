namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyHistoricalWeaponStats : IDeepEquatable<DestinyHistoricalWeaponStats>
{
    /// <summary>
    ///     The hash ID of the item definition that describes the weapon.
    /// </summary>
    [JsonPropertyName("referenceId")]
    public uint ReferenceId { get; set; }

    /// <summary>
    ///     Collection of stats for the period.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue> Values { get; set; }

    public bool DeepEquals(DestinyHistoricalWeaponStats? other)
    {
        return other is not null &&
               ReferenceId == other.ReferenceId &&
               Values.DeepEqualsDictionary(other.Values);
    }
}