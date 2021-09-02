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

        internal UserContextBungieClient(
            ILocalisedDestinyDefinitionRepositories repository,
            AuthorizationTokenData token,
            IAuthorizationStateHandler authorizationStateHandler,
            IBungieApiAccess apiAccess)
        {
            Repository = repository;
            TokenData = token;
            _authorizationStateHandler = authorizationStateHandler;
            App = new UserScopedAppMethodsAccess(apiAccess.App, TokenData);
            User = new UserScopedUserMethodsAccess(apiAccess.User, TokenData);
            Trending = new UserScopedTrendingMethodsAccess(apiAccess.Trending, TokenData);
            Tokens = new UserScopedTokenMethodsAccess(apiAccess.Tokens, TokenData);
            Misc = new UserScopedMiscMethodsAccess(apiAccess.Misc);
            GroupV2 = new UserScopedGroupV2MethodsAccess(apiAccess.GroupV2, TokenData);
            Forum = new UsedScopedForumMethodsAccess(apiAccess.Forum, TokenData);
            Fireteam = new UserScopedFireteamMethodsAccess(apiAccess.Fireteam, TokenData);
            Content = new UserScopedContentMethodsAccess(apiAccess.Content, TokenData);
            CommunityContent = new UserScopedCommunityContentMethodsAccess(apiAccess.Community);
            Destiny2 = new UserScopedDestiny2MethodsAccess(apiAccess.Destiny2, TokenData);
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
            if (TokenData.ReceiveTime.AddSeconds(TokenData.ExpiresIn) < DateTime.Now)
                await _authorizationStateHandler.RenewToken(TokenData);
        }

        /// <summary>
        /// <inheritdoc cref="IUserContextBungieClient.TokenData"/>
        /// </summary>
        public AuthorizationTokenData TokenData { get; }
    }
}