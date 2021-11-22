using DotNetBungieAPI.Authorization;
using System.Threading.Tasks;

namespace DotNetBungieAPI.Services.Interfaces
{
    public interface IAuthorizationHandler
    {
        string GetAuthorizationLink(AuthorizationState authData);
        AuthorizationState CreateNewAuthenticationAwaiter();
        ValueTask<AuthorizationTokenData> GetAuthTokenAsync(AuthorizationState authData);
        bool TryGetAccessToken(long membershipId, out string token);
        ValueTask<AuthorizationTokenData> RenewToken(AuthorizationTokenData authData);
    }
}