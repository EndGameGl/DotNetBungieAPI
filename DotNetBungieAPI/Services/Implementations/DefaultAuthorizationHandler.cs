using DotNetBungieAPI.Models.Authorization;
using DotNetBungieAPI.Service.Abstractions;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace DotNetBungieAPI.Services.Implementations;

internal sealed class DefaultAuthorizationHandler : IAuthorizationHandler
{
    private readonly IDotNetBungieApiHttpClient _client;
    private readonly IBungieClientConfiguration _configuration;
    private readonly ILogger<DefaultAuthorizationHandler> _logger;

    private readonly ConcurrentDictionary<string, AuthAwaiterContainer> _authAwaiters;

    public DefaultAuthorizationHandler(
        IDotNetBungieApiHttpClient dotNetBungieApiHttpClient,
        IBungieClientConfiguration configuration,
        ILogger<DefaultAuthorizationHandler> logger
    )
    {
        _client = dotNetBungieApiHttpClient;
        _configuration = configuration;
        _logger = logger;
        _authAwaiters = new ConcurrentDictionary<string, AuthAwaiterContainer>();
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

        return await _client.GetAuthorizationToken(authData.Code!);
    }

    public async ValueTask<AuthorizationTokenData> RenewToken(AuthorizationTokenData authData)
    {
        var newToken = await _client.RenewAuthorizationToken(authData);
        authData.Update(newToken);
        return authData;
    }

    public AsyncAuthorizationState CreateNewAsyncAuthorizationAwaiter(string? state = null)
    {
        state ??= RandomInstance.GetRandomString(20);
        return AsyncAuthorizationState.CreateAsyncAuthorizationAwaiter(state);
    }

    public string GetAuthorizationLink(AsyncAuthorizationState authData)
    {
        if (_configuration.ClientId != 0)
            return _client.GetAuthLink(_configuration.ClientId, authData.State);
        throw new ArgumentException("Client ID is missing");
    }

    public async Task<AuthorizationTokenData> GetAuthTokenAsync(AsyncAuthorizationState authData)
    {
        return await _client.GetAuthorizationToken(authData.Code!);
    }

    public void RegisterAsyncAuthorizationAwaiter(AsyncAuthorizationState authAwaiter)
    {
        _authAwaiters.AddOrUpdate(
            authAwaiter.State,
            new AuthAwaiterContainer() { AddedAt = DateTime.UtcNow, State = authAwaiter },
            (_, container) =>
            {
                container.State = authAwaiter;
                container.AddedAt = DateTime.UtcNow;
                return container;
            }
        );
    }

    public bool TrySendCodeToRegisteredAsyncAuthorizationAwaiter(string state, string code)
    {
        if (_authAwaiters.TryGetValue(state, out var awaiter))
        {
            _authAwaiters.Remove(state, out _);
            try
            {
                awaiter.State.ReceiveCode(code, state);
            }
            catch
            {
                _logger.LogWarning("Error while disposing of auth awaiter {State}", state);
            }
            
            return true;
        }

        return false;
    }

    public void ClearRegisteredAwaiters(TimeSpan? timeout = null)
    {
        string[] keysToRemove;
        if (timeout is null)
        {
            keysToRemove = _authAwaiters.Keys.ToArray();
        }
        else
        {
            keysToRemove = _authAwaiters
                .Where(x => x.Value.DidExpire(timeout.Value))
                .Select(x => x.Key)
                .ToArray();
        }

        foreach (var item in keysToRemove)
        {
            if (_authAwaiters.Remove(item, out var oldAwaiter))
            {
                try
                {
                    oldAwaiter.State.ReceiveCode(null, null);
                }
                catch
                {
                    _logger.LogWarning("Error while disposing of auth awaiter {State}", item);
                }
            }
        }
    }

    public async Task<AuthorizationTokenData> GetAuthTokenAsync(string code)
    {
        return await _client.GetAuthorizationToken(code);
    }

    private class AuthAwaiterContainer
    {
        internal AsyncAuthorizationState State { get; set; }
        internal DateTime AddedAt { get; set; }

        public bool DidExpire(TimeSpan timeSpan)
        {
            return DateTime.UtcNow >= AddedAt.Add(timeSpan);
        }
    }
}
