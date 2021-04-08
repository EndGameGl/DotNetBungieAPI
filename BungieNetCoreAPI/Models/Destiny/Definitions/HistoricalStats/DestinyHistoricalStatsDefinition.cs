using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModes;
using NetBungieAPI.Models.Destiny.Definitions.MedalTiers;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.HistoricalStats
{
    [DestinyDefinition(DefinitionsEnum.DestinyHistoricalStatsDefinition, DefinitionSources.BungieNet | DefinitionSources.SQLite, DefinitionKeyType.String)]
    public sealed record DestinyHistoricalStatsDefinition
    {
        [JsonPropertyName("statId")]
        public string StatId { get; init; }
        [JsonPropertyName("group")]
        public DestinyStatsGroupType Group { get; init; }
        [JsonPropertyName("periodTypes")]
        public ReadOnlyCollection<PeriodType> PeriodTypes { get; init; } = Defaults.EmptyReadOnlyCollection<PeriodType>();
        [JsonPropertyName("modes")]
        public ReadOnlyCollection<DestinyActivityModeType> Modes { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyActivityModeType>();
        [JsonPropertyName("category")]
        public DestinyStatsCategoryType Category { get; init; }
        [JsonPropertyName("statName")]
        public string StatName { get; init; }
        [JsonPropertyName("statNameAbbr")]
        public string StatNameAbbr { get; init; }
        [JsonPropertyName("statDescription")]
        public string StatDescription { get; init; }
        [JsonPropertyName("unitType")]
        public UnitType UnitType { get; init; }
        [JsonPropertyName("iconImage")]
        public string IconImage { get; init; }
        [JsonPropertyName("mergeMethod")]
        public DestinyStatsMergeMethod? MergeMethod { get; init; }
        [JsonPropertyName("unitLabel")]
        public string UnitLabel { get; init; }
        [JsonPropertyName("weight")]
        public int Weight { get; init; }
        [JsonPropertyName("medalTierHash")]
        public DefinitionHashPointer<DestinyMedalTierDefinition> MedalTier { get; init; } = DefinitionHashPointer<DestinyMedalTierDefinition>.Empty;
    }
}
