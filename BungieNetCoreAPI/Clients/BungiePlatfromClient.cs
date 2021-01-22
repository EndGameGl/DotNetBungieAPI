using BungieNetCoreAPI.Bungie;
using BungieNetCoreAPI.Bungie.Applications;
using BungieNetCoreAPI.Destiny;
using BungieNetCoreAPI.Destiny.Definitions;
using BungieNetCoreAPI.Destiny.Profile;
using BungieNetCoreAPI.Destiny.Responses;
using BungieNetCoreAPI.Logging;
using BungieNetCoreAPI.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        private string _apiKey;

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
            set { }
        }

        internal BungiePlatfromClient(string apiKey)
        {
            _apiKey = apiKey;
            _httpClient = UnityContainerFactory.Container.Resolve<IHttpClientInstance>();
            _logger = UnityContainerFactory.Container.Resolve<ILogger>();
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
        public async Task<DestinyManifest> GetDestinyManifest()
        {
            _logger.Log("Loading destiny manifest...", LogType.Info);
            var manifest = await GetData<DestinyManifest>("Destiny2/Manifest");
            _logger.Log($"Loaded destiny manifest: Version {manifest.Version}", LogType.Info);
            return manifest;
        }
        public async Task<T> GetDestinyEntityDefinition<T>(string entityType, uint hash) where T : DestinyDefinition
        {
            return await GetData<T>($"Destiny2/Manifest/{entityType}/{hash}");
        }
        public async Task<BungieNetUserInfo[]> SearchDestinyPlayer(BungieMembershipType membershipType, string displayName, bool returnOriginalProfile = false)
        {
            return await GetData<BungieNetUserInfo[]>($"Destiny2/SearchDestinyPlayer/{membershipType}/{displayName}/?returnOriginalProfile={returnOriginalProfile}");
        }
        public async Task<BungieNetUserMembershipWithLinkedDestinyProfiles> GetLinkedProfiles(BungieMembershipType membershipType, long membershipId, bool getAllMemberships = false)
        {
            return await GetData<BungieNetUserMembershipWithLinkedDestinyProfiles>($"Destiny2/{membershipType}/Profile/{membershipId}/LinkedProfiles/?getAllMemberships={getAllMemberships}");
        }
        public async Task<DestinyComponentProfileResponse> GetProfile(BungieMembershipType membershipType, long destinyMembershipId, DestinyComponentType[] componentTypes)
        {
            return await GetData<DestinyComponentProfileResponse>($"Destiny2/{membershipType}/Profile/{destinyMembershipId}/?components={string.Join(",", componentTypes)}");
        }
        public async Task<Dictionary<uint, GetPublicMilestonesResponse>> GetPublicMilestones()
        {
            return await GetData<Dictionary<uint, GetPublicMilestonesResponse>>($"Destiny2/Milestones");
        }
        #endregion
        private async Task<T> GetData<T>(string query)
        {
            var response = await _httpClient.Get(BungieClient.BungiePlatformUri + query);
            //if (response.IsSuccessStatusCode)
            //{
            var bungieResponse = JsonConvert.DeserializeObject<BungieResponse<T>>(await response.Content.ReadAsStringAsync());
            if (bungieResponse.ErrorCode == PlatformErrorCodes.Success && bungieResponse.Response != null)
            {
                return bungieResponse.Response;
            }
            else
                throw new Exception(bungieResponse.ErrorStatus);
            //}
            //else
            //    throw new Exception(response.ReasonPhrase);
        }
    }
}
