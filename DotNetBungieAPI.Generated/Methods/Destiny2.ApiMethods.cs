using DotNetBungieAPI.Generated.Models;

namespace DotNetBungieAPI.Generated.Methods;

public interface IDestiny2Api
{
    Task<ApiResponse<Models.Destiny.Config.DestinyManifest>> GetDestinyManifest();

    Task<ApiResponse<Models.Destiny.Definitions.DestinyDefinition>> GetDestinyEntityDefinition(
        string entityType,
        uint hashIdentifier
    );

    Task<ApiResponse<Models.User.UserInfoCard[]>> SearchDestinyPlayerByBungieName(
        Models.BungieMembershipType membershipType,
        Models.User.ExactSearchRequest body
    );

    Task<ApiResponse<Models.Destiny.Responses.DestinyLinkedProfilesResponse>> GetLinkedProfiles(
        long membershipId,
        Models.BungieMembershipType membershipType,
        bool getAllMemberships
    );

    Task<ApiResponse<Models.Destiny.Responses.DestinyProfileResponse>> GetProfile(
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        Models.Destiny.DestinyComponentType[] components
    );

    Task<ApiResponse<Models.Destiny.Responses.DestinyCharacterResponse>> GetCharacter(
        long characterId,
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        Models.Destiny.DestinyComponentType[] components
    );

    Task<ApiResponse<Models.Destiny.Milestones.DestinyMilestone>> GetClanWeeklyRewardState(
        long groupId
    );

    Task<ApiResponse<Models.Config.ClanBanner.ClanBannerSource>> GetClanBannerSource();

    Task<ApiResponse<Models.Destiny.Responses.DestinyItemResponse>> GetItem(
        long destinyMembershipId,
        long itemInstanceId,
        Models.BungieMembershipType membershipType,
        Models.Destiny.DestinyComponentType[] components
    );

    Task<ApiResponse<Models.Destiny.Responses.DestinyVendorsResponse>> GetVendors(
        long characterId,
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        Models.Destiny.DestinyComponentType[] components,
        Models.Destiny.DestinyVendorFilter filter
    );

    Task<ApiResponse<Models.Destiny.Responses.DestinyVendorResponse>> GetVendor(
        long characterId,
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        uint vendorHash,
        Models.Destiny.DestinyComponentType[] components
    );

    Task<ApiResponse<Models.Destiny.Responses.DestinyPublicVendorsResponse>> GetPublicVendors(
        Models.Destiny.DestinyComponentType[] components
    );

    Task<ApiResponse<Models.Destiny.Responses.DestinyCollectibleNodeDetailResponse>> GetCollectibleNodeDetails(
        long characterId,
        uint collectiblePresentationNodeHash,
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        Models.Destiny.DestinyComponentType[] components
    );

    Task<ApiResponse<int>> TransferItem(
        Models.Destiny.Requests.DestinyItemTransferRequest body,
        string authToken
    );

    Task<ApiResponse<int>> PullFromPostmaster(
        Models.Destiny.Requests.Actions.DestinyPostmasterTransferRequest body,
        string authToken
    );

    Task<ApiResponse<int>> EquipItem(
        Models.Destiny.Requests.Actions.DestinyItemActionRequest body,
        string authToken
    );

    Task<ApiResponse<Models.Destiny.DestinyEquipItemResults>> EquipItems(
        Models.Destiny.Requests.Actions.DestinyItemSetActionRequest body,
        string authToken
    );

    Task<ApiResponse<int>> EquipLoadout(
        Models.Destiny.Requests.Actions.DestinyLoadoutActionRequest body,
        string authToken
    );

    Task<ApiResponse<int>> SnapshotLoadout(
        Models.Destiny.Requests.Actions.DestinyLoadoutUpdateActionRequest body,
        string authToken
    );

    Task<ApiResponse<int>> UpdateLoadoutIdentifiers(
        Models.Destiny.Requests.Actions.DestinyLoadoutUpdateActionRequest body,
        string authToken
    );

    Task<ApiResponse<int>> ClearLoadout(
        Models.Destiny.Requests.Actions.DestinyLoadoutActionRequest body,
        string authToken
    );

    Task<ApiResponse<int>> SetItemLockState(
        Models.Destiny.Requests.Actions.DestinyItemStateRequest body,
        string authToken
    );

    Task<ApiResponse<int>> SetQuestTrackedState(
        Models.Destiny.Requests.Actions.DestinyItemStateRequest body,
        string authToken
    );

