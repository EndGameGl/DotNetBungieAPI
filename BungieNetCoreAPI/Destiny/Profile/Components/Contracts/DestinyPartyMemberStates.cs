using System;

namespace NetBungieApi.Destiny.Profile.Components.Contracts
{
    [Flags]
    public enum DestinyPartyMemberStates
    {
        None = 0,
        FireteamMember = 1,
        PosseMember = 2,
        GroupMember = 4,
        PartyLeader = 8
    }
}
