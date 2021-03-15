using NetBungieAPI.Bungie;
using NetBungieAPI.Bungie.Applications;
using NetBungieAPI.Destiny;
using NetBungieAPI.Destiny.Definitions;
using NetBungieAPI.Destiny.Definitions.ActivityModes;
using NetBungieAPI.Destiny.Definitions.HistoricalStats;
using NetBungieAPI.Destiny.Profile;
using NetBungieAPI.Destiny.Profile.Components.Contracts;
using NetBungieAPI.Destiny.Responses;
using NetBungieAPI.Logging;
using NetBungieAPI.Responses;
using NetBungieAPI.Services;
using NetBungieAPI.Authrorization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace NetBungieAPI.Clients
{
    public class BungiePlatfromClient
    {      
        private readonly IHttpClientInstance _httpClient;
        private readonly ILogger _logger;
        private readonly IConfigurationService _config;
        private readonly IAuthorizationStateHandler _authHandler;

        private readonly string _apiKey;

        private string _authorizationValue
        {
            get
            {
                if (_config.Settings.ClientID.HasValue && !string.IsNullOrEmpty(_config.Settings.ClientSecret))
                {
                    return Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_config.Settings.ClientID}:{_config.Settings.ClientSecret}"));
                }
                else
                    throw new Exception();
            }
        }

        internal BungiePlatfromClient(string apiKey, IConfigurationService configuration)
        {
            _apiKey = apiKey;
            _httpClient = StaticUnityContainer.GetHTTPClient();
            _logger = StaticUnityContainer.GetLogger();
            _authHandler = StaticUnityContainer.GetAuthHandler();
            _httpClient.AddAcceptHeader("application/json");
            _httpClient.AddHeader("X-API-Key", apiKey);
            _config = configuration;
        }

        public string GetAuthorizationLink()
        {
            var awaiter = _authHandler.CreateNewAuthAwaiter();
            return _httpClient.GetAuthLink(_config.Settings.ClientID.Value, awaiter.State);
        }
        public void ReceiveCode(string state, string code)
        {
            _authHandler.InputCode(state, code);
        }
        public async Task<AuthorizationTokenData> GetAuthorizationToken(string code)
        {
            var token = await _httpClient.GetAuthorizationToken(code, _authorizationValue);
            _authHandler.AddAuthToken(token);
            return token;
        }
        public async Task<AuthorizationTokenData> RenewAuthorizationToken(AuthorizationTokenData oldToken)
        {
            return await _httpClient.RenewAuthorizationToken(oldToken);
        }

        #region User methods
        public async Task<BungieResponse<BungieNetUser>> GetBungieNetUserById(long id)
        {
            return await GetData<BungieNetUser>($"User/GetBungieNetUserById/{id}");
        }
        public async Task<BungieResponse<BungieNetUser[]>> SearchUsers(string query)
        {
            if (!string.IsNullOrWhiteSpace(query))
                return await GetData<BungieNetUser[]>($"User/SearchUsers/?q={query}");
            else
                throw new Exception("Query must contain something.");
        }
        public async Task<BungieResponse<BungieNetUserAccountCredentialType[]>> GetCredentialTypesForTargetAccount(long id)
        {
            return await GetData<BungieNetUserAccountCredentialType[]>($"User/GetCredentialTypesForTargetAccount/{id}");
        }
        public async Task<BungieResponse<BungieUserTheme[]>> GetAvailableThemes()
        {
            return await GetData<BungieUserTheme[]>($"User/GetAvailableThemes");
        }
        public async Task<BungieResponse<BungieNetUserWithMemberships>> GetMembershipDataById(long id, BungieMembershipType membershipType)
        {
            return await GetData<BungieNetUserWithMemberships>($"User/GetMembershipsById/{id}/{membershipType}");
        }
        public async Task<BungieResponse<BungieNetUserWithMemberships>> GetMembershipDataForCurrentUser()
        {
            return await GetData<BungieNetUserWithMemberships>($"User/GetMembershipsForCurrentUser");
        }
        public async Task<BungieResponse<DestinyHardLinkedUserMembership>> GetMembershipFromHardLinkedCredential(long credential, BungieCredentialType credentialType = BungieCredentialType.SteamId)
        {
            return await GetData<DestinyHardLinkedUserMembership>($"User/GetMembershipFromHardLinkedCredential/{credentialType}/{credential}");
        }
        #endregion

        #region Misc methods
        /// <summary>
        /// List of available localization cultures
        /// </summary>
        /// <returns></returns>
        public async Task<BungieResponse<Dictionary<string, string>>> GetAvailableLocales()
        {
            return await GetData<Dictionary<string, string>>("GetAvailableLocales");
        }
        /// <summary>
        /// Get the common settings used by the Bungie.Net environment.
        /// </summary>
        /// <returns></returns>
        public async Task<BungieResponse<BungieNetSettings>> GetCommonSettings()
        {
            return await GetData<BungieNetSettings>("Settings");
        }
        /// <summary>
        /// Get the user-specific system overrides that should be respected alongside common systems.
        /// </summary>
        /// <returns></returns>
        public async Task<BungieResponse<Dictionary<string, BungieSystemSetting>>> GetUserSystemOverrides()
        {
            return await GetData<Dictionary<string, BungieSystemSetting>>("UserSystemOverrides");
        }
        /// <summary>
        /// Gets any active global alert for display in the forum banners, help pages, etc. Usually used for DOC alerts.
        /// </summary>
        /// <returns></returns>
        public async Task<BungieResponse<GlobalAlert[]>> GetGlobalAlerts()
        {
            return await GetData<GlobalAlert[]>("GlobalAlerts");
        }
        #endregion

        internal async Task<BungieResponse<T>> GetData<T>(string query, string defaultWebsite = null)
        {
            _logger.Log($"Getting data from: {query}", LogType.Debug);
            var finalQuery = string.Empty;
            if (defaultWebsite != null)
                finalQuery = $"{defaultWebsite}/{query}";
            //else
                //finalQuery = BungieClient.BungiePlatformUri + query;
            var response = await _httpClient.Get(finalQuery);
            var bungieResponse = JsonConvert.DeserializeObject<BungieResponse<T>>(await response.Content.ReadAsStringAsync());
            if (bungieResponse != null)
            {
                return bungieResponse;
            }
            else
                throw new Exception("No response from bungie.net");
        }
    }
}
