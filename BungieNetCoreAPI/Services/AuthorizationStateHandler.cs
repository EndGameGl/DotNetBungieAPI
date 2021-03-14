using NetBungieAPI.Authrorization;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace NetBungieAPI.Services
{
    public class AuthorizationStateHandler : IAuthorizationStateHandler
    {
        public ConcurrentDictionary<string, AuthorizationState> AuthorizationStates { get; }

        public AuthorizationStateHandler()
        {
            AuthorizationStates = new ConcurrentDictionary<string, AuthorizationState>();
        }

        public AuthorizationState CreateNewAuthAwaiter()
        {
            var awaiter = AuthorizationState.GetNewAuth();
            AuthorizationStates.TryAdd(awaiter.State, awaiter);
            return awaiter;
        }
        public void InputCode(string state, string code)
        {
            if (AuthorizationStates.TryGetValue(state, out var awaiter))
            {
                awaiter.ReceiveCode(code);
            }
        }
    }
}
