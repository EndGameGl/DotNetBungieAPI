using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.ProgressionLevelRequirements
{
    public class ProgressionLevelRequirementCurveEntry : IDeepEquatable<ProgressionLevelRequirementCurveEntry>
    {
        public double Value { get; }
        public double Weight { get; }

        [JsonConstructor]
        internal ProgressionLevelRequirementCurveEntry(double value, double weight)
        {
            Value = value;
            Weight = weight;
        }

        public bool DeepEquals(ProgressionLevelRequirementCurveEntry other)
        {
            return other != null &&
                   Value == other.Value &&
                   Weight == other.Weight;
        }
    }
}
