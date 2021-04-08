using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.StatGroups
{
    public class StatGroupInterpolation : IDeepEquatable<StatGroupInterpolation>
    {
        public int Value { get; init; }
        public int Weight { get; init; }

        [JsonConstructor]
        internal StatGroupInterpolation(int value, int weight)
        {
            Value = value;
            Weight = weight;
        }

        public bool DeepEquals(StatGroupInterpolation other)
        {
            return other != null &&
                   Value == other.Value &&
                   Weight == other.Weight;
        }
    }
}
