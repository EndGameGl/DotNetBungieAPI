namespace DotNetBungieAPI.Models.Destiny.HistoricalStats;

public sealed record DestinyPostGameCarnageReportExtendedData
{
    /// <summary>
    ///     List of weapons and their perspective values.
    /// </summary>
    [JsonPropertyName("weapons")]
    public ReadOnlyCollection<DestinyHistoricalWeaponStats> Weapons { get; init; } =
        ReadOnlyCollection<DestinyHistoricalWeaponStats>.Empty;

    /// <summary>
    ///     Collection of stats for the player in this activity.
    /// </summary>
    [JsonPropertyName("values")]
    public ReadOnlyDictionary<string, DestinyHistoricalStatsValue> Values { get; init; } =
        ReadOnlyDictionary<string, DestinyHistoricalStatsValue>.Empty;
}
