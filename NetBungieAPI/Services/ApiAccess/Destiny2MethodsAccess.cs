using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;
using NetBungieAPI.Exceptions;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Applications;
using NetBungieAPI.Models.Config;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Models.Destiny.Config;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModes;
using NetBungieAPI.Models.Destiny.Definitions.HistoricalStats;
using NetBungieAPI.Models.Destiny.HistoricalStats;
using NetBungieAPI.Models.Destiny.Milestones;
using NetBungieAPI.Models.Destiny.Responses;
using NetBungieAPI.Models.Queries;
using NetBungieAPI.Models.Requests;
using NetBungieAPI.Models.Responses;
using NetBungieAPI.Models.User;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;

namespace NetBungieAPI.Services.ApiAccess
{
    public class Destiny2MethodsAccess : IDestiny2MethodsAccess
    {
        private readonly IConfigurationService _configuration;
        private readonly IHttpClientInstance _httpClient;
        private readonly IJsonSerializationHelper _serializationHelper;

        internal Destiny2MethodsAccess(IHttpClientInstance httpClient, IJsonSerializationHelper serializationHelper,
            IConfigurationService configurationService)
        {
            _httpClient = httpClient;
            _serializationHelper = serializationHelper;
            _configuration = configurationService;
        }

        public async ValueTask<BungieResponse<DestinyManifest>> GetDestinyManifest(
            CancellationToken token = default)
        {
            return await _httpClient.GetFromBungieNetPlatform<DestinyManifest>("/Destiny2/Manifest/", token);
        }

        public async ValueTask<BungieResponse<T>> GetDestinyEntityDefinition<T>(DefinitionsEnum entityType, uint hash,
            CancellationToken token = default) where T : IDestinyDefinition
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/Manifest/")
                .AddUrlParam(entityType.ToString())
                .AddUrlParam(hash.ToString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<T>(url, token);
        }

        public async ValueTask<BungieResponse<UserInfoCard[]>> SearchDestinyPlayer(
            BungieMembershipType membershipType,
            string displayName,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/SearchDestinyPlayer/")
                .AddUrlParam(((int)membershipType).ToString())
                .AddUrlParam(displayName.Contains("#") ? displayName.Replace("#", "%23") : displayName)
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<UserInfoCard[]>(url, token);
        }

        public async ValueTask<BungieResponse<DestinyLinkedProfilesResponse>> GetLinkedProfiles(
            BungieMembershipType membershipType,
            long membershipId,
            bool getAllMemberships = false,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/")
                .AddUrlParam(((int)membershipType).ToString())
                .Append("Profile/")
                .AddUrlParam(membershipId.ToString())
                .Append("LinkedProfiles/")
                .AddQueryParam("getAllMemberships", getAllMemberships.ToString(), () => getAllMemberships)
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<DestinyLinkedProfilesResponse>(url, token);
        }

