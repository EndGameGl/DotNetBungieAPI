using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Config;
using NetBungieAPI.Models.User;
using NetBungieAPI.Services.ApiAccess.Interfaces;

namespace NetBungieAPI.Services.UserScopedApiAccess
{
    /// <summary>
    /// <inheritdoc cref="IUserMethodsAccess"/>
    /// </summary>
    public class UserScopedUserMethodsAccess
    {
        private readonly IUserMethodsAccess _apiAccess;
        private readonly AuthorizationTokenData _token;

        internal UserScopedUserMethodsAccess(
            IUserMethodsAccess access,
            AuthorizationTokenData token)
        {
            _apiAccess = access;
            _token = token;
        }

        public async ValueTask<BungieResponse<GeneralUser>> GetBungieNetUserById(
            long id,
            CancellationToken cancellationToken = default)
        {
            return await _apiAccess
                .GetBungieNetUserById(id, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<CredentialTypeForAccount[]>> GetCredentialTypesForTargetAccount(
            long id,
            CancellationToken cancellationToken = default)
        {
            return await _apiAccess
                .GetCredentialTypesForTargetAccount(id, _token, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<UserTheme[]>> GetAvailableThemes(
            CancellationToken token = default)
        {
            return await _apiAccess
                .GetAvailableThemes(token)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<UserMembershipData>> GetMembershipDataById(long id,
            BungieMembershipType membershipType, CancellationToken token = default)
        {
            return await _apiAccess
                .GetMembershipDataById(id, membershipType, token)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<UserMembershipData>> GetMembershipDataForCurrentUser(
            CancellationToken token = default)
        {
            return await _apiAccess
                .GetMembershipDataForCurrentUser(_token, token)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<HardLinkedUserMembership>> GetMembershipFromHardLinkedCredential(
            long credential,
            BungieCredentialType credentialType = BungieCredentialType.SteamId,
            CancellationToken token = default)
        {
            return await _apiAccess
                .GetMembershipFromHardLinkedCredential(credential, credentialType, token)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<UserSearchResponse>> SearchUsersByPrefix(
            string prefix,
            int page = 0,
            CancellationToken token = default)
        {
            return await _apiAccess
                .SearchByGlobalNamePrefix(prefix, page, token)
                .ConfigureAwait(false);
        }
    }
}