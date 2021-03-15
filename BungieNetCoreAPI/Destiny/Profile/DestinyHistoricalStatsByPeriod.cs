using NetBungieAPI.Destiny.Profile.Components.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile
{
    public class DestinyHistoricalStatsByPeriod
    {
        public ReadOnlyDictionary<string, DestinyHistoricalStatsValue> AllTime { get; }
        public ReadOnlyDictionary<string, DestinyHistoricalStatsValue> AllTimeTier1 { get; }
        public ReadOnlyDictionary<string, DestinyHistoricalStatsValue> AllTimeTier2 { get; }
        public ReadOnlyDictionary<string, DestinyHistoricalStatsValue> AllTimeTier3 { get; }
        public ReadOnlyCollection<DestinyHistoricalStatsPeriodGroup> Daily { get; }
        public ReadOnlyCollection<DestinyHistoricalStatsPeriodGroup> Monthly { get; }

        [JsonConstructor]
        internal DestinyHistoricalStatsByPeriod(
            Dictionary<string, DestinyHistoricalStatsValue> allTime,
            Dictionary<string, DestinyHistoricalStatsValue> allTimeTier1,
            Dictionary<string, DestinyHistoricalStatsValue> allTimeTier2,
            Dictionary<string, DestinyHistoricalStatsValue> allTimeTier3,
            DestinyHistoricalStatsPeriodGroup[] daily,
            DestinyHistoricalStatsPeriodGroup[] monthly)
        {
            AllTime = allTime.AsReadOnlyDictionaryOrEmpty();
            AllTimeTier1 = allTimeTier1.AsReadOnlyDictionaryOrEmpty();
            AllTimeTier2 = allTimeTier2.AsReadOnlyDictionaryOrEmpty();
            AllTimeTier3 = allTimeTier3.AsReadOnlyDictionaryOrEmpty();
            Daily = daily.AsReadOnlyOrEmpty();
            Monthly = monthly.AsReadOnlyOrEmpty();
        }
    }
}
