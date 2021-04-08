using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyHistoricalStatsValue
    {
        public string StatId { get; init; }
        public DestinyHistoricalStatsValuePair BasicValue { get; init; }
        public DestinyHistoricalStatsValuePair PerGameAverage { get; init; }
        public DestinyHistoricalStatsValuePair WeightedValue { get; init; }
        public long? ActivityId { get; init; }

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
