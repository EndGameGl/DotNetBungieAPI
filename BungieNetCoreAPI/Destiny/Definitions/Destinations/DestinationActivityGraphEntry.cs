using NetBungieApi.Destiny.Definitions.ActivityGraphs;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.Destinations
{
    /// <summary>
    /// Destinations and Activities may have default Activity Graphs that should be shown when you bring up the Director and are playing in either.
    /// <para/>
    /// This contract defines the graph referred to and the gating for when it is relevant.
    /// </summary>
    public class DestinationActivityGraphEntry : IDeepEquatable<DestinationActivityGraphEntry>
    {
        public DefinitionHashPointer<DestinyActivityGraphDefinition> ActivityGraph { get; }

        [JsonConstructor]
        internal DestinationActivityGraphEntry(uint activityGraphHash)
        {
            ActivityGraph = new DefinitionHashPointer<DestinyActivityGraphDefinition>(activityGraphHash, DefinitionsEnum.DestinyActivityGraphDefinition);
        }

        public bool DeepEquals(DestinationActivityGraphEntry other)
        {
            return other != null && ActivityGraph.DeepEquals(other.ActivityGraph);
        }
    }
}
