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

internal sealed class SocialApi : ISocialApi
{
    private readonly IBungieClientConfiguration _configuration;
    private readonly IDotNetBungieApiHttpClient _dotNetBungieApiHttpClient;
    private readonly IBungieNetJsonSerializer _serializer;

    public SocialApi(
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
    ///     Returns your Bungie Friend list
    /// </summary>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Social.Friends.BungieFriendListResponse>> GetFriendList(
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.ReadUserData))
            throw new InsufficientScopeException(ApplicationScopes.ReadUserData);

        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Social.Friends.BungieFriendListResponse>("/Social/Friends/", cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Returns your friend request queue.
    /// </summary>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Social.Friends.BungieFriendRequestListResponse>> GetFriendRequestList(
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.ReadUserData))
            throw new InsufficientScopeException(ApplicationScopes.ReadUserData);

        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Social.Friends.BungieFriendRequestListResponse>("/Social/Friends/Requests/", cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Requests a friend relationship with the target user. Any of the target user's linked membership ids are valid inputs.
    /// </summary>
    /// <param name="membershipId">The membership id of the user you wish to add.</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<bool>> IssueFriendRequest(
        string membershipId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.BnetWrite))
            throw new InsufficientScopeException(ApplicationScopes.BnetWrite);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Social/Friends/Add/{membershipId}/")
            .Build();
        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<bool>(url, cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Accepts a friend relationship with the target user. The user must be on your incoming friend request list, though no error will occur if they are not.
    /// </summary>
    /// <param name="membershipId">The membership id of the user you wish to accept.</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<bool>> AcceptFriendRequest(
        string membershipId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.BnetWrite))
            throw new InsufficientScopeException(ApplicationScopes.BnetWrite);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Social/Friends/Requests/Accept/{membershipId}/")
            .Build();
        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<bool>(url, cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Declines a friend relationship with the target user. The user must be on your incoming friend request list, though no error will occur if they are not.
    /// </summary>
    /// <param name="membershipId">The membership id of the user you wish to decline.</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<bool>> DeclineFriendRequest(
        string membershipId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.BnetWrite))
            throw new InsufficientScopeException(ApplicationScopes.BnetWrite);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Social/Friends/Requests/Decline/{membershipId}/")
            .Build();
        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<bool>(url, cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Remove a friend relationship with the target user. The user must be on your friend list, though no error will occur if they are not.
    /// </summary>
    /// <param name="membershipId">The membership id of the user you wish to remove.</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<bool>> RemoveFriend(
        string membershipId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.BnetWrite))
            throw new InsufficientScopeException(ApplicationScopes.BnetWrite);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Social/Friends/Remove/{membershipId}/")
            .Build();
        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<bool>(url, cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Remove a friend relationship with the target user. The user must be on your outgoing request friend list, though no error will occur if they are not.
    /// </summary>
    /// <param name="membershipId">The membership id of the user you wish to remove.</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<bool>> RemoveFriendRequest(
        string membershipId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.BnetWrite))
            throw new InsufficientScopeException(ApplicationScopes.BnetWrite);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Social/Friends/Requests/Remove/{membershipId}/")
            .Build();
        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<bool>(url, cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Gets the platform friend of the requested type, with additional information if they have Bungie accounts. Must have a recent login session with said platform.
    /// </summary>
    /// <param name="friendPlatform">The platform friend type.</param>
    /// <param name="page">The zero based page to return. Page size is 100.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Social.Friends.PlatformFriendResponse>> GetPlatformFriendList(
        Models.Social.Friends.PlatformFriendType friendPlatform,
        string page,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Social/PlatformFriends/{friendPlatform}/{page}/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Social.Friends.PlatformFriendResponse>(url, cancellationToken);
    }

}
