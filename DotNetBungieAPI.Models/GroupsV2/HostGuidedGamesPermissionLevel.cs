namespace DotNetBungieAPI.Models.GroupsV2;

/// <summary>
///     Used for setting the guided game permission level override (admins and founders can always host guided games).
/// </summary>
public enum HostGuidedGamesPermissionLevel
{
    None = 0,
    Beginner = 1,
    Member = 2
}