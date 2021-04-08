using NetBungieAPI.Models.Destiny.Definitions.Common;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.ActivityGraphs
{
    /// <summary>
    /// This is the position and other data related to nodes in the activity graph that you can click to launch activities. An Activity Graph node will only have one active Activity at a time, which will determine the activity to be launched (and, unless overrideDisplay information is provided, will also determine the tooltip and other UI related to the node)
    /// </summary>
    public sealed record DestinyActivityGraphNodeDefinition : IDeepEquatable<DestinyActivityGraphNodeDefinition>
    {
        /// <summary>
        /// An identifier for the Activity Graph Node, only guaranteed to be unique within its parent Activity Graph.
        /// </summary>
        [JsonPropertyName("nodeId")]
        public uint NodeId { get; init; }
        /// <summary>
        /// The node *may* have display properties that override the active Activity's display properties.
        /// </summary>
        [JsonPropertyName("overrideDisplay")]
        public DestinyDisplayPropertiesDefinition OverrideDisplay { get; init; }
        /// <summary>
        /// The position on the map for this node.
        /// </summary>
        [JsonPropertyName("position")]
        public DestinyPositionDefinition Position { get; init; }
        /// <summary>
        /// The node may have various visual accents placed on it, or styles applied. These are the list of possible styles that the Node can have. The game iterates through each, looking for the first one that passes a check of the required game/character/account state in order to show that style, and then renders the node in that style.
        /// </summary>
        [JsonPropertyName("featuringStates")]
        public ReadOnlyCollection<DestinyActivityGraphNodeFeaturingStateDefinition> FeaturingStates { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyActivityGraphNodeFeaturingStateDefinition>();
        /// <summary>
        /// The node may have various possible activities that could be active for it, however only one may be active at a time.
        /// </summary>
        [JsonPropertyName("activities")]
        public ReadOnlyCollection<DestinyActivityGraphNodeActivityDefinition> Activities { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyActivityGraphNodeActivityDefinition>();
        /// <summary>
        /// Represents possible states that the graph node can be in. These are combined with some checking that happens in the game client and server to determine which state is actually active at any given time.
        /// </summary>
        [JsonPropertyName("states")]
        public ReadOnlyCollection<DestinyActivityGraphNodeStateEntry> States { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyActivityGraphNodeStateEntry>();
        [JsonPropertyName("uiActivityTypeOverrideHash")]
        public uint UIActivityTypeOverrideHash { get; init; }
        [JsonPropertyName("uiStyleHash")]
        public uint UIStyleHash { get; init; }

        public bool DeepEquals(DestinyActivityGraphNodeDefinition other)
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
