using System.Threading;
using System.Threading.Tasks;
using DotNetBungieAPI.Clients;
using DotNetBungieAPI.Exceptions;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Applications;
using DotNetBungieAPI.Models.Authorization;
using DotNetBungieAPI.Models.Social;
using DotNetBungieAPI.Service.Abstractions;
using DotNetBungieAPI.Service.Abstractions.ApiAccess;

namespace DotNetBungieAPI.Services.ApiAccess;

/// <summary>
///     <inheritdoc cref="ISocialMethodsAccess" />
/// </summary>
internal sealed class SocialMethodsAccess : ISocialMethodsAccess
{
    private readonly IBungieClientConfiguration _configuration;
    private readonly IDotNetBungieApiHttpClient _dotNetBungieApiHttpClient;

    public SocialMethodsAccess(
        IDotNetBungieApiHttpClient dotNetBungieApiHttpClient,
        IBungieClientConfiguration configuration)
    {
        _dotNetBungieApiHttpClient = dotNetBungieApiHttpClient;
        _configuration = configuration;
    }


    public async ValueTask<BungieResponse<BungieFriendListResponse>> GetFriendList(
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default)
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.ReadUserData))
            throw new InsufficientScopeException(ApplicationScopes.ReadUserData);
        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<BungieFriendListResponse>(
                "/Social/Friends/",
                cancellationToken,
                authorizationToken.AccessToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<BungieResponse<BungieFriendRequestListResponse>> GetFriendRequestList(
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default)
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.ReadUserData))
            throw new InsufficientScopeException(ApplicationScopes.ReadUserData);
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<BungieFriendRequestListResponse>(
            "/Social/Friends/Requests/", cancellationToken, authorizationToken.AccessToken);
    }

    public async ValueTask<BungieResponse<bool>> IssueFriendRequest(
        string membershipId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default)
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.BnetWrite))
            throw new InsufficientScopeException(ApplicationScopes.BnetWrite);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/Social/Friends/Add/")
            .AddUrlParam(membershipId)
            .Build();

        return await _dotNetBungieApiHttpClient
            .PostToBungieNetPlatform<bool>(url, cancellationToken, authToken: authorizationToken.AccessToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<BungieResponse<bool>> AcceptFriendRequest(
        string membershipId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default)
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.BnetWrite))
            throw new InsufficientScopeException(ApplicationScopes.BnetWrite);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/Social/Friends/Requests/Accept/")
            .AddUrlParam(membershipId)
            .Build();

        return await _dotNetBungieApiHttpClient
            .PostToBungieNetPlatform<bool>(url, cancellationToken, authToken: authorizationToken.AccessToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<BungieResponse<bool>> DeclineFriendRequest(
        string membershipId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default)
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.BnetWrite))
            throw new InsufficientScopeException(ApplicationScopes.BnetWrite);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/Social/Friends/Requests/Decline/")
            .AddUrlParam(membershipId)
            .Build();

        return await _dotNetBungieApiHttpClient
            .PostToBungieNetPlatform<bool>(url, cancellationToken, authToken: authorizationToken.AccessToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<BungieResponse<bool>> RemoveFriend(
        string membershipId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default)
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.BnetWrite))
            throw new InsufficientScopeException(ApplicationScopes.BnetWrite);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/Social/Friends/Remove/")
            .AddUrlParam(membershipId)
            .Build();

        return await _dotNetBungieApiHttpClient
            .PostToBungieNetPlatform<bool>(url, cancellationToken, authToken: authorizationToken.AccessToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<BungieResponse<bool>> RemoveFriendRequest(
        string membershipId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default)
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.BnetWrite))
            throw new InsufficientScopeException(ApplicationScopes.BnetWrite);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/Social/Friends/Requests/Remove/")
            .AddUrlParam(membershipId)
            .Build();

        return await _dotNetBungieApiHttpClient
            .PostToBungieNetPlatform<bool>(url, cancellationToken, authToken: authorizationToken.AccessToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<BungieResponse<PlatformFriendResponse>> GetPlatformFriendList(
        PlatformFriendType friendPlatform,
        AuthorizationTokenData authorizationToken,
        int page = 0,
        CancellationToken cancellationToken = default)
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/Social/PlatformFriends/")
            .AddUrlParam(((int)friendPlatform).ToString())
            .AddUrlParam(page.ToString())
            .Build();

        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<PlatformFriendResponse>(
                url,
                cancellationToken,
                authorizationToken.AccessToken)
            .ConfigureAwait(false);
    }
}