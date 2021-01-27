using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.ActivityGraphs
{
    public class ActivityGraphLinkedGraphEntryLinkedGraphEntry : IDeepEquatable<ActivityGraphLinkedGraphEntryLinkedGraphEntry>
    {
        public DefinitionHashPointer<DestinyActivityGraphDefinition> ActivityGraph { get; }

        [JsonConstructor]
        internal ActivityGraphLinkedGraphEntryLinkedGraphEntry(uint activityGraphHash)
        {
            ActivityGraph = new DefinitionHashPointer<DestinyActivityGraphDefinition>(activityGraphHash, DefinitionsEnum.DestinyActivityGraphDefinition);
        }

        public bool DeepEquals(ActivityGraphLinkedGraphEntryLinkedGraphEntry other)
        {
            return other != null && ActivityGraph.DeepEquals(other.ActivityGraph);
        }
    }
}
