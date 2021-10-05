using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DotNetBungieAPI.Authorization;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Config;
using DotNetBungieAPI.Models.Entities;
using DotNetBungieAPI.Models.GroupsV2;
using DotNetBungieAPI.Models.Queries;
using DotNetBungieAPI.Services.ApiAccess.Interfaces;

namespace DotNetBungieAPI.Services.ApiAccess.UserScoped
{
    public sealed class UserScopedGroupV2MethodsAccess
    {
        private readonly IGroupV2MethodsAccess _apiAccess;
        private readonly AuthorizationTokenData _token;

        internal UserScopedGroupV2MethodsAccess(
            IGroupV2MethodsAccess apiAccess,
            AuthorizationTokenData token)
        {
            _apiAccess = apiAccess;
            _token = token;
        }

        public async ValueTask<BungieResponse<Dictionary<int, string>>> GetAvailableAvatars(
            CancellationToken token = default)
        {
            return await _apiAccess.GetAvailableAvatars(token);
        }

        public async ValueTask<BungieResponse<GroupTheme[]>> GetAvailableThemes(
            CancellationToken token = default)
        {
            return await _apiAccess.GetAvailableThemes(token);
        }

        public async ValueTask<BungieResponse<bool>> GetUserClanInviteSetting(
            BungieMembershipType mType,
            CancellationToken token = default)
        {
            return await _apiAccess.GetUserClanInviteSetting(_token, mType, token);
        }

        public async ValueTask<BungieResponse<GroupV2Card[]>> GetRecommendedGroups(
            GroupType groupType,
            GroupDateRange createDateRange,
            CancellationToken token = default)
        {
            return await _apiAccess.GetRecommendedGroups(_token, groupType, createDateRange, token);
        }

        public async ValueTask<BungieResponse<GroupSearchResponse>> GroupSearch(
            GroupQuery query,
            CancellationToken token = default)
        {
            return await _apiAccess.GroupSearch(query, token);
        }

        public async ValueTask<BungieResponse<GroupResponse>> GetGroup(
            long groupId,
            CancellationToken token = default)
        {
            return await _apiAccess.GetGroup(groupId, token);
        }

        public async ValueTask<BungieResponse<GroupResponse>> GetGroupByName(
            string groupName,
            GroupType groupType,
            CancellationToken token = default)
        {
            return await _apiAccess.GetGroupByName(groupName, groupType, token);
        }

        public async ValueTask<BungieResponse<GroupResponse>> GetGroupByNameV2(
            GroupNameSearchRequest request,
            CancellationToken token = default)
        {
            return await _apiAccess.GetGroupByNameV2(request, token);
        }

        public async ValueTask<BungieResponse<GroupOptionalConversation[]>> GetGroupOptionalConversations(
            long groupId,
            CancellationToken token = default)
        {
            return await _apiAccess.GetGroupOptionalConversations(groupId, token);
        }

        public async ValueTask<BungieResponse<int>> EditGroup(
            long groupId,
            GroupEditAction request,
            CancellationToken token = default)
        {
            return await _apiAccess.EditGroup(_token, groupId, request, token);
        }

        public async ValueTask<BungieResponse<int>> EditClanBanner(
            long groupId,
            ClanBanner request,
            CancellationToken token = default)
        {
            return await _apiAccess.EditClanBanner(_token, groupId, request, token);
        }

        public async ValueTask<BungieResponse<int>> EditFounderOptions(
            long groupId,
            GroupOptionsEditAction request,
            CancellationToken token = default)
        {
            return await _apiAccess.EditFounderOptions(_token, groupId, request, token);
        }

        public async ValueTask<BungieResponse<long>> AddOptionalConversation(
            long groupId,
            GroupOptionalConversationAddRequest request,
            CancellationToken token = default)
        {
            return await _apiAccess.AddOptionalConversation(_token, groupId, request, token);
        }

        public async ValueTask<BungieResponse<long>> EditOptionalConversation(
            long groupId,
            long conversationId,
            GroupOptionalConversationEditRequest request,
            CancellationToken token = default)
        {
            return await _apiAccess.EditOptionalConversation(_token, groupId, conversationId, request, token);
        }

        public async ValueTask<BungieResponse<SearchResultOfGroupMember>> GetMembersOfGroup(
            long groupId,
            int currentpage = 1,
            RuntimeGroupMemberType memberType = RuntimeGroupMemberType.None,
            string nameSearch = null,
            CancellationToken token = default)
        {
            return await _apiAccess.GetMembersOfGroup(groupId, currentpage, memberType, nameSearch, token);
        }

        public async ValueTask<BungieResponse<SearchResultOfGroupMember>> GetAdminsAndFounderOfGroup(
            long groupId,
            int currentpage = 1,
            CancellationToken token = default)
        {
            return await _apiAccess.GetAdminsAndFounderOfGroup(groupId, currentpage, token);
        }

        public async ValueTask<BungieResponse<int>> EditGroupMembership(
            long groupId,
            long membershipId,
            BungieMembershipType membershipType,
            RuntimeGroupMemberType memberType,
            CancellationToken token = default)
        {
            return await _apiAccess.EditGroupMembership(_token, groupId, membershipId, membershipType, memberType,
                token);
        }

