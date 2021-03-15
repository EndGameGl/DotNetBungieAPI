using NetBungieAPI.Destiny.Definitions.Progressions;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.ActivityGraphs
{
    /// <summary>
    /// When a Graph needs to show active Progressions, this defines those objectives as well as an identifier.
    /// </summary>
    public class ActivityGraphDisplayProgressionEntry : IDeepEquatable<ActivityGraphDisplayProgressionEntry>
    {
        public uint Id { get; }
        public DefinitionHashPointer<DestinyProgressionDefinition> Progression { get; }

        [JsonConstructor]
        internal ActivityGraphDisplayProgressionEntry(uint id, uint progressionHash)
        {
            Id = id;
            Progression = new DefinitionHashPointer<DestinyProgressionDefinition>(progressionHash, DefinitionsEnum.DestinyProgressionDefinition);
        }

        public bool DeepEquals(ActivityGraphDisplayProgressionEntry other)
        {
            return other != null &&
                Id == other.Id &&
                Progression.DeepEquals(other.Progression);
        }
    }
}
