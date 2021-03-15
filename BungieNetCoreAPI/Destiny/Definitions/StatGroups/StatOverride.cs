using NetBungieAPI.Destiny.Definitions.Stats;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.StatGroups
{
    public class StatOverride : IDeepEquatable<StatOverride>
    {
        public DefinitionHashPointer<DestinyStatDefinition> Stat { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }

        [JsonConstructor]
        internal StatOverride(uint statHash, DestinyDefinitionDisplayProperties displayProperties)
        {
            Stat = new DefinitionHashPointer<DestinyStatDefinition>(statHash, DefinitionsEnum.DestinyStatDefinition);
            DisplayProperties = displayProperties;
        }

        public bool DeepEquals(StatOverride other)
        {
            return other != null &&
                   Stat.DeepEquals(other.Stat) &&
                   DisplayProperties.DeepEquals(other.DisplayProperties);
        }
    }
}
