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
        public ConcurrentDictionary<string, AuthorizationState> AuthorizationStates { get; init; }
        public ConcurrentDictionary<long, AuthorizationTokenData> AuthorizationTokens { get; init; }

        public AuthorizationStateHandler(ILogger logger, IConfigurationService configuration, IHttpClientInstance httpClient)
        {
            _logger = logger;
            _config = configuration;
            AuthorizationStates = new ConcurrentDictionary<string, AuthorizationState>();
            AuthorizationTokens = new ConcurrentDictionary<long, AuthorizationTokenData>();
            _client = httpClient;
        }

        public AuthorizationState CreateNewAuthAwaiter()
        {
            var awaiter = AuthorizationState.GetNewAuth();
            AuthorizationStates.TryAdd(awaiter.State, awaiter);
            return awaiter;
        }
        public void InputCode(string state, string code)
        {
            if (AuthorizationStates.TryGetValue(state, out var awaiter))
            {
                awaiter.ReceiveCode(code);
            }
        }
        public void AddAuthToken(AuthorizationTokenData token)
        {
            _logger.Log($"Added new token for membership: {token.MembershipId}", LogType.Info);
            AuthorizationTokens.TryAdd(token.MembershipId, token);
        }
        public bool TryGetAccessToken(long membershipId, out string accessToken)
        {
            accessToken = default;
            if (AuthorizationTokens.TryGetValue(membershipId, out var token))
            {
                accessToken = token.AccessToken;
                return true;
            }
            return false;
        }
    }
}
