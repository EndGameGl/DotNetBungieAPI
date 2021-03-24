using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;
using NetBungieAPI.User;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess
{
    public class UserMethodsAccess : IUserMethodsAccess
    {
        private IHttpClientInstance _httpClient;
        private IAuthorizationStateHandler _authHandler;
        internal UserMethodsAccess(IHttpClientInstance httpClient, IAuthorizationStateHandler authHandler)
        {
            _httpClient = httpClient;
            _authHandler = authHandler;
        }
        public async Task<BungieResponse<GeneralUser>> GetBungieNetUserById(long id)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<GeneralUser>>($"/User/GetBungieNetUserById/{id}");
        }
        public async Task<BungieResponse<GeneralUser[]>> SearchUsers(string query)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<GeneralUser[]>>($"/User/SearchUsers/{query}");
        }
        public async Task<BungieResponse<CredentialTypeForAccount[]>> GetCredentialTypesForTargetAccount(long id)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<CredentialTypeForAccount[]>>($"/User/GetCredentialTypesForTargetAccount/{id}");
        }
        public async Task<BungieResponse<UserTheme[]>> GetAvailableThemes()
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<UserTheme[]>>($"/User/GetAvailableThemes");
        }
        public async Task<BungieResponse<UserMembershipData>> GetMembershipDataById(long id, BungieMembershipType membershipType)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<UserMembershipData>>($"/User/GetMembershipsById/{id}/{membershipType}");
        }
        public async Task<BungieResponse<UserMembershipData>> GetMembershipDataForCurrentUser(long id)
        {
            if (_authHandler.TryGetAccessToken(id, out var token))
            {
                return await _httpClient.GetResponseFromBungieNetPlatform<UserMembershipData>($"/User/GetMembershipsForCurrentUser", token);
            }
            throw new System.Exception("Missing token to make a call.");
        }
        public async Task<BungieResponse<HardLinkedUserMembership>> GetMembershipFromHardLinkedCredential(long credential, BungieCredentialType credentialType = BungieCredentialType.SteamId)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<HardLinkedUserMembership>>($"/User/GetMembershipFromHardLinkedCredential/{(byte)credentialType}/{credential}");
        }
    }
}
