namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats.Definitions;

public class DestinyHistoricalStatsDefinition
{
    /// <summary>
    ///     Unique programmer friendly ID for this stat
    /// </summary>
    [JsonPropertyName("statId")]
    public string StatId { get; set; }

    /// <summary>
    ///     Statistic group
    /// </summary>
    [JsonPropertyName("group")]
    public Destiny.HistoricalStats.Definitions.DestinyStatsGroupType Group { get; set; }

    /// <summary>
    ///     Time periods the statistic covers
    /// </summary>
    [JsonPropertyName("periodTypes")]
    public List<Destiny.HistoricalStats.Definitions.PeriodType> PeriodTypes { get; set; }

    /// <summary>
    ///     Game modes where this statistic can be reported.
    /// </summary>
    [JsonPropertyName("modes")]
    public List<Destiny.HistoricalStats.Definitions.DestinyActivityModeType> Modes { get; set; }

    /// <summary>
    ///     Category for the stat.
    /// </summary>
    [JsonPropertyName("category")]
    public Destiny.HistoricalStats.Definitions.DestinyStatsCategoryType Category { get; set; }

    /// <summary>
    ///     Display name
    /// </summary>
    [JsonPropertyName("statName")]
    public string StatName { get; set; }

    /// <summary>
    ///     Display name abbreviated
    /// </summary>
    [JsonPropertyName("statNameAbbr")]
    public string StatNameAbbr { get; set; }

    /// <summary>
    ///     Description of a stat if applicable.
    /// </summary>
    [JsonPropertyName("statDescription")]
    public string StatDescription { get; set; }

    /// <summary>
    ///     Unit, if any, for the statistic
    /// </summary>
    [JsonPropertyName("unitType")]
    public Destiny.HistoricalStats.Definitions.UnitType UnitType { get; set; }

    /// <summary>
    ///     Optional URI to an icon for the statistic
    /// </summary>
    [JsonPropertyName("iconImage")]
    public string IconImage { get; set; }

    /// <summary>
    ///     Optional icon for the statistic
    /// </summary>
    [JsonPropertyName("mergeMethod")]
    public int MergeMethod { get; set; }

    /// <summary>
    ///     Localized Unit Name for the stat.
    /// </summary>
    [JsonPropertyName("unitLabel")]
    public string UnitLabel { get; set; }

    /// <summary>
    ///     Weight assigned to this stat indicating its relative impressiveness.
    /// </summary>
    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    /// <summary>
    ///     The tier associated with this medal - be it implicitly or explicitly.
    /// </summary>
    [JsonPropertyName("medalTierHash")]
    public uint MedalTierHash { get; set; }
}
