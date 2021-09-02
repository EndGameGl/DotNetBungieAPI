using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;
using NetBungieAPI.Models;
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

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    /// <summary>
    /// Access to https://bungie.net/Platform/Destiny2 endpoint
    /// </summary>
    public interface IDestiny2MethodsAccess
    {
        /// <summary>
        ///     Returns the current version of the manifest as a json object.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyManifest>> GetDestinyManifest(
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Returns the static definition of an entity of the given Type and hash identifier. Examine the API Documentation for
        ///     the Type Names of entities that have their own definitions. Note that the return type will always *inherit from*
        ///     DestinyDefinition, but the specific type returned will be the requested entity type if it can be found. Please
        ///     don't use this as a chatty alternative to the Manifest database if you require large sets of data, but for simple
        ///     and one-off accesses this should be handy.
        /// </summary>
        /// <param name="entityType">
        ///     The type of entity for whom you would like results. These correspond to the entity's
        ///     definition contract name. For instance, if you are looking for items, this property should be
        ///     'DestinyInventoryItemDefinition'. PREVIEW: This endpoint is still in beta, and may experience rough edges. The
        ///     schema is tentatively in final form, but there may be bugs that prevent desirable operation.
        /// </param>
        /// <param name="hash">The hash identifier for the specific Entity you want returned.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <typeparam name="T"><see cref="IDestinyDefinition" /> entity</typeparam>
        /// <returns></returns>
        ValueTask<BungieResponse<T>> GetDestinyEntityDefinition<T>(
            DefinitionsEnum entityType,
            uint hash,
            CancellationToken cancellationToken = default) where T : IDestinyDefinition;

        /// <summary>
        ///     Returns a list of Destiny memberships given a global Bungie Display Name. This method will hide overridden memberships due to cross save.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type, or All. Indicates which memberships to return. You probably want this set to All.</param>
        /// <param name="displayName">The full bungie global display name to look up, include the # and the code at the end. This is an exact match lookup.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<UserInfoCard[]>> SearchDestinyPlayer(
            BungieMembershipType membershipType,
            string displayName,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Returns a summary information about all profiles linked to the requesting membership type/membership ID that have
        ///     valid Destiny information. The passed-in Membership Type/Membership ID may be a Bungie.Net membership or a Destiny
        ///     membership. It only returns the minimal amount of data to begin making more substantive requests, but will
        ///     hopefully serve as a useful alternative to UserServices for people who just care about Destiny data. Note that it
        ///     will only return linked accounts whose linkages you are allowed to view.
        /// </summary>
        /// <param name="membershipType">The type for the membership whose linked Destiny accounts you want returned.</param>
        /// <param name="membershipId">
        ///     The ID of the membership whose linked Destiny accounts you want returned. Make sure your
        ///     membership ID matches its Membership Type: don't pass us a PSN membership ID and the XBox membership type, it's not
        ///     going to work!
        /// </param>
        /// <param name="getAllMemberships">
        ///     if set to 'true', all memberships regardless of whether they're obscured by overrides
        ///     will be returned. Normal privacy restrictions on account linking will still apply no matter what.
        /// </param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyLinkedProfilesResponse>> GetLinkedProfiles(
            BungieMembershipType membershipType,
            long membershipId,
            bool getAllMemberships = false,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Returns Destiny Profile information for the supplied membership.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="destinyMembershipId">Destiny membership ID.</param>
        /// <param name="componentTypes">
        ///     List of components to return. See the DestinyComponentType enum for valid components to
        ///     request. You must request at least one component to receive results.
        /// </param>
        /// <param name="authorizationToken"></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyProfileResponse>> GetProfile(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            DestinyComponentType[] componentTypes,
            AuthorizationTokenData authorizationToken = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Returns character information for the supplied character.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="destinyMembershipId">Destiny membership ID.</param>
        /// <param name="characterId">ID of the character.</param>
        /// <param name="componentTypes">
        ///     List of components to return. See the DestinyComponentType enum for valid components to
        ///     request. You must request at least one component to receive results.
        /// </param>
        /// <param name="authorizationToken"></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyCharacterResponse>> GetCharacter(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long characterId,
            DestinyComponentType[] componentTypes,
            AuthorizationTokenData authorizationToken = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Returns information on the weekly clan rewards and if the clan has earned them or not. Note that this will always
        ///     report rewards as not redeemed.
        /// </summary>
        /// <param name="groupId">A valid group id of clan.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyMilestone>> GetClanWeeklyRewardState(
            long groupId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the dictionary of values for the Clan Banner
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<ClanBannerSource>> GetClanBannerSource(
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Retrieve the details of an instanced Destiny Item. An instanced Destiny item is one with an ItemInstanceId.
        ///     Non-instanced items, such as materials, have no useful instance-specific details and thus are not queryable here.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="destinyMembershipId">The membership ID of the destiny profile.</param>
        /// <param name="itemInstanceId">The Instance ID of the destiny item.</param>
        /// <param name="componentTypes">
        ///     List of components to return. See the DestinyComponentType enum for valid components to
        ///     request. You must request at least one component to receive results.
        /// </param>
        /// <param name="authorizationToken"></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyItemResponse>> GetItem(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long itemInstanceId,
            DestinyComponentType[] componentTypes,
            AuthorizationTokenData authorizationToken = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Get currently available vendors from the list of vendors that can possibly have rotating inventory. Note that this
        ///     does not include things like preview vendors and vendors-as-kiosks, neither of whom have rotating/dynamic
        ///     inventories. Use their definitions as-is for those.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="destinyMembershipId">The Destiny Character ID of the character for whom we're getting vendor info.</param>
        /// <param name="characterId">Destiny membership ID of another user. You may be denied.</param>
        /// <param name="componentTypes">
        ///     List of components to return. See the DestinyComponentType enum for valid components to
        ///     request. You must request at least one component to receive results.
        /// </param>
        /// <param name="authorizationToken"></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyVendorsResponse>> GetVendors(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long characterId,
            DestinyComponentType[] componentTypes,
            AuthorizationTokenData authorizationToken = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Get the details of a specific Vendor.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="destinyMembershipId">Destiny membership ID of another user. You may be denied.</param>
        /// <param name="characterId">The Destiny Character ID of the character for whom we're getting vendor info.</param>
        /// <param name="vendorHash">The Hash identifier of the Vendor to be returned.</param>
        /// <param name="componentTypes">
        ///     List of components to return. See the DestinyComponentType enum for valid components to
        ///     request. You must request at least one component to receive results.
        /// </param>
        /// <param name="authorizationToken"></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyVendorResponse>> GetVendor(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long characterId,
            uint vendorHash,
            DestinyComponentType[] componentTypes,
            AuthorizationTokenData authorizationToken = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Get items available from vendors where the vendors have items for sale that are common for everyone.
        /// </summary>
        /// <param name="componentTypes">
        ///     List of components to return. See the DestinyComponentType enum for valid components to
        ///     request. You must request at least one component to receive results.
        /// </param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyPublicVendorsResponse>> GetPublicVendors(
            DestinyComponentType[] componentTypes,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Given a Presentation Node that has Collectibles as direct descendants, this will return item details about those
        ///     descendants in the context of the requesting character.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="destinyMembershipId">Destiny membership ID of another user. You may be denied.</param>
        /// <param name="characterId">The Destiny Character ID of the character for whom we're getting collectible detail info.</param>
        /// <param name="collectiblePresentationNodeHash">
        ///     The hash identifier of the Presentation Node for whom we should return
        ///     collectible details. Details will only be returned for collectibles that are direct descendants of this node.
        /// </param>
        /// <param name="componentTypes">
        ///     List of components to return. See the DestinyComponentType enum for valid components to
        ///     request. You must request at least one component to receive results.
        /// </param>
        /// <param name="authorizationToken"></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyCollectibleNodeDetailResponse>> GetCollectibleNodeDetails(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long characterId,
            uint collectiblePresentationNodeHash,
            DestinyComponentType[] componentTypes,
            AuthorizationTokenData authorizationToken = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Transfer an item to/from your vault.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <param name="authorizationToken"></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<int>> TransferItem(
            DestinyItemTransferRequest request,
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Extract an item from the Postmaster, with whatever implications that may entail.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <param name="authorizationToken"></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<int>> PullFromPostmaster(
            DestinyPostmasterTransferRequest request,
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Equip an item.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <param name="authorizationToken"></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<int>> EquipItem(
            DestinyItemActionRequest request,
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Equip a list of items by itemInstanceIds.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <param name="authorizationToken"></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyEquipItemResults>> EquipItems(
            DestinyItemSetActionRequest request,
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Set the Lock State for an instanced item.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <param name="authorizationToken"></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<int>> SetItemLockState(
            DestinyItemStateRequest request,
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Set the Tracking State for an instanced item, if that item is a Quest or Bounty.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <param name="authorizationToken"></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<int>> SetQuestTrackedState(
            DestinyItemStateRequest request,
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Insert a plug into a socketed item.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <param name="authorizationToken"></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyItemChangeResponse>> InsertSocketPlug(
            DestinyInsertPlugsActionRequest request,
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Gets the available post game carnage report for the activity ID.
        /// </summary>
        /// <param name="activityId">The ID of the activity whose PGCR is requested.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyPostGameCarnageReportData>> GetPostGameCarnageReport(
            long activityId,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Report a player that you met in an activity that was engaging in ToS-violating activities. Both you and the
        ///     offending player must have played in the activityId passed in. Please use this judiciously and only when you have
        ///     strong suspicions of violation, pretty please.
        /// </summary>
        /// <param name="activityId">The ID of the activity where you ran into the brigand that you're reporting.</param>
        /// <param name="request">Request body</param>
        /// <param name="authorizationToken"></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<int>> ReportOffensivePostGameCarnageReportPlayer(
            long activityId,
            DestinyReportOffensePgcrRequest request,
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Gets historical stats definitions.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<ReadOnlyDictionary<string, DestinyHistoricalStatsDefinition>>>
            GetHistoricalStatsDefinition(
                CancellationToken cancellationToken = default);

        /// <summary>
        ///     Gets leaderboards with the signed in user's friends and the supplied destinyMembershipId as the focus.
        /// </summary>
        /// <param name="groupId">Group ID of the clan whose leaderboards you wish to fetch.</param>
        /// <param name="maxtop">Maximum number of top players to return. Use a large number to get entire leaderboard.</param>
        /// <param name="modes">List of game modes for which to get leaderboards.</param>
        /// <param name="statid">ID of stat to return rather than returning all Leaderboard stats.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<BungieResponse<
                ReadOnlyDictionary<string, ReadOnlyDictionary<string, DestinyClanLeaderboardsResponse>>>>
            GetClanLeaderboards(
                long groupId,
                int maxtop,
                DestinyActivityModeType[] modes,
                string statid = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        ///     Gets aggregated stats for a clan using the same categories as the clan leaderboards.
        /// </summary>
        /// <param name="groupId">Group ID of the clan whose leaderboards you wish to fetch.</param>
        /// <param name="modes">List of game modes for which to get leaderboards.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyClanAggregateStat[]>> GetClanAggregateStats(
            long groupId,
            DestinyActivityModeType[] modes,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Gets leaderboards with the signed in user's friends and the supplied destinyMembershipId as the focus.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="destinyMembershipId">The Destiny membershipId of the user to retrieve.</param>
        /// <param name="maxtop">Maximum number of top players to return. Use a large number to get entire leaderboard.</param>
        /// <param name="modes">List of game modes for which to get leaderboards.</param>
        /// <param name="statid">ID of stat to return rather than returning all Leaderboard stats.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<Dictionary<string, object>>> GetLeaderboards(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            int maxtop,
            DestinyActivityModeType[] modes,
            string statid = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Gets a page list of Destiny items.
        /// </summary>
        /// <param name="type">The type of entity for whom you would like results.</param>
        /// <param name="searchTerm">The string to use when searching for Destiny entities.</param>
        /// <param name="page">Page number to return, starting with 0.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyEntitySearchResult>> SearchDestinyEntities(
            DefinitionsEnum type,
            string searchTerm,
            int page = 0,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Gets historical stats for indicated character.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="destinyMembershipId">The Destiny membershipId of the user to retrieve</param>
        /// <param name="characterId">
        ///     The id of the character to retrieve. You can omit this character ID or set it to 0 to get
        ///     aggregate stats across all characters.
        /// </param>
        /// <param name="daystart">
        ///     First day to return when daily stats are requested. Currently, we cannot allow more than 31 days
        ///     of daily data to be requested in a single request.
        /// </param>
        /// <param name="dayend">
        ///     Last day to return when daily stats are requested. Currently, we cannot allow more than 31 days of
        ///     daily data to be requested in a single request.
        /// </param>
        /// <param name="groups">
        ///     Group of stats to include, otherwise only general stats are returned. Values: General, Weapons,
        ///     Medals
        /// </param>
        /// <param name="modes">Game modes to return.</param>
        /// <param name="periodType">Indicates a specific period type to return. Optional. May be: Daily, AllTime, or Activity</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<ReadOnlyDictionary<string, DestinyHistoricalStatsByPeriod>>> GetHistoricalStats(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long characterId,
            DateTime? daystart = null,
            DateTime? dayend = null,
            DestinyStatsGroupType[] groups = null,
            DestinyActivityModeType[] modes = null,
            PeriodType periodType = PeriodType.None,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Gets aggregate historical stats organized around each character for a given account.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="destinyMembershipId">The Destiny membershipId of the user to retrieve.</param>
        /// <param name="groups">
        ///     Group of stats to include, otherwise only general stats are returned. Values: General, Weapons,
        ///     Medals
        /// </param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyHistoricalStatsAccountResult>> GetHistoricalStatsForAccount(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            DestinyStatsGroupType[] groups = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Gets activity history stats for indicated character.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="destinyMembershipId">The Destiny membershipId of the user to retrieve.</param>
        /// <param name="characterId">The id of the character to retrieve.</param>
        /// <param name="count">Number of rows to return</param>
        /// <param name="mode">A filter for the activity mode to be returned. None returns all activities</param>
        /// <param name="page">Page number to return, starting with 0.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyActivityHistoryResults>> GetActivityHistory(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long characterId,
            int count = 25,
            DestinyActivityModeType mode = DestinyActivityModeType.None,
            int page = 0,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Gets details about unique weapon usage, including all exotic weapons.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="destinyMembershipId">The Destiny membershipId of the user to retrieve.</param>
        /// <param name="characterId">The id of the character to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyHistoricalWeaponStatsData>> GetUniqueWeaponHistory(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long characterId,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Gets all activities the character has participated in together with aggregate statistics for those activities.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="destinyMembershipId">The Destiny membershipId of the user to retrieve.</param>
        /// <param name="characterId">The specific character whose activities should be returned.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyAggregateActivityResults>> GetDestinyAggregateActivityStats(
            BungieMembershipType membershipType,
            long destinyMembershipId,
            long characterId,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Gets public information about currently available Milestones.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<Dictionary<uint, DestinyPublicMilestone>>> GetPublicMilestones(
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Gets custom localized content for the milestone of the given hash, if it exists.
        /// </summary>
        /// <param name="milestoneHash">The identifier for the milestone to be returned.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyMilestoneContent>> GetPublicMilestoneContent(
            uint milestoneHash,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Initialize a request to perform an advanced write action.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <param name="authorizationToken"></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<AwaInitializeResponse>> AwaInitializeRequest(
            AwaPermissionRequested request,
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Provide the result of the user interaction. Called by the Bungie Destiny App to approve or reject a request.
        /// </summary>
        /// <param name="request">Request body.</param>
        /// <param name="authorizationToken"></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<int>> AwaProvideAuthorizationResult(
            AwaUserResponse request,
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Returns the action token if user approves the request.
        /// </summary>
        /// <param name="correlationId">The identifier for the advanced write action request.</param>
        /// <param name="authorizationToken"></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<AwaAuthorizationResult>> AwaGetActionToken(
            string correlationId,
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default);
    }
}