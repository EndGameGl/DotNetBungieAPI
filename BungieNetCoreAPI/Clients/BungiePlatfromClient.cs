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
    }
}
