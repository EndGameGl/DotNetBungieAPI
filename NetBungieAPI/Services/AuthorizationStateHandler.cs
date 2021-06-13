using NetBungieAPI.Clients;
using NetBungieAPI.Logging;
using NetBungieAPI.Services;
using NetBungieAPI.Authorization;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Services.Interfaces;

namespace NetBungieAPI.Services
{
    public class AuthorizationStateHandler : IAuthorizationStateHandler
    {
        private readonly IHttpClientInstance _client;
        private readonly ILogger _logger;
        private readonly IConfigurationService _config;

        private ConcurrentDictionary<string, AuthorizationState> _authorizationStates { get; }
        private ConcurrentDictionary<long, AuthorizationTokenData> _authorizationTokenDatas { get; }

        public AuthorizationStateHandler(ILogger logger, IConfigurationService configuration,
            IHttpClientInstance httpClient)
        {
            _logger = logger;
            _config = configuration;
            _client = httpClient;
            _authorizationStates = new ConcurrentDictionary<string, AuthorizationState>();
            _authorizationTokenDatas = new ConcurrentDictionary<long, AuthorizationTokenData>();
        }

        public string GetAuthorizationLink(AuthorizationState authData)
        {
            return _client.GetAuthLink(_config.Settings.IdentificationSettings.ClientId.Value, authData.State);
        }

        public AuthorizationState CreateNewAuthentificationAwaiter()
        {
            var authAwaiter = AuthorizationState.GetNewAuth();
            if (_authorizationStates.TryAdd(authAwaiter.State, authAwaiter))
            {
                return authAwaiter;
            }

            throw new Exception("Couldn't create new authentification state.");
        }

        public async ValueTask<AuthorizationTokenData> GetAuthTokenAsync(AuthorizationState authData)
        {
            if (!authData.DidReceiveCallback)
                throw new Exception("No callback was received from state.");
            if (!authData.HasCode)
                throw new Exception("No code is present in state.");

            try
            {
                var newToken = await _client.GetAuthorizationToken(authData.Code);
                return _authorizationTokenDatas.AddOrUpdate(newToken.MembershipId, newToken, (_, _) => newToken);
            }
            catch (Exception e)
            {
                _logger.Log(e.Message, LogType.Error);
            }

            throw new Exception("Failed to get new token");
        }

        public bool TryGetAccessToken(long membershipId, out string token)
        {
            token = default;
            if (!_authorizationTokenDatas.TryGetValue(membershipId, out var tokenData)) 
                return false;
            token = tokenData.AccessToken;
            return true;

        }

        public async ValueTask<AuthorizationTokenData> RenewToken(AuthorizationTokenData authData)
        {
            try
            {
                var newToken = await _client.RenewAuthorizationToken(authData);
                return _authorizationTokenDatas.AddOrUpdate(newToken.MembershipId, newToken, (_, _) => newToken);
            }
            catch (Exception e)
            {
                _logger.Log(e.Message, LogType.Error);
            }

            throw new Exception("Failed to get new token");
        }
    }
}