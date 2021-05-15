using NetBungieAPI.Authorization;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.Interfaces
{
    public interface IAuthorizationStateHandler
    {
        string GetAuthorizationLink(AuthorizationState authData);
        AuthorizationState CreateNewAuthentificationAwaiter();
        ValueTask<AuthorizationTokenData> GetAuthTokenAsync(AuthorizationState authData);
        bool TryGetAccessToken(long membershipId, out string token);
    }
}
