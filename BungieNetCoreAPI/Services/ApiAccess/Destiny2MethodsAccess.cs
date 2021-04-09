using NetBungieAPI.Destiny;
using NetBungieAPI.Destiny.Profile;
using NetBungieAPI.Destiny.Profile.Components.Contracts;
using NetBungieAPI.Destiny.Responses;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModes;
using NetBungieAPI.Models.Destiny.Definitions.HistoricalStats;
using NetBungieAPI.Models.Destiny.Milestones;
using NetBungieAPI.Models.Queries;
using NetBungieAPI.Models.User;
using NetBungieAPI.Responses;
using NetBungieAPI.Services;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetBungieAPI
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
        /// <returns></returns>
        public async Task<BungieResponse<T>> GetDestinyEntityDefinition<T>(DefinitionsEnum entityType, uint hash) where T : IDestinyDefinition
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<T>>($"/Destiny2/Manifest/{entityType}/{hash}");
        }
        /// <summary>
        /// Returns a list of Destiny memberships given a full Gamertag or PSN ID. Unless you pass returnOriginalProfile=true, this will return membership information for the users' Primary Cross Save Profile if they are engaged in cross save rather than any original Destiny profile that is now being overridden.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type, or All.</param>
        /// <param name="displayName">The full gamertag or PSN id of the player. Spaces and case are ignored.</param>
        /// <param name="returnOriginalProfile">If passed in and set to true, we will return the original Destiny Profile(s) linked to that gamertag, and not their currently active Destiny Profile.</param>
        /// <returns></returns>
        public async Task<BungieResponse<UserInfoCard[]>> SearchDestinyPlayer(BungieMembershipType membershipType, string displayName, bool returnOriginalProfile = false)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<UserInfoCard[]>>($"/Destiny2/SearchDestinyPlayer/{membershipType}/{displayName}/?returnOriginalProfile={returnOriginalProfile}");
        }
        /// <summary>
        /// Returns a summary information about all profiles linked to the requesting membership type/membership ID that have valid Destiny information.
        /// </summary>
        /// <param name="membershipType">The type for the membership whose linked Destiny accounts you want returned.</param>
        /// <param name="membershipId">The ID of the membership whose linked Destiny accounts you want returned. Make sure your membership ID matches its Membership Type: don't pass us a PSN membership ID and the XBox membership type, it's not going to work!</param>
        /// <param name="getAllMemberships">if set to 'true', all memberships regardless of whether they're obscured by overrides will be returned. Normal privacy restrictions on account linking will still apply no matter what.</param>
        /// <returns></returns>
        public async Task<BungieResponse<DestinyLinkedProfilesResponse>> GetLinkedProfiles(BungieMembershipType membershipType, long membershipId, bool getAllMemberships = false)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<DestinyLinkedProfilesResponse>>($"/Destiny2/{membershipType}/Profile/{membershipId}/LinkedProfiles/?getAllMemberships={getAllMemberships}");
        }
        /// <summary>
        /// Returns Destiny Profile information for the supplied membership.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="destinyMembershipId">Destiny membership ID.</param>
        /// <param name="componentTypes">List of components to return. You must request at least one component to receive results.</param>
        /// <returns></returns>
        public async Task<BungieResponse<DestinyComponentProfileResponse>> GetProfile(BungieMembershipType membershipType, long destinyMembershipId,
            DestinyComponentType[] componentTypes)
        {
            if (componentTypes == null || componentTypes.Length == 0)
                throw new Exception("Specify some components before making a profile call.");
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<DestinyComponentProfileResponse>>($"/Destiny2/{membershipType}/Profile/{destinyMembershipId}/?components={componentTypes.ComponentsToIntString()}");
        }
        /// <summary>
        /// Returns character information for the supplied character.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="destinyMembershipId">Destiny membership ID.</param>
        /// <param name="characterId">ID of the character.</param>
        /// <param name="componentTypes">List of components to return</param>
        /// <returns>Character information for the supplied character.</returns>
        public async Task<BungieResponse<DestinyComponentCharacterResponse>> GetCharacter(BungieMembershipType membershipType, long destinyMembershipId, long characterId, DestinyComponentType[] componentTypes)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<DestinyComponentCharacterResponse>>($"/Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/?components={componentTypes.ComponentsToIntString()}");
        }
        /// <summary>
        /// Returns information on the weekly clan rewards and if the clan has earned them or not. Note that this will always report rewards as not redeemed.
        /// </summary>
        /// <param name="groupId">A valid group id of clan.</param>
        /// <returns></returns>
        public async Task<BungieResponse<DestinyMilestone>> GetClanWeeklyRewardState(long groupId)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<DestinyMilestone>>($"/Destiny2/Clan/{groupId}/WeeklyRewardState/");
        }
        /// <summary>
        /// Retrieve the details of an instanced Destiny Item. An instanced Destiny item is one with an ItemInstanceId. Non-instanced items, such as materials, have no useful instance-specific details and thus are not queryable here.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="destinyMembershipId">The membership ID of the destiny profile.</param>
        /// <param name="itemInstanceId">The Instance ID of the destiny item.</param>
        /// <param name="componentTypes">List of components to return</param>
        /// <returns></returns>
        public async Task<BungieResponse<DestinyComponentItemResponse>> GetItem(BungieMembershipType membershipType, long destinyMembershipId, long itemInstanceId, DestinyComponentType[] componentTypes)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<DestinyComponentItemResponse>>($"/Destiny2/{membershipType}/Profile/{destinyMembershipId}/Item/{itemInstanceId}/?components={componentTypes.ComponentsToIntString()}");
        }
        /// <summary>
        /// Get currently available vendors from the list of vendors that can possibly have rotating inventory. Note that this does not include things like preview vendors and vendors-as-kiosks, neither of whom have rotating/dynamic inventories. Use their definitions as-is for those.
        /// </summary>
        /// <param name="membershipType"></param>
        /// <param name="destinyMembershipId"></param>
        /// <param name="characterId"></param>
        /// <param name="componentTypes"></param>
        /// <returns></returns>
        public async Task<BungieResponse<DestinyVendorsResponse>> GetVendors(BungieMembershipType membershipType, long destinyMembershipId, long characterId, DestinyComponentType[] componentTypes)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<DestinyVendorsResponse>>($"Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/Vendors/?components={componentTypes.ComponentsToIntString()}");
        }
        /// <summary>
        /// Get the details of a specific Vendor.
        /// </summary>
        /// <param name="membershipType"></param>
        /// <param name="destinyMembershipId"></param>
        /// <param name="characterId"></param>
        /// <param name="vendorHash"></param>
        /// <param name="componentTypes"></param>
        /// <returns></returns>
        public async Task<BungieResponse<DestinyVendorResponse>> GetVendor(BungieMembershipType membershipType, long destinyMembershipId, long characterId, uint vendorHash, DestinyComponentType[] componentTypes)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<DestinyVendorResponse>>($"Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/Vendors/{vendorHash}/?components={componentTypes.ComponentsToIntString()}");
        }
        /// <summary>
        /// Get items available from vendors where the vendors have items for sale that are common for everyone.
        /// </summary>
        /// <param name="componentTypes"></param>
        /// <returns></returns>
        public async Task<BungieResponse<DestinyPublicVendorsResponse>> GetPublicVendors(DestinyComponentType[] componentTypes)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<DestinyPublicVendorsResponse>>($"/Destiny2/Vendors/?components={componentTypes.ComponentsToIntString()}");
        }
        /// <summary>
        /// Given a Presentation Node that has Collectibles as direct descendants, this will return item details about those descendants in the context of the requesting character.
        /// </summary>
        /// <param name="membershipType"></param>
        /// <param name="destinyMembershipId"></param>
        /// <param name="characterId"></param>
        /// <param name="collectiblePresentationNodeHash"></param>
        /// <param name="componentTypes"></param>
        /// <returns></returns>
        public async Task<BungieResponse<DestinyCollectibleNodeDetailResponse>> GetCollectibleNodeDetails(BungieMembershipType membershipType, long destinyMembershipId,
            long characterId, uint collectiblePresentationNodeHash, DestinyComponentType[] componentTypes)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<DestinyCollectibleNodeDetailResponse>>($"/Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/Collectibles/{collectiblePresentationNodeHash}/?components={componentTypes.ComponentsToIntString()}");
        }
        /// <summary>
        /// Gets the available post game carnage report for the activity ID.
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        public async Task<BungieResponse<DestinyPostGameCarnageReportData>> GetPostGameCarnageReport(long activityId)
        {
            return await _httpClient.GetFromStatsPlatfromAndDeserialize<BungieResponse<DestinyPostGameCarnageReportData>>($"/Destiny2/Stats/PostGameCarnageReport/{activityId}/");
        }
        /// <summary>
        /// Gets historical stats definitions.
        /// </summary>
        /// <returns></returns>
        public async Task<BungieResponse<Dictionary<string, DestinyHistoricalStatsDefinition>>> GetHistoricalStatsDefinition()
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<Dictionary<string, DestinyHistoricalStatsDefinition>>>($"/Destiny2/Stats/Definition/");
        }
        /// <summary>
        /// Gets a page list of Destiny items.
        /// </summary>
        /// <param name="type">The type of entity for whom you would like results.</param>
        /// <param name="searchTerm">The string to use when searching for Destiny entities.</param>
        /// <param name="page">Page number to return</param>
        /// <returns></returns>
        public async Task<BungieResponse<DestinyEntitySearchResult>> SearchDestinyEntities(DefinitionsEnum type, string searchTerm, int page = 0)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<DestinyEntitySearchResult>>($"/Destiny2/Armory/Search/{type}/{searchTerm}/?page={page}");
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
        /// <returns></returns>
        public async Task<BungieResponse<Dictionary<string, DestinyHistoricalStatsByPeriod>>> GetHistoricalStats(BungieMembershipType membershipType, long destinyMembershipId, long characterId,
            DateTime? daystart = null, DateTime? dayend = null, DestinyStatsGroupType[] groups = null, DestinyActivityModeType[] modes = null, PeriodType periodType = PeriodType.None)
        {
            bool hasParams = false;
            if (daystart != null || dayend != null || groups != null || modes != null || periodType != PeriodType.None)
                hasParams = true;
            var query = $"/Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/";
            if (hasParams)
            {
                List<string> parameters = new List<string>();
                if (daystart.HasValue)
                    parameters.Add($"daystart={daystart.Value.ToString("yyyy-MM-dd")}");
                if (dayend.HasValue)
                    parameters.Add($"dayend={dayend.Value.ToString("yyyy-MM-dd")}");
                if (groups != null && groups.Length > 0)
                    parameters.Add($"groups={string.Join(',', groups.Select(x => (int)x))}");
                if (modes != null && modes.Length > 0)
                    parameters.Add($"modes={string.Join(',', modes.Select(x => (int)x))}");
                if (periodType != PeriodType.None)
                    parameters.Add($"periodType={(int)periodType}");
                query = $"{query}?{string.Join('&', parameters)}";
            }
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<Dictionary<string, DestinyHistoricalStatsByPeriod>>>(query);
        }
        /// <summary>
        /// Gets aggregate historical stats organized around each character for a given account.
        /// </summary>
        /// <param name="membershipType"></param>
        /// <param name="destinyMembershipId"></param>
        /// <param name="groups"></param>
        /// <returns></returns>
        public async Task<BungieResponse<DestinyHistoricalStatsAccountResult>> GetHistoricalStatsForAccount(BungieMembershipType membershipType, long destinyMembershipId, DestinyStatsGroupType[] groups = null)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<DestinyHistoricalStatsAccountResult>>($"/Destiny2/{membershipType}/Account/{destinyMembershipId}/Stats/{(groups != null && groups.Length > 0 ? $"?groups={string.Join(',', groups.Select(x => (int)x))}" : string.Empty)}");
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
        /// <returns></returns>
        public async Task<BungieResponse<DestinyActivityHistoryResults>> GetActivityHistory(BungieMembershipType membershipType, long destinyMembershipId, long characterId, int count = 25,
            DestinyActivityModeType mode = DestinyActivityModeType.None, int page = 0)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<DestinyActivityHistoryResults>>($"/Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/Activities/?count={count}&mode={mode}&page={page}");
        }
        /// <summary>
        /// Gets details about unique weapon usage, including all exotic weapons.
        /// </summary>
        /// <param name="membershipType"></param>
        /// <param name="destinyMembershipId"></param>
        /// <param name="characterId"></param>
        /// <returns></returns>
        public async Task<BungieResponse<DestinyHistoricalWeaponStatsData>> GetUniqueWeaponHistory(BungieMembershipType membershipType, long destinyMembershipId, long characterId)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<DestinyHistoricalWeaponStatsData>>($"/Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/UniqueWeapons/");
        }
        /// <summary>
        /// Gets all activities the character has participated in together with aggregate statistics for those activities.
        /// </summary>
        /// <param name="membershipType"></param>
        /// <param name="destinyMembershipId"></param>
        /// <param name="characterId"></param>
        /// <returns></returns>
        public async Task<BungieResponse<DestinyAggregateActivityResults>> GetDestinyAggregateActivityStats(BungieMembershipType membershipType, long destinyMembershipId, long characterId)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<DestinyAggregateActivityResults>>($"/Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/AggregateActivityStats/");
        }
        /// <summary>
        /// Gets public information about currently available Milestones.
        /// </summary>
        /// <returns></returns>
        public async Task<BungieResponse<Dictionary<uint, GetPublicMilestonesResponse>>> GetPublicMilestones()
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<Dictionary<uint, GetPublicMilestonesResponse>>>($"/Destiny2/Milestones");
        }
        /// <summary>
        /// Gets custom localized content for the milestone of the given hash, if it exists.
        /// </summary>
        /// <param name="milestoneHash">The identifier for the milestone to be returned.</param>
        /// <returns></returns>
        public async Task<BungieResponse<DestinyMilestoneContent>> GetPublicMilestoneContent(uint milestoneHash)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<DestinyMilestoneContent>>($"/Destiny2/Milestones/{milestoneHash}/Content/");
        }
    }
}

// return await GetFromPlatfromAndDeserialize<BungieResponse<>>();
