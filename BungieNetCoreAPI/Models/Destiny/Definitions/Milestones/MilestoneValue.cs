using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Milestones
{
    public class MilestoneValue : IDeepEquatable<MilestoneValue>
    {
        public string Key { get; init; }
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        [JsonConstructor]
        internal MilestoneValue(string key, DestinyDisplayPropertiesDefinition displayProperties)
        {
            Key = key;
            DisplayProperties = displayProperties;
        }

        public bool DeepEquals(MilestoneValue other)
        {
            return other != null &&
                   Key == other.Key &&
                   DisplayProperties.DeepEquals(other.DisplayProperties);
        }
    }
}
