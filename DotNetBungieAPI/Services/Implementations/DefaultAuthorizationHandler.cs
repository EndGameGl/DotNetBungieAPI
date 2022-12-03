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

    public DefaultAuthorizationHandler(
        IDotNetBungieApiHttpClient dotNetBungieApiHttpClient,
        IBungieClientConfiguration configuration)
    {
        _client = dotNetBungieApiHttpClient;
        _configuration = configuration;
    }


    public string GetAuthorizationLink(AuthorizationState authData)
    {
        if (_configuration.ClientId != 0)
            return _client.GetAuthLink(_configuration.ClientId, authData.State);
        throw new NullReferenceException("Client ID is missing.");
    }

    public AuthorizationState CreateNewAuthenticationAwaiter(string? state = null)
    {
        state ??= RandomInstance.GetRandomString(20);

        var authAwaiter = AuthorizationState.GetNewAuth(state);

        return authAwaiter;
    }

    public async ValueTask<AuthorizationTokenData> GetAuthTokenAsync(AuthorizationState authData)
    {
        if (!authData.DidReceiveCallback)
            throw new Exception("No callback was received from state.");
        
        if (!authData.HasCode)
            throw new Exception("No code is present in state.");

        return await _client.GetAuthorizationToken(authData!.Code);
    }

    public async ValueTask<AuthorizationTokenData> RenewToken(AuthorizationTokenData authData)
    {
        var newToken = await _client.RenewAuthorizationToken(authData);
        authData.Update(newToken);
        return authData;
    }
}