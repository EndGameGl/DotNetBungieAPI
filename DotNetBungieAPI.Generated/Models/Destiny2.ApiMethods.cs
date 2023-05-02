namespace DotNetBungieAPI.Generated.Models;

public interface IDestiny2Api
{
    Task<ApiResponse<Destiny.Config.DestinyManifest>> GetDestinyManifest();

    Task<ApiResponse<Destiny.Definitions.DestinyDefinition>> GetDestinyEntityDefinition(
        string entityType,
        uint hashIdentifier
    );

    Task<ApiResponse<List<User.UserInfoCard>>> SearchDestinyPlayerByBungieName(
        BungieMembershipType membershipType,
        User.ExactSearchRequest body
    );

    Task<ApiResponse<Destiny.Responses.DestinyLinkedProfilesResponse>> GetLinkedProfiles(
        long membershipId,
        BungieMembershipType membershipType,
        bool getAllMemberships
    );

    Task<ApiResponse<Destiny.Responses.DestinyProfileResponse>> GetProfile(
        long destinyMembershipId,
        BungieMembershipType membershipType,
        List<Destiny.DestinyComponentType> components
    );

    Task<ApiResponse<Destiny.Responses.DestinyCharacterResponse>> GetCharacter(
        long characterId,
        long destinyMembershipId,
        BungieMembershipType membershipType,
        List<Destiny.DestinyComponentType> components
    );

    Task<ApiResponse<Destiny.Milestones.DestinyMilestone>> GetClanWeeklyRewardState(
        long groupId
    );

    Task<ApiResponse<Config.ClanBanner.ClanBannerSource>> GetClanBannerSource();

    Task<ApiResponse<Destiny.Responses.DestinyItemResponse>> GetItem(
        long destinyMembershipId,
        long itemInstanceId,
        BungieMembershipType membershipType,
        List<Destiny.DestinyComponentType> components
    );

    Task<ApiResponse<Destiny.Responses.DestinyVendorsResponse>> GetVendors(
        long characterId,
        long destinyMembershipId,
        BungieMembershipType membershipType,
        List<Destiny.DestinyComponentType> components,
        Destiny.DestinyVendorFilter filter
    );

    Task<ApiResponse<Destiny.Responses.DestinyVendorResponse>> GetVendor(
        long characterId,
        long destinyMembershipId,
        BungieMembershipType membershipType,
        uint vendorHash,
        List<Destiny.DestinyComponentType> components
    );

    Task<ApiResponse<Destiny.Responses.DestinyPublicVendorsResponse>> GetPublicVendors(
        List<Destiny.DestinyComponentType> components
    );

    Task<ApiResponse<Destiny.Responses.DestinyCollectibleNodeDetailResponse>> GetCollectibleNodeDetails(
        long characterId,
        uint collectiblePresentationNodeHash,
        long destinyMembershipId,
        BungieMembershipType membershipType,
        List<Destiny.DestinyComponentType> components
    );

    Task<ApiResponse<int>> TransferItem(
        Destiny.Requests.DestinyItemTransferRequest body,
        string authToken
    );

    Task<ApiResponse<int>> PullFromPostmaster(
        Destiny.Requests.Actions.DestinyPostmasterTransferRequest body,
        string authToken
    );

    Task<ApiResponse<int>> EquipItem(
        Destiny.Requests.Actions.DestinyItemActionRequest body,
        string authToken
    );

    Task<ApiResponse<Destiny.DestinyEquipItemResults>> EquipItems(
        Destiny.Requests.Actions.DestinyItemSetActionRequest body,
        string authToken
    );

    Task<ApiResponse<int>> EquipLoadout(
        Destiny.Requests.Actions.DestinyLoadoutActionRequest body,
        string authToken
    );

    Task<ApiResponse<int>> SnapshotLoadout(
        Destiny.Requests.Actions.DestinyLoadoutUpdateActionRequest body,
        string authToken
    );

    Task<ApiResponse<int>> UpdateLoadoutIdentifiers(
        Destiny.Requests.Actions.DestinyLoadoutUpdateActionRequest body,
        string authToken
    );

    Task<ApiResponse<int>> ClearLoadout(
        Destiny.Requests.Actions.DestinyLoadoutActionRequest body,
        string authToken
    );

    Task<ApiResponse<int>> SetItemLockState(
        Destiny.Requests.Actions.DestinyItemStateRequest body,
        string authToken
    );

    Task<ApiResponse<int>> SetQuestTrackedState(
        Destiny.Requests.Actions.DestinyItemStateRequest body,
        string authToken
    );

