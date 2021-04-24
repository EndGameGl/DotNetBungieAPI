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

        /// <summary>
        /// Edit an existing group's clan banner. You must have suitable permissions in the group to perform this operation. All fields are required.
        /// <para/>
        /// Requires AdminGroups scope.
        /// </summary>
        /// <param name="groupId">Group ID of the group to edit.</param>
        /// <param name="request">Request body</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns></returns>
        ValueTask<BungieResponse<int>> EditClanBanner(long groupId, ClanBanner request,
            CancellationToken token = default);

        /// <summary>
        /// Edit group options only available to a founder. You must have suitable permissions in the group to perform this operation.
        /// <para/>
        /// Requires AdminGroups scope.
        /// </summary>
        /// <param name="groupId">Group ID of the group to edit.</param>
        /// <param name="request">Request body</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns></returns>
        ValueTask<BungieResponse<int>> EditFounderOptions(long groupId, GroupOptionsEditAction request,
            CancellationToken token = default);

        /// <summary>
        /// Add a new optional conversation/chat channel. Requires admin permissions to the group.
        /// <para/>
        /// Requires AdminGroups scope.
        /// </summary>
        /// <param name="groupId">Group ID of the group to edit.</param>
        /// <param name="request">Request body</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns></returns>
        ValueTask<BungieResponse<long>> AddOptionalConversation(long groupId,
            GroupOptionalConversationAddRequest request,
            CancellationToken token = default);

        /// <summary>
        /// Edit the settings of an optional conversation/chat channel. Requires admin permissions to the group.
        /// <para/>
        /// Requires AdminGroups scope.
        /// </summary>
        /// <param name="groupId">Group ID of the group to edit.</param>
        /// <param name="conversationId">Conversation Id of the channel being edited.</param>
        /// <param name="request">Request body</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns></returns>
        ValueTask<BungieResponse<long>> EditOptionalConversation(long groupId, long conversationId,
            GroupOptionalConversationEditRequest request, CancellationToken token = default);

        /// <summary>
        /// Get the list of members in a given group.
        /// </summary>
        /// <param name="groupId">The ID of the group.</param>
        /// <param name="currentpage">Page number (starting with 1). Each page has a fixed size of 50 items per page.</param>
        /// <param name="memberType">Filter out other member types. Use None for all members.</param>
        /// <param name="nameSearch">The name fragment upon which a search should be executed for members with matching display or unique names.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns></returns>
        ValueTask<BungieResponse<SearchResultOfGroupMember>> GetMembersOfGroup(long groupId,
            int currentpage = 1, RuntimeGroupMemberType memberType = RuntimeGroupMemberType.None,
            string nameSearch = null, CancellationToken token = default);

        /// <summary>
        /// Get the list of members in a given group who are of admin level or higher.
        /// </summary>
        /// <param name="groupId">The ID of the group.</param>
        /// <param name="currentpage">Page number (starting with 1). Each page has a fixed size of 50 items per page.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns></returns>
        ValueTask<BungieResponse<SearchResultOfGroupMember>> GetAdminsAndFounderOfGroup(long groupId,
            int currentpage = 1, CancellationToken token = default);

        /// <summary>
        /// Edit the membership type of a given member. You must have suitable permissions in the group to perform this operation.
        /// </summary>
        /// <param name="groupId">ID of the group to which the member belongs.</param>
        /// <param name="membershipId">Membership ID to modify.</param>
        /// <param name="membershipType">Membership type of the provide membership ID.</param>
        /// <param name="memberType">New membertype for the specified member.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<int>> EditGroupMembership(long groupId, long membershipId,
            BungieMembershipType membershipType, RuntimeGroupMemberType memberType, CancellationToken token = default);
    }
}