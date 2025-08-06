namespace DotNetBungieAPI.Models.Destiny;

/// <summary>
///     I know this doesn't look like a Flags Enumeration/bitmask right now, but I assure you it is. This is the possible states that a Presentation Node can be in, and it is almost certain that its potential states will increase in the future. So don't treat it like a straight up enumeration.
/// </summary>
[System.Flags]
public enum DestinyPresentationNodeState : int
{
    None = 0,

    /// <summary>
    ///     If this is set, the game recommends that you not show this node. But you know your life, do what you've got to do.
    /// </summary>
    Invisible = 1,

    /// <summary>
    ///     Turns out Presentation Nodes can also be obscured. If they are, this is set.
    /// </summary>
    Obscured = 2
}
