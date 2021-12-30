using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny;

[System.Flags]
public enum DestinyPartyMemberStates : int
{
    None = 0,
    FireteamMember = 1,
    PosseMember = 2,
    GroupMember = 4,
    PartyLeader = 8
}
