using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Authorization;

namespace DotNetBungieAPI.Service.Abstractions.ApiAccess;

public interface IDestiny2Api
{
    Task<BungieResponse<Models.Destiny.Config.DestinyManifest>> GetDestinyManifest(CancellationToken cancellationToken = default);

    Task<BungieResponse<Models.Destiny.Definitions.DestinyDefinition>> GetDestinyEntityDefinition(
        string entityType,
        uint hashIdentifier,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.User.UserInfoCard[]>> SearchDestinyPlayerByBungieName(
        Models.BungieMembershipType membershipType,
        Models.User.ExactSearchRequest requestBody,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Destiny.Responses.DestinyLinkedProfilesResponse>> GetLinkedProfiles(
        long membershipId,
        Models.BungieMembershipType membershipType,
        bool getAllMemberships,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Destiny.Responses.DestinyProfileResponse>> GetProfile(
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        Models.Destiny.DestinyComponentType[] components,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Destiny.Responses.DestinyCharacterResponse>> GetCharacter(
        long characterId,
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        Models.Destiny.DestinyComponentType[] components,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Destiny.Milestones.DestinyMilestone>> GetClanWeeklyRewardState(
        long groupId,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Config.ClanBanner.ClanBannerSource>> GetClanBannerSource(CancellationToken cancellationToken = default);

    Task<BungieResponse<Models.Destiny.Responses.DestinyItemResponse>> GetItem(
        long destinyMembershipId,
        long itemInstanceId,
        Models.BungieMembershipType membershipType,
        Models.Destiny.DestinyComponentType[] components,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Destiny.Responses.DestinyVendorsResponse>> GetVendors(
        long characterId,
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        Models.Destiny.DestinyComponentType[] components,
        Models.Destiny.DestinyVendorFilter filter,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Destiny.Responses.DestinyVendorResponse>> GetVendor(
        long characterId,
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        uint vendorHash,
        Models.Destiny.DestinyComponentType[] components,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Destiny.Responses.DestinyPublicVendorsResponse>> GetPublicVendors(
        Models.Destiny.DestinyComponentType[] components,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Destiny.Responses.DestinyCollectibleNodeDetailResponse>> GetCollectibleNodeDetails(
        long characterId,
        uint collectiblePresentationNodeHash,
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        Models.Destiny.DestinyComponentType[] components,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<int>> TransferItem(
        Models.Destiny.Requests.DestinyItemTransferRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<int>> PullFromPostmaster(
        Models.Destiny.Requests.Actions.DestinyPostmasterTransferRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<int>> EquipItem(
        Models.Destiny.Requests.Actions.DestinyItemActionRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Destiny.DestinyEquipItemResults>> EquipItems(
        Models.Destiny.Requests.Actions.DestinyItemSetActionRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<int>> EquipLoadout(
        Models.Destiny.Requests.Actions.DestinyLoadoutActionRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<int>> SnapshotLoadout(
        Models.Destiny.Requests.Actions.DestinyLoadoutUpdateActionRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<int>> UpdateLoadoutIdentifiers(
        Models.Destiny.Requests.Actions.DestinyLoadoutUpdateActionRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<int>> ClearLoadout(
        Models.Destiny.Requests.Actions.DestinyLoadoutActionRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<int>> SetItemLockState(
        Models.Destiny.Requests.Actions.DestinyItemStateRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<int>> SetQuestTrackedState(
        Models.Destiny.Requests.Actions.DestinyItemStateRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Destiny.Responses.DestinyItemChangeResponse>> InsertSocketPlug(
        Models.Destiny.Requests.Actions.DestinyInsertPlugsActionRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Destiny.Responses.DestinyItemChangeResponse>> InsertSocketPlugFree(
        Models.Destiny.Requests.Actions.DestinyInsertPlugsFreeActionRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Destiny.HistoricalStats.DestinyPostGameCarnageReportData>> GetPostGameCarnageReport(
        long activityId,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<int>> ReportOffensivePostGameCarnageReportPlayer(
        long activityId,
        Models.Destiny.Reporting.Requests.DestinyReportOffensePgcrRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Dictionary<string, Models.Destiny.HistoricalStats.Definitions.DestinyHistoricalStatsDefinition>>> GetHistoricalStatsDefinition(CancellationToken cancellationToken = default);

    Task<BungieResponse<Dictionary<string, Dictionary<string, Models.Destiny.HistoricalStats.DestinyLeaderboard>>>> GetClanLeaderboards(
        long groupId,
        int maxtop,
        string modes,
        string statid,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Destiny.HistoricalStats.DestinyClanAggregateStat[]>> GetClanAggregateStats(
        long groupId,
        string modes,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Dictionary<string, Dictionary<string, Models.Destiny.HistoricalStats.DestinyLeaderboard>>>> GetLeaderboards(
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        int maxtop,
        string modes,
        string statid,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Dictionary<string, Dictionary<string, Models.Destiny.HistoricalStats.DestinyLeaderboard>>>> GetLeaderboardsForCharacter(
        long characterId,
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        int maxtop,
        string modes,
        string statid,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Destiny.Definitions.DestinyEntitySearchResult>> SearchDestinyEntities(
        string searchTerm,
        string type,
        int page,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Dictionary<string, Models.Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod>>> GetHistoricalStats(
        long characterId,
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        DateTime dayend,
        DateTime daystart,
        Models.Destiny.HistoricalStats.Definitions.DestinyStatsGroupType[] groups,
        Models.Destiny.HistoricalStats.Definitions.DestinyActivityModeType[] modes,
        Models.Destiny.HistoricalStats.Definitions.PeriodType periodType,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Destiny.HistoricalStats.DestinyHistoricalStatsAccountResult>> GetHistoricalStatsForAccount(
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        Models.Destiny.HistoricalStats.Definitions.DestinyStatsGroupType[] groups,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Destiny.HistoricalStats.DestinyActivityHistoryResults>> GetActivityHistory(
        long characterId,
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        int count,
        Models.Destiny.HistoricalStats.Definitions.DestinyActivityModeType mode,
        int page,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Destiny.HistoricalStats.DestinyHistoricalWeaponStatsData>> GetUniqueWeaponHistory(
        long characterId,
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Destiny.HistoricalStats.DestinyAggregateActivityResults>> GetDestinyAggregateActivityStats(
        long characterId,
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Destiny.Milestones.DestinyMilestoneContent>> GetPublicMilestoneContent(
        uint milestoneHash,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Dictionary<uint, Models.Destiny.Milestones.DestinyPublicMilestone>>> GetPublicMilestones(CancellationToken cancellationToken = default);

    Task<BungieResponse<Models.Destiny.Advanced.AwaInitializeResponse>> AwaInitializeRequest(
        Models.Destiny.Advanced.AwaPermissionRequested requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<int>> AwaProvideAuthorizationResult(
        Models.Destiny.Advanced.AwaUserResponse requestBody,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Destiny.Advanced.AwaAuthorizationResult>> AwaGetActionToken(
        string correlationId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

}
