using NetBungieAPI.Models;
using NetBungieAPI.Models.Config;
using NetBungieAPI.Models.GroupsV2;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface IGroupV2MethodsAccess
    {
        ValueTask<BungieResponse<Dictionary<int, string>>> GetAvailableAvatars(CancellationToken token = default);
        ValueTask<BungieResponse<GroupTheme[]>> GetAvailableThemes(CancellationToken token = default);

        ValueTask<BungieResponse<bool>> GetUserClanInviteSetting(BungieMembershipType mType,
            CancellationToken token = default);

        ValueTask<BungieResponse<GroupV2Card[]>> GetRecommendedGroups(GroupType groupType,
            GroupDateRange createDateRange, CancellationToken token = default);
    }
}