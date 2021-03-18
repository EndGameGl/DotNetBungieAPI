using NetBungieAPI.Bungie;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;
using NetBungieAPI.User;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess
{
    public class UserMethodsAccess : IUserMethodsAccess
    {
        private IHttpClientInstance _httpClient;
        internal UserMethodsAccess(IHttpClientInstance httpClient)
        {
            _httpClient = httpClient;
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
        public async Task<BungieResponse<BungieNetUserWithMemberships>> GetMembershipDataById(long id, BungieMembershipType membershipType)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<BungieNetUserWithMemberships>>($"/User/GetMembershipsById/{id}/{membershipType}");
        }
        public async Task<BungieResponse<BungieNetUserWithMemberships>> GetMembershipDataForCurrentUser()
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<BungieNetUserWithMemberships>>($"User/GetMembershipsForCurrentUser");
        }
        public async Task<BungieResponse<DestinyHardLinkedUserMembership>> GetMembershipFromHardLinkedCredential(long credential, BungieCredentialType credentialType = BungieCredentialType.SteamId)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<DestinyHardLinkedUserMembership>>($"/User/GetMembershipFromHardLinkedCredential/{credentialType}/{credential}");
        }
    }
}
