using System;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny
{
    [Flags, JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DestinyPartyMemberStates
    {
        None = 0,
        FireteamMember = 1,
        PosseMember = 2,
        GroupMember = 4,
        PartyLeader = 8
    }
}
