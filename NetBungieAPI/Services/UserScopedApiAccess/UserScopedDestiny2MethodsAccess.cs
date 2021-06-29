using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;
using NetBungieAPI.Models;
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

namespace NetBungieAPI.Services.UserScopedApiAccess
{
    public class UserScopedDestiny2MethodsAccess
    {
        private readonly IDestiny2MethodsAccess _apiAccess;
        private readonly AuthorizationTokenData _token;

        internal UserScopedDestiny2MethodsAccess(
            IDestiny2MethodsAccess apiAccess,
            AuthorizationTokenData token)
        {
            _apiAccess = apiAccess;
            _token = token;
        }

        public async ValueTask<BungieResponse<DestinyManifest>> GetDestinyManifest(
            CancellationToken token = default)
        {
            return await _apiAccess.GetDestinyManifest(token);
        }

        public async ValueTask<BungieResponse<T>> GetDestinyEntityDefinition<T>(
            DefinitionsEnum entityType,
            uint hash,
            CancellationToken token = default) where T : IDestinyDefinition
        {
            return await _apiAccess.GetDestinyEntityDefinition<T>(entityType, hash, token);
        }

        public async ValueTask<BungieResponse<UserInfoCard[]>> SearchDestinyPlayer(
            BungieMembershipType membershipType,
            string displayName,
            bool returnOriginalProfile = false,
            CancellationToken token = default)
        {
            return await _apiAccess.SearchDestinyPlayer(membershipType, displayName, returnOriginalProfile, token);
        }

        public async ValueTask<BungieResponse<DestinyLinkedProfilesResponse>> GetLinkedProfiles(
            BungieMembershipType membershipType,
            long membershipId,
            bool getAllMemberships = false,
            CancellationToken token = default)
        {
            return await _apiAccess.GetLinkedProfiles(membershipType, membershipId, getAllMemberships, token);
        }

        public async ValueTask<BungieResponse<DestinyProfileResponse>> GetProfile(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            DestinyComponentType[] componentTypes,
            CancellationToken token = default)
        {
            return await _apiAccess.GetProfile(membershipType, destinyMembershipId, componentTypes, _token, token);
        }

        public async ValueTask<BungieResponse<DestinyCharacterResponse>> GetCharacter(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long characterId,
            DestinyComponentType[] componentTypes,
            CancellationToken token = default)
        {
            return await _apiAccess.GetCharacter(membershipType, destinyMembershipId, characterId, componentTypes,
                _token, token);
        }

        public async ValueTask<BungieResponse<DestinyMilestone>> GetClanWeeklyRewardState(
            long groupId,
            CancellationToken token = default)
        {
            return await _apiAccess.GetClanWeeklyRewardState(groupId, token);
        }

        public async ValueTask<BungieResponse<DestinyItemResponse>> GetItem(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long itemInstanceId,
            DestinyComponentType[] componentTypes,
            CancellationToken token = default)
        {
            return await _apiAccess.GetItem(membershipType, destinyMembershipId, itemInstanceId, componentTypes, _token,
                token);
        }

        public async ValueTask<BungieResponse<DestinyVendorsResponse>> GetVendors(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long characterId,
            DestinyComponentType[] componentTypes,
            CancellationToken token = default)
        {
            return await _apiAccess.GetVendors(membershipType, destinyMembershipId, characterId, componentTypes, _token,
                token);
        }

        public async ValueTask<BungieResponse<DestinyVendorResponse>> GetVendor(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long characterId,
            uint vendorHash,
            DestinyComponentType[] componentTypes,
            CancellationToken token = default)
        {
            return await _apiAccess.GetVendor(membershipType, destinyMembershipId, characterId, vendorHash,
                componentTypes, _token, token);
        }

        public async ValueTask<BungieResponse<DestinyPublicVendorsResponse>> GetPublicVendors(
            DestinyComponentType[] componentTypes,
            CancellationToken token = default)
        {
            return await _apiAccess.GetPublicVendors(componentTypes, token);
        }

        public async ValueTask<BungieResponse<DestinyCollectibleNodeDetailResponse>> GetCollectibleNodeDetails(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long characterId,
            uint collectiblePresentationNodeHash,
            DestinyComponentType[] componentTypes,
            CancellationToken token = default)
        {
            return await _apiAccess.GetCollectibleNodeDetails(membershipType, destinyMembershipId, characterId,
                collectiblePresentationNodeHash, componentTypes, _token, token);
        }

        public async ValueTask<BungieResponse<int>> TransferItem(
            DestinyItemTransferRequest request,
            CancellationToken token = default)
        {
            return await _apiAccess.TransferItem(request, _token, token);
        }

        public async ValueTask<BungieResponse<int>> PullFromPostmaster(
            DestinyPostmasterTransferRequest request,
            CancellationToken token = default)
        {
            return await _apiAccess.PullFromPostmaster(request, _token, token);
        }

        public async ValueTask<BungieResponse<int>> EquipItem(
            DestinyItemActionRequest request,
            CancellationToken token = default)
        {
            return await _apiAccess.EquipItem(request, _token, token);
        }

        public async ValueTask<BungieResponse<DestinyEquipItemResults>> EquipItems(
            DestinyItemSetActionRequest request,
            CancellationToken token = default)
        {
            return await _apiAccess.EquipItems(request, _token, token);
        }

