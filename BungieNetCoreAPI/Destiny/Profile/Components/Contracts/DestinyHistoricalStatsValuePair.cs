using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyHistoricalStatsValuePair
    {
        public double Value { get; }
        public string DisplayValue { get; }

        [JsonConstructor]
        internal DestinyHistoricalStatsValuePair(double value, string displayValue)
        {
            Value = value;
            DisplayValue = displayValue;
        }
    }
}
