using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Authorization;

namespace DotNetBungieAPI.Service.Abstractions.ApiAccess;

public interface IGroupV2Api
{
    Task<BungieResponse<Dictionary<int, string>>> GetAvailableAvatars(AuthorizationTokenData? authorizationToken = null, CancellationToken cancellationToken = default);

    Task<BungieResponse<Models.Config.GroupTheme[]>> GetAvailableThemes(AuthorizationTokenData? authorizationToken = null, CancellationToken cancellationToken = default);

    Task<BungieResponse<bool>> GetUserClanInviteSetting(
        Models.BungieMembershipType mType,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.GroupsV2.GroupV2Card[]>> GetRecommendedGroups(
        Models.GroupsV2.GroupDateRange createDateRange,
        Models.GroupsV2.GroupType groupType,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.GroupsV2.GroupSearchResponse>> GroupSearch(
        Models.GroupsV2.GroupQuery requestBody,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.GroupsV2.GroupResponse>> GetGroup(
        long groupId,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.GroupsV2.GroupResponse>> GetGroupByName(
        string groupName,
        Models.GroupsV2.GroupType groupType,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.GroupsV2.GroupResponse>> GetGroupByNameV2(
        Models.GroupsV2.GroupNameSearchRequest requestBody,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.GroupsV2.GroupOptionalConversation[]>> GetGroupOptionalConversations(
        long groupId,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<int>> EditGroup(
        long groupId,
        Models.GroupsV2.GroupEditAction requestBody,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<int>> EditClanBanner(
        long groupId,
        Models.GroupsV2.ClanBanner requestBody,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<int>> EditFounderOptions(
        long groupId,
        Models.GroupsV2.GroupOptionsEditAction requestBody,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<long>> AddOptionalConversation(
        long groupId,
        Models.GroupsV2.GroupOptionalConversationAddRequest requestBody,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<long>> EditOptionalConversation(
        long conversationId,
        long groupId,
        Models.GroupsV2.GroupOptionalConversationEditRequest requestBody,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.SearchResultOfGroupMember>> GetMembersOfGroup(
        int currentpage,
        long groupId,
        Models.GroupsV2.RuntimeGroupMemberType memberType,
        string nameSearch,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.SearchResultOfGroupMember>> GetAdminsAndFounderOfGroup(
        int currentpage,
        long groupId,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<int>> EditGroupMembership(
        long groupId,
        long membershipId,
        Models.BungieMembershipType membershipType,
        Models.GroupsV2.RuntimeGroupMemberType memberType,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.GroupsV2.GroupMemberLeaveResult>> KickMember(
        long groupId,
        long membershipId,
        Models.BungieMembershipType membershipType,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<int>> BanMember(
        long groupId,
        long membershipId,
        Models.BungieMembershipType membershipType,
        Models.GroupsV2.GroupBanRequest requestBody,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<int>> UnbanMember(
        long groupId,
        long membershipId,
        Models.BungieMembershipType membershipType,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.SearchResultOfGroupBan>> GetBannedMembersOfGroup(
        int currentpage,
        long groupId,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.SearchResultOfGroupEditHistory>> GetGroupEditHistory(
        int currentpage,
        long groupId,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<bool>> AbdicateFoundership(
        long founderIdNew,
        long groupId,
        Models.BungieMembershipType membershipType,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.SearchResultOfGroupMemberApplication>> GetPendingMemberships(
        int currentpage,
        long groupId,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.SearchResultOfGroupMemberApplication>> GetInvitedIndividuals(
        int currentpage,
        long groupId,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Entities.EntityActionResult[]>> ApproveAllPending(
        long groupId,
        Models.GroupsV2.GroupApplicationRequest requestBody,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Entities.EntityActionResult[]>> DenyAllPending(
        long groupId,
        Models.GroupsV2.GroupApplicationRequest requestBody,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Entities.EntityActionResult[]>> ApprovePendingForList(
        long groupId,
        Models.GroupsV2.GroupApplicationListRequest requestBody,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<bool>> ApprovePending(
        long groupId,
        long membershipId,
        Models.BungieMembershipType membershipType,
        Models.GroupsV2.GroupApplicationRequest requestBody,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Entities.EntityActionResult[]>> DenyPendingForList(
        long groupId,
        Models.GroupsV2.GroupApplicationListRequest requestBody,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.GroupsV2.GetGroupsForMemberResponse>> GetGroupsForMember(
        Models.GroupsV2.GroupsForMemberFilter filter,
        Models.GroupsV2.GroupType groupType,
        long membershipId,
        Models.BungieMembershipType membershipType,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.GroupsV2.GroupMembershipSearchResponse>> RecoverGroupForFounder(
        Models.GroupsV2.GroupType groupType,
        long membershipId,
        Models.BungieMembershipType membershipType,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.GroupsV2.GroupPotentialMembershipSearchResponse>> GetPotentialGroupsForMember(
        Models.GroupsV2.GroupPotentialMemberStatus filter,
        Models.GroupsV2.GroupType groupType,
        long membershipId,
        Models.BungieMembershipType membershipType,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.GroupsV2.GroupApplicationResponse>> IndividualGroupInvite(
        long groupId,
        long membershipId,
        Models.BungieMembershipType membershipType,
        Models.GroupsV2.GroupApplicationRequest requestBody,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.GroupsV2.GroupApplicationResponse>> IndividualGroupInviteCancel(
        long groupId,
        long membershipId,
        Models.BungieMembershipType membershipType,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

}
