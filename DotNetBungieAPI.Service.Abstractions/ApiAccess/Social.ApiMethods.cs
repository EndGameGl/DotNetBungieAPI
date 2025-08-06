using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Authorization;

namespace DotNetBungieAPI.Service.Abstractions.ApiAccess;

public interface ISocialApi
{
    Task<BungieResponse<Models.Social.Friends.BungieFriendListResponse>> GetFriendList(
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Social.Friends.BungieFriendRequestListResponse>> GetFriendRequestList(
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<bool>> IssueFriendRequest(
        string membershipId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<bool>> AcceptFriendRequest(
        string membershipId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<bool>> DeclineFriendRequest(
        string membershipId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<bool>> RemoveFriend(
        string membershipId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<bool>> RemoveFriendRequest(
        string membershipId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Social.Friends.PlatformFriendResponse>> GetPlatformFriendList(
        Models.Social.Friends.PlatformFriendType friendPlatform,
        string page,
        CancellationToken cancellationToken = default
    );

}
