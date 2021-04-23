using NetBungieAPI.Models;
using NetBungieAPI.Models.Config;
using NetBungieAPI.Models.GroupsV2;
using NetBungieAPI.Services;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Models.Applications;

namespace NetBungieAPI.Services.ApiAccess
{
    public class GroupV2MethodsAccess : IGroupV2MethodsAccess
    {
        private readonly IHttpClientInstance _httpClient;
        private readonly IConfigurationService _configuration;

        internal GroupV2MethodsAccess(IHttpClientInstance httpClient, IConfigurationService configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
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
    }
}