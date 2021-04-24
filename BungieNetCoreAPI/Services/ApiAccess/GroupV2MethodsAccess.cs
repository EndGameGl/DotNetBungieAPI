﻿using NetBungieAPI.Models;
using NetBungieAPI.Models.Config;
using NetBungieAPI.Models.GroupsV2;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Models.Applications;
using NetBungieAPI.Models.Entities;
using NetBungieAPI.Models.Queries;

namespace NetBungieAPI.Services.ApiAccess
{
    public class GroupV2MethodsAccess : IGroupV2MethodsAccess
    {
        private readonly IHttpClientInstance _httpClient;
        private readonly IConfigurationService _configuration;
        private readonly IJsonSerializationHelper _serializationHelper;

        internal GroupV2MethodsAccess(IHttpClientInstance httpClient, IConfigurationService configuration,
            IJsonSerializationHelper serializationHelper)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _serializationHelper = serializationHelper;
        }

        public async ValueTask<BungieResponse<Dictionary<int, string>>> GetAvailableAvatars(
            CancellationToken token = default)
        {
            return await _httpClient.GetFromBungieNetPlatform<Dictionary<int, string>>("/GroupV2/GetAvailableAvatars/",
                token);
        }

        public async ValueTask<BungieResponse<GroupTheme[]>> GetAvailableThemes(CancellationToken token = default)
        {
            return await _httpClient.GetFromBungieNetPlatform<GroupTheme[]>("/GroupV2/GetAvailableThemes/", token);
        }

        public async ValueTask<BungieResponse<bool>> GetUserClanInviteSetting(BungieMembershipType mType,
            CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes.HasFlag(
                ApplicationScopes.ReadUserData))
                throw new Exception("Requires ReadUserData flag to run");

            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/GroupV2/GetUserClanInviteSetting/")
                .AddUrlParam(((int) mType).ToString())
                .Build();

