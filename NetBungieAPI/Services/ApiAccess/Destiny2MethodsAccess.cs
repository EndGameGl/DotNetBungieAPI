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
            CancellationToken cancellationToken = default)
        {
            return await _httpClient
                .GetFromBungieNetPlatform<DestinyManifest>("/Destiny2/Manifest/", cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<T>> GetDestinyEntityDefinition<T>(
            DefinitionsEnum entityType,
            uint hash,
            CancellationToken cancellationToken = default) where T : IDestinyDefinition
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Destiny2/Manifest/")
                .AddUrlParam(entityType.ToString())
                .AddUrlParam(hash.ToString())
                .Build();
            return await _httpClient
                .GetFromBungieNetPlatform<T>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<UserInfoCard[]>> SearchDestinyPlayer(
            BungieMembershipType membershipType,
            string displayName,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Destiny2/SearchDestinyPlayer/")
                .AddUrlParam(((int)membershipType).ToString())
                .AddUrlParam(displayName.Contains("#") ? displayName.Replace("#", "%23") : displayName)
                .Build();
            return await _httpClient
                .GetFromBungieNetPlatform<UserInfoCard[]>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<DestinyLinkedProfilesResponse>> GetLinkedProfiles(
            BungieMembershipType membershipType,
            long membershipId,
            bool getAllMemberships = false,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Destiny2/")
                .AddUrlParam(((int)membershipType).ToString())
                .Append("Profile/")
                .AddUrlParam(membershipId.ToString())
                .Append("LinkedProfiles/")
                .AddQueryParam("getAllMemberships", getAllMemberships.ToString(), () => getAllMemberships)
                .Build();
            return await _httpClient
                .GetFromBungieNetPlatform<DestinyLinkedProfilesResponse>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<DestinyProfileResponse>> GetProfile(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            DestinyComponentType[] componentTypes,
            AuthorizationTokenData authorizationToken = null,
            CancellationToken cancellationToken = default)
        {
            if (componentTypes == null || componentTypes.Length == 0)
                throw new ArgumentException("Specify some components before making a profile call.");

            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Destiny2/")
                .AddUrlParam(((int)membershipType).ToString())
                .Append("Profile/")
                .AddUrlParam(destinyMembershipId.ToString())
                .AddQueryParam("components", componentTypes.ComponentsToIntString())
                .Build();
            return await _httpClient
                .GetFromBungieNetPlatform<DestinyProfileResponse>(url, cancellationToken,
                    authorizationToken?.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<DestinyCharacterResponse>> GetCharacter(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long characterId,
            DestinyComponentType[] componentTypes,
            AuthorizationTokenData authorizationToken = null,
            CancellationToken cancellationToken = default)
        {
            if (componentTypes == null || componentTypes.Length == 0)
                throw new ArgumentException("Specify some components before making a profile call.");

            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Destiny2/")
                .AddUrlParam(((int)membershipType).ToString())
                .Append("Profile/")
                .AddUrlParam(destinyMembershipId.ToString())
                .Append("Character/")
                .AddUrlParam(characterId.ToString())
                .AddQueryParam("components", componentTypes.ComponentsToIntString())
                .Build();

            return await _httpClient
                .GetFromBungieNetPlatform<DestinyCharacterResponse>(url, cancellationToken,
                    authorizationToken?.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<DestinyMilestone>> GetClanWeeklyRewardState(
            long groupId,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Destiny2/Clan/")
                .AddUrlParam(groupId.ToString())
                .Append("WeeklyRewardState/")
                .Build();
            return await _httpClient
                .GetFromBungieNetPlatform<DestinyMilestone>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<ClanBannerSource>> GetClanBannerSource(
            CancellationToken cancellationToken = default)
        {
            return await _httpClient
                .GetFromBungieNetPlatform<ClanBannerSource>("/Destiny2/Clan/ClanBannerDictionary/", cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<DestinyItemResponse>> GetItem(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long itemInstanceId,
            DestinyComponentType[] componentTypes,
            AuthorizationTokenData authorizationToken = null,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Destiny2/")
                .AddUrlParam(((int)membershipType).ToString())
                .Append("Profile/")
                .AddUrlParam(destinyMembershipId.ToString())
                .Append("Item/")
                .AddUrlParam(itemInstanceId.ToString())
                .AddQueryParam("components", componentTypes.ComponentsToIntString())
                .Build();
            return await _httpClient
                .GetFromBungieNetPlatform<DestinyItemResponse>(url, cancellationToken, authorizationToken?.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<DestinyVendorsResponse>> GetVendors(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long characterId,
            DestinyComponentType[] componentTypes,
            AuthorizationTokenData authorizationToken = null,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Destiny2/")
                .AddUrlParam(((int)membershipType).ToString())
                .Append("Profile/")
                .AddUrlParam(destinyMembershipId.ToString())
                .Append("Character/")
                .AddUrlParam(characterId.ToString())
                .Append("Vendors/")
                .AddQueryParam("components", componentTypes.ComponentsToIntString())
                .Build();
            return await _httpClient
                .GetFromBungieNetPlatform<DestinyVendorsResponse>(url, cancellationToken,
                    authorizationToken?.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<DestinyVendorResponse>> GetVendor(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long characterId,
            uint vendorHash,
            DestinyComponentType[] componentTypes,
            AuthorizationTokenData authorizationToken = null,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
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
            return await _httpClient
                .GetFromBungieNetPlatform<DestinyVendorResponse>(url, cancellationToken,
                    authorizationToken?.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<DestinyPublicVendorsResponse>> GetPublicVendors(
            DestinyComponentType[] componentTypes,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Destiny2/Vendors/")
                .AddQueryParam("components", componentTypes.ComponentsToIntString())
                .Build();
            return await _httpClient
                .GetFromBungieNetPlatform<DestinyPublicVendorsResponse>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<DestinyCollectibleNodeDetailResponse>> GetCollectibleNodeDetails(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long characterId,
            uint collectiblePresentationNodeHash,
            DestinyComponentType[] componentTypes,
            AuthorizationTokenData authorizationToken = null,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
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
            return await _httpClient
                .GetFromBungieNetPlatform<DestinyCollectibleNodeDetailResponse>(url, cancellationToken,
                    authorizationToken?.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<int>> TransferItem(
            DestinyItemTransferRequest request,
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.MoveEquipDestinyItems))
                throw new InsufficientScopeException(ApplicationScopes.MoveEquipDestinyItems);
            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);
            return await _httpClient
                .PostToBungieNetPlatform<int>("/Destiny2/Actions/Items/TransferItem/", cancellationToken, stream,
                    authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<int>> PullFromPostmaster(
            DestinyPostmasterTransferRequest request,
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.MoveEquipDestinyItems))
                throw new InsufficientScopeException(ApplicationScopes.MoveEquipDestinyItems);

            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);
            return await _httpClient
                .PostToBungieNetPlatform<int>("/Destiny2/Actions/Items/PullFromPostmaster/", cancellationToken, stream,
                    authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<int>> EquipItem(
            DestinyItemActionRequest request,
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.MoveEquipDestinyItems))
                throw new InsufficientScopeException(ApplicationScopes.MoveEquipDestinyItems);

            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);
            return await _httpClient
                .PostToBungieNetPlatform<int>("/Destiny2/Actions/Items/EquipItem/", cancellationToken, stream,
                    authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<DestinyEquipItemResults>> EquipItems(
            DestinyItemSetActionRequest request,
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.MoveEquipDestinyItems))
                throw new InsufficientScopeException(ApplicationScopes.MoveEquipDestinyItems);

            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);
            return await _httpClient
                .PostToBungieNetPlatform<DestinyEquipItemResults>("/Destiny2/Actions/Items/EquipItems/",
                    cancellationToken, stream, authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<int>> SetItemLockState(
            DestinyItemStateRequest request,
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.MoveEquipDestinyItems))
                throw new InsufficientScopeException(ApplicationScopes.MoveEquipDestinyItems);

            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);
            return await _httpClient
                .PostToBungieNetPlatform<int>("/Destiny2/Actions/Items/SetLockState/", cancellationToken, stream,
                    authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<int>> SetQuestTrackedState(
            DestinyItemStateRequest request,
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.MoveEquipDestinyItems))
                throw new InsufficientScopeException(ApplicationScopes.MoveEquipDestinyItems);

            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);
            return await _httpClient
                .PostToBungieNetPlatform<int>("/Destiny2/Actions/Items/SetTrackedState/", cancellationToken, stream,
                    authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<DestinyItemChangeResponse>> InsertSocketPlug(
            DestinyInsertPlugsActionRequest request,
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.AdvancedWriteActions))
                throw new InsufficientScopeException(ApplicationScopes.AdvancedWriteActions);

            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);
            return await _httpClient
                .PostToBungieNetPlatform<DestinyItemChangeResponse>("/Destiny2/Actions/Items/InsertSocketPlug/",
                    cancellationToken, stream, authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<DestinyPostGameCarnageReportData>> GetPostGameCarnageReport(
            long activityId,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Destiny2/Stats/PostGameCarnageReport/")
                .AddUrlParam(activityId.ToString())
                .Build();

            return await _httpClient
                .GetFromBungieNetStatsPlatform<DestinyPostGameCarnageReportData>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<int>> ReportOffensivePostGameCarnageReportPlayer(
            long activityId,
            DestinyReportOffensePgcrRequest request,
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.BnetWrite))
                throw new InsufficientScopeException(ApplicationScopes.BnetWrite);

            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/Destiny2/Stats/PostGameCarnageReport/")
                .AddUrlParam(activityId.ToString())
                .Append("Report/")
                .Build();
            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);
            return await _httpClient
                .PostToBungieNetPlatform<int>(url, cancellationToken, stream, authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<ReadOnlyDictionary<string, DestinyHistoricalStatsDefinition>>>
            GetHistoricalStatsDefinition(
                CancellationToken cancellationToken = default)
        {
            return await _httpClient
                .GetFromBungieNetPlatform<ReadOnlyDictionary<string, DestinyHistoricalStatsDefinition>>(
                    "/Destiny2/Stats/Definition/", cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<
                ReadOnlyDictionary<string, ReadOnlyDictionary<string, DestinyClanLeaderboardsResponse>>>>
            GetClanLeaderboards(
                long groupId,
                int maxtop,
                DestinyActivityModeType[] modes,
                string statid = null,
                CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/Destiny2/Stats/Leaderboards/Clans/")
                .AddUrlParam(groupId.ToString())
                .AddQueryParam("maxtop", maxtop.ToString())
                .AddQueryParam("modes", string.Join(',', modes))
                .AddQueryParam("statid", statid, () => !string.IsNullOrWhiteSpace(statid))
                .Build();

            return await _httpClient
                .GetFromBungieNetPlatform<
                    ReadOnlyDictionary<string, ReadOnlyDictionary<string, DestinyClanLeaderboardsResponse>>>(url,
                    cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<DestinyClanAggregateStat[]>> GetClanAggregateStats(
            long groupId,
            DestinyActivityModeType[] modes,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/Destiny2/Stats/AggregateClanStats/")
                .AddUrlParam(groupId.ToString())
                .AddQueryParam("modes", string.Join(',', modes))
                .Build();

            return await _httpClient
                .GetFromBungieNetPlatform<DestinyClanAggregateStat[]>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<Dictionary<string, object>>> GetLeaderboards(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            int maxtop,
            DestinyActivityModeType[] modes,
            string statid = null,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool.GetBuilder(cancellationToken)
                .Append("/Destiny2/")
                .AddUrlParam(((int)membershipType).ToString())
                .Append("Account/")
                .AddUrlParam(destinyMembershipId.ToString())
                .Append("Stats/Leaderboards/")
                .AddQueryParam("maxtop", maxtop.ToString())
                .AddQueryParam("modes", string.Join(',', modes))
                .AddQueryParam("statid", statid, () => !string.IsNullOrWhiteSpace(statid))
                .Build();

            return await _httpClient
                .GetFromBungieNetPlatform<Dictionary<string, object>>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<DestinyEntitySearchResult>> SearchDestinyEntities(
            DefinitionsEnum type,
            string searchTerm,
            int page = 0,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Destiny2/Armory/Search/")
                .AddUrlParam(type.ToString())
                .AddUrlParam(searchTerm)
                .AddQueryParam("page", page.ToString())
                .Build();
            return await _httpClient
                .GetFromBungieNetPlatform<DestinyEntitySearchResult>(url, cancellationToken)
                .ConfigureAwait(false);
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
                CancellationToken cancellationToken = default)
        {
            var hasParams = daystart != null || dayend != null || groups != null || modes != null ||
                            periodType != PeriodType.None;
            var builder = StringBuilderPool
                .GetBuilder(cancellationToken)
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
                        builder.Build(), cancellationToken)
                    .ConfigureAwait(false);
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
                .GetFromBungieNetPlatform<ReadOnlyDictionary<string, DestinyHistoricalStatsByPeriod>>(builder.Build(),
                    cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<DestinyHistoricalStatsAccountResult>> GetHistoricalStatsForAccount(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            DestinyStatsGroupType[] groups = null,
            CancellationToken cancellationToken = default)
        {
            var builder = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Destiny2/")
                .AddUrlParam(((int)membershipType).ToString())
                .Append("Account/")
                .AddUrlParam(destinyMembershipId.ToString())
                .Append("Stats/");
            if (groups is { Length: > 0 })
                builder.AddQueryParam("groups", string.Join(',', groups.Select(x => (int)x)));
            return await _httpClient
                .GetFromBungieNetPlatform<DestinyHistoricalStatsAccountResult>(builder.Build(), cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<DestinyActivityHistoryResults>> GetActivityHistory(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long characterId,
            int count = 25,
            DestinyActivityModeType mode = DestinyActivityModeType.None,
            int page = 0,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
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
            return await _httpClient
                .GetFromBungieNetPlatform<DestinyActivityHistoryResults>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<DestinyHistoricalWeaponStatsData>> GetUniqueWeaponHistory(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long characterId,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Destiny2/")
                .AddUrlParam(((int)membershipType).ToString())
                .Append("Account/")
                .AddUrlParam(destinyMembershipId.ToString())
                .Append("Character/")
                .AddUrlParam(characterId.ToString())
                .Append("Stats/UniqueWeapons/")
                .Build();
            return await _httpClient
                .GetFromBungieNetPlatform<DestinyHistoricalWeaponStatsData>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<DestinyAggregateActivityResults>> GetDestinyAggregateActivityStats(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long characterId,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Destiny2/")
                .AddUrlParam(((int)membershipType).ToString())
                .Append("Account/")
                .AddUrlParam(destinyMembershipId.ToString())
                .Append("Character/")
                .AddUrlParam(characterId.ToString())
                .Append("Stats/AggregateActivityStats/")
                .Build();

            return await _httpClient
                .GetFromBungieNetPlatform<DestinyAggregateActivityResults>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<Dictionary<uint, DestinyPublicMilestone>>> GetPublicMilestones(
            CancellationToken cancellationToken = default)
        {
            return await _httpClient
                .GetFromBungieNetPlatform<Dictionary<uint, DestinyPublicMilestone>>("/Destiny2/Milestones",
                    cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<DestinyMilestoneContent>> GetPublicMilestoneContent(
            uint milestoneHash,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Destiny2/Milestones/")
                .AddUrlParam(milestoneHash.ToString())
                .Append("Content/")
                .Build();
            return await _httpClient
                .GetFromBungieNetPlatform<DestinyMilestoneContent>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<AwaInitializeResponse>> AwaInitializeRequest(
            AwaPermissionRequested request,
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.AdvancedWriteActions))
                throw new InsufficientScopeException(ApplicationScopes.AdvancedWriteActions);

            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);
            return await _httpClient
                .PostToBungieNetPlatform<AwaInitializeResponse>("/Destiny2/Awa/Initialize/", cancellationToken, stream,
                    authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<int>> AwaProvideAuthorizationResult(
            AwaUserResponse request,
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default)
        {
            var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);
            return await _httpClient
                .PostToBungieNetPlatform<int>("/Destiny2/Awa/AwaProvideAuthorizationResult/", cancellationToken, stream,
                    authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<AwaAuthorizationResult>> AwaGetActionToken(
            string correlationId,
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.AdvancedWriteActions))
                throw new InsufficientScopeException(ApplicationScopes.AdvancedWriteActions);

            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Destiny2/Awa/GetActionToken/")
                .AddUrlParam(correlationId)
                .Build();

            return await _httpClient
                .PostToBungieNetPlatform<AwaAuthorizationResult>(url, cancellationToken,
                    authToken: authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }
    }
}