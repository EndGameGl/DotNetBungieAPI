using NetBungieAPI.Bungie;
using NetBungieAPI.Services;
using System.Threading.Tasks;

namespace NetBungieAPI
{
    public static class UserMethods
    {
        private static IHttpClientInstance _httpClient;
        static UserMethods()
        {
            _httpClient = StaticUnityContainer.GetHTTPClient();
        }
        public static async Task<BungieResponse<BungieNetUser>> GetBungieNetUserById(long id)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<BungieNetUser>>($"/User/GetBungieNetUserById/{id}");
        }
        public static async Task<BungieResponse<BungieNetUser[]>> SearchUsers(string query)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<BungieNetUser[]>>($"/User/SearchUsers/{query}");
        }
        public static async Task<BungieResponse<BungieNetUserAccountCredentialType[]>> GetCredentialTypesForTargetAccount(long id)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<BungieNetUserAccountCredentialType[]>>($"User/GetCredentialTypesForTargetAccount/{id}");
        }
        public static async Task<BungieResponse<BungieUserTheme[]>> GetAvailableThemes()
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<BungieUserTheme[]>>($"/User/GetAvailableThemes");
        }
        public static async Task<BungieResponse<BungieNetUserWithMemberships>> GetMembershipDataById(long id, BungieMembershipType membershipType)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<BungieNetUserWithMemberships>>($"/User/GetMembershipsById/{id}/{membershipType}");
        }
        public static async Task<BungieResponse<BungieNetUserWithMemberships>> GetMembershipDataForCurrentUser()
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<BungieNetUserWithMemberships>>($"User/GetMembershipsForCurrentUser");
        }
        public static async Task<BungieResponse<DestinyHardLinkedUserMembership>> GetMembershipFromHardLinkedCredential(long credential, BungieCredentialType credentialType = BungieCredentialType.SteamId)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<DestinyHardLinkedUserMembership>>($"/User/GetMembershipFromHardLinkedCredential/{credentialType}/{credential}");
        }
    }
}
