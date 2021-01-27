using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.ActivityGraphs
{
    /// <summary>
    /// This is the position and other data related to nodes in the activity graph that you can click to launch activities. An Activity Graph node will only have one active Activity at a time, which will determine the activity to be launched (and, unless overrideDisplay information is provided, will also determine the tooltip and other UI related to the node)
    /// </summary>
    public class ActivityGraphNode : IDeepEquatable<ActivityGraphNode>
    {
        /// <summary>
        /// The node may have various possible activities that could be active for it, however only one may be active at a time.
        /// </summary>
        public ReadOnlyCollection<ActivityGraphNodeActivityEntry> Activities { get; }
        /// <summary>
        /// The node may have various visual accents placed on it, or styles applied. These are the list of possible styles that the Node can have. The game iterates through each, looking for the first one that passes a check of the required game/character/account state in order to show that style, and then renders the node in that style.
        /// </summary>
        public ReadOnlyCollection<ActivityGraphNodeFeaturingState> FeaturingStates { get; }
        /// <summary>
        /// An identifier for the Activity Graph Node, only guaranteed to be unique within its parent Activity Graph.
        /// </summary>
        public uint NodeId { get; }
        /// <summary>
        /// The node *may* have display properties that override the active Activity's display properties.
        /// </summary>
        public DestinyDefinitionDisplayProperties OverrideDisplay { get; }
        /// <summary>
        /// The position on the map for this node.
        /// </summary>
        public DestinyPosition Position { get; }
        /// <summary>
        /// Represents possible states that the graph node can be in. These are combined with some checking that happens in the game client and server to determine which state is actually active at any given time.
        /// </summary>
        public ReadOnlyCollection<ActivityGraphNodeState> States { get; }
        public uint UIActivityTypeOverrideHash { get; }
        public uint UIStyleHash { get; }

        [JsonConstructor]
        internal ActivityGraphNode(ActivityGraphNodeActivityEntry[] activities, ActivityGraphNodeFeaturingState[] featuringStates, uint nodeId, 
            DestinyDefinitionDisplayProperties overrideDisplay, DestinyPosition position, ActivityGraphNodeState[] states, uint uiActivityTypeOverrideHash, uint uiStyleHash)
        {
            Activities = activities.AsReadOnlyOrEmpty();
            FeaturingStates = featuringStates.AsReadOnlyOrEmpty();
            NodeId = nodeId;
            OverrideDisplay = overrideDisplay;
            Position = position;
            States = states.AsReadOnlyOrEmpty();
            UIActivityTypeOverrideHash = uiActivityTypeOverrideHash;
            UIStyleHash = uiStyleHash;
        }

        public bool DeepEquals(ActivityGraphNode other)
        {
            return other != null &&
                   Activities.DeepEqualsReadOnlyCollections(other.Activities) &&
                   FeaturingStates.DeepEqualsReadOnlyCollections(other.FeaturingStates) &&
                   NodeId == other.NodeId &&
                   OverrideDisplay.DeepEquals(other.OverrideDisplay) &&
                   Position.DeepEquals(other.Position) &&
                   States.DeepEqualsReadOnlyCollections(other.States) &&
                   UIActivityTypeOverrideHash == other.UIActivityTypeOverrideHash &&
                   UIStyleHash == other.UIStyleHash;
        }
    }
}
