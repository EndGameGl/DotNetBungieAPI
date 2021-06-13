using NetBungieAPI.Models;
using NetBungieAPI.Models.Config;
using NetBungieAPI.Models.GroupsV2;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;
using NetBungieAPI.Models.Entities;
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
        ValueTask<BungieResponse<Dictionary<int, string>>> GetAvailableAvatars(
            CancellationToken token = default);

        /// <summary>
        /// Returns a list of all available group themes.
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<GroupTheme[]>> GetAvailableThemes(
            CancellationToken token = default);

        /// <summary>
        /// Gets the state of the user's clan invite preferences for a particular membership type - true if they wish to be invited to clans, false otherwise.
        /// <para/>
        /// Requires ReadUserData scope.
        /// </summary>
        /// <param name="mType">The Destiny membership type of the account we wish to access settings.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<bool>> GetUserClanInviteSetting(
            AuthorizationTokenData authData,
            BungieMembershipType mType,
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
        ValueTask<BungieResponse<GroupV2Card[]>> GetRecommendedGroups(
            AuthorizationTokenData authData,
            GroupType groupType,
            GroupDateRange createDateRange,
            CancellationToken token = default);

        /// <summary>
        /// Search for Groups.
        /// </summary>
        /// <param name="query">Request body</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<GroupSearchResponse>> GroupSearch(
            GroupQuery query,
            CancellationToken token = default);

        /// <summary>
        /// Get information about a specific group of the given ID.
        /// </summary>
        /// <param name="groupId">Requested group's id.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<GroupResponse>> GetGroup(
            long groupId, 
            CancellationToken token = default);

        /// <summary>
        /// Get information about a specific group with the given name and type.
        /// </summary>
        /// <param name="groupName">Exact name of the group to find.</param>
        /// <param name="groupType">Type of group to find.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<GroupResponse>> GetGroupByName(
            string groupName, 
            GroupType groupType,
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
        ValueTask<BungieResponse<GroupOptionalConversation[]>> GetGroupOptionalConversations(
            long groupId,
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
        ValueTask<BungieResponse<int>> EditGroup(
            AuthorizationTokenData authData,
            long groupId,
            GroupEditAction request,
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
        ValueTask<BungieResponse<int>> EditClanBanner(
            AuthorizationTokenData authData,
            long groupId,
            ClanBanner request,
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
        ValueTask<BungieResponse<int>> EditFounderOptions(
            AuthorizationTokenData authData,
            long groupId,
            GroupOptionsEditAction request,
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
        ValueTask<BungieResponse<long>> AddOptionalConversation(
            AuthorizationTokenData authData,
            long groupId,
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
        ValueTask<BungieResponse<long>> EditOptionalConversation(
            AuthorizationTokenData authData,
            long groupId,
            long conversationId,
            GroupOptionalConversationEditRequest request,
            CancellationToken token = default);

        /// <summary>
        /// Get the list of members in a given group.
        /// </summary>
        /// <param name="groupId">The ID of the group.</param>
        /// <param name="currentpage">Page number (starting with 1). Each page has a fixed size of 50 items per page.</param>
        /// <param name="memberType">Filter out other member types. Use None for all members.</param>
        /// <param name="nameSearch">The name fragment upon which a search should be executed for members with matching display or unique names.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns></returns>
        ValueTask<BungieResponse<SearchResultOfGroupMember>> GetMembersOfGroup(
            long groupId,
            int currentpage = 1, 
            RuntimeGroupMemberType memberType = RuntimeGroupMemberType.None,
            string nameSearch = null, 
            CancellationToken token = default);

        /// <summary>
        /// Get the list of members in a given group who are of admin level or higher.
        /// </summary>
        /// <param name="groupId">The ID of the group.</param>
        /// <param name="currentpage">Page number (starting with 1). Each page has a fixed size of 50 items per page.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns></returns>
        ValueTask<BungieResponse<SearchResultOfGroupMember>> GetAdminsAndFounderOfGroup(
            long groupId,
            int currentpage = 1, 
            CancellationToken token = default);

        /// <summary>
        /// Edit the membership type of a given member. You must have suitable permissions in the group to perform this operation.
        /// <para/>
        /// Requires AdminGroups scope.
        /// </summary>
        /// <param name="groupId">ID of the group to which the member belongs.</param>
        /// <param name="membershipId">Membership ID to modify.</param>
        /// <param name="membershipType">Membership type of the provide membership ID.</param>
        /// <param name="memberType">New membertype for the specified member.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<int>> EditGroupMembership(
            AuthorizationTokenData authData,
            long groupId,
            long membershipId,
            BungieMembershipType membershipType,
            RuntimeGroupMemberType memberType,
            CancellationToken token = default);

        /// <summary>
        /// Kick a member from the given group, forcing them to reapply if they wish to re-join the group. You must have suitable permissions in the group to perform this operation.
        /// <para/>
        /// Requires AdminGroups scope.
        /// </summary>
        /// <param name="groupId">Group ID to kick the user from.</param>
        /// <param name="membershipId">Membership ID to kick.</param>
        /// <param name="membershipType">Membership type of the provided membership ID.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns></returns>
        ValueTask<BungieResponse<GroupMemberLeaveResult>> KickMember(
            AuthorizationTokenData authData,
            long groupId,
            long membershipId,
            BungieMembershipType membershipType,
            CancellationToken token = default);

        /// <summary>
        /// Bans the requested member from the requested group for the specified period of time.
        /// <para/>
        /// Requires AdminGroups scope.
        /// </summary>
        /// <param name="groupId">Group ID that has the member to ban.</param>
        /// <param name="membershipId">Membership ID of the member to ban from the group.</param>
        /// <param name="membershipType">Membership type of the provided membership ID.</param>
        /// <param name="request">Request body</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns></returns>
        ValueTask<BungieResponse<int>> BanMember(
            AuthorizationTokenData authData,
            long groupId,
            long membershipId,
            BungieMembershipType membershipType,
            GroupBanRequest request,
            CancellationToken token = default);

        /// <summary>
        /// Unbans the requested member, allowing them to re-apply for membership.
        /// <para/>
        /// Requires AdminGroups scope.
        /// </summary>
        /// <param name="groupId">Group ID that has the member to unban.</param>
        /// <param name="membershipId">Membership ID of the member to unban from the group</param>
        /// <param name="membershipType">Membership type of the provided membership ID.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns></returns>
        ValueTask<BungieResponse<int>> UnbanMember(
            AuthorizationTokenData authData,
            long groupId,
            long membershipId,
            BungieMembershipType membershipType,
            CancellationToken token = default);

        /// <summary>
        /// Get the list of banned members in a given group. Only accessible to group Admins and above. Not applicable to all groups. Check group features.
        /// </summary>
        /// <param name="groupId">Group ID whose banned members you are fetching</param>
        /// <param name="currentpage">Page number (starting with 1). Each page has a fixed size of 50 entries.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<SearchResultOfGroupBan>> GetBannedMembersOfGroup(
            AuthorizationTokenData authData,
            long groupId,
            int currentpage = 1,
            CancellationToken token = default);

        /// <summary>
        /// An administrative method to allow the founder of a group or clan to give up their position to another admin permanently.
        /// </summary>
        /// <param name="groupId">The target group id</param>
        /// <param name="founderIdNew">The new founder for this group. Must already be a group admin.</param>
        /// <param name="membershipType">Membership type of the provided founderIdNew.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<bool>> AbdicateFoundership(
            AuthorizationTokenData authData,
            long groupId,
            long founderIdNew,
            BungieMembershipType membershipType,
            CancellationToken token = default);

        /// <summary>
        /// Get the list of users who are awaiting a decision on their application to join a given group. Modified to include application info.
        /// </summary>
        /// <param name="groupId">ID of the group.</param>
        /// <param name="currentpage">Page number (starting with 1). Each page has a fixed size of 50 items per page.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<SearchResultOfGroupMemberApplication>> GetPendingMemberships(
            AuthorizationTokenData authData,
            long groupId,
            int currentpage = 1,
            CancellationToken token = default);

        /// <summary>
        /// Get the list of users who have been invited into the group.
        /// </summary>
        /// <param name="groupId">ID of the group.</param>
        /// <param name="currentpage">Page number (starting with 1). Each page has a fixed size of 50 items per page.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<SearchResultOfGroupMemberApplication>> GetInvitedIndividuals(
            AuthorizationTokenData authData,
            long groupId,
            int currentpage = 1, 
            CancellationToken token = default);

        /// <summary>
        /// Approve all of the pending users for the given group.
        /// </summary>
        /// <param name="groupId">ID of the group.</param>
        /// <param name="request">Request body</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<EntityActionResult[]>> ApproveAllPending(
            AuthorizationTokenData authData,
            long groupId, 
            GroupApplicationRequest request,
            CancellationToken token = default);

        /// <summary>
        /// Deny all of the pending users for the given group.
        /// </summary>
        /// <param name="groupId">ID of the group.</param>
        /// <param name="request">Request body</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<EntityActionResult[]>> DenyAllPending(
            AuthorizationTokenData authData,
            long groupId, 
            GroupApplicationRequest request,
            CancellationToken token = default);

        /// <summary>
        /// Approve all of the pending users for the given group.
        /// </summary>
        /// <param name="groupId">ID of the group.</param>
        /// <param name="request">Request body</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<EntityActionResult[]>> ApprovePendingForList(
            AuthorizationTokenData authData,
            long groupId,
            GroupApplicationListRequest request, 
            CancellationToken token = default);

        /// <summary>
        /// Approve the given membershipId to join the group/clan as long as they have applied.
        /// </summary>
        /// <param name="groupId">ID of the group.</param>
        /// <param name="membershipId">The membership id being approved.</param>
        /// <param name="membershipType">Membership type of the supplied membership ID.</param>
        /// <param name="request">Request body</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<bool>> ApprovePending(
            AuthorizationTokenData authData,
            long groupId, 
            long membershipId,
            BungieMembershipType membershipType, 
            GroupApplicationRequest request, CancellationToken token = default);

        /// <summary>
        /// Deny all of the pending users for the given group that match the passed-in.
        /// </summary>
        /// <param name="groupId">ID of the group.</param>
        /// <param name="request">Request body</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<EntityActionResult[]>> DenyPendingForList(
            AuthorizationTokenData authData,
            long groupId,
            GroupApplicationListRequest request, 
            CancellationToken token = default);

        /// <summary>
        /// Get information about the groups that a given member has joined.
        /// </summary>
        /// <param name="membershipType">Membership type of the supplied membership ID.</param>
        /// <param name="membershipId">Membership ID to for which to find founded groups.</param>
        /// <param name="filter">Filter apply to list of joined groups.</param>
        /// <param name="groupType">Type of group the supplied member founded.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<GetGroupsForMemberResponse>> GetGroupsForMember(
            BungieMembershipType membershipType, 
            long membershipId, 
            GroupsForMemberFilter filter, 
            GroupType groupType,
            CancellationToken token = default);

        /// <summary>
        /// Allows a founder to manually recover a group they can see in game but not on bungie.net
        /// </summary>
        /// <param name="membershipType">Membership type of the supplied membership ID.</param>
        /// <param name="membershipId">Membership ID to for which to find founded groups.</param>
        /// <param name="groupType">Type of group the supplied member founded.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<GroupMembershipSearchResponse>> RecoverGroupForFounder(
            BungieMembershipType membershipType, 
            long membershipId, 
            GroupType groupType,
            CancellationToken token = default);

        /// <summary>
        /// Get information about the groups that a given member has applied to or been invited to.
        /// </summary>
        /// <param name="membershipType">Membership type of the supplied membership ID.</param>
        /// <param name="membershipId">Membership ID to for which to find applied groups.</param>
        /// <param name="groupType">Type of group the supplied member applied.</param>
        /// <param name="filter">Filter apply to list of potential joined groups.</param>
        /// <param name="token"></param>
        /// <returns></returns>
        ValueTask<BungieResponse<GroupPotentialMembershipSearchResponse>> GetPotentialGroupsForMember(
            BungieMembershipType membershipType, 
            long membershipId, 
            GroupType groupType, 
            GroupsForMemberFilter filter,
            CancellationToken token = default);

        /// <summary>
        /// Invite a user to join this group.
        /// </summary>
        /// <param name="groupId">ID of the group you would like to join.</param>
        /// <param name="membershipType">MembershipType of the account being invited.</param>
        /// <param name="membershipId">Membership id of the account being invited.</param>
        /// <param name="request">Request body</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<GroupApplicationResponse>> IndividualGroupInvite(
            AuthorizationTokenData authData,
            long groupId,
            BungieMembershipType membershipType, 
            long membershipId, 
            GroupApplicationRequest request,
            CancellationToken token = default);

        /// <summary>
        /// Cancels a pending invitation to join a group.
        /// </summary>
        /// <param name="groupId">ID of the group you would like to join.</param>
        /// <param name="membershipType">MembershipType of the account being cancelled.</param>
        /// <param name="membershipId">Membership id of the account being cancelled.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<GroupApplicationResponse>> IndividualGroupInviteCancel(
            AuthorizationTokenData authData,
            long groupId,
            BungieMembershipType membershipType, 
            long membershipId, 
            CancellationToken token = default);
    }
}