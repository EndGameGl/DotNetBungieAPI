using System;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;
using NetBungieAPI.Exceptions;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Applications;
using NetBungieAPI.Models.Config;
using NetBungieAPI.Models.User;
using NetBungieAPI.Services.ApiAccess.Interfaces;

namespace NetBungieAPI.Services.UserScopedApiAccess
{
    public class UserScopedUserMethodsAccess
    {
        private IUserMethodsAccess _apiAccess;
        private AuthorizationTokenData _token;
        
        internal UserScopedUserMethodsAccess(
            IUserMethodsAccess access,
            AuthorizationTokenData token)
        {
            _apiAccess = access;
            _token = token;
        }

        public async ValueTask<BungieResponse<GeneralUser>> GetBungieNetUserById(
            long id,
            CancellationToken token = default)
        {
            return await _apiAccess.GetBungieNetUserById(id, token);
        }

        public async ValueTask<BungieResponse<GeneralUser[]>> SearchUsers(
            string query,
            CancellationToken token = default)
        {
            return await _apiAccess.SearchUsers(query, token);
        }

        public async ValueTask<BungieResponse<CredentialTypeForAccount[]>> GetCredentialTypesForTargetAccount(
            long id,
            CancellationToken token = default)
        {
            return await _apiAccess.GetCredentialTypesForTargetAccount(id, _token, token);
        }

        public async ValueTask<BungieResponse<UserTheme[]>> GetAvailableThemes(
            CancellationToken token = default)
        {
            return await _apiAccess.GetAvailableThemes(token);
        }

        public async ValueTask<BungieResponse<UserMembershipData>> GetMembershipDataById(long id,
            BungieMembershipType membershipType, CancellationToken token = default)
        {
            return await _apiAccess.GetMembershipDataById(id, membershipType, token);
        }

        public async ValueTask<BungieResponse<UserMembershipData>> GetMembershipDataForCurrentUser(
            CancellationToken token = default)
        {
            return await _apiAccess.GetMembershipDataForCurrentUser(_token, token);
        }

        public async ValueTask<BungieResponse<HardLinkedUserMembership>> GetMembershipFromHardLinkedCredential(
            long credential,
            BungieCredentialType credentialType = BungieCredentialType.SteamId,
            CancellationToken token = default)
        {
            return await _apiAccess.GetMembershipFromHardLinkedCredential(credential, credentialType, token);
        }
    }
}