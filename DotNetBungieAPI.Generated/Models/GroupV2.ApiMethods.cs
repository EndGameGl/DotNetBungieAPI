namespace DotNetBungieAPI.Generated.Models;

public interface IGroupV2Api
{
    Task<ApiResponse<Dictionary<int, string>>> GetAvailableAvatars();

    Task<ApiResponse<List<Config.GroupTheme>>> GetAvailableThemes();

    Task<ApiResponse<bool>> GetUserClanInviteSetting(
        BungieMembershipType mType,
        string authToken
    );

    Task<ApiResponse<List<GroupsV2.GroupV2Card>>> GetRecommendedGroups(
        GroupsV2.GroupDateRange createDateRange,
        GroupsV2.GroupType groupType,
        string authToken
    );

    Task<ApiResponse<GroupsV2.GroupSearchResponse>> GroupSearch(
        GroupsV2.GroupQuery body
    );

    Task<ApiResponse<GroupsV2.GroupResponse>> GetGroup(
        long groupId
    );

    Task<ApiResponse<GroupsV2.GroupResponse>> GetGroupByName(
        string groupName,
        GroupsV2.GroupType groupType
    );

    Task<ApiResponse<GroupsV2.GroupResponse>> GetGroupByNameV2(
        GroupsV2.GroupNameSearchRequest body
    );

    Task<ApiResponse<List<GroupsV2.GroupOptionalConversation>>> GetGroupOptionalConversations(
        long groupId
    );

    Task<ApiResponse<int>> EditGroup(
        long groupId,
        GroupsV2.GroupEditAction body,
        string authToken
    );

    Task<ApiResponse<int>> EditClanBanner(
        long groupId,
        GroupsV2.ClanBanner body,
        string authToken
    );

    Task<ApiResponse<int>> EditFounderOptions(
        long groupId,
        GroupsV2.GroupOptionsEditAction body,
        string authToken
    );

    Task<ApiResponse<long>> AddOptionalConversation(
        long groupId,
        GroupsV2.GroupOptionalConversationAddRequest body,
        string authToken
    );

    Task<ApiResponse<long>> EditOptionalConversation(
        long conversationId,
        long groupId,
        GroupsV2.GroupOptionalConversationEditRequest body,
        string authToken
    );

    Task<ApiResponse<SearchResultOfGroupMember>> GetMembersOfGroup(
        int currentpage,
        long groupId,
        GroupsV2.RuntimeGroupMemberType memberType,
        string nameSearch
    );

    Task<ApiResponse<SearchResultOfGroupMember>> GetAdminsAndFounderOfGroup(
        int currentpage,
        long groupId
    );

    Task<ApiResponse<int>> EditGroupMembership(
        long groupId,
        long membershipId,
        BungieMembershipType membershipType,
        GroupsV2.RuntimeGroupMemberType memberType,
        string authToken
    );

    Task<ApiResponse<GroupsV2.GroupMemberLeaveResult>> KickMember(
        long groupId,
        long membershipId,
        BungieMembershipType membershipType,
        string authToken
    );

    Task<ApiResponse<int>> BanMember(
        long groupId,
        long membershipId,
        BungieMembershipType membershipType,
        GroupsV2.GroupBanRequest body,
        string authToken
    );

    Task<ApiResponse<int>> UnbanMember(
        long groupId,
        long membershipId,
        BungieMembershipType membershipType,
        string authToken
    );

    Task<ApiResponse<SearchResultOfGroupBan>> GetBannedMembersOfGroup(
        int currentpage,
        long groupId,
        string authToken
    );

    Task<ApiResponse<bool>> AbdicateFoundership(
        long founderIdNew,
        long groupId,
        BungieMembershipType membershipType
    );

    Task<ApiResponse<SearchResultOfGroupMemberApplication>> GetPendingMemberships(
        int currentpage,
        long groupId,
        string authToken
    );

    Task<ApiResponse<SearchResultOfGroupMemberApplication>> GetInvitedIndividuals(
        int currentpage,
        long groupId,
        string authToken
    );

    Task<ApiResponse<List<Entities.EntityActionResult>>> ApproveAllPending(
        long groupId,
        GroupsV2.GroupApplicationRequest body,
        string authToken
    );

    Task<ApiResponse<List<Entities.EntityActionResult>>> DenyAllPending(
        long groupId,
        GroupsV2.GroupApplicationRequest body,
        string authToken
    );

    Task<ApiResponse<List<Entities.EntityActionResult>>> ApprovePendingForList(
        long groupId,
        GroupsV2.GroupApplicationListRequest body,
        string authToken
    );

    Task<ApiResponse<bool>> ApprovePending(
        long groupId,
        long membershipId,
        BungieMembershipType membershipType,
        GroupsV2.GroupApplicationRequest body,
        string authToken
    );

    Task<ApiResponse<List<Entities.EntityActionResult>>> DenyPendingForList(
        long groupId,
        GroupsV2.GroupApplicationListRequest body,
        string authToken
    );

    Task<ApiResponse<GroupsV2.GetGroupsForMemberResponse>> GetGroupsForMember(
        GroupsV2.GroupsForMemberFilter filter,
        GroupsV2.GroupType groupType,
        long membershipId,
        BungieMembershipType membershipType
    );

    Task<ApiResponse<GroupsV2.GroupMembershipSearchResponse>> RecoverGroupForFounder(
        GroupsV2.GroupType groupType,
        long membershipId,
        BungieMembershipType membershipType
    );

    Task<ApiResponse<GroupsV2.GroupPotentialMembershipSearchResponse>> GetPotentialGroupsForMember(
        GroupsV2.GroupPotentialMemberStatus filter,
        GroupsV2.GroupType groupType,
        long membershipId,
        BungieMembershipType membershipType
    );

    Task<ApiResponse<GroupsV2.GroupApplicationResponse>> IndividualGroupInvite(
        long groupId,
        long membershipId,
        BungieMembershipType membershipType,
        GroupsV2.GroupApplicationRequest body,
        string authToken
    );

    Task<ApiResponse<GroupsV2.GroupApplicationResponse>> IndividualGroupInviteCancel(
        long groupId,
        long membershipId,
        BungieMembershipType membershipType,
        string authToken
    );

}
