using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.ActivityGraphs
{
    public class ActivityGraphNode
    {
        public List<ActivityGraphNodeActivityEntry> Activities { get; }
        public List<ActivityGraphNodeFeaturingState> FeaturingStates { get; }
        public uint NodeId { get; }
        public DestinyDefinitionDisplayProperties OverrideDisplay { get; }
        public DestinyPosition Position { get; }
        public List<ActivityGraphNodeState> States { get; }
        public uint UIActivityTypeOverrideHash { get; }
        public uint UIStyleHash { get; }

        [JsonConstructor]
        private ActivityGraphNode(List<ActivityGraphNodeActivityEntry> activities, List<ActivityGraphNodeFeaturingState> featuringStates, uint nodeId, 
            DestinyDefinitionDisplayProperties overrideDisplay, DestinyPosition position, List<ActivityGraphNodeState> states, uint uiActivityTypeOverrideHash, uint uiStyleHash)
        {
            if (activities == null)
                Activities = new List<ActivityGraphNodeActivityEntry>();
            else
                Activities = activities;
            if (featuringStates == null)
                FeaturingStates = new List<ActivityGraphNodeFeaturingState>();
            else
                FeaturingStates = featuringStates;
            NodeId = nodeId;
            OverrideDisplay = overrideDisplay;
            Position = position;
            if (states == null)
                States = new List<ActivityGraphNodeState>();
            else
                States = states;
            UIActivityTypeOverrideHash = uiActivityTypeOverrideHash;
            UIStyleHash = uiStyleHash;
        }
    }
}
