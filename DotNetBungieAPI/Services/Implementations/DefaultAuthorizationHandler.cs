using System.Collections.Concurrent;
using System.Threading.Tasks;
using DotNetBungieAPI.Clients;
using DotNetBungieAPI.Models.Authorization;
using DotNetBungieAPI.Service.Abstractions;
using Microsoft.Extensions.Logging;

namespace DotNetBungieAPI.Services.Implementations;

internal sealed class DefaultAuthorizationHandler : IAuthorizationHandler
{
    private readonly IDotNetBungieApiHttpClient _client;
    private readonly IBungieClientConfiguration _configuration;
    private readonly ILogger<DefaultAuthorizationHandler> _logger;

    public DefaultAuthorizationHandler(
        ILogger<DefaultAuthorizationHandler> logger,
        IDotNetBungieApiHttpClient dotNetBungieApiHttpClient,
        IBungieClientConfiguration configuration)
    {
        _logger = logger;
        _client = dotNetBungieApiHttpClient;
        _configuration = configuration;
        _authorizationStates = new ConcurrentDictionary<string, AuthorizationState>();
        _authorizationTokenDatas = new ConcurrentDictionary<long, AuthorizationTokenData>();
    }

    private readonly ConcurrentDictionary<string, AuthorizationState> _authorizationStates;
    private readonly ConcurrentDictionary<long, AuthorizationTokenData> _authorizationTokenDatas;

    public string GetAuthorizationLink(AuthorizationState authData)
    {
        if (_configuration.ClientId != 0)
            return _client.GetAuthLink(_configuration.ClientId, authData.State);
        throw new NullReferenceException("Client ID is missing.");
    }

    public AuthorizationState CreateNewAuthenticationAwaiter()
    {
        var authAwaiter = AuthorizationState.GetNewAuth();
        
        if (_authorizationStates.TryAdd(authAwaiter.State, authAwaiter)) return authAwaiter;

        throw new Exception("Couldn't create new authentication state.");
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
            _logger.LogError("{Message}", e.Message);
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
            _logger.LogError("{Message}", e.Message);
        }

        throw new Exception("Failed to get new token");
    }
}