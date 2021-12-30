using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public sealed class DestinyHistoricalWeaponStats
{

    /// <summary>
    ///     The hash ID of the item definition that describes the weapon.
    /// </summary>
    [JsonPropertyName("referenceId")]
    public uint ReferenceId { get; init; }

    /// <summary>
    ///     Collection of stats for the period.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue> Values { get; init; }
}
