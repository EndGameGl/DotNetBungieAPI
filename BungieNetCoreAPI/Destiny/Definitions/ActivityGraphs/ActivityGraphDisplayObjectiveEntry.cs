using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.ActivityGraphs
{
    public class ActivityGraphDisplayObjectiveEntry
    {
        public uint Id { get; }
        public DefinitionHashPointer<DestinyObjectiveDefinition> Objective { get; }

        [JsonConstructor]
        private ActivityGraphDisplayObjectiveEntry(uint id, uint objectiveHash)
        {
            Id = id;
            Objective = new DefinitionHashPointer<DestinyObjectiveDefinition>(objectiveHash, "DestinyObjectiveDefinition");
        }
    }
}
