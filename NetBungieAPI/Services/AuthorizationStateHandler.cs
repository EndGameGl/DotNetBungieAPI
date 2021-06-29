using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;
using NetBungieAPI.Logging;
using NetBungieAPI.Services.Interfaces;

namespace NetBungieAPI.Services
{
    public class AuthorizationStateHandler : IAuthorizationStateHandler
    {
        private readonly IHttpClientInstance _client;
        private readonly IConfigurationService _config;
        private readonly ILogger _logger;

        public AuthorizationStateHandler(ILogger logger, IConfigurationService configuration,
            IHttpClientInstance httpClient)
        {
            _logger = logger;
            _config = configuration;
            _client = httpClient;
            _authorizationStates = new ConcurrentDictionary<string, AuthorizationState>();
            _authorizationTokenDatas = new ConcurrentDictionary<long, AuthorizationTokenData>();
        }

        private ConcurrentDictionary<string, AuthorizationState> _authorizationStates { get; }
        private ConcurrentDictionary<long, AuthorizationTokenData> _authorizationTokenDatas { get; }

        public string GetAuthorizationLink(AuthorizationState authData)
        {
            if (_config.Settings.IdentificationSettings.ClientId != null)
                return _client.GetAuthLink(_config.Settings.IdentificationSettings.ClientId.Value, authData.State);
            throw new NullReferenceException("Client ID is missing.");
        }

        public AuthorizationState CreateNewAuthentificationAwaiter()
        {
            var authAwaiter = AuthorizationState.GetNewAuth();
            if (_authorizationStates.TryAdd(authAwaiter.State, authAwaiter)) return authAwaiter;

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
                authData.Update(newToken);
                return _authorizationTokenDatas.AddOrUpdate(newToken.MembershipId, authData, (_, _) => authData);
            }
            catch (Exception e)
            {
                _logger.Log(e.Message, LogType.Error);
            }

            throw new Exception("Failed to get new token");
        }
    }
}