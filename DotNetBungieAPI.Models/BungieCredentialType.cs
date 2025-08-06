namespace DotNetBungieAPI.Models;

/// <summary>
///     The types of credentials the Accounts system supports. This is the external facing enum used in place of the internal-only Bungie.SharedDefinitions.CredentialType.
/// </summary>
public enum BungieCredentialType : byte
{
    None = 0,

    Xuid = 1,

    Psnid = 2,

    Wlid = 3,

    Fake = 4,

    Facebook = 5,

    Google = 8,

    Windows = 9,

    DemonId = 10,

    SteamId = 12,

    BattleNetId = 14,

    StadiaId = 16,

    TwitchId = 18,

    EgsId = 20
}
