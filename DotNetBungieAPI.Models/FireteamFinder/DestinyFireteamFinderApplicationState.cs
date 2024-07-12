namespace DotNetBungieAPI.Models.FireteamFinder;

public enum DestinyFireteamFinderApplicationState
{
    Unknown = 0,
    WaitingForApplicants = 1,
    WaitingForLobbyOwner = 2,
    Accepted = 3,
    Rejected = 4,
    Deleted = 5,
    Expired = 6
}
