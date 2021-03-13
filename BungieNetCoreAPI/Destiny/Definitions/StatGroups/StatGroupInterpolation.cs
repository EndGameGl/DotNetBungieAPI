using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.StatGroups
{
    public class StatGroupInterpolation : IDeepEquatable<StatGroupInterpolation>
    {
        public int Value { get; }
        public int Weight { get; }

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
