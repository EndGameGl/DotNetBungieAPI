using DotNetBungieAPI.Generated.Models;

namespace DotNetBungieAPI.Generated.Methods;

public interface IGroupV2Api
{
    Task<ApiResponse<Dictionary<int, string>>> GetAvailableAvatars();

    Task<ApiResponse<Models.Config.GroupTheme[]>> GetAvailableThemes();

    Task<ApiResponse<bool>> GetUserClanInviteSetting(
        Models.BungieMembershipType mType,
        string authToken
    );

    Task<ApiResponse<Models.GroupsV2.GroupV2Card[]>> GetRecommendedGroups(
        Models.GroupsV2.GroupDateRange createDateRange,
        Models.GroupsV2.GroupType groupType,
        string authToken
    );

    Task<ApiResponse<Models.GroupsV2.GroupSearchResponse>> GroupSearch(
        Models.GroupsV2.GroupQuery body
    );

    Task<ApiResponse<Models.GroupsV2.GroupResponse>> GetGroup(
        long groupId
    );

    Task<ApiResponse<Models.GroupsV2.GroupResponse>> GetGroupByName(
        string groupName,
        Models.GroupsV2.GroupType groupType
    );

    Task<ApiResponse<Models.GroupsV2.GroupResponse>> GetGroupByNameV2(
        Models.GroupsV2.GroupNameSearchRequest body
    );

    Task<ApiResponse<Models.GroupsV2.GroupOptionalConversation[]>> GetGroupOptionalConversations(
        long groupId
    );

    Task<ApiResponse<int>> EditGroup(
        long groupId,
        Models.GroupsV2.GroupEditAction body,
        string authToken
    );

    Task<ApiResponse<int>> EditClanBanner(
        long groupId,
        Models.GroupsV2.ClanBanner body,
        string authToken
    );

    Task<ApiResponse<int>> EditFounderOptions(
        long groupId,
        Models.GroupsV2.GroupOptionsEditAction body,
        string authToken
    );

    Task<ApiResponse<long>> AddOptionalConversation(
        long groupId,
        Models.GroupsV2.GroupOptionalConversationAddRequest body,
        string authToken
    );

    Task<ApiResponse<long>> EditOptionalConversation(
        long conversationId,
        long groupId,
        Models.GroupsV2.GroupOptionalConversationEditRequest body,
        string authToken
    );

    Task<ApiResponse<Models.SearchResultOfGroupMember>> GetMembersOfGroup(
        int currentpage,
        long groupId,
        Models.GroupsV2.RuntimeGroupMemberType memberType,
        string nameSearch
    );

    Task<ApiResponse<Models.SearchResultOfGroupMember>> GetAdminsAndFounderOfGroup(
        int currentpage,
        long groupId
    );

    Task<ApiResponse<int>> EditGroupMembership(
        long groupId,
        long membershipId,
        Models.BungieMembershipType membershipType,
        Models.GroupsV2.RuntimeGroupMemberType memberType,
        string authToken
    );

    Task<ApiResponse<Models.GroupsV2.GroupMemberLeaveResult>> KickMember(
        long groupId,
        long membershipId,
        Models.BungieMembershipType membershipType,
        string authToken
    );

    Task<ApiResponse<int>> BanMember(
        long groupId,
        long membershipId,
        Models.BungieMembershipType membershipType,
        Models.GroupsV2.GroupBanRequest body,
        string authToken
    );

    Task<ApiResponse<int>> UnbanMember(
        long groupId,
        long membershipId,
        Models.BungieMembershipType membershipType,
        string authToken
    );

    Task<ApiResponse<Models.SearchResultOfGroupBan>> GetBannedMembersOfGroup(
        int currentpage,
        long groupId,
        string authToken
    );

    Task<ApiResponse<Models.SearchResultOfGroupEditHistory>> GetGroupEditHistory(
        int currentpage,
        long groupId,
        string authToken
    );

    Task<ApiResponse<bool>> AbdicateFoundership(
        long founderIdNew,
        long groupId,
        Models.BungieMembershipType membershipType
    );

    Task<ApiResponse<Models.SearchResultOfGroupMemberApplication>> GetPendingMemberships(
        int currentpage,
        long groupId,
        string authToken
    );

    Task<ApiResponse<Models.SearchResultOfGroupMemberApplication>> GetInvitedIndividuals(
        int currentpage,
        long groupId,
        string authToken
    );

    Task<ApiResponse<Models.Entities.EntityActionResult[]>> ApproveAllPending(
        long groupId,
        Models.GroupsV2.GroupApplicationRequest body,
        string authToken
    );

    Task<ApiResponse<Models.Entities.EntityActionResult[]>> DenyAllPending(
        long groupId,
        Models.GroupsV2.GroupApplicationRequest body,
        string authToken
    );

    Task<ApiResponse<Models.Entities.EntityActionResult[]>> ApprovePendingForList(
        long groupId,
        Models.GroupsV2.GroupApplicationListRequest body,
        string authToken
    );

    Task<ApiResponse<bool>> ApprovePending(
        long groupId,
        long membershipId,
        Models.BungieMembershipType membershipType,
        Models.GroupsV2.GroupApplicationRequest body,
        string authToken
    );

    Task<ApiResponse<Models.Entities.EntityActionResult[]>> DenyPendingForList(
        long groupId,
        Models.GroupsV2.GroupApplicationListRequest body,
        string authToken
    );

    Task<ApiResponse<Models.GroupsV2.GetGroupsForMemberResponse>> GetGroupsForMember(
        Models.GroupsV2.GroupsForMemberFilter filter,
        Models.GroupsV2.GroupType groupType,
        long membershipId,
        Models.BungieMembershipType membershipType
    );

    Task<ApiResponse<Models.GroupsV2.GroupMembershipSearchResponse>> RecoverGroupForFounder(
        Models.GroupsV2.GroupType groupType,
        long membershipId,
        Models.BungieMembershipType membershipType
    );

    Task<ApiResponse<Models.GroupsV2.GroupPotentialMembershipSearchResponse>> GetPotentialGroupsForMember(
        Models.GroupsV2.GroupPotentialMemberStatus filter,
        Models.GroupsV2.GroupType groupType,
        long membershipId,
        Models.BungieMembershipType membershipType
    );

    Task<ApiResponse<Models.GroupsV2.GroupApplicationResponse>> IndividualGroupInvite(
        long groupId,
        long membershipId,
        Models.BungieMembershipType membershipType,
        Models.GroupsV2.GroupApplicationRequest body,
        string authToken
    );

    Task<ApiResponse<Models.GroupsV2.GroupApplicationResponse>> IndividualGroupInviteCancel(
        long groupId,
        long membershipId,
        Models.BungieMembershipType membershipType,
        string authToken
    );

}
