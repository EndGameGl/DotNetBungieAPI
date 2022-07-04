namespace DotNetBungieAPI.Models.Applications;

public enum ApplicationStatus
{
    /// <summary>
    ///     No value assigned
    /// </summary>
    None = 0,

    /// <summary>
    ///     Application exists and works but will not appear in any public catalog. New applications start in this state, test
    ///     applications will remain in this state.
    /// </summary>
    Private = 1,

    /// <summary>
    ///     Active applications that can appear in an catalog.
    /// </summary>
    Public = 2,

    /// <summary>
    ///     Application disabled by the owner. All authorizations will be treated as terminated while in this state. Owner can
    ///     move back to private or public state.
    /// </summary>
    Disabled = 3,

    /// <summary>
    ///     Application has been blocked by Bungie. It cannot be transitioned out of this state by the owner. Authorizations
    ///     are terminated when an application is in this state.
    /// </summary>
    Blocked = 4
}