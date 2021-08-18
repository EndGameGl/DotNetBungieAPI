using System;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;
using NetBungieAPI.Repositories;
using NetBungieAPI.Services.Interfaces;
using NetBungieAPI.Services.UserScopedApiAccess;

namespace NetBungieAPI.Clients
{
    /// <summary>
    /// <inheritdoc cref="IUserContextBungieClient"/>
    /// </summary>
    public class UserContextBungieClient : IUserContextBungieClient
    {
        private readonly IAuthorizationStateHandler _authorizationStateHandler;
        private readonly AuthorizationTokenData _token;

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

        /// <summary>
        /// <inheritdoc cref="IUserContextBungieClient.Repository"/>
        /// </summary>
        public ILocalisedDestinyDefinitionRepositories Repository { get; }

        /// <summary>
        /// <inheritdoc cref="IUserContextBungieClient.App"/>
        /// </summary>
        public UserScopedAppMethodsAccess App { get; }

        /// <summary>
        /// <inheritdoc cref="IUserContextBungieClient.User"/>
        /// </summary>
        public UserScopedUserMethodsAccess User { get; }

        /// <summary>
        /// <inheritdoc cref="IUserContextBungieClient.Trending"/>
        /// </summary>
        public UserScopedTrendingMethodsAccess Trending { get; }

        /// <summary>
        /// <inheritdoc cref="IUserContextBungieClient.Tokens"/>
        /// </summary>
        public UserScopedTokenMethodsAccess Tokens { get; }

        /// <summary>
        /// <inheritdoc cref="IUserContextBungieClient.Misc"/>
        /// </summary>
        public UserScopedMiscMethodsAccess Misc { get; }

        /// <summary>
        /// <inheritdoc cref="IUserContextBungieClient.GroupV2"/>
        /// </summary>
        public UserScopedGroupV2MethodsAccess GroupV2 { get; }

        /// <summary>
        /// <inheritdoc cref="IUserContextBungieClient.Forum"/>
        /// </summary>
        public UsedScopedForumMethodsAccess Forum { get; }

        /// <summary>
        /// <inheritdoc cref="IUserContextBungieClient.Fireteam"/>
        /// </summary>
        public UserScopedFireteamMethodsAccess Fireteam { get; }

        /// <summary>
        /// <inheritdoc cref="IUserContextBungieClient.Content"/>
        /// </summary>
        public UserScopedContentMethodsAccess Content { get; }

        /// <summary>
        /// <inheritdoc cref="IUserContextBungieClient.CommunityContent"/>
        /// </summary>
        public UserScopedCommunityContentMethodsAccess CommunityContent { get; }

        /// <summary>
        /// <inheritdoc cref="IUserContextBungieClient.Destiny2"/>
        /// </summary>
        public UserScopedDestiny2MethodsAccess Destiny2 { get; }

        /// <summary>
        /// <inheritdoc cref="IUserContextBungieClient.ValidateToken"/>
        /// </summary>
        public async Task ValidateToken()
        {
            if (_token.ReceiveTime.AddSeconds(_token.ExpiresIn) < DateTime.Now)
                await _authorizationStateHandler.RenewToken(_token);
        }
    }
}