using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Profile.Components.Contracts
{
    public class DestinyHistoricalStatsWithMerged
    {
        public ReadOnlyDictionary<string, DestinyHistoricalStatsByPeriod> Results { get; }
        public DestinyHistoricalStatsByPeriod Merged { get; }

        [JsonConstructor]
        internal DestinyHistoricalStatsWithMerged(Dictionary<string, DestinyHistoricalStatsByPeriod> results, DestinyHistoricalStatsByPeriod merged)
        {
            Results = results.AsReadOnlyDictionaryOrEmpty();
            Merged = merged;
        }
    }
}
