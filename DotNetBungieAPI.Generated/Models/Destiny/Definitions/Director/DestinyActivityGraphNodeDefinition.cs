namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Director;

/// <summary>
///     This is the position and other data related to nodes in the activity graph that you can click to launch activities. An Activity Graph node will only have one active Activity at a time, which will determine the activity to be launched (and, unless overrideDisplay information is provided, will also determine the tooltip and other UI related to the node)
/// </summary>
public sealed class DestinyActivityGraphNodeDefinition
{

    /// <summary>
    ///     An identifier for the Activity Graph Node, only guaranteed to be unique within its parent Activity Graph.
    /// </summary>
    [JsonPropertyName("nodeId")]
    public uint NodeId { get; init; }

    /// <summary>
    ///     The node *may* have display properties that override the active Activity's display properties.
    /// </summary>
    [JsonPropertyName("overrideDisplay")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition OverrideDisplay { get; init; }

    /// <summary>
    ///     The position on the map for this node.
    /// </summary>
    [JsonPropertyName("position")]
    public Destiny.Definitions.Common.DestinyPositionDefinition Position { get; init; }

    /// <summary>
    ///     The node may have various visual accents placed on it, or styles applied. These are the list of possible styles that the Node can have. The game iterates through each, looking for the first one that passes a check of the required game/character/account state in order to show that style, and then renders the node in that style.
    /// </summary>
    [JsonPropertyName("featuringStates")]
    public List<Destiny.Definitions.Director.DestinyActivityGraphNodeFeaturingStateDefinition> FeaturingStates { get; init; }

    /// <summary>
    ///     The node may have various possible activities that could be active for it, however only one may be active at a time. See the DestinyActivityGraphNodeActivityDefinition for details.
    /// </summary>
    [JsonPropertyName("activities")]
    public List<Destiny.Definitions.Director.DestinyActivityGraphNodeActivityDefinition> Activities { get; init; }

    /// <summary>
    ///     Represents possible states that the graph node can be in. These are combined with some checking that happens in the game client and server to determine which state is actually active at any given time.
    /// </summary>
    [JsonPropertyName("states")]
    public List<Destiny.Definitions.Director.DestinyActivityGraphNodeStateEntry> States { get; init; }
}
