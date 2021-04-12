using NetBungieAPI.Models;
using NetBungieAPI.Models.Config;
using NetBungieAPI.Models.User;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess
{
    public class UserMethodsAccess : IUserMethodsAccess
    {
        private readonly IHttpClientInstance _httpClient;
        private readonly IAuthorizationStateHandler _authHandler;
        internal UserMethodsAccess(IHttpClientInstance httpClient, IAuthorizationStateHandler authHandler)
        {
            _httpClient = httpClient;
            _authHandler = authHandler;
        }
        public async ValueTask<BungieResponse<GeneralUser>> GetBungieNetUserById(long id, CancellationToken token = default)
        {
            var url = StringBuilderPool.GetBuilder(token).Append("/User/GetBungieNetUserById/").Append(id).ToString();
            return await _httpClient.GetFromBungieNetPlatform<GeneralUser>(url, token);
        }
        public async ValueTask<BungieResponse<GeneralUser[]>> SearchUsers(string query, CancellationToken token = default)
        {
            var url = StringBuilderPool.GetBuilder(token).Append("/User/SearchUsers/?q=").Append(query).ToString();
            return await _httpClient.GetFromBungieNetPlatform<GeneralUser[]>(url, token);
        }
        public async ValueTask<BungieResponse<CredentialTypeForAccount[]>> GetCredentialTypesForTargetAccount(long id, CancellationToken token = default)
        {
            var url = StringBuilderPool.GetBuilder(token).Append("/User/GetCredentialTypesForTargetAccount/").Append(id).ToString();
            return await _httpClient.GetFromBungieNetPlatform<CredentialTypeForAccount[]>(url, token);
        }
        public async ValueTask<BungieResponse<UserTheme[]>> GetAvailableThemes(CancellationToken token = default)
        {
            return await _httpClient.GetFromBungieNetPlatform<UserTheme[]>("/User/GetAvailableThemes", token);
        }
        public async ValueTask<BungieResponse<UserMembershipData>> GetMembershipDataById(long id, BungieMembershipType membershipType, CancellationToken token = default)
        {
            var url = StringBuilderPool.GetBuilder().Append("/User/GetMembershipsById/").Append(id).Append('/').Append((int)membershipType).ToString();
            return await _httpClient.GetFromBungieNetPlatform<UserMembershipData>(url, token);
        }
        public async ValueTask<BungieResponse<UserMembershipData>> GetMembershipDataForCurrentUser(long id, CancellationToken token = default)
        {
            if (_authHandler.TryGetAccessToken(id, out var accessToken))
            {
                return await _httpClient.GetFromBungieNetPlatform<UserMembershipData>("/User/GetMembershipsForCurrentUser", token, accessToken);
            }
            throw new System.Exception("Missing token to make a call.");
        }
        public async ValueTask<BungieResponse<HardLinkedUserMembership>> GetMembershipFromHardLinkedCredential(long credential, BungieCredentialType credentialType = BungieCredentialType.SteamId, CancellationToken token = default)
        {
            var url = StringBuilderPool.GetBuilder().Append("/User/GetMembershipFromHardLinkedCredential/").Append((byte)credentialType).Append('/').Append(credential).ToString();
            return await _httpClient.GetFromBungieNetPlatform<HardLinkedUserMembership>(url, token);
        }
    }
}
