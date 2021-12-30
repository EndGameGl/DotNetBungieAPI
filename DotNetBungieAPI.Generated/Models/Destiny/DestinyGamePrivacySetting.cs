using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny;

public enum DestinyGamePrivacySetting : int
{
    Open = 0,
    ClanAndFriendsOnly = 1,
    FriendsOnly = 2,
    InvitationOnly = 3,
    Closed = 4
}
