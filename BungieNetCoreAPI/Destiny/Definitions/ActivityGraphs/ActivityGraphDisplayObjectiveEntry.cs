using BungieNetCoreAPI.Destiny.Definitions.Objectives;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.ActivityGraphs
{
    /// <summary>
    /// When a Graph needs to show active Objectives, this defines those objectives as well as an identifier.
    /// </summary>
    public class ActivityGraphDisplayObjectiveEntry : IDeepEquatable<ActivityGraphDisplayObjectiveEntry>
    {
        /// <summary>
        /// This field is apparently something that CUI uses to manually wire up objectives to display info.
        /// </summary>
        public uint Id { get; }
        /// <summary>
        /// The objective being shown on the map.
        /// </summary>
        public DefinitionHashPointer<DestinyObjectiveDefinition> Objective { get; }

        [JsonConstructor]
        internal ActivityGraphDisplayObjectiveEntry(uint id, uint objectiveHash)
        {
            Id = id;
            Objective = new DefinitionHashPointer<DestinyObjectiveDefinition>(objectiveHash, DefinitionsEnum.DestinyObjectiveDefinition);
        }

        public bool DeepEquals(ActivityGraphDisplayObjectiveEntry other)
        {
            return other != null &&
                Id == other.Id &&
                Objective.DeepEquals(other.Objective);
        }
    }
}
