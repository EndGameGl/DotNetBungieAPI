using BungieNetCoreAPI.Destiny.Definitions.ActivityGraphs;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Activities
{
    /// <summary>
    /// Destinations and Activities may have default Activity Graphs that should be shown when you bring up the Director and are playing in either.
    /// <para/>
    /// This contract defines the graph referred to and the gating for when it is relevant.
    /// </summary>
    public class ActivityGraphListEntry : IDeepEquatable<ActivityGraphListEntry>
    {
        public DefinitionHashPointer<DestinyActivityGraphDefinition> ActivityGraph { get; }

        [JsonConstructor]
        internal ActivityGraphListEntry(uint activityGraphHash)
        {
            ActivityGraph = new DefinitionHashPointer<DestinyActivityGraphDefinition>(activityGraphHash, DefinitionsEnum.DestinyActivityGraphDefinition);
        }

        public bool DeepEquals(ActivityGraphListEntry other)
        {
            return other != null &&
                ActivityGraph.DeepEquals(other.ActivityGraph);
        }
    }
}