        public async ValueTask<BungieResponse<DestinyProfileResponse>> GetProfile(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            DestinyComponentType[] componentTypes,
            AuthorizationTokenData authData = null,
            CancellationToken token = default)
        {
            if (componentTypes == null || componentTypes.Length == 0)
                throw new ArgumentException("Specify some components before making a profile call.");

            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/")
                .AddUrlParam(((int)membershipType).ToString())
                .Append("Profile/")
                .AddUrlParam(destinyMembershipId.ToString())
                .AddQueryParam("components", componentTypes.ComponentsToIntString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<DestinyProfileResponse>(url, token,
                authData?.AccessToken);
        }

        public async ValueTask<BungieResponse<DestinyCharacterResponse>> GetCharacter(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long characterId,
            DestinyComponentType[] componentTypes,
            AuthorizationTokenData authData = null,
            CancellationToken token = default)
        {
            if (componentTypes == null || componentTypes.Length == 0)
                throw new ArgumentException("Specify some components before making a profile call.");

            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/")
                .AddUrlParam(((int)membershipType).ToString())
                .Append("Profile/")
                .AddUrlParam(destinyMembershipId.ToString())
                .Append("Character/")
                .AddUrlParam(characterId.ToString())
                .AddQueryParam("components", componentTypes.ComponentsToIntString())
                .Build();

            return await _httpClient.GetFromBungieNetPlatform<DestinyCharacterResponse>(url, token,
                authData?.AccessToken);
        }

        public async ValueTask<BungieResponse<DestinyMilestone>> GetClanWeeklyRewardState(
            long groupId,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/Clan/")
                .AddUrlParam(groupId.ToString())
                .Append("WeeklyRewardState/")
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<DestinyMilestone>(url, token);
        }

        public async ValueTask<BungieResponse<ClanBannerSource>> GetClanBannerSource(
            CancellationToken token = default)
        {
            return await _httpClient.GetFromBungieNetPlatform<ClanBannerSource>("/Destiny2/Clan/ClanBannerDictionary/",
                token);
        }

        public async ValueTask<BungieResponse<DestinyItemResponse>> GetItem(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long itemInstanceId,
            DestinyComponentType[] componentTypes,
            AuthorizationTokenData authData = null,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/")
                .AddUrlParam(((int)membershipType).ToString())
                .Append("Profile/")
                .AddUrlParam(destinyMembershipId.ToString())
                .Append("Item/")
                .AddUrlParam(itemInstanceId.ToString())
                .AddQueryParam("components", componentTypes.ComponentsToIntString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<DestinyItemResponse>(url, token,
                authData?.AccessToken);
        }

        public async ValueTask<BungieResponse<DestinyVendorsResponse>> GetVendors(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long characterId,
            DestinyComponentType[] componentTypes,
            AuthorizationTokenData authData = null,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/")
                .AddUrlParam(((int)membershipType).ToString())
                .Append("Profile/")
                .AddUrlParam(destinyMembershipId.ToString())
                .Append("Character/")
                .AddUrlParam(characterId.ToString())
                .Append("Vendors/")
                .AddQueryParam("components", componentTypes.ComponentsToIntString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<DestinyVendorsResponse>(url, token,
                authData?.AccessToken);
        }

        public async ValueTask<BungieResponse<DestinyVendorResponse>> GetVendor(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long characterId,
            uint vendorHash,
            DestinyComponentType[] componentTypes,
            AuthorizationTokenData authData = null,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/")
                .AddUrlParam(((int)membershipType).ToString())
                .Append("Profile/")
                .AddUrlParam(destinyMembershipId.ToString())
                .Append("Character/")
                .AddUrlParam(characterId.ToString())
                .Append("Vendors/")
                .AddUrlParam(vendorHash.ToString())
                .AddQueryParam("components", componentTypes.ComponentsToIntString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<DestinyVendorResponse>(url, token,
                authData?.AccessToken);
        }

        public async ValueTask<BungieResponse<DestinyPublicVendorsResponse>> GetPublicVendors(
            DestinyComponentType[] componentTypes,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/Vendors/")
                .AddQueryParam("components", componentTypes.ComponentsToIntString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<DestinyPublicVendorsResponse>(url, token);
        }

        public async ValueTask<BungieResponse<DestinyCollectibleNodeDetailResponse>> GetCollectibleNodeDetails(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long characterId,
            uint collectiblePresentationNodeHash,
            DestinyComponentType[] componentTypes,
            AuthorizationTokenData authData = null,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/")
                .AddUrlParam(((int)membershipType).ToString())
                .AddQueryParam("components", componentTypes.ComponentsToIntString())
                .Append("Profile/")
                .AddUrlParam(destinyMembershipId.ToString())
                .Append("Character/")
                .AddUrlParam(characterId.ToString())
                .Append("Collectibles/")
                .AddUrlParam(collectiblePresentationNodeHash.ToString())
                .AddQueryParam("components", componentTypes.ComponentsToIntString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<DestinyCollectibleNodeDetailResponse>(url, token,
                authData?.AccessToken);
        }

        public async ValueTask<BungieResponse<int>> TransferItem(
            DestinyItemTransferRequest request,
            AuthorizationTokenData authData,
            CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.MoveEquipDestinyItems))
                throw new InsufficientScopeException(ApplicationScopes.MoveEquipDestinyItems);
            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);
            return await _httpClient.PostToBungieNetPlatform<int>("/Destiny2/Actions/Items/TransferItem/", token,
                stream, authData.AccessToken);
        }

        public async ValueTask<BungieResponse<int>> PullFromPostmaster(
            DestinyPostmasterTransferRequest request,
            AuthorizationTokenData authData,
            CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.MoveEquipDestinyItems))
                throw new InsufficientScopeException(ApplicationScopes.MoveEquipDestinyItems);

            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);
            return await _httpClient.PostToBungieNetPlatform<int>("/Destiny2/Actions/Items/PullFromPostmaster/", token,
                stream, authData.AccessToken);
        }

