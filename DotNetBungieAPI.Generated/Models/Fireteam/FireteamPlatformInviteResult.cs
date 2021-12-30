using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Fireteam;

public enum FireteamPlatformInviteResult : byte
{
    None = 0,
    Success = 1,
    AlreadyInFireteam = 2,
    Throttled = 3,
    ServiceError = 4
}
