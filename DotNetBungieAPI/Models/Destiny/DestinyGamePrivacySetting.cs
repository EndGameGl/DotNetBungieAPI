namespace DotNetBungieAPI.Models.Destiny;

/// <summary>
///     A player can choose to restrict requests to join their Fireteam to specific states. These are the possible states a
///     user can choose.
/// </summary>
public enum DestinyGamePrivacySetting
{
    Open = 0,
    ClanAndFriendsOnly = 1,
    FriendsOnly = 2,
    InvitationOnly = 3,
    Closed = 4
}