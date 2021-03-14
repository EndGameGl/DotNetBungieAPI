using NetBungieApi.Clients;
using NetBungieApi.Logging;
using NetBungieApi.Services;
using NetBungieAPI.Authrorization;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetBungieAPI.Services
{
    public class AuthorizationStateHandler : IAuthorizationStateHandler
    {
        private readonly ILogger _logger;
        private readonly IConfigurationService _config;
        private Timer _tokenTimer;
        public ConcurrentDictionary<string, AuthorizationState> AuthorizationStates { get; }
        public ConcurrentDictionary<int, AuthorizationTokenData> AuthorizationTokens { get; }

        public AuthorizationStateHandler(ILogger logger, IConfigurationService configuration)
        {
            _logger = logger;
            _config = configuration;
            AuthorizationStates = new ConcurrentDictionary<string, AuthorizationState>();
            AuthorizationTokens = new ConcurrentDictionary<int, AuthorizationTokenData>();
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
        private void CheckTokenRenewal(object state)
        {
            foreach (var token in AuthorizationTokens.Select(x => x.Value))
            {
                if ((DateTime.Now - token.ReceiveTime).Seconds <= 60)
                {
                    Task.Run(async () => await HandleTokenExpiration(token));
                }
            }
        }
        private async Task HandleTokenExpiration(AuthorizationTokenData token)
        {
            var newToken = await BungieClient.Platform.RenewAuthorizationToken(token);
            AuthorizationTokens[newToken.MembershipId] = newToken;
        }
    }
}
