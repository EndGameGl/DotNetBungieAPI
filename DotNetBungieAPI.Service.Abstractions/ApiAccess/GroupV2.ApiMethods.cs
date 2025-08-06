using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Authorization;

namespace DotNetBungieAPI.Service.Abstractions.ApiAccess;

public interface IGroupV2Api
{
    Task<BungieResponse<Dictionary<int, string>>> GetAvailableAvatars(CancellationToken cancellationToken = default);

    Task<BungieResponse<Models.Config.GroupTheme[]>> GetAvailableThemes(CancellationToken cancellationToken = default);

    Task<BungieResponse<bool>> GetUserClanInviteSetting(
        Models.BungieMembershipType mType,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.GroupsV2.GroupV2Card[]>> GetRecommendedGroups(
        Models.GroupsV2.GroupDateRange createDateRange,
        Models.GroupsV2.GroupType groupType,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.GroupsV2.GroupSearchResponse>> GroupSearch(
        Models.GroupsV2.GroupQuery requestBody,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.GroupsV2.GroupResponse>> GetGroup(
        long groupId,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.GroupsV2.GroupResponse>> GetGroupByName(
        string groupName,
        Models.GroupsV2.GroupType groupType,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.GroupsV2.GroupResponse>> GetGroupByNameV2(
        Models.GroupsV2.GroupNameSearchRequest requestBody,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.GroupsV2.GroupOptionalConversation[]>> GetGroupOptionalConversations(
        long groupId,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<int>> EditGroup(
        long groupId,
        Models.GroupsV2.GroupEditAction requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<int>> EditClanBanner(
        long groupId,
        Models.GroupsV2.ClanBanner requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<int>> EditFounderOptions(
        long groupId,
        Models.GroupsV2.GroupOptionsEditAction requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<long>> AddOptionalConversation(
        long groupId,
        Models.GroupsV2.GroupOptionalConversationAddRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<long>> EditOptionalConversation(
        long conversationId,
        long groupId,
        Models.GroupsV2.GroupOptionalConversationEditRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.SearchResultOfGroupMember>> GetMembersOfGroup(
        int currentpage,
        long groupId,
        Models.GroupsV2.RuntimeGroupMemberType memberType,
        string nameSearch,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.SearchResultOfGroupMember>> GetAdminsAndFounderOfGroup(
        int currentpage,
        long groupId,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<int>> EditGroupMembership(
        long groupId,
        long membershipId,
        Models.BungieMembershipType membershipType,
        Models.GroupsV2.RuntimeGroupMemberType memberType,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.GroupsV2.GroupMemberLeaveResult>> KickMember(
        long groupId,
        long membershipId,
        Models.BungieMembershipType membershipType,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<int>> BanMember(
        long groupId,
        long membershipId,
        Models.BungieMembershipType membershipType,
        Models.GroupsV2.GroupBanRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<int>> UnbanMember(
        long groupId,
        long membershipId,
        Models.BungieMembershipType membershipType,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.SearchResultOfGroupBan>> GetBannedMembersOfGroup(
        int currentpage,
        long groupId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.SearchResultOfGroupEditHistory>> GetGroupEditHistory(
        int currentpage,
        long groupId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<bool>> AbdicateFoundership(
        long founderIdNew,
        long groupId,
        Models.BungieMembershipType membershipType,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.SearchResultOfGroupMemberApplication>> GetPendingMemberships(
        int currentpage,
        long groupId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.SearchResultOfGroupMemberApplication>> GetInvitedIndividuals(
        int currentpage,
        long groupId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Entities.EntityActionResult[]>> ApproveAllPending(
        long groupId,
        Models.GroupsV2.GroupApplicationRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Entities.EntityActionResult[]>> DenyAllPending(
        long groupId,
        Models.GroupsV2.GroupApplicationRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Entities.EntityActionResult[]>> ApprovePendingForList(
        long groupId,
        Models.GroupsV2.GroupApplicationListRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<bool>> ApprovePending(
        long groupId,
        long membershipId,
        Models.BungieMembershipType membershipType,
        Models.GroupsV2.GroupApplicationRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Entities.EntityActionResult[]>> DenyPendingForList(
        long groupId,
        Models.GroupsV2.GroupApplicationListRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.GroupsV2.GetGroupsForMemberResponse>> GetGroupsForMember(
        Models.GroupsV2.GroupsForMemberFilter filter,
        Models.GroupsV2.GroupType groupType,
        long membershipId,
        Models.BungieMembershipType membershipType,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.GroupsV2.GroupMembershipSearchResponse>> RecoverGroupForFounder(
        Models.GroupsV2.GroupType groupType,
        long membershipId,
        Models.BungieMembershipType membershipType,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.GroupsV2.GroupPotentialMembershipSearchResponse>> GetPotentialGroupsForMember(
        Models.GroupsV2.GroupPotentialMemberStatus filter,
        Models.GroupsV2.GroupType groupType,
        long membershipId,
        Models.BungieMembershipType membershipType,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.GroupsV2.GroupApplicationResponse>> IndividualGroupInvite(
        long groupId,
        long membershipId,
        Models.BungieMembershipType membershipType,
        Models.GroupsV2.GroupApplicationRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.GroupsV2.GroupApplicationResponse>> IndividualGroupInviteCancel(
        long groupId,
        long membershipId,
        Models.BungieMembershipType membershipType,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

}
