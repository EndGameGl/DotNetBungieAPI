using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyHistoricalStatsWithMerged
    {
        public ReadOnlyDictionary<string, DestinyHistoricalStatsByPeriod> Results { get; init; }
        public DestinyHistoricalStatsByPeriod Merged { get; init; }

        [JsonConstructor]
        internal DestinyHistoricalStatsWithMerged(Dictionary<string, DestinyHistoricalStatsByPeriod> results, DestinyHistoricalStatsByPeriod merged)
        {
            Results = results.AsReadOnlyDictionaryOrEmpty();
            Merged = merged;
        }
    }
}
