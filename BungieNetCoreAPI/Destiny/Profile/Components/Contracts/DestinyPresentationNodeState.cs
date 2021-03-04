using System;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    [Flags]
    public enum DestinyPresentationNodeState
    {
        None = 0,
        Invisible = 1,
        Obscured = 2
    }
}
