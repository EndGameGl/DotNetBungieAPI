using DotNetBungieAPI.Models.Authorization;
using DotNetBungieAPI.Models.Exceptions;

namespace DotNetBungieAPI.Service.Abstractions;

/// <summary>
///     Service for handling OAuth2 interactions with https://www.bungie.net/
/// </summary>
public interface IAuthorizationHandler
{
    /// <summary>
    ///     Gets authorization link for given <see cref="AuthorizationState"/> instance
    /// </summary>
    /// <param name="authData">Object that tracks authorization state</param>
    /// <returns></returns>
    [Obsolete("Use GetAuthorizationLink for async awaiter insted")]
    string GetAuthorizationLink(AuthorizationState authData);

    /// <summary>
    ///     Creates new <see cref="AuthorizationState"/> object to track auth state
    /// </summary>
    /// <param name="state">Custom state can be provided, will not be url-encoded automatically</param>
    /// <returns></returns>
    [Obsolete("Use CreateNewAsyncAuthenticationAwaiter for async awaiter insted")]
    AuthorizationState CreateNewAuthenticationAwaiter(string? state = null);

    /// <summary>
    ///     Gets actual auth token when code is properly validated with <see cref="AuthorizationState.ReceiveCode(string,string)"/>
    /// </summary>
    /// <param name="authData">Auth tracker to get actual token from</param>
    /// <returns>Auth token</returns>
    /// <exception cref="BungieNetAuthorizationErrorException">Thrown when failed to properly receive token from bungie.net auth endpoint</exception>
    [Obsolete("Use GetAuthTokenAsync for async awaiter insted")]
    ValueTask<AuthorizationTokenData> GetAuthTokenAsync(AuthorizationState authData);

    /// <summary>
    ///     Creates new awaiter for authorization
    /// </summary>
    /// <param name="state">Predefined state, will generate random if left null</param>
    /// <returns></returns>
    AsyncAuthorizationState CreateNewAsyncAuthorizationAwaiter(string? state = null);

    /// <summary>
    ///     Creates auth link for user from exising awaiter
    /// </summary>
    /// <param name="authData"></param>
    /// <returns></returns>
    string GetAuthorizationLink(AsyncAuthorizationState authData);

    /// <summary>
    ///     Gets new token from awaiter
    /// </summary>
    /// <param name="authData"></param>
    /// <returns></returns>
    Task<AuthorizationTokenData> GetAuthTokenAsync(AsyncAuthorizationState authData);

    /// <summary>
    ///     Registers existing awaiter for future completion
    /// </summary>
    /// <param name="authAwaiter"></param>
    void RegisterAsyncAuthorizationAwaiter(AsyncAuthorizationState authAwaiter);

    /// <summary>
    ///     Searches and inputs code to awaiter with matching state
    /// </summary>
    /// <param name="state"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    bool TrySendCodeToRegisteredAsyncAuthorizationAwaiter(string state, string code);

    /// <summary>
    ///     Removes all awaiters, if timeout is provided, older than due date
    /// </summary>
    /// <param name="timeout"></param>
    void ClearRegisteredAwaiters(TimeSpan? timeout = null);

    /// <summary>
    ///     Gets new auth token from raw code
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    Task<AuthorizationTokenData> GetAuthTokenAsync(string code);

    /// <summary>
    ///     Renews token for given <see cref="AuthorizationTokenData"/>
    /// </summary>
    /// <param name="authData">Token to renew</param>
    /// <returns>Renewed token</returns>
    /// <exception cref="ReauthRequiredException">Thrown when <see cref="AuthorizationTokenData.RefreshToken"/> expired</exception>
    /// <exception cref="BungieNetAuthorizationErrorException">Thrown when failed to properly receive token from bungie.net auth endpoint</exception>
    ValueTask<AuthorizationTokenData> RenewToken(AuthorizationTokenData authData);
}
