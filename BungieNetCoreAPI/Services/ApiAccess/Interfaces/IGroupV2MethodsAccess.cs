using NetBungieAPI.GroupsV2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface IGroupV2MethodsAccess
    {
        Task<BungieResponse<Dictionary<int, string>>> GetAvailableAvatars();
        Task<BungieResponse<GroupTheme[]>> GetAvailableThemes();
        Task<BungieResponse<bool>> GetUserClanInviteSetting(BungieMembershipType mType);
        Task<BungieResponse<GroupV2Card[]>> GetRecommendedGroups(GroupType groupType, GroupDateRange createDateRange);
    }
}
