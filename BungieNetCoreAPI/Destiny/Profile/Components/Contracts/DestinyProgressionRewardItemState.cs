using System;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    [Flags]
    public enum DestinyProgressionRewardItemState
    {
        None = 0,
        Invisible = 1,
        Earned = 2,
        Claimed = 4,
        ClaimAllowed = 8
    }
}
