namespace DotNetBungieAPI.Models.Destiny;

/// <summary>
///     Represents the different states a progression reward item can be in.
/// </summary>
[Flags]
public enum DestinyProgressionRewardItemState
{
    None = 0,

    /// <summary>
    ///     If this is set, the reward should be hidden.
    /// </summary>
    Invisible = 1,

    /// <summary>
    ///     If this is set, the reward has been earned.
    /// </summary>
    Earned = 2,

    /// <summary>
    ///     If this is set, the reward has been claimed.
    /// </summary>
    Claimed = 4,

    /// <summary>
    ///     If this is set, the reward is allowed to be claimed by this Character. An item can be earned but still can't be
    ///     claimed in certain circumstances, like if it's only allowed for certain subclasses. It also might not be able to be
    ///     claimed if you already claimed it!
    /// </summary>
    ClaimAllowed = 8
}