using System;

namespace NetBungieAPI.GroupsV2
{
    [Flags]
    public enum Capabilities
    {
        None = 0,
        Leaderboards = 1,
        Callsign = 2,
        OptionalConversations = 4,
        ClanBanner = 8,
        D2InvestmentData = 16,
        Tags = 32,
        Alliances = 64
    }
}
