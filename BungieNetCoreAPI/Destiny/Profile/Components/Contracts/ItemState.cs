using System;

namespace NetBungieApi.Destiny.Profile.Components.Contracts
{
    [Flags]
    public enum ItemState
    {
        None = 0,
        Locked = 1,
        Tracked = 2,
        Masterwork = 4
    }
}
