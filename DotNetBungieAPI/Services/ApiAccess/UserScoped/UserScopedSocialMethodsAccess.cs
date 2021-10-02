using System.Threading;
using System.Threading.Tasks;
using DotNetBungieAPI.Authorization;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Social;
using DotNetBungieAPI.Services.ApiAccess.Interfaces;

namespace DotNetBungieAPI.Services.ApiAccess.UserScoped
{
    /// <summary>
    /// <inheritdoc cref="ISocialMethodsAccess"/>
    /// </summary>
    public class UserScopedSocialMethodsAccess
    {
        private readonly ISocialMethodsAccess _socialMethodsAccess;
        private readonly AuthorizationTokenData _token;

        internal UserScopedSocialMethodsAccess(
            ISocialMethodsAccess socialMethodsAccess,
            AuthorizationTokenData token)
        {
            _socialMethodsAccess = socialMethodsAccess;
            _token = token;
        }

        public async ValueTask<BungieResponse<BungieFriendListResponse>> GetFriendList(
            CancellationToken cancellationToken = default)
        {
            return await _socialMethodsAccess
                .GetFriendList(_token, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<BungieFriendRequestListResponse>> GetFriendRequestList(
            CancellationToken cancellationToken = default)
        {
            return await _socialMethodsAccess
                .GetFriendRequestList(_token, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<bool>> IssueFriendRequest(
            string membershipId,
            CancellationToken cancellationToken = default)
        {
            return await _socialMethodsAccess
                .IssueFriendRequest(membershipId, _token, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<bool>> AcceptFriendRequest(
            string membershipId,
            CancellationToken cancellationToken = default)
        {
            return await _socialMethodsAccess
                .AcceptFriendRequest(membershipId, _token, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<bool>> DeclineFriendRequest(
            string membershipId,
            CancellationToken cancellationToken = default)
        {
            return await _socialMethodsAccess
                .DeclineFriendRequest(membershipId, _token, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<bool>> RemoveFriend(
            string membershipId,
            CancellationToken cancellationToken = default)
        {
            return await _socialMethodsAccess
                .RemoveFriend(membershipId, _token, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<bool>> RemoveFriendRequest(
            string membershipId,
            CancellationToken cancellationToken = default)
        {
            return await _socialMethodsAccess
                .RemoveFriendRequest(membershipId, _token, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<PlatformFriendResponse>> GetPlatformFriendList(
            PlatformFriendType friendPlatform,
            int page = 0,
            CancellationToken cancellationToken = default)
        {
            return await _socialMethodsAccess
                .GetPlatformFriendList(friendPlatform, _token, page, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}