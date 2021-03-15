using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyHistoricalStatsValue
    {
        public string StatId { get; }
        public DestinyHistoricalStatsValuePair BasicValue { get; }
        public DestinyHistoricalStatsValuePair PerGameAverage { get; }
        public DestinyHistoricalStatsValuePair WeightedValue { get; }
        public long? ActivityId { get; }

        [JsonConstructor]
        internal DestinyHistoricalStatsValue(string statId, DestinyHistoricalStatsValuePair basic, DestinyHistoricalStatsValuePair pga,
            DestinyHistoricalStatsValuePair weighted, long? activityId)
        {
            StatId = statId;
            BasicValue = basic;
            PerGameAverage = pga;
            WeightedValue = weighted;
            ActivityId = activityId;
        }
    }
}
