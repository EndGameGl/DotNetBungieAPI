using BungieNetCoreAPI.Destiny.Definitions.Progressions;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.ActivityGraphs
{
    public class ActivityGraphDisplayProgressionEntry
    {
        public uint Id { get; }
        public DefinitionHashPointer<DestinyProgressionDefinition> Progression { get; }

        [JsonConstructor]
        private ActivityGraphDisplayProgressionEntry(uint id, uint progressionHash)
        {
            Id = id;
            Progression = new DefinitionHashPointer<DestinyProgressionDefinition>(progressionHash, DefinitionsEnum.DestinyProgressionDefinition);
        }
    }
}