        public async ValueTask<BungieResponse<int>> SetItemLockState(
            DestinyItemStateRequest request,
            CancellationToken token = default)
        {
            return await _apiAccess.SetItemLockState(request, _token, token);
        }

        public async ValueTask<BungieResponse<int>> SetQuestTrackedState(
            DestinyItemStateRequest request,
            CancellationToken token = default)
        {
            return await _apiAccess.SetQuestTrackedState(request, _token, token);
        }

        public async ValueTask<BungieResponse<DestinyItemChangeResponse>> InsertSocketPlug(
            DestinyInsertPlugsActionRequest request,
            CancellationToken token = default)
        {
            return await _apiAccess.InsertSocketPlug(request, _token, token);
        }

        public async ValueTask<BungieResponse<DestinyPostGameCarnageReportData>> GetPostGameCarnageReport(
            long activityId,
            CancellationToken token = default)
        {
            return await _apiAccess.GetPostGameCarnageReport(activityId, token);
        }

        public async ValueTask<BungieResponse<int>> ReportOffensivePostGameCarnageReportPlayer(
            long activityId,
            DestinyReportOffensePgcrRequest request,
            CancellationToken token = default)
        {
            return await _apiAccess.ReportOffensivePostGameCarnageReportPlayer(activityId, request, _token, token);
        }

        public async ValueTask<BungieResponse<ReadOnlyDictionary<string, DestinyHistoricalStatsDefinition>>>
            GetHistoricalStatsDefinition(CancellationToken token = default)
        {
            return await _apiAccess.GetHistoricalStatsDefinition(token);
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
            return await _apiAccess.GetClanLeaderboards(groupId, maxtop, modes, statid, token);
        }

        public async ValueTask<BungieResponse<DestinyClanAggregateStat[]>> GetClanAggregateStats(
            long groupId,
            DestinyActivityModeType[] modes,
            CancellationToken token = default)
        {
            return await _apiAccess.GetClanAggregateStats(groupId, modes, token);
        }

        public async ValueTask<BungieResponse<Dictionary<string, object>>> GetLeaderboards(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            int maxtop,
            DestinyActivityModeType[] modes,
            string statid = null,
            CancellationToken token = default)
        {
            return await _apiAccess.GetLeaderboards(membershipType, destinyMembershipId, maxtop, modes, statid, token);
        }

        public async ValueTask<BungieResponse<DestinyEntitySearchResult>> SearchDestinyEntities(
            DefinitionsEnum type,
            string searchTerm,
            int page = 0,
            CancellationToken token = default)
        {
            return await _apiAccess.SearchDestinyEntities(type, searchTerm, page, token);
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
            return await _apiAccess.GetHistoricalStats(membershipType, destinyMembershipId, characterId, daystart,
                dayend, groups, modes, periodType, token);
        }

        public async ValueTask<BungieResponse<DestinyHistoricalStatsAccountResult>> GetHistoricalStatsForAccount(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            DestinyStatsGroupType[] groups = null,
            CancellationToken token = default)
        {
            return await _apiAccess.GetHistoricalStatsForAccount(membershipType, destinyMembershipId, groups, token);
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
            return await _apiAccess.GetActivityHistory(membershipType, destinyMembershipId, characterId, count, mode,
                page, token);
        }

        public async ValueTask<BungieResponse<DestinyHistoricalWeaponStatsData>> GetUniqueWeaponHistory(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long characterId,
            CancellationToken token = default)
        {
            return await _apiAccess.GetUniqueWeaponHistory(membershipType, destinyMembershipId, characterId, token);
        }

        public async ValueTask<BungieResponse<DestinyAggregateActivityResults>> GetDestinyAggregateActivityStats(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long characterId,
            CancellationToken token = default)
        {
            return await _apiAccess.GetDestinyAggregateActivityStats(membershipType, destinyMembershipId, characterId,
                token);
        }

        public async ValueTask<BungieResponse<Dictionary<uint, DestinyPublicMilestone>>> GetPublicMilestones(
            CancellationToken token = default)
        {
            return await _apiAccess.GetPublicMilestones(token);
        }

        public async ValueTask<BungieResponse<DestinyMilestoneContent>> GetPublicMilestoneContent(
            uint milestoneHash,
            CancellationToken token = default)
        {
            return await _apiAccess.GetPublicMilestoneContent(milestoneHash, token);
        }

        public async ValueTask<BungieResponse<AwaInitializeResponse>> AwaInitializeRequest(
            AwaPermissionRequested request,
            CancellationToken token = default)
        {
            return await _apiAccess.AwaInitializeRequest(request, _token, token);
        }

        public async ValueTask<BungieResponse<int>> AwaProvideAuthorizationResult(
            AwaUserResponse request,
            CancellationToken token = default)
        {
            return await _apiAccess.AwaProvideAuthorizationResult(request, _token, token);
        }

        public async ValueTask<BungieResponse<AwaAuthorizationResult>> AwaGetActionToken(
            string correlationId,
            CancellationToken token = default)
        {
            return await _apiAccess.AwaGetActionToken(correlationId, _token, token);
        }
    }
}