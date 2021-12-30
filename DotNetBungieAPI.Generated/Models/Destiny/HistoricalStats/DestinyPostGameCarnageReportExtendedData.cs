using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public sealed class DestinyPostGameCarnageReportExtendedData
{

    [JsonPropertyName("weapons")]
    public List<Destiny.HistoricalStats.DestinyHistoricalWeaponStats> Weapons { get; init; }

    [JsonPropertyName("values")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue> Values { get; init; }
}
