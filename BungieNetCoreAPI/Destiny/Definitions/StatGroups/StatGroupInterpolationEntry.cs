using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.StatGroups
{
    public class StatGroupInterpolationEntry
    {
        public int Value { get; }
        public int Weight { get; }

        [JsonConstructor]
        private StatGroupInterpolationEntry(int value, int weight)
        {
            Value = value;
            Weight = weight;
        }
    }
}
