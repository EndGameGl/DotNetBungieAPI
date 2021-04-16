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
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Models.Destiny.HistoricalStats;

namespace NetBungieAPI.Services.ApiAccess
{
    public class Destiny2MethodsAccess : IDestiny2MethodsAccess
    {
        private IHttpClientInstance _httpClient;

        internal Destiny2MethodsAccess(IHttpClientInstance httpClient)
        {
            _httpClient = httpClient;
        }

        public async ValueTask<BungieResponse<DestinyManifest>> GetDestinyManifest(CancellationToken token = default)
        {
            return await _httpClient.GetFromBungieNetPlatform<DestinyManifest>("/Destiny2/Manifest", token);
        }

        /// <summary>
        /// Returns the  definition of an entity of the given Type and hash identifier.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="entityType">The type of entity for whom you would like results.</param>
        /// <param name="hash">The hash identifier for the specific Entity you want returned.</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async ValueTask<BungieResponse<T>> GetDestinyEntityDefinition<T>(DefinitionsEnum entityType, uint hash,
            CancellationToken token = default) where T : IDestinyDefinition
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/Manifest/")
                .AddUrlParam(entityType.ToString())
                .AddUrlParam(hash.ToString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<T>(url, token);
        }

        /// <summary>
        /// Returns a list of Destiny memberships given a full Gamertag or PSN ID. Unless you pass returnOriginalProfile=true, this will return membership information for the users' Primary Cross Save Profile if they are engaged in cross save rather than any original Destiny profile that is now being overridden.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type, or All.</param>
        /// <param name="displayName">The full gamertag or PSN id of the player. Spaces and case are ignored.</param>
        /// <param name="returnOriginalProfile">If passed in and set to true, we will return the original Destiny Profile(s) linked to that gamertag, and not their currently active Destiny Profile.</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async ValueTask<BungieResponse<UserInfoCard[]>> SearchDestinyPlayer(BungieMembershipType membershipType,
            string displayName, bool returnOriginalProfile = false, CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/SearchDestinyPlayer/")
                .AddUrlParam(((int) membershipType).ToString())
                .AddUrlParam(displayName)
                .AddQueryParam("returnOriginalProfile", returnOriginalProfile.ToString(), () => returnOriginalProfile)
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<UserInfoCard[]>(url, token);
        }

        /// <summary>
        /// Returns a summary information about all profiles linked to the requesting membership type/membership ID that have valid Destiny information.
        /// </summary>
        /// <param name="membershipType">The type for the membership whose linked Destiny accounts you want returned.</param>
        /// <param name="membershipId">The ID of the membership whose linked Destiny accounts you want returned. Make sure your membership ID matches its Membership Type: don't pass us a PSN membership ID and the XBox membership type, it's not going to work!</param>
        /// <param name="getAllMemberships">if set to 'true', all memberships regardless of whether they're obscured by overrides will be returned. Normal privacy restrictions on account linking will still apply no matter what.</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async ValueTask<BungieResponse<DestinyLinkedProfilesResponse>> GetLinkedProfiles(
            BungieMembershipType membershipType, long membershipId, bool getAllMemberships = false,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/")
                .AddUrlParam(((int) membershipType).ToString())
                .Append("Profile/")
                .AddUrlParam(membershipId.ToString())
                .Append("LinkedProfiles/")
                .AddQueryParam("getAllMemberships", getAllMemberships.ToString(), () => getAllMemberships)
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<DestinyLinkedProfilesResponse>(url, token);
        }

        /// <summary>
        /// Returns Destiny Profile information for the supplied membership.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="destinyMembershipId">Destiny membership ID.</param>
        /// <param name="componentTypes">List of components to return. You must request at least one component to receive results.</param>
        /// <param name="token"></param> 
        /// <returns></returns>
        public async ValueTask<BungieResponse<DestinyProfileResponse>> GetProfile(BungieMembershipType membershipType,
            long destinyMembershipId,
            DestinyComponentType[] componentTypes, CancellationToken token = default)
        {
            if (componentTypes == null || componentTypes.Length == 0)
                throw new ArgumentException("Specify some components before making a profile call.");

            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/")
                .AddUrlParam(((int) membershipType).ToString())
                .Append("Profile/")
                .AddUrlParam(destinyMembershipId.ToString())
                .AddQueryParam("components", componentTypes.ComponentsToIntString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<DestinyProfileResponse>(url, token);
        }

        /// <summary>
        /// Returns character information for the supplied character.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="destinyMembershipId">Destiny membership ID.</param>
        /// <param name="characterId">ID of the character.</param>
        /// <param name="componentTypes">List of components to return</param>
        /// <param name="token"></param>
        /// <returns>Character information for the supplied character.</returns>
        public async ValueTask<BungieResponse<DestinyCharacterResponse>> GetCharacter(
            BungieMembershipType membershipType, long destinyMembershipId, long characterId,
            DestinyComponentType[] componentTypes, CancellationToken token = default)
        {
            if (componentTypes == null || componentTypes.Length == 0)
                throw new ArgumentException("Specify some components before making a profile call.");

            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/")
                .AddUrlParam(((int) membershipType).ToString())
                .Append("Profile/")
                .AddUrlParam(destinyMembershipId.ToString())
                .Append("Character/")
                .AddUrlParam(characterId.ToString())
                .AddQueryParam("components", componentTypes.ComponentsToIntString())
                .Build();

            return await _httpClient.GetFromBungieNetPlatform<DestinyCharacterResponse>(url, token);
        }

        /// <summary>
        /// Returns information on the weekly clan rewards and if the clan has earned them or not. Note that this will always report rewards as not redeemed.
        /// </summary>
        /// <param name="groupId">A valid group id of clan.</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async ValueTask<BungieResponse<DestinyMilestone>> GetClanWeeklyRewardState(long groupId,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/Clan/")
                .AddUrlParam(groupId.ToString())
                .Append("WeeklyRewardState/")
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<DestinyMilestone>(url, token);
        }

        /// <summary>
        /// Retrieve the details of an instanced Destiny Item. An instanced Destiny item is one with an ItemInstanceId. Non-instanced items, such as materials, have no useful instance-specific details and thus are not queryable here.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="destinyMembershipId">The membership ID of the destiny profile.</param>
        /// <param name="itemInstanceId">The Instance ID of the destiny item.</param>
        /// <param name="componentTypes">List of components to return</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async ValueTask<BungieResponse<DestinyItemResponse>> GetItem(BungieMembershipType membershipType,
            long destinyMembershipId, long itemInstanceId, DestinyComponentType[] componentTypes,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/")
                .AddUrlParam(((int) membershipType).ToString())
                .Append("Profile/")
                .AddUrlParam(destinyMembershipId.ToString())
                .Append("Item/")
                .AddUrlParam(itemInstanceId.ToString())
                .AddQueryParam("components", componentTypes.ComponentsToIntString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<DestinyItemResponse>(url, token);
        }

        /// <summary>
        /// Get currently available vendors from the list of vendors that can possibly have rotating inventory. Note that this does not include things like preview vendors and vendors-as-kiosks, neither of whom have rotating/dynamic inventories. Use their definitions as-is for those.
        /// </summary>
        /// <param name="membershipType"></param>
        /// <param name="destinyMembershipId"></param>
        /// <param name="characterId"></param>
        /// <param name="componentTypes"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async ValueTask<BungieResponse<DestinyVendorsResponse>> GetVendors(BungieMembershipType membershipType,
            long destinyMembershipId, long characterId, DestinyComponentType[] componentTypes,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/")
                .AddUrlParam(((int) membershipType).ToString())
                .Append("Profile/")
                .AddUrlParam(destinyMembershipId.ToString())
                .Append("Character/")
                .AddUrlParam(characterId.ToString())
                .Append("Vendors/")
                .AddQueryParam("components", componentTypes.ComponentsToIntString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<DestinyVendorsResponse>(url, token);
        }

        /// <summary>
        /// Get the details of a specific Vendor.
        /// </summary>
        /// <param name="membershipType"></param>
        /// <param name="destinyMembershipId"></param>
        /// <param name="characterId"></param>
        /// <param name="vendorHash"></param>
        /// <param name="componentTypes"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async ValueTask<BungieResponse<DestinyVendorResponse>> GetVendor(BungieMembershipType membershipType,
            long destinyMembershipId, long characterId, uint vendorHash, DestinyComponentType[] componentTypes,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/")
                .AddUrlParam(((int) membershipType).ToString())
                .Append("Profile/")
                .AddUrlParam(destinyMembershipId.ToString())
                .Append("Character/")
                .AddUrlParam(characterId.ToString())
                .Append("Vendors/")
                .AddUrlParam(vendorHash.ToString())
                .AddQueryParam("components", componentTypes.ComponentsToIntString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<DestinyVendorResponse>(url, token);
        }

        /// <summary>
        /// Get items available from vendors where the vendors have items for sale that are common for everyone.
        /// </summary>
        /// <param name="componentTypes"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async ValueTask<BungieResponse<DestinyPublicVendorsResponse>> GetPublicVendors(
            DestinyComponentType[] componentTypes, CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/Vendors/")
                .AddQueryParam("components", componentTypes.ComponentsToIntString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<DestinyPublicVendorsResponse>(url, token);
        }

        /// <summary>
        /// Given a Presentation Node that has Collectibles as direct descendants, this will return item details about those descendants in the context of the requesting character.
        /// </summary>
        /// <param name="membershipType"></param>
        /// <param name="destinyMembershipId"></param>
        /// <param name="characterId"></param>
        /// <param name="collectiblePresentationNodeHash"></param>
        /// <param name="componentTypes"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async ValueTask<BungieResponse<DestinyCollectibleNodeDetailResponse>> GetCollectibleNodeDetails(
            BungieMembershipType membershipType, long destinyMembershipId,
            long characterId, uint collectiblePresentationNodeHash, DestinyComponentType[] componentTypes,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/")
                .AddUrlParam(((int) membershipType).ToString())
                .AddQueryParam("components", componentTypes.ComponentsToIntString())
                .Append("Profile/")
                .AddUrlParam(destinyMembershipId.ToString())
                .Append("Character/")
                .AddUrlParam(characterId.ToString())
                .Append("Collectibles/")
                .AddUrlParam(collectiblePresentationNodeHash.ToString())
                .AddQueryParam("components", componentTypes.ComponentsToIntString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<DestinyCollectibleNodeDetailResponse>(url, token);
        }

        /// <summary>
        /// Gets the available post game carnage report for the activity ID.
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async ValueTask<BungieResponse<DestinyPostGameCarnageReportData>> GetPostGameCarnageReport(
            long activityId, CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/Stats/PostGameCarnageReport/")
                .AddUrlParam(activityId.ToString())
                .Build();

            return await _httpClient.GetFromBungieNetStatsPlatform<DestinyPostGameCarnageReportData>(url, token);
        }

        /// <summary>
        /// Gets historical stats definitions.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async ValueTask<BungieResponse<ReadOnlyDictionary<string, DestinyHistoricalStatsDefinition>>>
            GetHistoricalStatsDefinition(CancellationToken token = default)
        {
            return await _httpClient
                .GetFromBungieNetPlatform<ReadOnlyDictionary<string, DestinyHistoricalStatsDefinition>>(
                    $"/Destiny2/Stats/Definition/", token);
        }

        /// <summary>
        /// Gets a page list of Destiny items.
        /// </summary>
        /// <param name="type">The type of entity for whom you would like results.</param>
        /// <param name="searchTerm">The string to use when searching for Destiny entities.</param>
        /// <param name="page">Page number to return</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async ValueTask<BungieResponse<DestinyEntitySearchResult>> SearchDestinyEntities(DefinitionsEnum type,
            string searchTerm, int page = 0, CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/Armory/Search/")
                .AddUrlParam(type.ToString())
                .AddUrlParam(searchTerm)
                .AddQueryParam("page", page.ToString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<DestinyEntitySearchResult>(url, token);
        }

        /// <summary>
        /// Gets historical stats for indicated character.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="destinyMembershipId">The Destiny membershipId of the user to retrieve.</param>
        /// <param name="characterId">The id of the character to retrieve. You can omit this character ID or set it to 0 to get aggregate stats across all characters.</param>
        /// <param name="daystart">First day to return when daily stats are requested.</param>
        /// <param name="dayend">Last day to return when daily stats are requested.</param>
        /// <param name="groups">Group of stats to include, otherwise only general stats are returned. Values: General, Weapons, Medals</param>
        /// <param name="modes">Game modes to return.</param>
        /// <param name="periodType">Indicates a specific period type to return. Optional. May be: Daily, AllTime, or Activity</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async ValueTask<BungieResponse<ReadOnlyDictionary<string, DestinyHistoricalStatsByPeriod>>>
            GetHistoricalStats(
                BungieMembershipType membershipType, long destinyMembershipId, long characterId,
                DateTime? daystart = null, DateTime? dayend = null, DestinyStatsGroupType[] groups = null,
                DestinyActivityModeType[] modes = null, PeriodType periodType = PeriodType.None,
                CancellationToken token = default)
        {
            var hasParams = daystart != null || dayend != null || groups != null || modes != null ||
                            periodType != PeriodType.None;
            var builder = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/")
                .AddUrlParam(((int) membershipType).ToString())
                .Append("Account/")
                .AddUrlParam(destinyMembershipId.ToString())
                .Append("Character/")
                .AddUrlParam(characterId.ToString())
                .Append("Stats/");
            if (!hasParams)
                return await _httpClient
                    .GetFromBungieNetPlatform<ReadOnlyDictionary<string, DestinyHistoricalStatsByPeriod>>(
                        builder.Build(), token);
            if (daystart.HasValue)
                builder.AddQueryParam("daystart", daystart.Value.ToString("yyyy-MM-dd"));
            if (dayend.HasValue)
                builder.AddQueryParam("dayend", dayend.Value.ToString("yyyy-MM-dd"));
            if (groups is {Length: > 0})
                builder.AddQueryParam("groups", string.Join(',', groups.Select(x => (int) x)));
            if (modes is {Length: > 0})
                builder.AddQueryParam("modes", string.Join(',', modes.Select(x => (int) x)));
            if (periodType != PeriodType.None)
                builder.AddQueryParam("periodType", ((int) periodType).ToString());

            return await _httpClient
                .GetFromBungieNetPlatform<ReadOnlyDictionary<string, DestinyHistoricalStatsByPeriod>>(
                    builder.Build(), token);
        }

        /// <summary>
        /// Gets aggregate historical stats organized around each character for a given account.
        /// </summary>
        /// <param name="membershipType"></param>
        /// <param name="destinyMembershipId"></param>
        /// <param name="groups"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async ValueTask<BungieResponse<DestinyHistoricalStatsAccountResult>> GetHistoricalStatsForAccount(
            BungieMembershipType membershipType, long destinyMembershipId, DestinyStatsGroupType[] groups = null,
            CancellationToken token = default)
        {
            var builder = StringBuilderPool
                .GetBuilder(token)
                .Append("Destiny2/")
                .AddUrlParam(((int) membershipType).ToString())
                .Append("Account/")
                .AddUrlParam(destinyMembershipId.ToString())
                .Append("Stats/");
            if (groups is {Length: > 0})
                builder.AddQueryParam("groups", string.Join(',', groups.Select(x => (int) x)));
            return await _httpClient.GetFromBungieNetPlatform<DestinyHistoricalStatsAccountResult>(builder.Build(),
                token);
        }

        /// <summary>
        /// Gets activity history stats for indicated character.
        /// </summary>
        /// <param name="membershipType"></param>
        /// <param name="destinyMembershipId"></param>
        /// <param name="characterId"></param>
        /// <param name="count"></param>
        /// <param name="mode"></param>
        /// <param name="page"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async ValueTask<BungieResponse<DestinyActivityHistoryResults>> GetActivityHistory(
            BungieMembershipType membershipType, long destinyMembershipId, long characterId, int count = 25,
            DestinyActivityModeType mode = DestinyActivityModeType.None, int page = 0,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("Destiny2/")
                .AddUrlParam(((int) membershipType).ToString())
                .Append("Account/")
                .AddUrlParam(destinyMembershipId.ToString())
                .Append("Character/")
                .AddUrlParam(characterId.ToString())
                .Append("Stats/Activities/")
                .AddQueryParam("count", count.ToString())
                .AddQueryParam("mode", ((int) mode).ToString())
                .AddQueryParam("page", page.ToString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<DestinyActivityHistoryResults>(url, token);
        }

        /// <summary>
        /// Gets details about unique weapon usage, including all exotic weapons.
        /// </summary>
        /// <param name="membershipType"></param>
        /// <param name="destinyMembershipId"></param>
        /// <param name="characterId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async ValueTask<BungieResponse<DestinyHistoricalWeaponStatsData>> GetUniqueWeaponHistory(
            BungieMembershipType membershipType, long destinyMembershipId, long characterId,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/")
                .AddUrlParam(((int) membershipType).ToString())
                .Append("Account/")
                .AddUrlParam(destinyMembershipId.ToString())
                .Append("Character/")
                .AddUrlParam(characterId.ToString())
                .Append("Stats/UniqueWeapons/")
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<DestinyHistoricalWeaponStatsData>(url, token);
        }

        /// <summary>
        /// Gets all activities the character has participated in together with aggregate statistics for those activities.
        /// </summary>
        /// <param name="membershipType"></param>
        /// <param name="destinyMembershipId"></param>
        /// <param name="characterId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async ValueTask<BungieResponse<DestinyAggregateActivityResults>> GetDestinyAggregateActivityStats(
            BungieMembershipType membershipType, long destinyMembershipId, long characterId,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/")
                .AddUrlParam(((int) membershipType).ToString())
                .Append("Account/")
                .AddUrlParam(destinyMembershipId.ToString())
                .Append("Character/")
                .AddUrlParam(characterId.ToString())
                .Append("Stats/AggregateActivityStats/")
                .Build();

            return await _httpClient.GetFromBungieNetPlatform<DestinyAggregateActivityResults>(url, token);
        }

        /// <summary>
        /// Gets public information about currently available Milestones.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async ValueTask<BungieResponse<Dictionary<uint, DestinyPublicMilestone>>> GetPublicMilestones(
            CancellationToken token = default)
        {
            return await _httpClient.GetFromBungieNetPlatform<Dictionary<uint, DestinyPublicMilestone>>(
                $"/Destiny2/Milestones", token);
        }

        /// <summary>
        /// Gets custom localized content for the milestone of the given hash, if it exists.
        /// </summary>
        /// <param name="milestoneHash">The identifier for the milestone to be returned.</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async ValueTask<BungieResponse<DestinyMilestoneContent>> GetPublicMilestoneContent(uint milestoneHash,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Destiny2/Milestones/")
                .AddUrlParam(milestoneHash.ToString())
                .Append("Content/")
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<DestinyMilestoneContent>(url, token);
        }
    }
}