        public async ValueTask<BungieResponse<int>> EquipItem(
            DestinyItemActionRequest request,
            AuthorizationTokenData authData,
            CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.MoveEquipDestinyItems))
                throw new InsufficientScopeException(ApplicationScopes.MoveEquipDestinyItems);

            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);
            return await _httpClient.PostToBungieNetPlatform<int>("/Destiny2/Actions/Items/EquipItem/", token,
                stream, authData.AccessToken);
        }

        public async ValueTask<BungieResponse<DestinyEquipItemResults>> EquipItems(
            DestinyItemSetActionRequest request,
            AuthorizationTokenData authData,
            CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.MoveEquipDestinyItems))
                throw new InsufficientScopeException(ApplicationScopes.MoveEquipDestinyItems);

            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);
            return await _httpClient.PostToBungieNetPlatform<DestinyEquipItemResults>(
                "/Destiny2/Actions/Items/EquipItems/", token, stream, authData.AccessToken);
        }

        public async ValueTask<BungieResponse<int>> SetItemLockState(
            DestinyItemStateRequest request,
            AuthorizationTokenData authData,
            CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.MoveEquipDestinyItems))
                throw new InsufficientScopeException(ApplicationScopes.MoveEquipDestinyItems);

            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);
            return await _httpClient.PostToBungieNetPlatform<int>("/Destiny2/Actions/Items/SetLockState/", token,
                stream, authData.AccessToken);
        }

        public async ValueTask<BungieResponse<int>> SetQuestTrackedState(
            DestinyItemStateRequest request,
            AuthorizationTokenData authData,
            CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.MoveEquipDestinyItems))
                throw new InsufficientScopeException(ApplicationScopes.MoveEquipDestinyItems);

            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);
            return await _httpClient.PostToBungieNetPlatform<int>("/Destiny2/Actions/Items/SetTrackedState/", token,
                stream, authData.AccessToken);
        }

        public async ValueTask<BungieResponse<DestinyItemChangeResponse>> InsertSocketPlug(
            DestinyInsertPlugsActionRequest request,
            AuthorizationTokenData authData,
            CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.AdvancedWriteActions))
                throw new InsufficientScopeException(ApplicationScopes.AdvancedWriteActions);

            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);
            return await _httpClient.PostToBungieNetPlatform<DestinyItemChangeResponse>(
                "/Destiny2/Actions/Items/InsertSocketPlug/", token, stream, authData.AccessToken);
        }

        public async ValueTask<BungieResponse<DestinyPostGameCarnageReportData>> GetPostGameCarnageReport(
            long activityId,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/Stats/PostGameCarnageReport/")
                .AddUrlParam(activityId.ToString())
                .Build();

            return await _httpClient.GetFromBungieNetStatsPlatform<DestinyPostGameCarnageReportData>(url, token);
        }

        public async ValueTask<BungieResponse<int>> ReportOffensivePostGameCarnageReportPlayer(
            long activityId,
            DestinyReportOffensePgcrRequest request,
            AuthorizationTokenData authData,
            CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.BnetWrite))
                throw new InsufficientScopeException(ApplicationScopes.BnetWrite);

            var url = StringBuilderPool.GetBuilder(token)
                .Append("/Destiny2/Stats/PostGameCarnageReport/")
                .AddUrlParam(activityId.ToString())
                .Append("Report/")
                .Build();
            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);
            return await _httpClient.PostToBungieNetPlatform<int>(url, token, stream, authData.AccessToken);
        }

        public async ValueTask<BungieResponse<ReadOnlyDictionary<string, DestinyHistoricalStatsDefinition>>>
            GetHistoricalStatsDefinition(
                CancellationToken token = default)
        {
            return await _httpClient
                .GetFromBungieNetPlatform<ReadOnlyDictionary<string, DestinyHistoricalStatsDefinition>>(
                    "/Destiny2/Stats/Definition/", token);
        }

        public async ValueTask<BungieResponse<
                ReadOnlyDictionary<string, ReadOnlyDictionary<string, DestinyClanLeaderboardsResponse>>>>
            GetClanLeaderboards(
                long groupId,
                int maxtop,
                DestinyActivityModeType[] modes,
                string statid = null,
                CancellationToken token = default)
        {
            var url = StringBuilderPool.GetBuilder(token)
                .Append("/Destiny2/Stats/Leaderboards/Clans/")
                .AddUrlParam(groupId.ToString())
                .AddQueryParam("maxtop", maxtop.ToString())
                .AddQueryParam("modes", string.Join(',', modes))
                .AddQueryParam("statid", statid, () => !string.IsNullOrWhiteSpace(statid))
                .Build();

            return await _httpClient
                .GetFromBungieNetPlatform<
                    ReadOnlyDictionary<string, ReadOnlyDictionary<string, DestinyClanLeaderboardsResponse>>>(url,
                    token);
        }

        public async ValueTask<BungieResponse<DestinyClanAggregateStat[]>> GetClanAggregateStats(
            long groupId,
            DestinyActivityModeType[] modes,
            CancellationToken token = default)
        {
            var url = StringBuilderPool.GetBuilder(token)
                .Append("/Destiny2/Stats/AggregateClanStats/")
                .AddUrlParam(groupId.ToString())
                .AddQueryParam("modes", string.Join(',', modes))
                .Build();

            return await _httpClient.GetFromBungieNetPlatform<DestinyClanAggregateStat[]>(url, token);
        }

        public async ValueTask<BungieResponse<Dictionary<string, object>>> GetLeaderboards(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            int maxtop,
            DestinyActivityModeType[] modes,
            string statid = null,
            CancellationToken token = default)
        {
            var url = StringBuilderPool.GetBuilder(token)
                .Append("/Destiny2/")
                .AddUrlParam(((int)membershipType).ToString())
                .Append("Account/")
                .AddUrlParam(destinyMembershipId.ToString())
                .Append("Stats/Leaderboards/")
                .AddQueryParam("maxtop", maxtop.ToString())
                .AddQueryParam("modes", string.Join(',', modes))
                .AddQueryParam("statid", statid, () => !string.IsNullOrWhiteSpace(statid))
                .Build();

            return await _httpClient.GetFromBungieNetPlatform<Dictionary<string, object>>(url, token);
        }

        public async ValueTask<BungieResponse<DestinyEntitySearchResult>> SearchDestinyEntities(
            DefinitionsEnum type,
            string searchTerm,
            int page = 0,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/Armory/Search/")
                .AddUrlParam(type.ToString())
                .AddUrlParam(searchTerm)
                .AddQueryParam("page", page.ToString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<DestinyEntitySearchResult>(url, token);
        }

        public async ValueTask<BungieResponse<ReadOnlyDictionary<string, DestinyHistoricalStatsByPeriod>>>
            GetHistoricalStats(
                BungieMembershipType membershipType,
                long destinyMembershipId,
                long characterId,
                DateTime? daystart = null,
                DateTime? dayend = null,
                DestinyStatsGroupType[] groups = null,
                DestinyActivityModeType[] modes = null,
                PeriodType periodType = PeriodType.None,
                CancellationToken token = default)
        {
            var hasParams = daystart != null || dayend != null || groups != null || modes != null ||
                            periodType != PeriodType.None;
            var builder = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/")
                .AddUrlParam(((int)membershipType).ToString())
                .Append("Account/")
                .AddUrlParam(destinyMembershipId.ToString())
                .Append("Character/")
                .AddUrlParam(characterId.ToString())
                .Append("Stats/");
            if (!hasParams)
                return await _httpClient
                    .GetFromBungieNetPlatform<ReadOnlyDictionary<string, DestinyHistoricalStatsByPeriod>>(
                        builder.Build(), token);
            if (daystart.HasValue)
                builder.AddQueryParam("daystart", daystart.Value.ToString("yyyy-MM-dd"));
            if (dayend.HasValue)
                builder.AddQueryParam("dayend", dayend.Value.ToString("yyyy-MM-dd"));
            if (groups is { Length: > 0 })
                builder.AddQueryParam("groups", string.Join(',', groups.Select(x => (int)x)));
            if (modes is { Length: > 0 })
                builder.AddQueryParam("modes", string.Join(',', modes.Select(x => (int)x)));
            if (periodType != PeriodType.None)
                builder.AddQueryParam("periodType", ((int)periodType).ToString());

            return await _httpClient
                .GetFromBungieNetPlatform<ReadOnlyDictionary<string, DestinyHistoricalStatsByPeriod>>(
                    builder.Build(), token);
        }

        public async ValueTask<BungieResponse<DestinyHistoricalStatsAccountResult>> GetHistoricalStatsForAccount(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            DestinyStatsGroupType[] groups = null,
            CancellationToken token = default)
        {
            var builder = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/")
                .AddUrlParam(((int)membershipType).ToString())
                .Append("Account/")
                .AddUrlParam(destinyMembershipId.ToString())
                .Append("Stats/");
            if (groups is { Length: > 0 })
                builder.AddQueryParam("groups", string.Join(',', groups.Select(x => (int)x)));
            return await _httpClient.GetFromBungieNetPlatform<DestinyHistoricalStatsAccountResult>(builder.Build(),
                token);
        }

        public async ValueTask<BungieResponse<DestinyActivityHistoryResults>> GetActivityHistory(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long characterId,
            int count = 25,
            DestinyActivityModeType mode = DestinyActivityModeType.None,
            int page = 0,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/")
                .AddUrlParam(((int)membershipType).ToString())
                .Append("Account/")
                .AddUrlParam(destinyMembershipId.ToString())
                .Append("Character/")
                .AddUrlParam(characterId.ToString())
                .Append("Stats/Activities/")
                .AddQueryParam("count", count.ToString())
                .AddQueryParam("mode", ((int)mode).ToString())
                .AddQueryParam("page", page.ToString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<DestinyActivityHistoryResults>(url, token);
        }

        public async ValueTask<BungieResponse<DestinyHistoricalWeaponStatsData>> GetUniqueWeaponHistory(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long characterId,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/")
                .AddUrlParam(((int)membershipType).ToString())
                .Append("Account/")
                .AddUrlParam(destinyMembershipId.ToString())
                .Append("Character/")
                .AddUrlParam(characterId.ToString())
                .Append("Stats/UniqueWeapons/")
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<DestinyHistoricalWeaponStatsData>(url, token);
        }

        public async ValueTask<BungieResponse<DestinyAggregateActivityResults>> GetDestinyAggregateActivityStats(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long characterId,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/")
                .AddUrlParam(((int)membershipType).ToString())
                .Append("Account/")
                .AddUrlParam(destinyMembershipId.ToString())
                .Append("Character/")
                .AddUrlParam(characterId.ToString())
                .Append("Stats/AggregateActivityStats/")
                .Build();

            return await _httpClient.GetFromBungieNetPlatform<DestinyAggregateActivityResults>(url, token);
        }

        public async ValueTask<BungieResponse<Dictionary<uint, DestinyPublicMilestone>>> GetPublicMilestones(
            CancellationToken token = default)
        {
            return await _httpClient.GetFromBungieNetPlatform<Dictionary<uint, DestinyPublicMilestone>>(
                "/Destiny2/Milestones", token);
        }

        public async ValueTask<BungieResponse<DestinyMilestoneContent>> GetPublicMilestoneContent(
            uint milestoneHash,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/Milestones/")
                .AddUrlParam(milestoneHash.ToString())
                .Append("Content/")
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<DestinyMilestoneContent>(url, token);
        }

        public async ValueTask<BungieResponse<AwaInitializeResponse>> AwaInitializeRequest(
            AwaPermissionRequested request,
            AuthorizationTokenData authData,
            CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.AdvancedWriteActions))
                throw new InsufficientScopeException(ApplicationScopes.AdvancedWriteActions);

            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);
            return await _httpClient.PostToBungieNetPlatform<AwaInitializeResponse>("/Destiny2/Awa/Initialize/", token,
                stream, authData.AccessToken);
        }

        public async ValueTask<BungieResponse<int>> AwaProvideAuthorizationResult(
            AwaUserResponse request,
            AuthorizationTokenData authData,
            CancellationToken token = default)
        {
            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);
            return await _httpClient.PostToBungieNetPlatform<int>("/Destiny2/Awa/AwaProvideAuthorizationResult/", token,
                stream, authData.AccessToken);
        }

        public async ValueTask<BungieResponse<AwaAuthorizationResult>> AwaGetActionToken(
            string correlationId,
            AuthorizationTokenData authData,
            CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes
                .HasFlag(ApplicationScopes.AdvancedWriteActions))
                throw new InsufficientScopeException(ApplicationScopes.AdvancedWriteActions);

            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/Awa/GetActionToken/")
                .AddUrlParam(correlationId)
                .Build();

            return await _httpClient.PostToBungieNetPlatform<AwaAuthorizationResult>(url, token,
                authToken: authData.AccessToken);
        }
    }
}