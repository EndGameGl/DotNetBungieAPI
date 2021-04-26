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
using NetBungieAPI.Models.Requests;
using NetBungieAPI.Models.Responses;

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

        /// <summary>
        /// Returns a summary information about all profiles linked to the requesting membership type/membership ID that have valid Destiny information. The passed-in Membership Type/Membership ID may be a Bungie.Net membership or a Destiny membership. It only returns the minimal amount of data to begin making more substantive requests, but will hopefully serve as a useful alternative to UserServices for people who just care about Destiny data. Note that it will only return linked accounts whose linkages you are allowed to view.
        /// </summary>
        /// <param name="membershipType">The type for the membership whose linked Destiny accounts you want returned.</param>
        /// <param name="membershipId">The ID of the membership whose linked Destiny accounts you want returned. Make sure your membership ID matches its Membership Type: don't pass us a PSN membership ID and the XBox membership type, it's not going to work!</param>
        /// <param name="getAllMemberships">if set to 'true', all memberships regardless of whether they're obscured by overrides will be returned. Normal privacy restrictions on account linking will still apply no matter what.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyLinkedProfilesResponse>> GetLinkedProfiles(BungieMembershipType membershipType,
            long membershipId, bool getAllMemberships = false, CancellationToken token = default);

        /// <summary>
        /// Returns Destiny Profile information for the supplied membership.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="destinyMembershipId">Destiny membership ID.</param>
        /// <param name="componentTypes">List of components to return. See the DestinyComponentType enum for valid components to request. You must request at least one component to receive results.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyProfileResponse>> GetProfile(BungieMembershipType membershipType,
            long destinyMembershipId, DestinyComponentType[] componentTypes, CancellationToken token = default);

        /// <summary>
        /// Returns character information for the supplied character.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="destinyMembershipId">Destiny membership ID.</param>
        /// <param name="characterId">ID of the character.</param>
        /// <param name="componentTypes">List of components to return. See the DestinyComponentType enum for valid components to request. You must request at least one component to receive results.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyCharacterResponse>> GetCharacter(BungieMembershipType membershipType,
            long destinyMembershipId, long characterId, DestinyComponentType[] componentTypes,
            CancellationToken token = default);

        /// <summary>
        /// Returns information on the weekly clan rewards and if the clan has earned them or not. Note that this will always report rewards as not redeemed.
        /// </summary>
        /// <param name="groupId">A valid group id of clan.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyMilestone>> GetClanWeeklyRewardState(long groupId,
            CancellationToken token = default);

        /// <summary>
        /// Retrieve the details of an instanced Destiny Item. An instanced Destiny item is one with an ItemInstanceId. Non-instanced items, such as materials, have no useful instance-specific details and thus are not queryable here.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="destinyMembershipId">The membership ID of the destiny profile.</param>
        /// <param name="itemInstanceId">The Instance ID of the destiny item.</param>
        /// <param name="componentTypes">List of components to return. See the DestinyComponentType enum for valid components to request. You must request at least one component to receive results.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyItemResponse>> GetItem(BungieMembershipType membershipType,
            long destinyMembershipId, long itemInstanceId, DestinyComponentType[] componentTypes,
            CancellationToken token = default);

        /// <summary>
        /// Get currently available vendors from the list of vendors that can possibly have rotating inventory. Note that this does not include things like preview vendors and vendors-as-kiosks, neither of whom have rotating/dynamic inventories. Use their definitions as-is for those.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="destinyMembershipId">The Destiny Character ID of the character for whom we're getting vendor info.</param>
        /// <param name="characterId">Destiny membership ID of another user. You may be denied.</param>
        /// <param name="componentTypes">List of components to return. See the DestinyComponentType enum for valid components to request. You must request at least one component to receive results.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyVendorsResponse>> GetVendors(BungieMembershipType membershipType,
            long destinyMembershipId, long characterId, DestinyComponentType[] componentTypes,
            CancellationToken token = default);

        /// <summary>
        /// Get the details of a specific Vendor.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="destinyMembershipId">Destiny membership ID of another user. You may be denied.</param>
        /// <param name="characterId">The Destiny Character ID of the character for whom we're getting vendor info.</param>
        /// <param name="vendorHash">The Hash identifier of the Vendor to be returned.</param>
        /// <param name="componentTypes">List of components to return. See the DestinyComponentType enum for valid components to request. You must request at least one component to receive results.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyVendorResponse>> GetVendor(BungieMembershipType membershipType,
            long destinyMembershipId, long characterId, uint vendorHash, DestinyComponentType[] componentTypes,
            CancellationToken token = default);

        /// <summary>
        /// Get items available from vendors where the vendors have items for sale that are common for everyone.
        /// </summary>
        /// <param name="componentTypes">List of components to return. See the DestinyComponentType enum for valid components to request. You must request at least one component to receive results.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyPublicVendorsResponse>> GetPublicVendors(DestinyComponentType[] componentTypes,
            CancellationToken token = default);

        /// <summary>
        /// Given a Presentation Node that has Collectibles as direct descendants, this will return item details about those descendants in the context of the requesting character.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="destinyMembershipId">Destiny membership ID of another user. You may be denied.</param>
        /// <param name="characterId">The Destiny Character ID of the character for whom we're getting collectible detail info.</param>
        /// <param name="collectiblePresentationNodeHash">The hash identifier of the Presentation Node for whom we should return collectible details. Details will only be returned for collectibles that are direct descendants of this node.</param>
        /// <param name="componentTypes">List of components to return. See the DestinyComponentType enum for valid components to request. You must request at least one component to receive results.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyCollectibleNodeDetailResponse>> GetCollectibleNodeDetails(
            BungieMembershipType membershipType, long destinyMembershipId, long characterId,
            uint collectiblePresentationNodeHash, DestinyComponentType[] componentTypes,
            CancellationToken token = default);

        /// <summary>
        /// Transfer an item to/from your vault.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<int>> TransferItem(DestinyItemTransferRequest request,
            CancellationToken token = default);

        /// <summary>
        /// Extract an item from the Postmaster, with whatever implications that may entail.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<int>> PullFromPostmaster(DestinyPostmasterTransferRequest request,
            CancellationToken token = default);

        /// <summary>
        /// Equip an item.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<int>> EquipItem(DestinyItemActionRequest request,
            CancellationToken token = default);

        /// <summary>
        /// Equip a list of items by itemInstanceIds. 
        /// </summary>
        /// <param name="request">Request body</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyEquipItemResults>> EquipItems(DestinyItemSetActionRequest request,
            CancellationToken token = default);

        /// <summary>
        /// Set the Lock State for an instanced item.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<int>> SetItemLockState(DestinyItemStateRequest request,
            CancellationToken token = default);

        /// <summary>
        /// Set the Tracking State for an instanced item, if that item is a Quest or Bounty.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<int>> SetQuestTrackedState(DestinyItemStateRequest request,
            CancellationToken token = default);

        /// <summary>
        /// Insert a plug into a socketed item.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyItemChangeResponse>> InsertSocketPlug(
            DestinyInsertPlugsActionRequest request, CancellationToken token = default);

        /// <summary>
        /// Gets the available post game carnage report for the activity ID.
        /// </summary>
        /// <param name="activityId">The ID of the activity whose PGCR is requested.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<DestinyPostGameCarnageReportData>> GetPostGameCarnageReport(long activityId,
            CancellationToken token = default);

        /// <summary>
        /// Report a player that you met in an activity that was engaging in ToS-violating activities. Both you and the offending player must have played in the activityId passed in. Please use this judiciously and only when you have strong suspicions of violation, pretty please.
        /// </summary>
        /// <param name="activityId">The ID of the activity where you ran into the brigand that you're reporting.</param>
        /// <param name="request">Request body</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<int>> ReportOffensivePostGameCarnageReportPlayer(long activityId,
            DestinyReportOffensePgcrRequest request, CancellationToken token = default);
        
        /// <summary>
        /// Gets historical stats definitions.
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<ReadOnlyDictionary<string, DestinyHistoricalStatsDefinition>>>
            GetHistoricalStatsDefinition(CancellationToken token = default);

        /// <summary>
        /// Gets leaderboards with the signed in user's friends and the supplied destinyMembershipId as the focus.
        /// </summary>
        /// <param name="groupId">Group ID of the clan whose leaderboards you wish to fetch.</param>
        /// <param name="maxtop">Maximum number of top players to return. Use a large number to get entire leaderboard.</param>
        /// <param name="modes">List of game modes for which to get leaderboards.</param>
        /// <param name="statid">ID of stat to return rather than returning all Leaderboard stats.</param>
        /// <param name="token"></param>
        /// <returns></returns>
        ValueTask<BungieResponse<
                ReadOnlyDictionary<string, ReadOnlyDictionary<string, DestinyClanLeaderboardsResponse>>>>
            GetClanLeaderboards(long groupId, int maxtop, DestinyActivityModeType[] modes, string statid = null,
                CancellationToken token = default);
        
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