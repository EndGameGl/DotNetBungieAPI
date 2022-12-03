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
    string GetAuthorizationLink(AuthorizationState authData);

    /// <summary>
    ///     Creates new <see cref="AuthorizationState"/> object to track auth state
    /// </summary>
    /// <param name="state">Custom state can be provided, will not be url-encoded automatically</param>
    /// <returns></returns>
    AuthorizationState CreateNewAuthenticationAwaiter(string? state = null);

    /// <summary>
    ///     Gets actual auth token when code is properly validated with <see cref="AuthorizationState.ReceiveCode(string,string)"/>
    /// </summary>
    /// <param name="authData">Auth tracker to get actual token from</param>
    /// <returns>Auth token</returns>
    /// <exception cref="BungieNetAuthorizationErrorException">Thrown when failed to properly receive token from bungie.net auth endpoint</exception>
    ValueTask<AuthorizationTokenData> GetAuthTokenAsync(AuthorizationState authData);
    
    /// <summary>
    ///     Renews token for given <see cref="AuthorizationTokenData"/>
    /// </summary>
    /// <param name="authData">Token to renew</param>
    /// <returns>Renewed token</returns>
    /// <exception cref="ReauthRequiredException">Thrown when <see cref="AuthorizationTokenData.RefreshToken"/> expired</exception>
    /// <exception cref="BungieNetAuthorizationErrorException">Thrown when failed to properly receive token from bungie.net auth endpoint</exception>
    ValueTask<AuthorizationTokenData> RenewToken(AuthorizationTokenData authData);
}