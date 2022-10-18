using DotNetBungieAPI.Models.Authorization;

namespace DotNetBungieAPI.Service.Abstractions;

public interface IAuthorizationHandler
{
    string GetAuthorizationLink(AuthorizationState authData);
    AuthorizationState CreateNewAuthenticationAwaiter(string? state = null);
    ValueTask<AuthorizationTokenData> GetAuthTokenAsync(AuthorizationState authData);
    bool TryGetAccessToken(long membershipId, out string token);
    ValueTask<AuthorizationTokenData> RenewToken(AuthorizationTokenData authData);
}