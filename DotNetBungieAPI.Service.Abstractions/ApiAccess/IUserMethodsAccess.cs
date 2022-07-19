using System.Collections.ObjectModel;
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
    Task<BungieResponse<GeneralUser>> GetBungieNetUserById(
        long id,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Gets a list of all display names linked to this membership id but sanitized (profanity filtered). Obeys all visibility rules of calling user and is heavily cached.
    /// </summary>
    /// <param name="membershipId">The requested membership id to load.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<ReadOnlyDictionary<BungieCredentialType, string>>> GetSanitizedPlatformDisplayNames(
        long membershipId,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Returns a list of credential types attached to the requested account
    /// </summary>
    /// <param name="membershipId">The user's membership id</param>
    /// <param name="authorizationToken">Auth token for respective user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<ReadOnlyCollection<CredentialTypeForAccount>>> GetCredentialTypesForTargetAccount(
        long membershipId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Returns a list of all available user themes.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<ReadOnlyCollection<UserTheme>>> GetAvailableThemes(
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Returns a list of accounts associated with the supplied membership ID and membership type. This will include all
    ///     linked accounts (even when hidden) if supplied credentials permit it.
    /// </summary>
    /// <param name="membershipId">The membership ID of the target user.</param>
    /// <param name="membershipType">Type of the supplied membership ID.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<UserMembershipData>> GetMembershipDataById(
        long membershipId,
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
    Task<BungieResponse<UserMembershipData>> GetMembershipDataForCurrentUser(
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
    Task<BungieResponse<HardLinkedUserMembership>> GetMembershipFromHardLinkedCredential(
        long credential,
        BungieCredentialType credentialType = BungieCredentialType.SteamId,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Given the prefix of a global display name, returns all users who share that name.
    /// </summary>
    /// <param name="request">Request body</param>
    /// <param name="page">The zero-based page of results you desire.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<UserSearchResponse>> SearchByGlobalNamePost(
        UserSearchPrefixRequest request,
        int page = 0,
        CancellationToken cancellationToken = default);
}