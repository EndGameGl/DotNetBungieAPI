using BungieNetCoreAPI.Destiny.Definitions.ActivityGraphs;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Milestones
{
    public class MilestoneActivityGraphNode
    {
        public DefinitionHashPointer<DestinyActivityGraphDefinition> ActivityGraph { get; }
        public uint ActivityGraphNodeHash { get; }

        [JsonConstructor]
        private MilestoneActivityGraphNode(uint activityGraphHash, uint activityGraphNodeHash)
        {
            ActivityGraph = new DefinitionHashPointer<DestinyActivityGraphDefinition>(activityGraphHash, DefinitionsEnum.DestinyActivityGraphDefinition);
            ActivityGraphNodeHash = activityGraphNodeHash;
        }
    }
}