        public async ValueTask<BungieResponse<GroupMemberLeaveResult>> KickMember(
            long groupId,
            long membershipId,
            BungieMembershipType membershipType,
            CancellationToken token = default)
        {
            return await _apiAccess.KickMember(_token, groupId, membershipId, membershipType, token);
        }

        public async ValueTask<BungieResponse<int>> BanMember(
            long groupId,
            long membershipId,
            BungieMembershipType membershipType,
            GroupBanRequest request,
            CancellationToken token = default)
        {
            return await _apiAccess.BanMember(_token, groupId, membershipId, membershipType, request, token);
        }

        public async ValueTask<BungieResponse<int>> UnbanMember(
            long groupId,
            long membershipId,
            BungieMembershipType membershipType,
            CancellationToken token = default)
        {
            return await _apiAccess.UnbanMember(_token, groupId, membershipId, membershipType, token);
        }

        public async ValueTask<BungieResponse<SearchResultOfGroupBan>> GetBannedMembersOfGroup(
            long groupId,
            int currentpage = 1,
            CancellationToken token = default)
        {
            return await _apiAccess.GetBannedMembersOfGroup(_token, groupId, currentpage, token);
        }

        public async ValueTask<BungieResponse<bool>> AbdicateFoundership(
            long groupId,
            long founderIdNew,
            BungieMembershipType membershipType,
            CancellationToken token = default)
        {
            return await _apiAccess.AbdicateFoundership(_token, groupId, founderIdNew, membershipType, token);
        }

        public async ValueTask<BungieResponse<SearchResultOfGroupMemberApplication>> GetPendingMemberships(
            long groupId,
            int currentpage = 1,
            CancellationToken token = default)
        {
            return await _apiAccess.GetPendingMemberships(_token, groupId, currentpage, token);
        }

        public async ValueTask<BungieResponse<SearchResultOfGroupMemberApplication>> GetInvitedIndividuals(
            long groupId,
            int currentpage = 1,
            CancellationToken token = default)
        {
            return await _apiAccess.GetInvitedIndividuals(_token, groupId, currentpage, token);
        }

        public async ValueTask<BungieResponse<EntityActionResult[]>> ApproveAllPending(
            long groupId,
            GroupApplicationRequest request,
            CancellationToken token = default)
        {
            return await _apiAccess.ApproveAllPending(_token, groupId, request, token);
        }

        public async ValueTask<BungieResponse<EntityActionResult[]>> DenyAllPending(
            long groupId,
            GroupApplicationRequest request,
            CancellationToken token = default)
        {
            return await _apiAccess.DenyAllPending(_token, groupId, request, token);
        }

        public async ValueTask<BungieResponse<EntityActionResult[]>> ApprovePendingForList(
            long groupId,
            GroupApplicationListRequest request,
            CancellationToken token = default)
        {
            return await _apiAccess.ApprovePendingForList(_token, groupId, request, token);
        }

        public async ValueTask<BungieResponse<bool>> ApprovePending(
            long groupId,
            long membershipId,
            BungieMembershipType membershipType,
            GroupApplicationRequest request,
            CancellationToken token = default)
        {
            return await _apiAccess.ApprovePending(_token, groupId, membershipId, membershipType, request, token);
        }

        public async ValueTask<BungieResponse<EntityActionResult[]>> DenyPendingForList(
            long groupId,
            GroupApplicationListRequest request,
            CancellationToken token = default)
        {
            return await _apiAccess.DenyPendingForList(_token, groupId, request, token);
        }

        public async ValueTask<BungieResponse<GetGroupsForMemberResponse>> GetGroupsForMember(
            BungieMembershipType membershipType,
            long membershipId,
            GroupsForMemberFilter filter,
            GroupType groupType,
            CancellationToken token = default)
        {
            return await _apiAccess.GetGroupsForMember(membershipType, membershipId, filter, groupType, token);
        }

        public async ValueTask<BungieResponse<GroupMembershipSearchResponse>> RecoverGroupForFounder(
            BungieMembershipType membershipType,
            long membershipId,
            GroupType groupType,
            CancellationToken token = default)
        {
            return await _apiAccess.RecoverGroupForFounder(membershipType, membershipId, groupType, token);
        }

        public async ValueTask<BungieResponse<GroupPotentialMembershipSearchResponse>> GetPotentialGroupsForMember(
            BungieMembershipType membershipType,
            long membershipId,
            GroupType groupType,
            GroupsForMemberFilter filter,
            CancellationToken token = default)
        {
            return await _apiAccess.GetPotentialGroupsForMember(membershipType, membershipId, groupType, filter, token);
        }

        public async ValueTask<BungieResponse<GroupApplicationResponse>> IndividualGroupInvite(
            long groupId,
            BungieMembershipType membershipType,
            long membershipId,
            GroupApplicationRequest request,
            CancellationToken token = default)
        {
            return await _apiAccess.IndividualGroupInvite(_token, groupId, membershipType, membershipId, request,
                token);
        }

        public async ValueTask<BungieResponse<GroupApplicationResponse>> IndividualGroupInviteCancel(
            long groupId,
            BungieMembershipType membershipType,
            long membershipId,
            CancellationToken token = default)
        {
            return await _apiAccess.IndividualGroupInviteCancel(_token, groupId, membershipType, membershipId, token);
        }
    }
}