using NetBungieAPI.Clients;
using NetBungieAPI.Logging;
using NetBungieAPI.Services;
using NetBungieAPI.Authrorization;
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

        private AuthorizationState _authorizationState;
        private AuthorizationTokenData _authorizationToken;

        public AuthorizationStateHandler(ILogger logger, IConfigurationService configuration, IHttpClientInstance httpClient)
        {
            _logger = logger;
            _config = configuration;
            _client = httpClient;
        }

        public AuthorizationState CreateNewAuthAwaiter()
        {
            var _authorizationState = AuthorizationState.GetNewAuth();
            return _authorizationState;
        }
        public void InputCode(string state, string code)
        {
            _authorizationState?.ReceiveCode(code);
        }
        public void AddAuthToken(AuthorizationTokenData token)
        {
            _logger.Log($"Added new token for membership: {token.MembershipId}", LogType.Info);
            _authorizationToken = token;
        }
        public bool TryGetAccessToken(out string accessToken)
        {
            accessToken = default;
            if (_authorizationToken is null) return false;
            accessToken = _authorizationToken.AccessToken;
            return true;
        }
    }
}
