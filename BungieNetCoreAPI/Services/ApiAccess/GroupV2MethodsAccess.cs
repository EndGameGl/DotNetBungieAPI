using NetBungieAPI.GroupsV2;
using NetBungieAPI.Services;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess
{
    public class GroupV2MethodsAccess : IGroupV2MethodsAccess
    {
        private IHttpClientInstance _httpClient;
        internal GroupV2MethodsAccess(IHttpClientInstance httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BungieResponse<Dictionary<int, string>>> GetAvailableAvatars()
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<Dictionary<int, string>>>("/GroupV2/GetAvailableAvatars/");
        }
        public async Task<BungieResponse<GroupTheme[]>> GetAvailableThemes()
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<GroupTheme[]>>("/GroupV2/GetAvailableThemes/");
        }
        public async Task<BungieResponse<bool>> GetUserClanInviteSetting(BungieMembershipType mType)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<bool>>($"/GroupV2/GetUserClanInviteSetting/{mType}/");
        }
        public async Task<BungieResponse<GroupV2Card[]>> GetRecommendedGroups(GroupType groupType, GroupDateRange createDateRange)
        {         
            return await _httpClient.PostToPlatformAndDeserialize<BungieResponse<GroupV2Card[]>>($"/GroupV2/Recommended/{(int)groupType}/{(int)createDateRange}/", string.Empty);
        }
    }
}
