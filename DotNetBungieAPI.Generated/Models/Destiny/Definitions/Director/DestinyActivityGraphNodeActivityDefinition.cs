namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Director;

/// <summary>
///     The actual activity to be redirected to when you click on the node. Note that a node can have many Activities attached to it: but only one will be active at any given time. The list of Node Activities will be traversed, and the first one found to be active will be displayed. This way, a node can layer multiple variants of an activity on top of each other. For instance, one node can control the weekly Crucible Playlist. There are multiple possible playlists, but only one is active for the week.
/// </summary>
public class DestinyActivityGraphNodeActivityDefinition : IDeepEquatable<DestinyActivityGraphNodeActivityDefinition>
{
    /// <summary>
    ///     An identifier for this node activity. It is only guaranteed to be unique within the Activity Graph.
    /// </summary>
    [JsonPropertyName("nodeActivityId")]
    public uint NodeActivityId { get; set; }

    /// <summary>
    ///     The activity that will be activated if the user clicks on this node. Controls all activity-related information displayed on the node if it is active (the text shown in the tooltip etc)
    /// </summary>
    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; set; }

    public bool DeepEquals(DestinyActivityGraphNodeActivityDefinition? other)
    {
        return other is not null &&
               NodeActivityId == other.NodeActivityId &&
               ActivityHash == other.ActivityHash;
    }
}