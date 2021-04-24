using NetBungieAPI.Models;
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

        public async ValueTask<BungieResponse<GroupResponse>> GetGroup(long groupId,
            CancellationToken token = default)
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
            GroupOptionalConversationAddRequest request,
            CancellationToken token = default)
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
    }
}