    Task<ApiResponse<Models.Destiny.Responses.DestinyItemChangeResponse>> InsertSocketPlug(
        Models.Destiny.Requests.Actions.DestinyInsertPlugsActionRequest body,
        string authToken
    );

    Task<ApiResponse<Models.Destiny.Responses.DestinyItemChangeResponse>> InsertSocketPlugFree(
        Models.Destiny.Requests.Actions.DestinyInsertPlugsFreeActionRequest body,
        string authToken
    );

    Task<ApiResponse<Models.Destiny.HistoricalStats.DestinyPostGameCarnageReportData>> GetPostGameCarnageReport(
        long activityId
    );

    Task<ApiResponse<int>> ReportOffensivePostGameCarnageReportPlayer(
        long activityId,
        Models.Destiny.Reporting.Requests.DestinyReportOffensePgcrRequest body,
        string authToken
    );

    Task<ApiResponse<Dictionary<string, Models.Destiny.HistoricalStats.Definitions.DestinyHistoricalStatsDefinition>>> GetHistoricalStatsDefinition();

    Task<ApiResponse<Dictionary<string, Dictionary<string, Models.Destiny.HistoricalStats.DestinyLeaderboard>>>> GetClanLeaderboards(
        long groupId,
        int maxtop,
        string modes,
        string statid
    );

    Task<ApiResponse<Models.Destiny.HistoricalStats.DestinyClanAggregateStat[]>> GetClanAggregateStats(
        long groupId,
        string modes
    );

    Task<ApiResponse<Dictionary<string, Dictionary<string, Models.Destiny.HistoricalStats.DestinyLeaderboard>>>> GetLeaderboards(
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        int maxtop,
        string modes,
        string statid
    );

    Task<ApiResponse<Dictionary<string, Dictionary<string, Models.Destiny.HistoricalStats.DestinyLeaderboard>>>> GetLeaderboardsForCharacter(
        long characterId,
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        int maxtop,
        string modes,
        string statid
    );

    Task<ApiResponse<Models.Destiny.Definitions.DestinyEntitySearchResult>> SearchDestinyEntities(
        string searchTerm,
        string type,
        int page
    );

    Task<ApiResponse<Dictionary<string, Models.Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod>>> GetHistoricalStats(
        long characterId,
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        DateTime dayend,
        DateTime daystart,
        Models.Destiny.HistoricalStats.Definitions.DestinyStatsGroupType[] groups,
        Models.Destiny.HistoricalStats.Definitions.DestinyActivityModeType[] modes,
        Models.Destiny.HistoricalStats.Definitions.PeriodType periodType
    );

    Task<ApiResponse<Models.Destiny.HistoricalStats.DestinyHistoricalStatsAccountResult>> GetHistoricalStatsForAccount(
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        Models.Destiny.HistoricalStats.Definitions.DestinyStatsGroupType[] groups
    );

    Task<ApiResponse<Models.Destiny.HistoricalStats.DestinyActivityHistoryResults>> GetActivityHistory(
        long characterId,
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        int count,
        Models.Destiny.HistoricalStats.Definitions.DestinyActivityModeType mode,
        int page
    );

    Task<ApiResponse<Models.Destiny.HistoricalStats.DestinyHistoricalWeaponStatsData>> GetUniqueWeaponHistory(
        long characterId,
        long destinyMembershipId,
        Models.BungieMembershipType membershipType
    );

    Task<ApiResponse<Models.Destiny.HistoricalStats.DestinyAggregateActivityResults>> GetDestinyAggregateActivityStats(
        long characterId,
        long destinyMembershipId,
        Models.BungieMembershipType membershipType
    );

    Task<ApiResponse<Models.Destiny.Milestones.DestinyMilestoneContent>> GetPublicMilestoneContent(
        uint milestoneHash
    );

    Task<ApiResponse<Dictionary<uint, Models.Destiny.Milestones.DestinyPublicMilestone>>> GetPublicMilestones();

    Task<ApiResponse<Models.Destiny.Advanced.AwaInitializeResponse>> AwaInitializeRequest(
        Models.Destiny.Advanced.AwaPermissionRequested body,
        string authToken
    );

    Task<ApiResponse<int>> AwaProvideAuthorizationResult(
        Models.Destiny.Advanced.AwaUserResponse body
    );

    Task<ApiResponse<Models.Destiny.Advanced.AwaAuthorizationResult>> AwaGetActionToken(
        string correlationId,
        string authToken
    );

}
