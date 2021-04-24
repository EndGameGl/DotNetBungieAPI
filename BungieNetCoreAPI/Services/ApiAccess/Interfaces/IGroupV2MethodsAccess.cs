using NetBungieAPI.Models;
using NetBungieAPI.Models.Config;
using NetBungieAPI.Models.GroupsV2;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Models.Queries;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface IGroupV2MethodsAccess
    {
        /// <summary>
        /// Returns a list of all available group avatars for the signed-in user.
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<Dictionary<int, string>>> GetAvailableAvatars(CancellationToken token = default);

        /// <summary>
        /// Returns a list of all available group themes.
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<GroupTheme[]>> GetAvailableThemes(CancellationToken token = default);
        /// <summary>
        /// Gets the state of the user's clan invite preferences for a particular membership type - true if they wish to be invited to clans, false otherwise.
        /// <para/>
        /// Requires ReadUserData scope.
        /// </summary>
        /// <param name="mType">The Destiny membership type of the account we wish to access settings.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<bool>> GetUserClanInviteSetting(BungieMembershipType mType,
            CancellationToken token = default);
        /// <summary>
        /// Gets groups recommended for you based on the groups to whom those you follow belong.
        /// <para/>
        /// Requires ReadGroups scope.
        /// </summary>
        /// <param name="groupType">Type of groups requested</param>
        /// <param name="createDateRange">Requested range in which to pull recommended groups</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<GroupV2Card[]>> GetRecommendedGroups(GroupType groupType,
            GroupDateRange createDateRange, CancellationToken token = default);

        /// <summary>
        /// Search for Groups.
        /// </summary>
        /// <param name="query">Request body</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<GroupSearchResponse>> GroupSearch(GroupQuery query,
            CancellationToken token = default);

        /// <summary>
        /// Get information about a specific group of the given ID.
        /// </summary>
        /// <param name="groupId">Requested group's id.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<GroupResponse>> GetGroup(long groupId, CancellationToken token = default);

        /// <summary>
        /// Get information about a specific group with the given name and type.
        /// </summary>
        /// <param name="groupName">Exact name of the group to find.</param>
        /// <param name="groupType">Type of group to find.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<GroupResponse>> GetGroupByName(string groupName, GroupType groupType,
            CancellationToken token = default);

        /// <summary>
        /// Get information about a specific group with the given name and type. The POST version.
        /// </summary>
        /// <param name="request">Request params</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<GroupResponse>> GetGroupByNameV2(GroupNameSearchRequest request,
            CancellationToken token = default);

        /// <summary>
        /// Gets a list of available optional conversation channels and their settings.
        /// </summary>
        /// <param name="groupId">Requested group's id.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<GroupOptionalConversation[]>> GetGroupOptionalConversations(long groupId,
            CancellationToken token = default);

        /// <summary>
        /// Edit an existing group. You must have suitable permissions in the group to perform this operation. This latest revision will only edit the fields you pass in - pass null for properties you want to leave unaltered.
        /// <para/>
        /// Requires AdminGroups scope.
        /// </summary>
        /// <param name="groupId">Group ID of the group to edit.</param>
        /// <param name="request">Request body</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns></returns>
        ValueTask<BungieResponse<int>> EditGroup(long groupId, GroupEditAction request,
            CancellationToken token = default);
    }
}