            return await _httpClient.GetFromBungieNetPlatform<bool>(url, token);
        }

        public async ValueTask<BungieResponse<GroupV2Card[]>> GetRecommendedGroups(GroupType groupType,
            GroupDateRange createDateRange, CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes.HasFlag(
                ApplicationScopes.ReadGroups))
                throw new Exception("Requires ReadGroups flag to run");

            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/GroupV2/Recommended/")
                .AddUrlParam(((int) groupType).ToString())
                .AddUrlParam(((int) createDateRange).ToString())
                .Build();

            return await _httpClient.PostToBungieNetPlatform<GroupV2Card[]>(url, token);
        }

        public async ValueTask<BungieResponse<GroupSearchResponse>> GroupSearch(GroupQuery query,
            CancellationToken token = default)
        {
            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, query);
            return await _httpClient.PostToBungieNetPlatform<GroupSearchResponse>("/GroupV2/Search/", token, stream);
        }

        public async ValueTask<BungieResponse<GroupResponse>> GetGroup(long groupId, CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Build();

            return await _httpClient.GetFromBungieNetPlatform<GroupResponse>(url, token);
        }

        public async ValueTask<BungieResponse<GroupResponse>> GetGroupByName(string groupName, GroupType groupType,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/GroupV2/Name/")
                .AddUrlParam(groupName)
                .AddUrlParam(((int) groupType).ToString())
                .Build();

            return await _httpClient.GetFromBungieNetPlatform<GroupResponse>(url, token);
        }

        public async ValueTask<BungieResponse<GroupResponse>> GetGroupByNameV2(GroupNameSearchRequest request,
            CancellationToken token = default)
        {
            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);
            return await _httpClient.PostToBungieNetPlatform<GroupResponse>("/GroupV2/NameV2/", token, stream);
        }

        public async ValueTask<BungieResponse<GroupOptionalConversation[]>> GetGroupOptionalConversations(long groupId,
            CancellationToken token = default)
        {
            var url = StringBuilderPool.GetBuilder(token)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("OptionalConversations/")
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<GroupOptionalConversation[]>(url, token);
        }

        public async ValueTask<BungieResponse<int>> EditGroup(long groupId, GroupEditAction request,
            CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.AdminGroups))
                throw new Exception("AdminGroups flag must be set to call this API.");

            var url = StringBuilderPool.GetBuilder(token)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Edit/")
                .Build();
            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);
            return await _httpClient.PostToBungieNetPlatform<int>(url, token, stream);
        }

        public async ValueTask<BungieResponse<int>> EditClanBanner(long groupId, ClanBanner request,
            CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.AdminGroups))
                throw new Exception("AdminGroups flag must be set to call this API.");

            var url = StringBuilderPool.GetBuilder(token)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("EditClanBanner/")
                .Build();
            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);
            return await _httpClient.PostToBungieNetPlatform<int>(url, token, stream);
        }

        public async ValueTask<BungieResponse<int>> EditFounderOptions(long groupId, GroupOptionsEditAction request,
            CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.AdminGroups))
                throw new Exception("AdminGroups flag must be set to call this API.");

            var url = StringBuilderPool.GetBuilder(token)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("EditFounderOptions/")
                .Build();
            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);
            return await _httpClient.PostToBungieNetPlatform<int>(url, token, stream);
        }

        public async ValueTask<BungieResponse<long>> AddOptionalConversation(long groupId,
            GroupOptionalConversationAddRequest request, CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.AdminGroups))
                throw new Exception("AdminGroups flag must be set to call this API.");

            var url = StringBuilderPool.GetBuilder(token)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("OptionalConversations/Add/")
                .Build();
            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);
            return await _httpClient.PostToBungieNetPlatform<long>(url, token, stream);
        }

        public async ValueTask<BungieResponse<long>> EditOptionalConversation(long groupId, long conversationId,
            GroupOptionalConversationEditRequest request, CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.AdminGroups))
                throw new Exception("AdminGroups flag must be set to call this API.");

            var url = StringBuilderPool.GetBuilder(token)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("OptionalConversations/Edit/")
                .AddUrlParam(conversationId.ToString())
                .Build();

            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);
            return await _httpClient.PostToBungieNetPlatform<long>(url, token, stream);
        }

        public async ValueTask<BungieResponse<SearchResultOfGroupMember>> GetMembersOfGroup(long groupId,
            int currentpage = 1, RuntimeGroupMemberType memberType = RuntimeGroupMemberType.None,
            string nameSearch = null, CancellationToken token = default)
        {
            var url = StringBuilderPool.GetBuilder(token)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Members/")
                .AddQueryParam("currentpage", currentpage.ToString())
                .AddQueryParam("memberType", ((int) memberType).ToString())
                .AddQueryParam("nameSearch", nameSearch, () => !string.IsNullOrWhiteSpace(nameSearch))
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<SearchResultOfGroupMember>(url, token);
        }

        public async ValueTask<BungieResponse<SearchResultOfGroupMember>> GetAdminsAndFounderOfGroup(long groupId,
            int currentpage = 1, CancellationToken token = default)
        {
            var url = StringBuilderPool.GetBuilder(token)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("AdminsAndFounder/")
                .AddQueryParam("currentpage", currentpage.ToString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<SearchResultOfGroupMember>(url, token);
        }

        public async ValueTask<BungieResponse<int>> EditGroupMembership(long groupId, long membershipId,
            BungieMembershipType membershipType, RuntimeGroupMemberType memberType, CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.AdminGroups))
                throw new Exception("AdminGroups flag must be set to call this API.");

            var url = StringBuilderPool.GetBuilder(token)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Members/")
                .AddUrlParam(((int) membershipType).ToString())
                .AddUrlParam(membershipId.ToString())
                .Append("SetMembershipType/")
                .AddUrlParam(((int) memberType).ToString())
                .Build();
            return await _httpClient.PostToBungieNetPlatform<int>(url, token);
        }

        public async ValueTask<BungieResponse<GroupMemberLeaveResult>> KickMember(long groupId, long membershipId,
            BungieMembershipType membershipType, CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.AdminGroups))
                throw new Exception("AdminGroups flag must be set to call this API.");

            var url = StringBuilderPool.GetBuilder(token)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Members/")
                .AddUrlParam(((int) membershipType).ToString())
                .AddUrlParam(membershipId.ToString())
                .Append("Kick/")
                .Build();
            return await _httpClient.PostToBungieNetPlatform<GroupMemberLeaveResult>(url, token);
        }

        public async ValueTask<BungieResponse<int>> BanMember(long groupId, long membershipId,
            BungieMembershipType membershipType, GroupBanRequest request, CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.AdminGroups))
                throw new Exception("AdminGroups flag must be set to call this API.");

            var url = StringBuilderPool.GetBuilder(token)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Members/")
                .AddUrlParam(((int) membershipType).ToString())
                .AddUrlParam(membershipId.ToString())
                .Append("Ban/")
                .Build();

            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);

            return await _httpClient.PostToBungieNetPlatform<int>(url, token, stream);
        }

        public async ValueTask<BungieResponse<int>> UnbanMember(long groupId, long membershipId,
            BungieMembershipType membershipType, CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.AdminGroups))
                throw new Exception("AdminGroups flag must be set to call this API.");

            var url = StringBuilderPool.GetBuilder(token)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Members/")
                .AddUrlParam(((int) membershipType).ToString())
                .AddUrlParam(membershipId.ToString())
                .Append("Unban/")
                .Build();

            return await _httpClient.PostToBungieNetPlatform<int>(url, token);
        }

        public async ValueTask<BungieResponse<SearchResultOfGroupBan>> GetBannedMembersOfGroup(long groupId,
            int currentpage = 1, CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.AdminGroups))
                throw new Exception("AdminGroups flag must be set to call this API.");

            var url = StringBuilderPool.GetBuilder(token)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Banned/")
                .AddQueryParam("currentpage", currentpage.ToString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<SearchResultOfGroupBan>(url, token);
        }

        public async ValueTask<BungieResponse<bool>> AbdicateFoundership(long groupId, long founderIdNew,
            BungieMembershipType membershipType, CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.AdminGroups))
                throw new Exception("AdminGroups flag must be set to call this API.");

            var url = StringBuilderPool.GetBuilder(token)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Admin/AbdicateFoundership/")
                .AddUrlParam(((int) membershipType).ToString())
                .AddUrlParam(founderIdNew.ToString())
                .Build();

            return await _httpClient.PostToBungieNetPlatform<bool>(url, token);
        }

        public async ValueTask<BungieResponse<SearchResultOfGroupMemberApplication>> GetPendingMemberships(long groupId,
            int currentpage = 1, CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.AdminGroups))
                throw new Exception("AdminGroups flag must be set to call this API.");

            var url = StringBuilderPool.GetBuilder(token)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Members/Pending/")
                .AddQueryParam("currentpage", currentpage.ToString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<SearchResultOfGroupMemberApplication>(url, token);
        }

        public async ValueTask<BungieResponse<SearchResultOfGroupMemberApplication>> GetInvitedIndividuals(long groupId,
            int currentpage = 1, CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.AdminGroups))
                throw new Exception("AdminGroups flag must be set to call this API.");

            var url = StringBuilderPool.GetBuilder(token)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Members/InvitedIndividuals/")
                .AddQueryParam("currentpage", currentpage.ToString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<SearchResultOfGroupMemberApplication>(url, token);
        }

        public async ValueTask<BungieResponse<EntityActionResult[]>> ApproveAllPending(long groupId,
            GroupApplicationRequest request, CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.AdminGroups))
                throw new Exception("AdminGroups flag must be set to call this API.");

            var url = StringBuilderPool.GetBuilder(token)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Members/ApproveAll/")
                .Build();

            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);

            return await _httpClient.PostToBungieNetPlatform<EntityActionResult[]>(url, token, stream);
        }

        public async ValueTask<BungieResponse<EntityActionResult[]>> DenyAllPending(long groupId,
            GroupApplicationRequest request, CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.AdminGroups))
                throw new Exception("AdminGroups flag must be set to call this API.");

            var url = StringBuilderPool.GetBuilder(token)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Members/DenyAll/")
                .Build();

            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);

            return await _httpClient.PostToBungieNetPlatform<EntityActionResult[]>(url, token, stream);
        }

        public async ValueTask<BungieResponse<EntityActionResult[]>> ApprovePendingForList(long groupId,
            GroupApplicationListRequest request, CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.AdminGroups))
                throw new Exception("AdminGroups flag must be set to call this API.");

            var url = StringBuilderPool.GetBuilder(token)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Members/ApproveList/")
                .Build();

            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);

            return await _httpClient.PostToBungieNetPlatform<EntityActionResult[]>(url, token, stream);
        }

        public async ValueTask<BungieResponse<bool>> ApprovePending(long groupId, long membershipId,
            BungieMembershipType membershipType, GroupApplicationRequest request, CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.AdminGroups))
                throw new Exception("AdminGroups flag must be set to call this API.");

            var url = StringBuilderPool.GetBuilder(token)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Members/Approve/")
                .AddUrlParam(((int) membershipType).ToString())
                .AddUrlParam(membershipId.ToString())
                .Build();

            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);

            return await _httpClient.PostToBungieNetPlatform<bool>(url, token, stream);
        }

        public async ValueTask<BungieResponse<EntityActionResult[]>> DenyPendingForList(long groupId,
            GroupApplicationListRequest request, CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.AdminGroups))
                throw new Exception("AdminGroups flag must be set to call this API.");

            var url = StringBuilderPool.GetBuilder(token)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Members/DenyList/")
                .Build();

            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);

            return await _httpClient.PostToBungieNetPlatform<EntityActionResult[]>(url, token, stream);
        }

        public async ValueTask<BungieResponse<GetGroupsForMemberResponse>> GetGroupsForMember(
            BungieMembershipType membershipType, long membershipId, GroupsForMemberFilter filter, GroupType groupType,
            CancellationToken token = default)
        {
            var url = StringBuilderPool.GetBuilder(token)
                .Append("/GroupV2/User/")
                .AddUrlParam(((int) membershipType).ToString())
                .AddUrlParam(membershipId.ToString())
                .AddUrlParam(((int) filter).ToString())
                .AddUrlParam(((int) groupType).ToString())
                .Build();

            return await _httpClient.GetFromBungieNetPlatform<GetGroupsForMemberResponse>(url, token);
        }
        
        public async ValueTask<BungieResponse<GroupMembershipSearchResponse>> RecoverGroupForFounder(
            BungieMembershipType membershipType, long membershipId, GroupType groupType,
            CancellationToken token = default)
        {
            var url = StringBuilderPool.GetBuilder(token)
                .Append("/GroupV2/Recover/")
                .AddUrlParam(((int) membershipType).ToString())
                .AddUrlParam(membershipId.ToString())
                .AddUrlParam(((int) groupType).ToString())
                .Build();

            return await _httpClient.GetFromBungieNetPlatform<GroupMembershipSearchResponse>(url, token);
        }
        
        public async ValueTask<BungieResponse<GroupPotentialMembershipSearchResponse>> GetPotentialGroupsForMember(
            BungieMembershipType membershipType, long membershipId, GroupType groupType, GroupsForMemberFilter filter,
            CancellationToken token = default)
        {
            var url = StringBuilderPool.GetBuilder(token)
                .Append("/GroupV2/User/Potential/")
                .AddUrlParam(((int) membershipType).ToString())
                .AddUrlParam(membershipId.ToString())
                .AddUrlParam(((int) filter).ToString())
                .AddUrlParam(((int) groupType).ToString())
                .Build();

            return await _httpClient.GetFromBungieNetPlatform<GroupPotentialMembershipSearchResponse>(url, token);
        }
        
        public async ValueTask<BungieResponse<GroupApplicationResponse>> IndividualGroupInvite(long groupId, 
            BungieMembershipType membershipType, long membershipId, GroupApplicationRequest request, 
            CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.AdminGroups))
                throw new Exception("AdminGroups flag must be set to call this API.");

            var url = StringBuilderPool.GetBuilder(token)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Members/IndividualInvite/")
                .AddUrlParam(((int)membershipType).ToString())
                .AddUrlParam(membershipId.ToString())
                .Build();

            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);

            return await _httpClient.PostToBungieNetPlatform<GroupApplicationResponse>(url, token, stream);
        }
        
        public async ValueTask<BungieResponse<GroupApplicationResponse>> IndividualGroupInviteCancel(long groupId, 
            BungieMembershipType membershipType, long membershipId, CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.AdminGroups))
                throw new Exception("AdminGroups flag must be set to call this API.");

            var url = StringBuilderPool.GetBuilder(token)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Members/IndividualInviteCancel/")
                .AddUrlParam(((int)membershipType).ToString())
                .AddUrlParam(membershipId.ToString())
                .Build();

            return await _httpClient.PostToBungieNetPlatform<GroupApplicationResponse>(url, token);
        }
    }
}