using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Authorization;
using DotNetBungieAPI.Models.Config;
using DotNetBungieAPI.Models.Requests;
using DotNetBungieAPI.Models.User;

namespace DotNetBungieAPI.Service.Abstractions.ApiAccess;

/// <summary>
///     Access to https://bungie.net/Platform/User endpoint
/// </summary>
public interface IUserMethodsAccess
{
    /// <summary>
    ///     Loads a bungienet user by membership id.
    /// </summary>
    /// <param name="id">The requested Bungie.net membership id.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    ValueTask<BungieResponse<GeneralUser>> GetBungieNetUserById(
        long id,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Returns a list of credential types attached to the requested account
    /// </summary>
    /// <param name="id">The user's membership id</param>
    /// ///
    /// <param name="authorizationToken">Authorization token</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    ValueTask<BungieResponse<CredentialTypeForAccount[]>> GetCredentialTypesForTargetAccount(
        long id,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Returns a list of all available user themes.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    ValueTask<BungieResponse<UserTheme[]>> GetAvailableThemes(
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Returns a list of accounts associated with the supplied membership ID and membership type. This will include all
    ///     linked accounts (even when hidden) if supplied credentials permit it.
    /// </summary>
    /// <param name="id">The membership ID of the target user.</param>
    /// <param name="membershipType">Type of the supplied membership ID.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    ValueTask<BungieResponse<UserMembershipData>> GetMembershipDataById(
        long id,
        BungieMembershipType membershipType,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Returns a list of accounts associated with signed in user. This is useful for OAuth implementations that do not
    ///     give you access to the token response.
    /// </summary>
    /// ///
    /// <param name="authorizationToken">Authorization token</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    ValueTask<BungieResponse<UserMembershipData>>
        GetMembershipDataForCurrentUser(
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default);

    /// <summary>
    ///     Gets any hard linked membership given a credential. Only works for credentials that are public (just SteamID64
    ///     right now). Cross Save aware.
    /// </summary>
    /// <param name="credential">The credential to look up. Must be a valid SteamID64.</param>
    /// <param name="credentialType">The credential type. 'SteamId' is the only valid value at present.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    ValueTask<BungieResponse<HardLinkedUserMembership>> GetMembershipFromHardLinkedCredential(
        long credential,
        BungieCredentialType credentialType = BungieCredentialType.SteamId,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Given the prefix of a global display name, returns all users who share that name.
    /// </summary>
    /// <param name="displayNamePrefix">The display name prefix you're looking for.</param>
    /// <param name="page">The zero-based page of results you desire.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    [Obsolete("Do not use this to search users, use SearchByGlobalNamePost instead.")]
    ValueTask<BungieResponse<UserSearchResponse>> SearchByGlobalNamePrefix(
        string displayNamePrefix,
        int page = 0,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Given the prefix of a global display name, returns all users who share that name.
    /// </summary>
    /// <param name="request">Request body</param>
    /// <param name="page">The zero-based page of results you desire.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    ValueTask<BungieResponse<UserSearchResponse>> SearchByGlobalNamePost(
        UserSearchPrefixRequest request,
        int page = 0,
        CancellationToken cancellationToken = default);
}