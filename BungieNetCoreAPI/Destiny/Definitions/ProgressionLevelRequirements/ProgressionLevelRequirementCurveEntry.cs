using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.ProgressionLevelRequirements
{
    public class ProgressionLevelRequirementCurveEntry
    {
        public double Value { get; }
        public double Weight { get; }

        [JsonConstructor]
        private ProgressionLevelRequirementCurveEntry(double value, double weight)
        {
            Value = value;
            Weight = weight;
        }
    }
}
