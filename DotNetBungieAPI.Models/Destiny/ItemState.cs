namespace DotNetBungieAPI.Models.Destiny;

/// <summary>
///     A flags enumeration/bitmask where each bit represents a different possible state that the item can be in that may
///     effect how the item is displayed to the user and what actions can be performed against it.
/// </summary>
[Flags]
public enum ItemState
{
    None = 0,

    /// <summary>
    ///     If this bit is set, the item has been "locked" by the user and cannot be deleted. You may want to represent this
    ///     visually with a "lock" icon.
    /// </summary>
    Locked = 1,

    /// <summary>
    ///     If this bit is set, the item is a quest that's being tracked by the user. You may want a visual indicator to show
    ///     that this is a tracked quest.
    /// </summary>
    Tracked = 2,

    /// <summary>
    ///     If this bit is set, the item has a Masterwork plug inserted. This usually coincides with having a special "glowing"
    ///     effect applied to the item's icon.
    /// </summary>
    Masterwork = 4,

    /// <summary>
    ///     If this bit is set, the item has been 'crafted' by the player. You may want to represent this visually with a "crafted" icon overlay.
    /// </summary>
    Crafted = 8,

    /// <summary>
    ///     If this bit is set, the item has a 'highlighted' objective. You may want to represent this with an orange-red icon border color.
    /// </summary>
    HighlightedObjective = 16
}
