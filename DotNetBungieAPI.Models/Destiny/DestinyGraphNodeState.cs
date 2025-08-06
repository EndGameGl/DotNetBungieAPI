namespace DotNetBungieAPI.Models.Destiny;

/// <summary>
///     Represents a potential state of an Activity Graph node.
/// </summary>
public enum DestinyGraphNodeState : int
{
    Hidden = 0,

    Visible = 1,

    Teaser = 2,

    Incomplete = 3,

    Completed = 4
}
