using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Social;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface ISocialMethodsAccess
    {
        /// <summary>
        ///     Returns your Bungie Friend list
        /// </summary>
        /// <param name="authData">Authorization token</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<BungieFriendListResponse>> GetFriendList(
            AuthorizationTokenData authData,
            CancellationToken token = default);

        /// <summary>
        ///     Returns your friend request queue.
        /// </summary>
        /// <param name="authData">Authorization token</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<BungieFriendRequestListResponse>> GetFriendRequestList(
            AuthorizationTokenData authData,
            CancellationToken token = default);

        /// <summary>
        ///     Requests a friend relationship with the target user. Any of the target user's linked membership ids are valid inputs.
        /// </summary>
        /// <param name="membershipId">The membership id of the user you wish to add.</param>
        /// <param name="authData">Authorization token</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<bool>> IssueFriendRequest(
            string membershipId,
            AuthorizationTokenData authData,
            CancellationToken token = default);

        /// <summary>
        ///     Accepts a friend relationship with the target user. The user must be on your incoming friend request list, though no error will occur if they are not.
        /// </summary>
        /// <param name="membershipId">The membership id of the user you wish to accept.</param>
        /// <param name="authData">Authorization token</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<bool>> AcceptFriendRequest(
            string membershipId,
            AuthorizationTokenData authData,
            CancellationToken token = default);

        /// <summary>
        ///     Declines a friend relationship with the target user. The user must be on your incoming friend request list, though no error will occur if they are not.
        /// </summary>
        /// <param name="membershipId">The membership id of the user you wish to decline.</param>
        /// <param name="authData">Authorization token</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<bool>> DeclineFriendRequest(
            string membershipId,
            AuthorizationTokenData authData,
            CancellationToken token = default);

        /// <summary>
        ///     Remove a friend relationship with the target user. The user must be on your friend list, though no error will occur if they are not.
        /// </summary>
        /// <param name="membershipId">The membership id of the user you wish to remove.</param>
        /// <param name="authData">Authorization token</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<bool>> RemoveFriend(
            string membershipId,
            AuthorizationTokenData authData,
            CancellationToken token = default);

        /// <summary>
        ///     Remove a friend relationship with the target user. The user must be on your outgoing request friend list, though no error will occur if they are not.
        /// </summary>
        /// <param name="membershipId">The membership id of the user you wish to remove.</param>
        /// <param name="authData">Authorization token</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<bool>> RemoveFriendRequest(
            string membershipId,
            AuthorizationTokenData authData,
            CancellationToken token = default);
        
        /// <summary>
        ///     Gets the platform friend of the requested type, with additional information if they have Bungie accounts. Must have a recent login session with said platform.
        /// </summary>
        /// <param name="friendPlatform">The platform friend type.</param>
        /// <param name="authData">Authorization token</param>
        /// <param name="page">The zero based page to return. Page size is 100.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<PlatformFriendResponse>> GetPlatformFriendList(
            PlatformFriendType friendPlatform,
            AuthorizationTokenData authData,
            int page = 0, 
            CancellationToken token = default);
    }
}