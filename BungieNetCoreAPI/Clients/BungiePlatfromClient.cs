using BungieNetCoreAPI.Bungie;
using BungieNetCoreAPI.Bungie.Applications;
using BungieNetCoreAPI.Destiny;
using BungieNetCoreAPI.Destiny.Definitions;
using BungieNetCoreAPI.Destiny.Profile;
using BungieNetCoreAPI.Destiny.Profile.Components.Contracts;
using BungieNetCoreAPI.Destiny.Responses;
using BungieNetCoreAPI.Logging;
using BungieNetCoreAPI.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace BungieNetCoreAPI.Clients
{
    public class BungiePlatfromClient
    {
        private readonly IHttpClientInstance _httpClient;
        private readonly ILogger _logger;

        private readonly string _apiKey;

        private int? _oAuthClientID;
        private string _oAuthClientSecret;

        private string _authorizationValue
        {
            get
            {
                if (_oAuthClientID.HasValue && !string.IsNullOrEmpty(_oAuthClientSecret))
                {
                    return Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_oAuthClientID}:{_oAuthClientSecret}"));
                }
                else
                    throw new Exception();
            }
        }

        internal BungiePlatfromClient(string apiKey)
        {
            _apiKey = apiKey;
            _httpClient = StaticUnityContainer.GetService<IHttpClientInstance>();
            _logger = StaticUnityContainer.GetService<ILogger>();
            _httpClient.AddAcceptHeader("application/json");
            _httpClient.AddHeader("X-API-Key", apiKey);          
        }

        

        #region App methods
        public async Task<BungieApplication[]> GetBungieApplications()
        {
            return await GetData<BungieApplication[]>($"App/FirstParty/");
        }
        #endregion

        #region User methods
        public async Task<BungieNetUser> GetBungieNetUserById(long id)
        {
            return await GetData<BungieNetUser>($"User/GetBungieNetUserById/{id}");
        }
        public async Task<BungieNetUser[]> SearchUsers(string query)
        {
            if (!string.IsNullOrWhiteSpace(query))
                return await GetData<BungieNetUser[]>($"User/SearchUsers/?q={query}");
            else
                throw new Exception("Query must contain something.");
        }
        public async Task<BungieNetUserAccountCredentialType[]> GetCredentialTypesForTargetAccount(long id)
        {
            return await GetData<BungieNetUserAccountCredentialType[]>($"User/GetCredentialTypesForTargetAccount/{id}");
        }
        public async Task<BungieUserTheme[]> GetAvailableThemes()
        {
            return await GetData<BungieUserTheme[]>($"User/GetAvailableThemes");
        }
        public async Task<BungieNetUserWithMemberships> GetMembershipDataById(long id, BungieMembershipType membershipType)
        {
            return await GetData<BungieNetUserWithMemberships>($"User/GetMembershipsById/{id}/{membershipType}");
        }
        public async Task<BungieNetUserWithMemberships> GetMembershipDataForCurrentUser()
        {
            return await GetData<BungieNetUserWithMemberships>($"User/GetMembershipsForCurrentUser");
        }
        public async Task<DestinyHardLinkedUserMembership> GetMembershipFromHardLinkedCredential(long credential, BungieCredentialType credentialType = BungieCredentialType.SteamId)
        {
            return await GetData<DestinyHardLinkedUserMembership>($"User/GetMembershipFromHardLinkedCredential/{credentialType}/{credential}");
        }
        #endregion

        #region Destiny 2 methods
        /// <summary>
        /// Returns the current version of the manifest.
        /// </summary>
        /// <returns></returns>
        public async Task<DestinyManifest> GetDestinyManifest()
        {
            _logger.Log("Loading destiny manifest...", LogType.Info);
            var manifest = await GetData<DestinyManifest>("Destiny2/Manifest");
            _logger.Log($"Loaded destiny manifest: Version {manifest.Version}", LogType.Info);
            return manifest;
        }
        /// <summary>
        /// Returns the static definition of an entity of the given Type and hash identifier.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="entityType">The type of entity for whom you would like results.</param>
        /// <param name="hash">The hash identifier for the specific Entity you want returned.</param>
        /// <returns></returns>
        public async Task<T> GetDestinyEntityDefinition<T>(DefinitionsEnum entityType, uint hash) where T : IDestinyDefinition
        {
            return await GetData<T>($"Destiny2/Manifest/{entityType}/{hash}");
        }
        /// <summary>
        /// Returns a list of Destiny memberships given a full Gamertag or PSN ID. Unless you pass returnOriginalProfile=true, this will return membership information for the users' Primary Cross Save Profile if they are engaged in cross save rather than any original Destiny profile that is now being overridden.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type, or All.</param>
        /// <param name="displayName">The full gamertag or PSN id of the player. Spaces and case are ignored.</param>
        /// <param name="returnOriginalProfile">If passed in and set to true, we will return the original Destiny Profile(s) linked to that gamertag, and not their currently active Destiny Profile.</param>
        /// <returns></returns>
        public async Task<BungieNetUserInfo[]> SearchDestinyPlayer(BungieMembershipType membershipType, string displayName, bool returnOriginalProfile = false)
        {
            return await GetData<BungieNetUserInfo[]>($"Destiny2/SearchDestinyPlayer/{membershipType}/{displayName}/?returnOriginalProfile={returnOriginalProfile}");
        }
        /// <summary>
        /// Returns a summary information about all profiles linked to the requesting membership type/membership ID that have valid Destiny information.
        /// </summary>
        /// <param name="membershipType">The type for the membership whose linked Destiny accounts you want returned.</param>
        /// <param name="membershipId">The ID of the membership whose linked Destiny accounts you want returned. Make sure your membership ID matches its Membership Type: don't pass us a PSN membership ID and the XBox membership type, it's not going to work!</param>
        /// <param name="getAllMemberships">if set to 'true', all memberships regardless of whether they're obscured by overrides will be returned. Normal privacy restrictions on account linking will still apply no matter what.</param>
        /// <returns></returns>
        public async Task<BungieNetUserMembershipWithLinkedDestinyProfiles> GetLinkedProfiles(BungieMembershipType membershipType, long membershipId, bool getAllMemberships = false)
        {
            return await GetData<BungieNetUserMembershipWithLinkedDestinyProfiles>($"Destiny2/{membershipType}/Profile/{membershipId}/LinkedProfiles/?getAllMemberships={getAllMemberships}");
        }
        /// <summary>
        /// Returns Destiny Profile information for the supplied membership.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="destinyMembershipId">Destiny membership ID.</param>
        /// <param name="componentTypes">List of components to return. You must request at least one component to receive results.</param>
        /// <returns></returns>
        public async Task<DestinyComponentProfileResponse> GetProfile(BungieMembershipType membershipType, long destinyMembershipId, params DestinyComponentType[] componentTypes)
        {
            return await GetData<DestinyComponentProfileResponse>($"Destiny2/{membershipType}/Profile/{destinyMembershipId}/?components={componentTypes.ComponentsToIntString()}");
        }
        /// <summary>
        /// Returns character information for the supplied character.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="destinyMembershipId">Destiny membership ID.</param>
        /// <param name="characterId">ID of the character.</param>
        /// <param name="componentTypes">List of components to return</param>
        /// <returns>Character information for the supplied character.</returns>
        public async Task<DestinyComponentCharacterResponse> GetCharacter(BungieMembershipType membershipType, long destinyMembershipId, long characterId, params DestinyComponentType[] componentTypes)
        {
            return await GetData<DestinyComponentCharacterResponse>($"Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/?components={componentTypes.ComponentsToIntString()}");
        }
        /// <summary>
        /// Returns information on the weekly clan rewards and if the clan has earned them or not. Note that this will always report rewards as not redeemed.
        /// </summary>
        /// <param name="groupId">A valid group id of clan.</param>
        /// <returns></returns>
        public async Task<DestinyMilestone> GetClanWeeklyRewardState(long groupId)
        {
            return await GetData<DestinyMilestone>($"Destiny2/Clan/{groupId}/WeeklyRewardState/");
        }
        /// <summary>
        /// Retrieve the details of an instanced Destiny Item. An instanced Destiny item is one with an ItemInstanceId. Non-instanced items, such as materials, have no useful instance-specific details and thus are not queryable here.
        /// </summary>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="destinyMembershipId">The membership ID of the destiny profile.</param>
        /// <param name="itemInstanceId">The Instance ID of the destiny item.</param>
        /// <param name="componentTypes">List of components to return</param>
        /// <returns></returns>
        public async Task<DestinyComponentItemResponse> GetItem(BungieMembershipType membershipType, long destinyMembershipId, long itemInstanceId, params DestinyComponentType[] componentTypes)
        {
            return await GetData<DestinyComponentItemResponse>($"Destiny2/{membershipType}/Profile/{destinyMembershipId}/Item/{itemInstanceId}/?components={componentTypes.ComponentsToIntString()}");
        }
        /// <summary>
        /// Get currently available vendors from the list of vendors that can possibly have rotating inventory. Note that this does not include things like preview vendors and vendors-as-kiosks, neither of whom have rotating/dynamic inventories. Use their definitions as-is for those.
        /// </summary>
        /// <param name="membershipType"></param>
        /// <param name="destinyMembershipId"></param>
        /// <param name="characterId"></param>
        /// <param name="componentTypes"></param>
        /// <returns></returns>
        public async Task<DestinyVendorsResponse> GetVendors(BungieMembershipType membershipType, long destinyMembershipId, long characterId, params DestinyComponentType[] componentTypes)
        {
            return await GetData<DestinyVendorsResponse>($"Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/Vendors/?components={componentTypes.ComponentsToIntString()}");
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
        public async Task<DestinyVendorResponse> GetVendor(BungieMembershipType membershipType, long destinyMembershipId, long characterId, uint vendorHash, params DestinyComponentType[] componentTypes)
        {
            return await GetData<DestinyVendorResponse>($"Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/Vendors/{vendorHash}/?components={componentTypes.ComponentsToIntString()}");
        }
        /// <summary>
        /// Get items available from vendors where the vendors have items for sale that are common for everyone.
        /// </summary>
        /// <param name="componentTypes"></param>
        /// <returns></returns>
        public async Task<DestinyPublicVendorsResponse> GetPublicVendors(params DestinyComponentType[] componentTypes)
        {
            return await GetData<DestinyPublicVendorsResponse>($"Destiny2/Vendors/?components={componentTypes.ComponentsToIntString()}");
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
        public async Task<DestinyCollectibleNodeDetailResponse> GetCollectibleNodeDetails(BungieMembershipType membershipType, long destinyMembershipId, 
            long characterId, uint collectiblePresentationNodeHash, params DestinyComponentType[] componentTypes)
        {
            return await GetData<DestinyCollectibleNodeDetailResponse>($"Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/Collectibles/{collectiblePresentationNodeHash}/?components={componentTypes.ComponentsToIntString()}");
        }



        /// <summary>
        /// Gets public information about currently available Milestones.
        /// </summary>
        /// <returns></returns>
        public async Task<Dictionary<uint, GetPublicMilestonesResponse>> GetPublicMilestones()
        {
            return await GetData<Dictionary<uint, GetPublicMilestonesResponse>>($"Destiny2/Milestones");
        }
        /// <summary>
        /// Gets custom localized content for the milestone of the given hash, if it exists.
        /// </summary>
        /// <param name="milestoneHash">The identifier for the milestone to be returned.</param>
        /// <returns></returns>
        public async Task<DestinyMilestoneContent> GetPublicMilestoneContent(uint milestoneHash)
        {
            return await GetData<DestinyMilestoneContent>($"/Destiny2/Milestones/{milestoneHash}/Content/");
        }

        #endregion

        #region Misc methods
        /// <summary>
        /// List of available localization cultures
        /// </summary>
        /// <returns></returns>
        public async Task<Dictionary<string, string>> GetAvailableLocales()
        {
            return await GetData<Dictionary<string, string>>("GetAvailableLocales");
        }
        /// <summary>
        /// Get the common settings used by the Bungie.Net environment.
        /// </summary>
        /// <returns></returns>
        public async Task<BungieNetSettings> GetCommonSettings()
        {
            return await GetData<BungieNetSettings>("Settings");
        }
        /// <summary>
        /// Get the user-specific system overrides that should be respected alongside common systems.
        /// </summary>
        /// <returns></returns>
        public async Task<Dictionary<string, BungieSystemSetting>> GetUserSystemOverrides()
        {
            return await GetData<Dictionary<string, BungieSystemSetting>>("UserSystemOverrides");
        }
        /// <summary>
        /// Gets any active global alert for display in the forum banners, help pages, etc. Usually used for DOC alerts.
        /// </summary>
        /// <returns></returns>
        public async Task<GlobalAlert[]> GetGlobalAlerts()
        {
            return await GetData<GlobalAlert[]>("GlobalAlerts");
        }
        #endregion

        private async Task<T> GetData<T>(string query)
        {
            _logger.Log($"Getting data from: {query}", LogType.Debug);
            var response = await _httpClient.Get(BungieClient.BungiePlatformUri + query);
            //if (response.IsSuccessStatusCode)
            //{
            //var stringResponse = await response.Content.ReadAsStringAsync();
            var bungieResponse = JsonConvert.DeserializeObject<BungieResponse<T>>(await response.Content.ReadAsStringAsync());
            if (bungieResponse.ErrorCode == PlatformErrorCodes.Success && bungieResponse.Response != null)
            {
                return bungieResponse.Response;
            }
            else
                return default;
                //throw new Exception(bungieResponse.ErrorStatus);
            //}
            //else
            //    throw new Exception(response.ReasonPhrase);
        }
    }
}
