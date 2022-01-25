namespace DotNetBungieAPI.Generated.Models.Applications;

[System.Flags]
public enum ApplicationScopes : long
{
    /// <summary>
    ///     Read basic user profile information such as the user's handle, avatar icon, etc.
    /// </summary>
    ReadBasicUserProfile = 1,

    /// <summary>
    ///     Read Group/Clan Forums, Wall, and Members for groups and clans that the user has joined.
    /// </summary>
    ReadGroups = 2,

    /// <summary>
    ///     Write Group/Clan Forums, Wall, and Members for groups and clans that the user has joined.
    /// </summary>
    WriteGroups = 4,

    /// <summary>
    ///     Administer Group/Clan Forums, Wall, and Members for groups and clans that the user is a founder or an administrator.
    /// </summary>
    AdminGroups = 8,

    /// <summary>
    ///     Create new groups, clans, and forum posts, along with other actions that are reserved for Bungie.net elevated scope: not meant to be used by third party applications.
    /// </summary>
    BnetWrite = 16,

    /// <summary>
    ///     Move or equip Destiny items
    /// </summary>
    MoveEquipDestinyItems = 32,

    /// <summary>
    ///     Read Destiny 1 Inventory and Vault contents. For Destiny 2, this scope is needed to read anything regarded as private. This is the only scope a Destiny 2 app needs for read operations against Destiny 2 data such as inventory, vault, currency, vendors, milestones, progression, etc.
    /// </summary>
    ReadDestinyInventoryAndVault = 64,

    /// <summary>
    ///     Read user data such as who they are web notifications, clan/group memberships, recent activity, muted users.
    /// </summary>
    ReadUserData = 128,

    /// <summary>
    ///     Edit user data such as preferred language, status, motto, avatar selection and theme.
    /// </summary>
    EditUserData = 256,

    /// <summary>
    ///     Access vendor and advisor data specific to a user. OBSOLETE. This scope is only used on the Destiny 1 API.
    /// </summary>
    ReadDestinyVendorsAndAdvisors = 512,

    /// <summary>
    ///     Read offer history and claim and apply tokens for the user.
    /// </summary>
    ReadAndApplyTokens = 1024,

    /// <summary>
    ///     Can perform actions that will result in a prompt to the user via the Destiny app.
    /// </summary>
    AdvancedWriteActions = 2048,

    /// <summary>
    ///     Can user the partner offer api to claim rewards defined for a partner
    /// </summary>
    PartnerOfferGrant = 4096,

    /// <summary>
    ///     Allows an app to query sensitive information like unlock flags and values not available through normal methods.
    /// </summary>
    DestinyUnlockValueQuery = 8192,

    /// <summary>
    ///     Allows an app to query sensitive user PII, most notably email information.
    /// </summary>
    UserPiiRead = 16384
}
