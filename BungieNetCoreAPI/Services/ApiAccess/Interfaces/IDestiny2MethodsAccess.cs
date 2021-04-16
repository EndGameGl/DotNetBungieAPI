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
        ValueTask<BungieResponse<DestinyManifest>> GetDestinyManifest(CancellationToken token = default);
        ValueTask<BungieResponse<T>> GetDestinyEntityDefinition<T>(DefinitionsEnum entityType, uint hash, CancellationToken token = default) where T : IDestinyDefinition;
        ValueTask<BungieResponse<UserInfoCard[]>> SearchDestinyPlayer(BungieMembershipType membershipType, string displayName, bool returnOriginalProfile = false, CancellationToken token = default);
        ValueTask<BungieResponse<DestinyLinkedProfilesResponse>> GetLinkedProfiles(BungieMembershipType membershipType, long membershipId, bool getAllMemberships = false, CancellationToken token = default);
        ValueTask<BungieResponse<DestinyProfileResponse>> GetProfile(BungieMembershipType membershipType, long destinyMembershipId, DestinyComponentType[] componentTypes, CancellationToken token = default);
        ValueTask<BungieResponse<DestinyCharacterResponse>> GetCharacter(BungieMembershipType membershipType, long destinyMembershipId, long characterId, DestinyComponentType[] componentTypes, CancellationToken token = default);
        ValueTask<BungieResponse<DestinyMilestone>> GetClanWeeklyRewardState(long groupId, CancellationToken token = default);
        ValueTask<BungieResponse<DestinyItemResponse>> GetItem(BungieMembershipType membershipType, long destinyMembershipId, long itemInstanceId, DestinyComponentType[] componentTypes, CancellationToken token = default);
        ValueTask<BungieResponse<DestinyVendorsResponse>> GetVendors(BungieMembershipType membershipType, long destinyMembershipId, long characterId, DestinyComponentType[] componentTypes, CancellationToken token = default);
        ValueTask<BungieResponse<DestinyVendorResponse>> GetVendor(BungieMembershipType membershipType, long destinyMembershipId, long characterId, uint vendorHash, DestinyComponentType[] componentTypes, CancellationToken token = default);
        ValueTask<BungieResponse<DestinyPublicVendorsResponse>> GetPublicVendors(DestinyComponentType[] componentTypes, CancellationToken token = default);
        ValueTask<BungieResponse<DestinyCollectibleNodeDetailResponse>> GetCollectibleNodeDetails(BungieMembershipType membershipType, long destinyMembershipId, long characterId, uint collectiblePresentationNodeHash, DestinyComponentType[] componentTypes, CancellationToken token = default);
        ValueTask<BungieResponse<DestinyPostGameCarnageReportData>> GetPostGameCarnageReport(long activityId, CancellationToken token = default);
        ValueTask<BungieResponse<ReadOnlyDictionary<string, DestinyHistoricalStatsDefinition>>> GetHistoricalStatsDefinition(CancellationToken token = default);
        ValueTask<BungieResponse<DestinyEntitySearchResult>> SearchDestinyEntities(DefinitionsEnum type, string searchTerm, int page = 0, CancellationToken token = default);
        ValueTask<BungieResponse<ReadOnlyDictionary<string, DestinyHistoricalStatsByPeriod>>> GetHistoricalStats(BungieMembershipType membershipType, long destinyMembershipId, long characterId, DateTime? daystart = null, DateTime? dayend = null, DestinyStatsGroupType[] groups = null, DestinyActivityModeType[] modes = null, PeriodType periodType = PeriodType.None, CancellationToken token = default);
        ValueTask<BungieResponse<DestinyHistoricalStatsAccountResult>> GetHistoricalStatsForAccount(BungieMembershipType membershipType, long destinyMembershipId, DestinyStatsGroupType[] groups = null, CancellationToken token = default);
        ValueTask<BungieResponse<DestinyActivityHistoryResults>> GetActivityHistory(BungieMembershipType membershipType, long destinyMembershipId, long characterId, int count = 25, DestinyActivityModeType mode = DestinyActivityModeType.None, int page = 0, CancellationToken token = default);
        ValueTask<BungieResponse<DestinyHistoricalWeaponStatsData>> GetUniqueWeaponHistory(BungieMembershipType membershipType, long destinyMembershipId, long characterId, CancellationToken token = default);
        ValueTask<BungieResponse<DestinyAggregateActivityResults>> GetDestinyAggregateActivityStats(BungieMembershipType membershipType, long destinyMembershipId, long characterId, CancellationToken token = default);
        ValueTask<BungieResponse<Dictionary<uint, DestinyPublicMilestone>>> GetPublicMilestones(CancellationToken token = default);
        ValueTask<BungieResponse<DestinyMilestoneContent>> GetPublicMilestoneContent(uint milestoneHash, CancellationToken token = default);
    }
}
