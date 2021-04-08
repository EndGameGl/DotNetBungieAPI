using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyHistoricalStatsPeriodGroup
    {
        public DateTime Period { get; init; }
        public DestinyHistoricalStatsActivity ActivityDetails { get; init; }
        public ReadOnlyDictionary<string, DestinyHistoricalStatsValue> Values { get; init; }

        [JsonConstructor]
        internal DestinyHistoricalStatsPeriodGroup(DateTime period, DestinyHistoricalStatsActivity activityDetails, 
            Dictionary<string, DestinyHistoricalStatsValue> values)
        {
            Period = period;
            ActivityDetails = activityDetails;
            Values = values.AsReadOnlyDictionaryOrEmpty();
        }
    }
}
