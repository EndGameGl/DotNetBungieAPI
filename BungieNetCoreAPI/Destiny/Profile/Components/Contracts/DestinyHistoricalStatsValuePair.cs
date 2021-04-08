using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyHistoricalStatsValuePair
    {
        public double Value { get; init; }
        public string DisplayValue { get; init; }

        [JsonConstructor]
        internal DestinyHistoricalStatsValuePair(double value, string displayValue)
        {
            Value = value;
            DisplayValue = displayValue;
        }
    }
}
