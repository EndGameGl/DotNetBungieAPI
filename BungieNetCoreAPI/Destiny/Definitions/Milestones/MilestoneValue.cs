using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Milestones
{
    public class MilestoneValue : IDeepEquatable<MilestoneValue>
    {
        public string Key { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }

        [JsonConstructor]
        internal MilestoneValue(string key, DestinyDefinitionDisplayProperties displayProperties)
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
