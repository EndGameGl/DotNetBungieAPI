using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.PlugSets
{
    [DestinyDefinition(type: DefinitionsEnum.DestinyPlugSetDefinition, presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyPlugSetDefinition : IDestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public bool IsFakePlugSet { get; }
        public List<PlugSetReusablePlugItem> ReusablePlugItems { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyPlugSetDefinition(DestinyDefinitionDisplayProperties displayProperties, bool isFakePlugSet, List<PlugSetReusablePlugItem> reusablePlugItems,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            IsFakePlugSet = isFakePlugSet;
            ReusablePlugItems = reusablePlugItems;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
