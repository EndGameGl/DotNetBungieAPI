using NetBungieAPI.Attributes;
using NetBungieAPI.Destiny.Definitions.ActivityModes;
using NetBungieAPI.Destiny.Definitions.MedalTiers;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Models.Destiny.Definitions.HistoricalStats
{
    [DestinyDefinition(DefinitionsEnum.DestinyHistoricalStatsDefinition, DefinitionSources.BungieNet | DefinitionSources.SQLite, DefinitionKeyType.String)]
    public class DestinyHistoricalStatsDefinition
    {
        public string StatId { get; init; }
        public DestinyStatsGroupType Group { get; init; }
        public ReadOnlyCollection<PeriodType> PeriodTypes { get; init; }
        public ReadOnlyCollection<DestinyActivityModeType> Modes { get; init; }
        public DestinyStatsCategoryType Category { get; init; }
        public string StatName { get; init; }
        public string StatNameAbbr { get; init; }
        public string StatDescription { get; init; }
        public UnitType UnitType { get; init; }
        public string IconImage { get; init; }
        public DestinyStatsMergeMethod? MergeMethod { get; init; }
        public string UnitLabel { get; init; }
        public int Weight { get; init; }
        public DefinitionHashPointer<DestinyMedalTierDefinition> MedalTier { get; init; }

        [JsonConstructor]
        internal DestinyHistoricalStatsDefinition(string statId, DestinyStatsGroupType group, PeriodType[] periodTypes, DestinyActivityModeType[] modes,
            DestinyStatsCategoryType category, string statName, string statNameAbbr, string statDescription, UnitType unitType, string iconImage,
            DestinyStatsMergeMethod? mergeMethod, string unitLabel, int weight, uint? medalTierHash)
        {
            StatId = statId;
            Group = group;
            PeriodTypes = periodTypes.AsReadOnlyOrEmpty();
            Modes = modes.AsReadOnlyOrEmpty();
            Category = category;
            StatName = statName;
            StatNameAbbr = statNameAbbr;
            StatDescription = statDescription;
            UnitType = unitType;
            IconImage = iconImage;
            MergeMethod = mergeMethod;
            UnitLabel = unitLabel;
            Weight = weight;
            MedalTier = new DefinitionHashPointer<DestinyMedalTierDefinition>(medalTierHash, DefinitionsEnum.DestinyMedalTierDefinition);
        }
    }
}
