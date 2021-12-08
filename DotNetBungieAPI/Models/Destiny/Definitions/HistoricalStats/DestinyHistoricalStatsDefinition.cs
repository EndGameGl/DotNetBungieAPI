using DotNetBungieAPI.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.ActivityModes;
using DotNetBungieAPI.Models.Destiny.Definitions.MedalTiers;

namespace DotNetBungieAPI.Models.Destiny.Definitions.HistoricalStats;

[DestinyDefinition(DefinitionsEnum.DestinyHistoricalStatsDefinition)]
public sealed record DestinyHistoricalStatsDefinition
{
    /// <summary>
    ///     Unique programmer friendly ID for this stat
    /// </summary>
    [JsonPropertyName("statId")]
    public string StatId { get; init; }

    /// <summary>
    ///     Statistic group
    /// </summary>
    [JsonPropertyName("group")]
    public DestinyStatsGroupType Group { get; init; }

    /// <summary>
    ///     Time periods the statistic covers
    /// </summary>
    [JsonPropertyName("periodTypes")]
    public ReadOnlyCollection<PeriodType> PeriodTypes { get; init; } =
        ReadOnlyCollections<PeriodType>.Empty;

    /// <summary>
    ///     Game modes where this statistic can be reported.
    /// </summary>
    [JsonPropertyName("modes")]
    public ReadOnlyCollection<DestinyActivityModeType> Modes { get; init; } =
        ReadOnlyCollections<DestinyActivityModeType>.Empty;

    /// <summary>
    ///     Category for the stat.
    /// </summary>
    [JsonPropertyName("category")]
    public DestinyStatsCategoryType Category { get; init; }

    /// <summary>
    ///     Display name
    /// </summary>
    [JsonPropertyName("statName")]
    public string StatName { get; init; }

    /// <summary>
    ///     Display name abbreviated
    /// </summary>
    [JsonPropertyName("statNameAbbr")]
    public string StatNameAbbr { get; init; }

    /// <summary>
    ///     Description of a stat if applicable.
    /// </summary>
    [JsonPropertyName("statDescription")]
    public string StatDescription { get; init; }

    /// <summary>
    ///     Unit, if any, for the statistic
    /// </summary>
    [JsonPropertyName("unitType")]
    public UnitType UnitType { get; init; }

    /// <summary>
    ///     Optional URI to an icon for the statistic
    /// </summary>
    [JsonPropertyName("iconImage")]
    public BungieNetResource IconImage { get; init; }

    /// <summary>
    ///     Optional icon for the statistic
    /// </summary>
    [JsonPropertyName("mergeMethod")]
    public DestinyStatsMergeMethod? MergeMethod { get; init; }

    /// <summary>
    ///     Localized Unit Name for the stat.
    /// </summary>
    [JsonPropertyName("unitLabel")]
    public string UnitLabel { get; init; }

    /// <summary>
    ///     Weight assigned to this stat indicating its relative impressiveness.
    /// </summary>
    [JsonPropertyName("weight")]
    public int Weight { get; init; }

    /// <summary>
    ///     The tier associated with this medal - be it implicitly or explicitly.
    /// </summary>
    [JsonPropertyName("medalTierHash")]
    public DefinitionHashPointer<DestinyMedalTierDefinition> MedalTier { get; init; } =
        DefinitionHashPointer<DestinyMedalTierDefinition>.Empty;
}