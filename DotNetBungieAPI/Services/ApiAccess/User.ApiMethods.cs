using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Applications;
using DotNetBungieAPI.Models.Authorization;
using DotNetBungieAPI.Models.Exceptions;
using DotNetBungieAPI.Service.Abstractions;
using DotNetBungieAPI.Service.Abstractions.ApiAccess;

namespace DotNetBungieAPI.Services.ApiAccess;

internal sealed class UserApi : IUserApi
{
    private readonly IBungieClientConfiguration _configuration;
    private readonly IDotNetBungieApiHttpClient _dotNetBungieApiHttpClient;
    private readonly IBungieNetJsonSerializer _serializer;

    public UserApi(
        IBungieClientConfiguration configuration,
        IDotNetBungieApiHttpClient dotNetBungieApiHttpClient,
        IBungieNetJsonSerializer serializer
    )
    {
        _configuration = _configuration;
        _dotNetBungieApiHttpClient = dotNetBungieApiHttpClient;
        _serializer = serializer;
    }

    /// <summary>
    ///     Loads a bungienet user by membership id.
    /// </summary>
    /// <param name="id">The requested Bungie.net membership id.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.User.GeneralUser>> GetBungieNetUserById(
        long id,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/User/GetBungieNetUserById/{id}/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.User.GeneralUser>(url, cancellationToken);
    }

    /// <summary>
    ///     Gets a list of all display names linked to this membership id but sanitized (profanity filtered). Obeys all visibility rules of calling user and is heavily cached.
    /// </summary>
    /// <param name="membershipId">The requested membership id to load.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Dictionary<Models.BungieCredentialType, string>>> GetSanitizedPlatformDisplayNames(
        long membershipId,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/User/GetSanitizedPlatformDisplayNames/{membershipId}/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Dictionary<Models.BungieCredentialType, string>>(url, cancellationToken);
    }

    /// <summary>
    ///     Returns a list of credential types attached to the requested account
    /// </summary>
    /// <param name="membershipId">The user's membership id</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.User.Models.GetCredentialTypesForAccountResponse[]>> GetCredentialTypesForTargetAccount(
        long membershipId,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/User/GetCredentialTypesForTargetAccount/{membershipId}/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.User.Models.GetCredentialTypesForAccountResponse[]>(url, cancellationToken);
    }

    /// <summary>
    ///     Returns a list of all available user themes.
    /// </summary>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Config.UserTheme[]>> GetAvailableThemes(CancellationToken cancellationToken = default)
    {
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Config.UserTheme[]>("/User/GetAvailableThemes/", cancellationToken);
    }

    /// <summary>
    ///     Returns a list of accounts associated with the supplied membership ID and membership type. This will include all linked accounts (even when hidden) if supplied credentials permit it.
    /// </summary>
    /// <param name="membershipId">The membership ID of the target user.</param>
    /// <param name="membershipType">Type of the supplied membership ID.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.User.UserMembershipData>> GetMembershipDataById(
        long membershipId,
        Models.BungieMembershipType membershipType,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/User/GetMembershipsById/{membershipId}/{membershipType}/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.User.UserMembershipData>(url, cancellationToken);
    }

    /// <summary>
    ///     Returns a list of accounts associated with signed in user. This is useful for OAuth implementations that do not give you access to the token response.
    /// </summary>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.User.UserMembershipData>> GetMembershipDataForCurrentUser(
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.ReadBasicUserProfile))
            throw new InsufficientScopeException(ApplicationScopes.ReadBasicUserProfile);

        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.User.UserMembershipData>("/User/GetMembershipsForCurrentUser/", cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Gets any hard linked membership given a credential. Only works for credentials that are public (just SteamID64 right now). Cross Save aware.
    /// </summary>
    /// <param name="credential">The credential to look up. Must be a valid SteamID64.</param>
    /// <param name="crType">The credential type. 'SteamId' is the only valid value at present.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.User.HardLinkedUserMembership>> GetMembershipFromHardLinkedCredential(
        string credential,
        Models.BungieCredentialType crType,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/User/GetMembershipFromHardLinkedCredential/{crType}/{credential}/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.User.HardLinkedUserMembership>(url, cancellationToken);
    }

    /// <summary>
    ///     [OBSOLETE] Do not use this to search users, use SearchByGlobalNamePost instead.
    /// </summary>
    /// <param name="displayNamePrefix">The display name prefix you're looking for.</param>
    /// <param name="page">The zero-based page of results you desire.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.User.UserSearchResponse>> SearchByGlobalNamePrefix(
        string displayNamePrefix,
        int page,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/User/Search/Prefix/{displayNamePrefix}/{page}/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.User.UserSearchResponse>(url, cancellationToken);
    }

    /// <summary>
    ///     Given the prefix of a global display name, returns all users who share that name.
    /// </summary>
    /// <param name="page">The zero-based page of results you desire.</param>
    /// <param name="requestBody">Request body</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.User.UserSearchResponse>> SearchByGlobalNamePost(
        int page,
        Models.User.UserSearchPrefixRequest requestBody,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/User/Search/GlobalName/{page}/")
            .Build();
        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<Models.User.UserSearchResponse>(url, cancellationToken, content: stream);
    }

}
