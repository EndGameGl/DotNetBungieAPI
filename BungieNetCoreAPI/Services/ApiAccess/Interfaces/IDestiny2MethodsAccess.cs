using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Models.Destiny.Config;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModes;
using NetBungieAPI.Models.Destiny.Definitions.HistoricalStats;
using NetBungieAPI.Models.Destiny.Milestones;
using NetBungieAPI.Models.Destiny.Responses;
using NetBungieAPI.Models.Queries;
using NetBungieAPI.Models.User;
using NetBungieAPI.Responses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Models.Destiny.HistoricalStats;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface IDestiny2MethodsAccess
    {
        /// <summary>
        /// Returns the current version of the manifest as a json object.
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyManifest>> GetDestinyManifest(CancellationToken token = default);

        /// <summary>
        /// Returns the static definition of an entity of the given Type and hash identifier. Examine the API Documentation for the Type Names of entities that have their own definitions. Note that the return type will always *inherit from* DestinyDefinition, but the specific type returned will be the requested entity type if it can be found. Please don't use this as a chatty alternative to the Manifest database if you require large sets of data, but for simple and one-off accesses this should be handy.
        /// </summary>
        /// <param name="entityType">The type of entity for whom you would like results. These correspond to the entity's definition contract name. For instance, if you are looking for items, this property should be 'DestinyInventoryItemDefinition'. PREVIEW: This endpoint is still in beta, and may experience rough edges. The schema is tentatively in final form, but there may be bugs that prevent desirable operation.</param>
        /// <param name="hash">The hash identifier for the specific Entity you want returned.</param>
        /// <param name="token">Cancellation token</param>
        /// <typeparam name="T"><see cref="IDestinyDefinition"/> entity</typeparam>
        /// <returns></returns>
        ValueTask<BungieResponse<T>> GetDestinyEntityDefinition<T>(DefinitionsEnum entityType, uint hash,
            CancellationToken token = default) where T : IDestinyDefinition;

        /// <summary>
        /// Returns a list of Destiny memberships given a full Gamertag or PSN ID. Unless you pass returnOriginalProfile=true, this will return membership information for the users' Primary Cross Save Profile if they are engaged in cross save rather than any original Destiny profile that is now being overridden.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type, or All.</param>
        /// <param name="displayName">The full gamertag or PSN id of the player. Spaces and case are ignored.</param>
        /// <param name="returnOriginalProfile">If passed in and set to true, we will return the original Destiny Profile(s) linked to that gamertag, and not their currently active Destiny Profile.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<UserInfoCard[]>> SearchDestinyPlayer(BungieMembershipType membershipType,
            string displayName, bool returnOriginalProfile = false, CancellationToken token = default);

        ValueTask<BungieResponse<DestinyLinkedProfilesResponse>> GetLinkedProfiles(BungieMembershipType membershipType,
            long membershipId, bool getAllMemberships = false, CancellationToken token = default);

        ValueTask<BungieResponse<DestinyProfileResponse>> GetProfile(BungieMembershipType membershipType,
            long destinyMembershipId, DestinyComponentType[] componentTypes, CancellationToken token = default);

        ValueTask<BungieResponse<DestinyCharacterResponse>> GetCharacter(BungieMembershipType membershipType,
            long destinyMembershipId, long characterId, DestinyComponentType[] componentTypes,
            CancellationToken token = default);

        ValueTask<BungieResponse<DestinyMilestone>> GetClanWeeklyRewardState(long groupId,
            CancellationToken token = default);

        ValueTask<BungieResponse<DestinyItemResponse>> GetItem(BungieMembershipType membershipType,
            long destinyMembershipId, long itemInstanceId, DestinyComponentType[] componentTypes,
            CancellationToken token = default);

        ValueTask<BungieResponse<DestinyVendorsResponse>> GetVendors(BungieMembershipType membershipType,
            long destinyMembershipId, long characterId, DestinyComponentType[] componentTypes,
            CancellationToken token = default);

        ValueTask<BungieResponse<DestinyVendorResponse>> GetVendor(BungieMembershipType membershipType,
            long destinyMembershipId, long characterId, uint vendorHash, DestinyComponentType[] componentTypes,
            CancellationToken token = default);

        ValueTask<BungieResponse<DestinyPublicVendorsResponse>> GetPublicVendors(DestinyComponentType[] componentTypes,
            CancellationToken token = default);

        ValueTask<BungieResponse<DestinyCollectibleNodeDetailResponse>> GetCollectibleNodeDetails(
            BungieMembershipType membershipType, long destinyMembershipId, long characterId,
            uint collectiblePresentationNodeHash, DestinyComponentType[] componentTypes,
            CancellationToken token = default);

        ValueTask<BungieResponse<DestinyPostGameCarnageReportData>> GetPostGameCarnageReport(long activityId,
            CancellationToken token = default);

        ValueTask<BungieResponse<ReadOnlyDictionary<string, DestinyHistoricalStatsDefinition>>>
            GetHistoricalStatsDefinition(CancellationToken token = default);

        ValueTask<BungieResponse<DestinyEntitySearchResult>> SearchDestinyEntities(DefinitionsEnum type,
            string searchTerm, int page = 0, CancellationToken token = default);

        ValueTask<BungieResponse<ReadOnlyDictionary<string, DestinyHistoricalStatsByPeriod>>> GetHistoricalStats(
            BungieMembershipType membershipType, long destinyMembershipId, long characterId, DateTime? daystart = null,
            DateTime? dayend = null, DestinyStatsGroupType[] groups = null, DestinyActivityModeType[] modes = null,
            PeriodType periodType = PeriodType.None, CancellationToken token = default);

        ValueTask<BungieResponse<DestinyHistoricalStatsAccountResult>> GetHistoricalStatsForAccount(
            BungieMembershipType membershipType, long destinyMembershipId, DestinyStatsGroupType[] groups = null,
            CancellationToken token = default);

        ValueTask<BungieResponse<DestinyActivityHistoryResults>> GetActivityHistory(BungieMembershipType membershipType,
            long destinyMembershipId, long characterId, int count = 25,
            DestinyActivityModeType mode = DestinyActivityModeType.None, int page = 0,
            CancellationToken token = default);

        ValueTask<BungieResponse<DestinyHistoricalWeaponStatsData>> GetUniqueWeaponHistory(
            BungieMembershipType membershipType, long destinyMembershipId, long characterId,
            CancellationToken token = default);

        ValueTask<BungieResponse<DestinyAggregateActivityResults>> GetDestinyAggregateActivityStats(
            BungieMembershipType membershipType, long destinyMembershipId, long characterId,
            CancellationToken token = default);

        ValueTask<BungieResponse<Dictionary<uint, DestinyPublicMilestone>>> GetPublicMilestones(
            CancellationToken token = default);

        ValueTask<BungieResponse<DestinyMilestoneContent>> GetPublicMilestoneContent(uint milestoneHash,
            CancellationToken token = default);
    }
}