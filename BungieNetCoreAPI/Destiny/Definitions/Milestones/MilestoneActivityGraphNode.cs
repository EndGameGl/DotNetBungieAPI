﻿using NetBungieApi.Destiny.Definitions.ActivityGraphs;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.Milestones
{
    public class MilestoneActivityGraphNode : IDeepEquatable<MilestoneActivityGraphNode>
    {
        public DefinitionHashPointer<DestinyActivityGraphDefinition> ActivityGraph { get; }
        public uint ActivityGraphNodeHash { get; }

        [JsonConstructor]
        internal MilestoneActivityGraphNode(uint activityGraphHash, uint activityGraphNodeHash)
        {
            ActivityGraph = new DefinitionHashPointer<DestinyActivityGraphDefinition>(activityGraphHash, DefinitionsEnum.DestinyActivityGraphDefinition);
            ActivityGraphNodeHash = activityGraphNodeHash;
        }

        public bool DeepEquals(MilestoneActivityGraphNode other)
        {
            return other != null &&
                ActivityGraph.DeepEquals(other.ActivityGraph) &&
                ActivityGraphNodeHash == other.ActivityGraphNodeHash;
        }
    }
}
