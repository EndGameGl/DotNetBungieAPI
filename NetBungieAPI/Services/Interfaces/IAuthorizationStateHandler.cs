using System.Threading.Tasks;
using NetBungieAPI.Authorization;

namespace NetBungieAPI.Services.Interfaces
{
    public interface IAuthorizationStateHandler
    {
        string GetAuthorizationLink(AuthorizationState authData);
        AuthorizationState CreateNewAuthentificationAwaiter();
        ValueTask<AuthorizationTokenData> GetAuthTokenAsync(AuthorizationState authData);
        bool TryGetAccessToken(long membershipId, out string token);
        ValueTask<AuthorizationTokenData> RenewToken(AuthorizationTokenData authData);
    }
}