using NetBungieAPI.Destiny;
using NetBungieAPI.Destiny.Definitions;
using NetBungieAPI.Destiny.Definitions.ActivityModes;
using NetBungieAPI.Destiny.Definitions.HistoricalStats;
using NetBungieAPI.Destiny.Profile;
using NetBungieAPI.Destiny.Profile.Components.Contracts;
using NetBungieAPI.Destiny.Responses;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Queries;
using NetBungieAPI.Models.User;
using NetBungieAPI.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface IDestiny2MethodsAccess
    {
        ValueTask<BungieResponse<DestinyManifest>> GetDestinyManifest(CancellationToken token = default);
        Task<BungieResponse<T>> GetDestinyEntityDefinition<T>(DefinitionsEnum entityType, uint hash) where T : IDestinyDefinition;
        Task<BungieResponse<UserInfoCard[]>> SearchDestinyPlayer(BungieMembershipType membershipType, string displayName, bool returnOriginalProfile = false);
        Task<BungieResponse<DestinyLinkedProfilesResponse>> GetLinkedProfiles(BungieMembershipType membershipType, long membershipId, bool getAllMemberships = false);
        Task<BungieResponse<DestinyComponentProfileResponse>> GetProfile(BungieMembershipType membershipType, long destinyMembershipId, DestinyComponentType[] componentTypes);
        Task<BungieResponse<DestinyComponentCharacterResponse>> GetCharacter(BungieMembershipType membershipType, long destinyMembershipId, long characterId, DestinyComponentType[] componentTypes);
        Task<BungieResponse<DestinyMilestone>> GetClanWeeklyRewardState(long groupId);
        Task<BungieResponse<DestinyComponentItemResponse>> GetItem(BungieMembershipType membershipType, long destinyMembershipId, long itemInstanceId, DestinyComponentType[] componentTypes);
        Task<BungieResponse<DestinyVendorsResponse>> GetVendors(BungieMembershipType membershipType, long destinyMembershipId, long characterId, DestinyComponentType[] componentTypes);
        Task<BungieResponse<DestinyVendorResponse>> GetVendor(BungieMembershipType membershipType, long destinyMembershipId, long characterId, uint vendorHash, DestinyComponentType[] componentTypes);
        Task<BungieResponse<DestinyPublicVendorsResponse>> GetPublicVendors(DestinyComponentType[] componentTypes);
        Task<BungieResponse<DestinyCollectibleNodeDetailResponse>> GetCollectibleNodeDetails(BungieMembershipType membershipType, long destinyMembershipId, long characterId, uint collectiblePresentationNodeHash, DestinyComponentType[] componentTypes);
        Task<BungieResponse<DestinyPostGameCarnageReportData>> GetPostGameCarnageReport(long activityId);
        Task<BungieResponse<Dictionary<string, DestinyHistoricalStatsDefinition>>> GetHistoricalStatsDefinition();
        Task<BungieResponse<DestinyEntitySearchResult>> SearchDestinyEntities(DefinitionsEnum type, string searchTerm, int page = 0);
        Task<BungieResponse<Dictionary<string, DestinyHistoricalStatsByPeriod>>> GetHistoricalStats(BungieMembershipType membershipType, long destinyMembershipId, long characterId, DateTime? daystart = null, DateTime? dayend = null, DestinyStatsGroupType[] groups = null, DestinyActivityModeType[] modes = null, PeriodType periodType = PeriodType.None);
        Task<BungieResponse<DestinyHistoricalStatsAccountResult>> GetHistoricalStatsForAccount(BungieMembershipType membershipType, long destinyMembershipId, DestinyStatsGroupType[] groups = null);
        Task<BungieResponse<DestinyActivityHistoryResults>> GetActivityHistory(BungieMembershipType membershipType, long destinyMembershipId, long characterId, int count = 25, DestinyActivityModeType mode = DestinyActivityModeType.None, int page = 0);
        Task<BungieResponse<DestinyHistoricalWeaponStatsData>> GetUniqueWeaponHistory(BungieMembershipType membershipType, long destinyMembershipId, long characterId);
        Task<BungieResponse<DestinyAggregateActivityResults>> GetDestinyAggregateActivityStats(BungieMembershipType membershipType, long destinyMembershipId, long characterId);
        Task<BungieResponse<Dictionary<uint, GetPublicMilestonesResponse>>> GetPublicMilestones();
        Task<BungieResponse<DestinyMilestoneContent>> GetPublicMilestoneContent(uint milestoneHash);
    }
}
