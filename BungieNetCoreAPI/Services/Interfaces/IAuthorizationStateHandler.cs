using NetBungieAPI.Authrorization;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace NetBungieAPI.Services.Interfaces
{
    public interface IAuthorizationStateHandler
    {
        AuthorizationState CreateNewAuthAwaiter();
        void InputCode(string state, string code);
        void AddAuthToken(AuthorizationTokenData token);
        bool TryGetAccessToken(out string accessToken);
    }
}
