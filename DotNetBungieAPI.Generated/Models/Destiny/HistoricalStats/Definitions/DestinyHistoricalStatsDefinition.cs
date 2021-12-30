using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats.Definitions;

public sealed class DestinyHistoricalStatsDefinition
{

    [JsonPropertyName("statId")]
    public string StatId { get; init; }

    [JsonPropertyName("group")]
    public Destiny.HistoricalStats.Definitions.DestinyStatsGroupType Group { get; init; }

    [JsonPropertyName("periodTypes")]
    public List<Destiny.HistoricalStats.Definitions.PeriodType> PeriodTypes { get; init; }

    [JsonPropertyName("modes")]
    public List<Destiny.HistoricalStats.Definitions.DestinyActivityModeType> Modes { get; init; }

    [JsonPropertyName("category")]
    public Destiny.HistoricalStats.Definitions.DestinyStatsCategoryType Category { get; init; }

    [JsonPropertyName("statName")]
    public string StatName { get; init; }

    [JsonPropertyName("statNameAbbr")]
    public string StatNameAbbr { get; init; }

    [JsonPropertyName("statDescription")]
    public string StatDescription { get; init; }

    [JsonPropertyName("unitType")]
    public Destiny.HistoricalStats.Definitions.UnitType UnitType { get; init; }

    [JsonPropertyName("iconImage")]
    public string IconImage { get; init; }

    [JsonPropertyName("mergeMethod")]
    public int? MergeMethod { get; init; }

    [JsonPropertyName("unitLabel")]
    public string UnitLabel { get; init; }

    [JsonPropertyName("weight")]
    public int Weight { get; init; }

    [JsonPropertyName("medalTierHash")]
    public uint? MedalTierHash { get; init; }
}
