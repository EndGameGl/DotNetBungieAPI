using NetBungieAPI.Attributes;
using NetBungieAPI.Destiny.Definitions.ActivityModes;
using NetBungieAPI.Destiny.Definitions.MedalTiers;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.HistoricalStats
{
    [DestinyDefinition(DefinitionsEnum.DestinyHistoricalStatsDefinition, DefinitionSources.BungieNet | DefinitionSources.SQLite, DefinitionKeyType.String)]
    public class DestinyHistoricalStatsDefinition
    {
        public string StatId { get; }
        public DestinyStatsGroupType Group { get; }
        public ReadOnlyCollection<PeriodType> PeriodTypes { get; }
        public ReadOnlyCollection<DestinyActivityModeType> Modes { get; }
        public DestinyStatsCategoryType Category { get; }
        public string StatName { get; }
        public string StatNameAbbr { get; }
        public string StatDescription { get; }
        public UnitType UnitType { get; }
        public string IconImage { get; }
        public DestinyStatsMergeMethod? MergeMethod { get; }
        public string UnitLabel { get; }
        public int Weight { get; }
        public DefinitionHashPointer<DestinyMedalTierDefinition> MedalTier { get; }

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
