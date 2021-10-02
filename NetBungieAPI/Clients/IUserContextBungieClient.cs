using System.Threading.Tasks;
using NetBungieAPI.Authorization;
using NetBungieAPI.Repositories;
using NetBungieAPI.Services.ApiAccess.UserScoped;
using NetBungieAPI.Services.Interfaces;

namespace NetBungieAPI.Clients
{
    /// <summary>
    /// <see cref="IBungieClient"/> that is scoped down to single user, mainly for making API calls simpler
    /// </summary>
    public interface IUserContextBungieClient
    {
        /// <summary>
        /// <inheritdoc cref="IBungieClient.Repository"/>
        /// </summary>
        IDestiny2DefinitionRepository Repository { get; }

        /// <summary>
        /// <inheritdoc cref="IBungieApiAccess.App"/>
        /// </summary>
        UserScopedAppMethodsAccess App { get; }

        /// <summary>
        /// <inheritdoc cref="IBungieApiAccess.User"/>
        /// </summary>
        UserScopedUserMethodsAccess User { get; }

        /// <summary>
        /// <inheritdoc cref="IBungieApiAccess.Trending"/>
        /// </summary>
        UserScopedTrendingMethodsAccess Trending { get; }

        /// <summary>
        /// <inheritdoc cref="IBungieApiAccess.Tokens"/>
        /// </summary>
        UserScopedTokenMethodsAccess Tokens { get; }

        /// <summary>
        /// <inheritdoc cref="IBungieApiAccess.Misc"/>
        /// </summary>
        UserScopedMiscMethodsAccess Misc { get; }

        /// <summary>
        /// <inheritdoc cref="IBungieApiAccess.GroupV2"/>
        /// </summary>
        UserScopedGroupV2MethodsAccess GroupV2 { get; }

        /// <summary>
        /// <inheritdoc cref="IBungieApiAccess.Forum"/>
        /// </summary>
        UsedScopedForumMethodsAccess Forum { get; }

        /// <summary>
        /// <inheritdoc cref="IBungieApiAccess.Fireteam"/>
        /// </summary>
        UserScopedFireteamMethodsAccess Fireteam { get; }

        /// <summary>
        /// <inheritdoc cref="IBungieApiAccess.Content"/>
        /// </summary>
        UserScopedContentMethodsAccess Content { get; }

        /// <summary>
        /// <inheritdoc cref="IBungieApiAccess.Community"/>
        /// </summary>
        UserScopedCommunityContentMethodsAccess CommunityContent { get; }

        /// <summary>
        /// <inheritdoc cref="IBungieApiAccess.Destiny2"/>
        /// </summary>
        UserScopedDestiny2MethodsAccess Destiny2 { get; }

        /// <summary>
        /// Validates user token
        /// </summary>
        /// <returns></returns>
        Task ValidateToken();

        /// <summary>
        /// User token
        /// </summary>
        public AuthorizationTokenData TokenData { get; }
    }
}