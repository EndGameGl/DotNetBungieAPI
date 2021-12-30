using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models;

public enum BungieMembershipType : int
{
    None = 0,
    TigerXbox = 1,
    TigerPsn = 2,
    TigerSteam = 3,
    TigerBlizzard = 4,
    TigerStadia = 5,
    TigerDemon = 10,
    BungieNext = 254,
    All = -1
}
