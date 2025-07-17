namespace DotNetBungieAPI.Generated.Models;

/// <summary>
///     The types of membership the Accounts system supports. This is the external facing enum used in place of the internal-only Bungie.SharedDefinitions.MembershipType.
/// </summary>
public enum BungieMembershipType : int
{
    None = 0,

    TigerXbox = 1,

    TigerPsn = 2,

    TigerSteam = 3,

    TigerBlizzard = 4,

    TigerStadia = 5,

    TigerEgs = 6,

    TigerDemon = 10,

    GoliathGame = 20,

    BungieNext = 254,

    /// <summary>
    ///     "All" is only valid for searching capabilities: you need to pass the actual matching BungieMembershipType for any query where you pass a known membershipId.
    /// </summary>
    All = -1
}
