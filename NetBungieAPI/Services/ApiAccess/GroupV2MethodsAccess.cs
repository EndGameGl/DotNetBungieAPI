using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;
using NetBungieAPI.Clients;
using NetBungieAPI.Exceptions;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Applications;
using NetBungieAPI.Models.Config;
using NetBungieAPI.Models.Entities;
using NetBungieAPI.Models.GroupsV2;
using NetBungieAPI.Models.Queries;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;

namespace NetBungieAPI.Services.ApiAccess
{
    public class GroupV2MethodsAccess : IGroupV2MethodsAccess
    {
        private readonly BungieClientConfiguration _configuration;
        private readonly IDotNetBungieApiHttpClient _dotNetBungieApiHttpClient;
        private readonly IBungieNetJsonSerializer _serializer;

        internal GroupV2MethodsAccess(
            IDotNetBungieApiHttpClient dotNetBungieApiHttpClient, 
            BungieClientConfiguration configuration,
            IBungieNetJsonSerializer serializer)
        {
            _dotNetBungieApiHttpClient = dotNetBungieApiHttpClient;
            _configuration = configuration;
            _serializer = serializer;
        }

        public async ValueTask<BungieResponse<Dictionary<int, string>>> GetAvailableAvatars(
            CancellationToken cancellationToken = default)
        {
            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<Dictionary<int, string>>("/GroupV2/GetAvailableAvatars/", cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<GroupTheme[]>> GetAvailableThemes(
            CancellationToken cancellationToken = default)
        {
            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<GroupTheme[]>("/GroupV2/GetAvailableThemes/", cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<bool>> GetUserClanInviteSetting(
            AuthorizationTokenData authorizationToken,
            BungieMembershipType mType,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.ReadUserData))
                throw new InsufficientScopeException(ApplicationScopes.ReadUserData);

            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/GroupV2/GetUserClanInviteSetting/")
                .AddUrlParam(((int)mType).ToString())
                .Build();

            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<bool>(url, cancellationToken, authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<GroupV2Card[]>> GetRecommendedGroups(
            AuthorizationTokenData authorizationToken,
            GroupType groupType,
            GroupDateRange createDateRange,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.ReadGroups))
                throw new InsufficientScopeException(ApplicationScopes.ReadGroups);

            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/GroupV2/Recommended/")
                .AddUrlParam(((int)groupType).ToString())
                .AddUrlParam(((int)createDateRange).ToString())
                .Build();

            return await _dotNetBungieApiHttpClient
                .PostToBungieNetPlatform<GroupV2Card[]>(url, cancellationToken,
                    authToken: authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<GroupSearchResponse>> GroupSearch(
            GroupQuery query,
            CancellationToken cancellationToken = default)
        {
            var stream = new MemoryStream();
            await _serializer.SerializeAsync(stream, query);
            return await _dotNetBungieApiHttpClient
                .PostToBungieNetPlatform<GroupSearchResponse>("/GroupV2/Search/", cancellationToken, stream)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<GroupResponse>> GetGroup(
            long groupId,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Build();

            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<GroupResponse>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<GroupResponse>> GetGroupByName(
            string groupName,
            GroupType groupType,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/GroupV2/Name/")
                .AddUrlParam(groupName)
                .AddUrlParam(((int)groupType).ToString())
                .Build();

            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<GroupResponse>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<GroupResponse>> GetGroupByNameV2(
            GroupNameSearchRequest request,
            CancellationToken cancellationToken = default)
        {
            var stream = new MemoryStream();
            await _serializer.SerializeAsync(stream, request);
            return await _dotNetBungieApiHttpClient
                .PostToBungieNetPlatform<GroupResponse>("/GroupV2/NameV2/", cancellationToken, stream)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<GroupOptionalConversation[]>> GetGroupOptionalConversations(
            long groupId,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("OptionalConversations/")
                .Build();
            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<GroupOptionalConversation[]>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<int>> EditGroup(
            AuthorizationTokenData authorizationToken,
            long groupId,
            GroupEditAction request,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
                throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Edit/")
                .Build();
            var stream = new MemoryStream();
            await _serializer.SerializeAsync(stream, request);
            return await _dotNetBungieApiHttpClient
                .PostToBungieNetPlatform<int>(url, cancellationToken, stream, authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<int>> EditClanBanner(
            AuthorizationTokenData authorizationToken,
            long groupId,
            ClanBanner request,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
                throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("EditClanBanner/")
                .Build();
            var stream = new MemoryStream();
            await _serializer.SerializeAsync(stream, request);
            return await _dotNetBungieApiHttpClient
                .PostToBungieNetPlatform<int>(url, cancellationToken, stream, authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<int>> EditFounderOptions(
            AuthorizationTokenData authorizationToken,
            long groupId,
            GroupOptionsEditAction request,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
                throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("EditFounderOptions/")
                .Build();
            var stream = new MemoryStream();
            await _serializer.SerializeAsync(stream, request);
            return await _dotNetBungieApiHttpClient
                .PostToBungieNetPlatform<int>(url, cancellationToken, stream, authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<long>> AddOptionalConversation(
            AuthorizationTokenData authorizationToken,
            long groupId,
            GroupOptionalConversationAddRequest request,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
                throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("OptionalConversations/Add/")
                .Build();
            var stream = new MemoryStream();
            await _serializer.SerializeAsync(stream, request);
            return await _dotNetBungieApiHttpClient
                .PostToBungieNetPlatform<long>(url, cancellationToken, stream, authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<long>> EditOptionalConversation(
            AuthorizationTokenData authorizationToken,
            long groupId,
            long conversationId,
            GroupOptionalConversationEditRequest request,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
                throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("OptionalConversations/Edit/")
                .AddUrlParam(conversationId.ToString())
                .Build();

            var stream = new MemoryStream();
            await _serializer.SerializeAsync(stream, request);
            return await _dotNetBungieApiHttpClient
                .PostToBungieNetPlatform<long>(url, cancellationToken, stream, authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<SearchResultOfGroupMember>> GetMembersOfGroup(
            long groupId,
            int currentpage = 1,
            RuntimeGroupMemberType memberType = RuntimeGroupMemberType.None,
            string nameSearch = null,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Members/")
                .AddQueryParam("currentpage", currentpage.ToString())
                .AddQueryParam("memberType", ((int)memberType).ToString())
                .AddQueryParam("nameSearch", nameSearch, () => !string.IsNullOrWhiteSpace(nameSearch))
                .Build();
            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<SearchResultOfGroupMember>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<SearchResultOfGroupMember>> GetAdminsAndFounderOfGroup(
            long groupId,
            int currentpage = 1,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("AdminsAndFounder/")
                .AddQueryParam("currentpage", currentpage.ToString())
                .Build();
            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<SearchResultOfGroupMember>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<int>> EditGroupMembership(
            AuthorizationTokenData authorizationToken,
            long groupId,
            long membershipId,
            BungieMembershipType membershipType,
            RuntimeGroupMemberType memberType,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
                throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Members/")
                .AddUrlParam(((int)membershipType).ToString())
                .AddUrlParam(membershipId.ToString())
                .Append("SetMembershipType/")
                .AddUrlParam(((int)memberType).ToString())
                .Build();
            return await _dotNetBungieApiHttpClient
                .PostToBungieNetPlatform<int>(url, cancellationToken, authToken: authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<GroupMemberLeaveResult>> KickMember(
            AuthorizationTokenData authorizationToken,
            long groupId,
            long membershipId,
            BungieMembershipType membershipType,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
                throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Members/")
                .AddUrlParam(((int)membershipType).ToString())
                .AddUrlParam(membershipId.ToString())
                .Append("Kick/")
                .Build();
            return await _dotNetBungieApiHttpClient
                .PostToBungieNetPlatform<GroupMemberLeaveResult>(url, cancellationToken,
                    authToken: authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<int>> BanMember(
            AuthorizationTokenData authorizationToken,
            long groupId,
            long membershipId,
            BungieMembershipType membershipType,
            GroupBanRequest request,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
                throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Members/")
                .AddUrlParam(((int)membershipType).ToString())
                .AddUrlParam(membershipId.ToString())
                .Append("Ban/")
                .Build();

            var stream = new MemoryStream();
            await _serializer.SerializeAsync(stream, request);
            return await _dotNetBungieApiHttpClient
                .PostToBungieNetPlatform<int>(url, cancellationToken, stream, authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<int>> UnbanMember(
            AuthorizationTokenData authorizationToken,
            long groupId,
            long membershipId,
            BungieMembershipType membershipType,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
                throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Members/")
                .AddUrlParam(((int)membershipType).ToString())
                .AddUrlParam(membershipId.ToString())
                .Append("Unban/")
                .Build();

            return await _dotNetBungieApiHttpClient
                .PostToBungieNetPlatform<int>(url, cancellationToken, authToken: authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<SearchResultOfGroupBan>> GetBannedMembersOfGroup(
            AuthorizationTokenData authorizationToken,
            long groupId,
            int currentpage = 1,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
                throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Banned/")
                .AddQueryParam("currentpage", currentpage.ToString())
                .Build();
            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<SearchResultOfGroupBan>(url, cancellationToken,
                    authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<bool>> AbdicateFoundership(
            AuthorizationTokenData authorizationToken,
            long groupId,
            long founderIdNew,
            BungieMembershipType membershipType,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
                throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Admin/AbdicateFoundership/")
                .AddUrlParam(((int)membershipType).ToString())
                .AddUrlParam(founderIdNew.ToString())
                .Build();

            return await _dotNetBungieApiHttpClient
                .PostToBungieNetPlatform<bool>(url, cancellationToken, authToken: authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<SearchResultOfGroupMemberApplication>> GetPendingMemberships(
            AuthorizationTokenData authorizationToken,
            long groupId,
            int currentpage = 1,
            CancellationToken token = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
                throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

            var url = StringBuilderPool.GetBuilder(token)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Members/Pending/")
                .AddQueryParam("currentpage", currentpage.ToString())
                .Build();
            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<SearchResultOfGroupMemberApplication>(url, token,
                    authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<SearchResultOfGroupMemberApplication>> GetInvitedIndividuals(
            AuthorizationTokenData authorizationToken,
            long groupId,
            int currentpage = 1,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
                throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Members/InvitedIndividuals/")
                .AddQueryParam("currentpage", currentpage.ToString())
                .Build();
            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<SearchResultOfGroupMemberApplication>(url, cancellationToken,
                    authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<EntityActionResult[]>> ApproveAllPending(
            AuthorizationTokenData authorizationToken,
            long groupId,
            GroupApplicationRequest request,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
                throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Members/ApproveAll/")
                .Build();

            var stream = new MemoryStream();
            await _serializer.SerializeAsync(stream, request);
            return await _dotNetBungieApiHttpClient
                .PostToBungieNetPlatform<EntityActionResult[]>(url, cancellationToken, stream,
                    authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<EntityActionResult[]>> DenyAllPending(
            AuthorizationTokenData authorizationToken,
            long groupId,
            GroupApplicationRequest request,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
                throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Members/DenyAll/")
                .Build();

            var stream = new MemoryStream();
            await _serializer.SerializeAsync(stream, request);

            return await _dotNetBungieApiHttpClient
                .PostToBungieNetPlatform<EntityActionResult[]>(url, cancellationToken, stream,
                    authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<EntityActionResult[]>> ApprovePendingForList(
            AuthorizationTokenData authorizationToken,
            long groupId,
            GroupApplicationListRequest request,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
                throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Members/ApproveList/")
                .Build();

            var stream = new MemoryStream();
            await _serializer.SerializeAsync(stream, request);
            return await _dotNetBungieApiHttpClient
                .PostToBungieNetPlatform<EntityActionResult[]>(url, cancellationToken, stream,
                    authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<bool>> ApprovePending(
            AuthorizationTokenData authorizationToken,
            long groupId,
            long membershipId,
            BungieMembershipType membershipType,
            GroupApplicationRequest request,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
                throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Members/Approve/")
                .AddUrlParam(((int)membershipType).ToString())
                .AddUrlParam(membershipId.ToString())
                .Build();

            var stream = new MemoryStream();
            await _serializer.SerializeAsync(stream, request);
            return await _dotNetBungieApiHttpClient
                .PostToBungieNetPlatform<bool>(url, cancellationToken, stream, authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<EntityActionResult[]>> DenyPendingForList(
            AuthorizationTokenData authorizationToken,
            long groupId,
            GroupApplicationListRequest request,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
                throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Members/DenyList/")
                .Build();

            var stream = new MemoryStream();
            await _serializer.SerializeAsync(stream, request);
            return await _dotNetBungieApiHttpClient
                .PostToBungieNetPlatform<EntityActionResult[]>(url, cancellationToken, stream,
                    authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<GetGroupsForMemberResponse>> GetGroupsForMember(
            BungieMembershipType membershipType,
            long membershipId,
            GroupsForMemberFilter filter,
            GroupType groupType,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/GroupV2/User/")
                .AddUrlParam(((int)membershipType).ToString())
                .AddUrlParam(membershipId.ToString())
                .AddUrlParam(((int)filter).ToString())
                .AddUrlParam(((int)groupType).ToString())
                .Build();

            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<GetGroupsForMemberResponse>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<GroupMembershipSearchResponse>> RecoverGroupForFounder(
            BungieMembershipType membershipType,
            long membershipId,
            GroupType groupType,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/GroupV2/Recover/")
                .AddUrlParam(((int)membershipType).ToString())
                .AddUrlParam(membershipId.ToString())
                .AddUrlParam(((int)groupType).ToString())
                .Build();

            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<GroupMembershipSearchResponse>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<GroupPotentialMembershipSearchResponse>> GetPotentialGroupsForMember(
            BungieMembershipType membershipType,
            long membershipId,
            GroupType groupType,
            GroupsForMemberFilter filter,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/GroupV2/User/Potential/")
                .AddUrlParam(((int)membershipType).ToString())
                .AddUrlParam(membershipId.ToString())
                .AddUrlParam(((int)filter).ToString())
                .AddUrlParam(((int)groupType).ToString())
                .Build();

            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<GroupPotentialMembershipSearchResponse>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<GroupApplicationResponse>> IndividualGroupInvite(
            AuthorizationTokenData authorizationToken,
            long groupId,
            BungieMembershipType membershipType,
            long membershipId,
            GroupApplicationRequest request,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
                throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Members/IndividualInvite/")
                .AddUrlParam(((int)membershipType).ToString())
                .AddUrlParam(membershipId.ToString())
                .Build();

            var stream = new MemoryStream();
            await _serializer.SerializeAsync(stream, request);

            return await _dotNetBungieApiHttpClient
                .PostToBungieNetPlatform<GroupApplicationResponse>(url, cancellationToken, stream,
                    authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<GroupApplicationResponse>> IndividualGroupInviteCancel(
            AuthorizationTokenData authorizationToken,
            long groupId,
            BungieMembershipType membershipType,
            long membershipId,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
                throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/GroupV2/")
                .AddUrlParam(groupId.ToString())
                .Append("Members/IndividualInviteCancel/")
                .AddUrlParam(((int)membershipType).ToString())
                .AddUrlParam(membershipId.ToString())
                .Build();

            return await _dotNetBungieApiHttpClient
                .PostToBungieNetPlatform<GroupApplicationResponse>(url, cancellationToken,
                    authToken: authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }
    }
}