    Task<ApiResponse<Destiny.Responses.DestinyItemChangeResponse>> InsertSocketPlug(
        Destiny.Requests.Actions.DestinyInsertPlugsActionRequest body,
        string authToken
    );

    Task<ApiResponse<Destiny.Responses.DestinyItemChangeResponse>> InsertSocketPlugFree(
        Destiny.Requests.Actions.DestinyInsertPlugsFreeActionRequest body,
        string authToken
    );

    Task<ApiResponse<Destiny.HistoricalStats.DestinyPostGameCarnageReportData>> GetPostGameCarnageReport(
        long activityId
    );

    Task<ApiResponse<int>> ReportOffensivePostGameCarnageReportPlayer(
        long activityId,
        Destiny.Reporting.Requests.DestinyReportOffensePgcrRequest body,
        string authToken
    );

    Task<ApiResponse<Dictionary<string, Destiny.HistoricalStats.Definitions.DestinyHistoricalStatsDefinition>>> GetHistoricalStatsDefinition();

    Task<ApiResponse<Dictionary<string, Dictionary<string, Destiny.HistoricalStats.DestinyLeaderboard>>>> GetClanLeaderboards(
        long groupId,
        int maxtop,
        string modes,
        string statid
    );

    Task<ApiResponse<List<Destiny.HistoricalStats.DestinyClanAggregateStat>>> GetClanAggregateStats(
        long groupId,
        string modes
    );

    Task<ApiResponse<Dictionary<string, Dictionary<string, Destiny.HistoricalStats.DestinyLeaderboard>>>> GetLeaderboards(
        long destinyMembershipId,
        BungieMembershipType membershipType,
        int maxtop,
        string modes,
        string statid
    );

    Task<ApiResponse<Dictionary<string, Dictionary<string, Destiny.HistoricalStats.DestinyLeaderboard>>>> GetLeaderboardsForCharacter(
        long characterId,
        long destinyMembershipId,
        BungieMembershipType membershipType,
        int maxtop,
        string modes,
        string statid
    );

    Task<ApiResponse<Destiny.Definitions.DestinyEntitySearchResult>> SearchDestinyEntities(
        string searchTerm,
        string type,
        int page
    );

    Task<ApiResponse<Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod>>> GetHistoricalStats(
        long characterId,
        long destinyMembershipId,
        BungieMembershipType membershipType,
        DateTime dayend,
        DateTime daystart,
        List<Destiny.HistoricalStats.Definitions.DestinyStatsGroupType> groups,
        List<Destiny.HistoricalStats.Definitions.DestinyActivityModeType> modes,
        Destiny.HistoricalStats.Definitions.PeriodType periodType
    );

    Task<ApiResponse<Destiny.HistoricalStats.DestinyHistoricalStatsAccountResult>> GetHistoricalStatsForAccount(
        long destinyMembershipId,
        BungieMembershipType membershipType,
        List<Destiny.HistoricalStats.Definitions.DestinyStatsGroupType> groups
    );

    Task<ApiResponse<Destiny.HistoricalStats.DestinyActivityHistoryResults>> GetActivityHistory(
        long characterId,
        long destinyMembershipId,
        BungieMembershipType membershipType,
        int count,
        Destiny.HistoricalStats.Definitions.DestinyActivityModeType mode,
        int page
    );

    Task<ApiResponse<Destiny.HistoricalStats.DestinyHistoricalWeaponStatsData>> GetUniqueWeaponHistory(
        long characterId,
        long destinyMembershipId,
        BungieMembershipType membershipType
    );

    Task<ApiResponse<Destiny.HistoricalStats.DestinyAggregateActivityResults>> GetDestinyAggregateActivityStats(
        long characterId,
        long destinyMembershipId,
        BungieMembershipType membershipType
    );

    Task<ApiResponse<Destiny.Milestones.DestinyMilestoneContent>> GetPublicMilestoneContent(
        uint milestoneHash
    );

    Task<ApiResponse<Dictionary<uint, Destiny.Milestones.DestinyPublicMilestone>>> GetPublicMilestones();

    Task<ApiResponse<Destiny.Advanced.AwaInitializeResponse>> AwaInitializeRequest(
        Destiny.Advanced.AwaPermissionRequested body,
        string authToken
    );

    Task<ApiResponse<int>> AwaProvideAuthorizationResult(
        Destiny.Advanced.AwaUserResponse body
    );

    Task<ApiResponse<Destiny.Advanced.AwaAuthorizationResult>> AwaGetActionToken(
        string correlationId,
        string authToken
    );

}
