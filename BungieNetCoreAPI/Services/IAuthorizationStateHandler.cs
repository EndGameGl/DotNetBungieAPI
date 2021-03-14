using NetBungieAPI.Authrorization;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace NetBungieAPI.Services
{
    public interface IAuthorizationStateHandler
    {
        ConcurrentDictionary<string, AuthorizationState> AuthorizationStates { get; }
        AuthorizationState CreateNewAuthAwaiter();
        void InputCode(string state, string code);
        void AddAuthToken(AuthorizationTokenData token);
    }
}
