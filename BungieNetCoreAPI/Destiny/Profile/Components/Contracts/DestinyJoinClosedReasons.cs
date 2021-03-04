using System;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    [Flags]
    public enum DestinyJoinClosedReasons
    {
        None = 0,
        InMatchmaking = 1,
        Loading = 2,
        SoloMode = 4,
        InternalReasons = 8,
        DisallowedByGameState = 16,
        Offline = 32768
    }
}
