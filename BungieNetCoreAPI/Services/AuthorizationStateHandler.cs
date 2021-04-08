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
        private Timer _tokenTimer;
        public ConcurrentDictionary<string, AuthorizationState> AuthorizationStates { get; init; }
        public ConcurrentDictionary<long, AuthorizationTokenData> AuthorizationTokens { get; init; }

        public AuthorizationStateHandler(ILogger logger, IConfigurationService configuration, IHttpClientInstance httpClient)
        {
            _logger = logger;
            _config = configuration;
            AuthorizationStates = new ConcurrentDictionary<string, AuthorizationState>();
            AuthorizationTokens = new ConcurrentDictionary<long, AuthorizationTokenData>();
            _client = httpClient;
            _tokenTimer = new Timer(CheckTokenRenewal, null, Timeout.Infinite, Timeout.Infinite);
            if (_config.Settings.RenewTokens)
            {
                _tokenTimer.Change(0, _config.Settings.TokenCheckRefreshRate);
            }
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
        private void CheckTokenRenewal(object state)
        {
            foreach (var token in AuthorizationTokens.Select(x => x.Value))
            {
                if (true)//(DateTime.Now - token.ReceiveTime).Seconds <= 60)
                {
                    Task.Run(async () => await HandleTokenExpiration(token));
                }
            }
        }
        private async Task HandleTokenExpiration(AuthorizationTokenData token)
        {
            var newToken = await _client.RenewAuthorizationToken(token);
            AuthorizationTokens[newToken.MembershipId] = newToken;
            _logger.Log($"Renewed token for membership: {token.MembershipId}", LogType.Info);
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
