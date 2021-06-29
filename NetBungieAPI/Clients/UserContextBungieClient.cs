using System;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;
using NetBungieAPI.Repositories;
using NetBungieAPI.Services.Interfaces;
using NetBungieAPI.Services.UserScopedApiAccess;

namespace NetBungieAPI.Clients
{
    public class UserContextBungieClient : IUserContextBungieClient
    {
        private AuthorizationTokenData _token;
        private IAuthorizationStateHandler _authorizationStateHandler;
        public ILocalisedDestinyDefinitionRepositories Repository { get; }
        public UserScopedAppMethodsAccess App { get; }
        public UserScopedUserMethodsAccess User { get; }
        public UserScopedTrendingMethodsAccess Trending { get; }
        public UserScopedTokenMethodsAccess Tokens { get; }
        public UserScopedMiscMethodsAccess Misc { get; }
        public UserScopedGroupV2MethodsAccess GroupV2 { get; }
        public UsedScopedForumMethodsAccess Forum { get; }
        public UserScopedFireteamMethodsAccess Fireteam { get; }
        public UserScopedContentMethodsAccess Content { get; }
        public UserScopedCommunityContentMethodsAccess CommunityContent { get; }
        public UserScopedDestiny2MethodsAccess Destiny2 { get; }

        internal UserContextBungieClient(
            ILocalisedDestinyDefinitionRepositories repository,
            AuthorizationTokenData token,
            IAuthorizationStateHandler authorizationStateHandler,
            IBungieApiAccess apiAccess)
        {
            Repository = repository;
            _token = token;
            _authorizationStateHandler = authorizationStateHandler;
            App = new UserScopedAppMethodsAccess(apiAccess.App, _token);
            User = new UserScopedUserMethodsAccess(apiAccess.User, _token);
            Trending = new UserScopedTrendingMethodsAccess(apiAccess.Trending, _token);
            Tokens = new UserScopedTokenMethodsAccess(apiAccess.Tokens, _token);
            Misc = new UserScopedMiscMethodsAccess(apiAccess.Misc);
            GroupV2 = new UserScopedGroupV2MethodsAccess(apiAccess.GroupV2, _token);
            Forum = new UsedScopedForumMethodsAccess(apiAccess.Forum, _token);
            Fireteam = new UserScopedFireteamMethodsAccess(apiAccess.Fireteam, _token);
            Content = new UserScopedContentMethodsAccess(apiAccess.Content, _token);
            CommunityContent = new UserScopedCommunityContentMethodsAccess(apiAccess.Community);
            Destiny2 = new UserScopedDestiny2MethodsAccess(apiAccess.Destiny2, _token);
        }

        public async Task ValidateToken()
        {
            if (_token.ReceiveTime.AddSeconds(_token.ExpiresIn) < DateTime.Now)
            {
                await _authorizationStateHandler.RenewToken(_token);
            }
        }
    }
}