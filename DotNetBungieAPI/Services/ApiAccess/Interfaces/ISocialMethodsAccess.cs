using DotNetBungieAPI.Authorization;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Social;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetBungieAPI.Services.ApiAccess.Interfaces
{
    /// <summary>
    /// Access to https://bungie.net/Platform/Social endpoint
    /// </summary>
    public interface ISocialMethodsAccess
    {
        /// <summary>
        ///     Returns your Bungie Friend list
        /// </summary>
        /// <param name="authorizationToken">Authorization token</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<BungieFriendListResponse>> GetFriendList(
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Returns your friend request queue.
        /// </summary>
        /// <param name="authorizationToken">Authorization token</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<BungieFriendRequestListResponse>> GetFriendRequestList(
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Requests a friend relationship with the target user. Any of the target user's linked membership ids are valid inputs.
        /// </summary>
        /// <param name="membershipId">The membership id of the user you wish to add.</param>
        /// <param name="authorizationToken">Authorization token</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<bool>> IssueFriendRequest(
            string membershipId,
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Accepts a friend relationship with the target user. The user must be on your incoming friend request list, though no error will occur if they are not.
        /// </summary>
        /// <param name="membershipId">The membership id of the user you wish to accept.</param>
        /// <param name="authorizationToken">Authorization token</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<bool>> AcceptFriendRequest(
            string membershipId,
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Declines a friend relationship with the target user. The user must be on your incoming friend request list, though no error will occur if they are not.
        /// </summary>
        /// <param name="membershipId">The membership id of the user you wish to decline.</param>
        /// <param name="authorizationToken">Authorization token</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<bool>> DeclineFriendRequest(
            string membershipId,
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Remove a friend relationship with the target user. The user must be on your friend list, though no error will occur if they are not.
        /// </summary>
        /// <param name="membershipId">The membership id of the user you wish to remove.</param>
        /// <param name="authorizationToken">Authorization token</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<bool>> RemoveFriend(
            string membershipId,
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Remove a friend relationship with the target user. The user must be on your outgoing request friend list, though no error will occur if they are not.
        /// </summary>
        /// <param name="membershipId">The membership id of the user you wish to remove.</param>
        /// <param name="authorizationToken">Authorization token</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<bool>> RemoveFriendRequest(
            string membershipId,
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Gets the platform friend of the requested type, with additional information if they have Bungie accounts. Must have a recent login session with said platform.
        /// </summary>
        /// <param name="friendPlatform">The platform friend type.</param>
        /// <param name="authorizationToken">Authorization token</param>
        /// <param name="page">The zero based page to return. Page size is 100.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<PlatformFriendResponse>> GetPlatformFriendList(
            PlatformFriendType friendPlatform,
            AuthorizationTokenData authorizationToken,
            int page = 0,
            CancellationToken cancellationToken = default);
    }
}