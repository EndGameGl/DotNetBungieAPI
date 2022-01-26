namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Director;

/// <summary>
///     This is the position and other data related to nodes in the activity graph that you can click to launch activities. An Activity Graph node will only have one active Activity at a time, which will determine the activity to be launched (and, unless overrideDisplay information is provided, will also determine the tooltip and other UI related to the node)
/// </summary>
public class DestinyActivityGraphNodeDefinition : IDeepEquatable<DestinyActivityGraphNodeDefinition>
{
    /// <summary>
    ///     An identifier for the Activity Graph Node, only guaranteed to be unique within its parent Activity Graph.
    /// </summary>
    [JsonPropertyName("nodeId")]
    public uint NodeId { get; set; }

    /// <summary>
    ///     The node *may* have display properties that override the active Activity's display properties.
    /// </summary>
    [JsonPropertyName("overrideDisplay")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition OverrideDisplay { get; set; }

    /// <summary>
    ///     The position on the map for this node.
    /// </summary>
    [JsonPropertyName("position")]
    public Destiny.Definitions.Common.DestinyPositionDefinition Position { get; set; }

    /// <summary>
    ///     The node may have various visual accents placed on it, or styles applied. These are the list of possible styles that the Node can have. The game iterates through each, looking for the first one that passes a check of the required game/character/account state in order to show that style, and then renders the node in that style.
    /// </summary>
    [JsonPropertyName("featuringStates")]
    public List<Destiny.Definitions.Director.DestinyActivityGraphNodeFeaturingStateDefinition> FeaturingStates { get; set; }

    /// <summary>
    ///     The node may have various possible activities that could be active for it, however only one may be active at a time. See the DestinyActivityGraphNodeActivityDefinition for details.
    /// </summary>
    [JsonPropertyName("activities")]
    public List<Destiny.Definitions.Director.DestinyActivityGraphNodeActivityDefinition> Activities { get; set; }

    /// <summary>
    ///     Represents possible states that the graph node can be in. These are combined with some checking that happens in the game client and server to determine which state is actually active at any given time.
    /// </summary>
    [JsonPropertyName("states")]
    public List<Destiny.Definitions.Director.DestinyActivityGraphNodeStateEntry> States { get; set; }

    public bool DeepEquals(DestinyActivityGraphNodeDefinition? other)
    {
        return other is not null &&
               NodeId == other.NodeId &&
               (OverrideDisplay is not null ? OverrideDisplay.DeepEquals(other.OverrideDisplay) : other.OverrideDisplay is null) &&
               (Position is not null ? Position.DeepEquals(other.Position) : other.Position is null) &&
               FeaturingStates.DeepEqualsList(other.FeaturingStates) &&
               Activities.DeepEqualsList(other.Activities) &&
               States.DeepEqualsList(other.States);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyActivityGraphNodeDefinition? other)
    {
        if (other is null) return;
        if (NodeId != other.NodeId)
        {
            NodeId = other.NodeId;
            OnPropertyChanged(nameof(NodeId));
        }
        if (!OverrideDisplay.DeepEquals(other.OverrideDisplay))
        {
            OverrideDisplay.Update(other.OverrideDisplay);
            OnPropertyChanged(nameof(OverrideDisplay));
        }
        if (!Position.DeepEquals(other.Position))
        {
            Position.Update(other.Position);
            OnPropertyChanged(nameof(Position));
        }
        if (!FeaturingStates.DeepEqualsList(other.FeaturingStates))
        {
            FeaturingStates = other.FeaturingStates;
            OnPropertyChanged(nameof(FeaturingStates));
        }
        if (!Activities.DeepEqualsList(other.Activities))
        {
            Activities = other.Activities;
            OnPropertyChanged(nameof(Activities));
        }
        if (!States.DeepEqualsList(other.States))
        {
            States = other.States;
            OnPropertyChanged(nameof(States));
        }
    }
}