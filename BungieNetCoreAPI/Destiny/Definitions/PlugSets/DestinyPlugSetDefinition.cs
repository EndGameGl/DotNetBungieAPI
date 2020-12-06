using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.PlugSets
{
    [DestinyDefinition("DestinyPlugSetDefinition")]
    public class DestinyPlugSetDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public bool IsFakePlugSet { get; }
        public List<PlugSetReusablePlugItem> ReusablePlugItems { get; }

        [JsonConstructor]
        private DestinyPlugSetDefinition(DestinyDefinitionDisplayProperties displayProperties, bool isFakePlugSet, List<PlugSetReusablePlugItem> reusablePlugItems,
            bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            IsFakePlugSet = isFakePlugSet;
            ReusablePlugItems = reusablePlugItems;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
