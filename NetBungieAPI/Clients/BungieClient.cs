using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NetBungieAPI.Authorization;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Models.Destiny.Definitions.HistoricalStats;
using NetBungieAPI.Repositories;
using NetBungieAPI.Services.Interfaces;

namespace NetBungieAPI.Clients
{
    /// <summary>
    ///     <see cref="IBungieClient" /> implementation
    /// </summary>
    internal sealed class BungieClient : IBungieClient
    {
        private readonly ILogger _logger;
        private readonly BungieClientConfiguration _configuration;

        internal BungieClient(
            ILogger logger,
            IBungieApiAccess apiAccess,
            IAuthorizationHandler authorizationHandler,
            IDestiny2DefinitionRepository repository,
            IDefinitionProvider definitionProvider,
            BungieClientConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            Authentication = authorizationHandler;
            Repository = repository;
            ApiAccess = apiAccess;
            DefinitionProvider = definitionProvider;
        }

        /// <summary>
        ///     <inheritdoc cref="IBungieClient.Authentication" />
        /// </summary>
        public IAuthorizationHandler Authentication { get; }

        /// <summary>
        ///     <inheritdoc cref="IBungieClient.Repository" />
        /// </summary>
        public IDestiny2DefinitionRepository Repository { get; }

        /// <summary>
        ///     <inheritdoc cref="IBungieClient.ApiAccess" />
        /// </summary>
        public IBungieApiAccess ApiAccess { get; }

        public IDefinitionProvider DefinitionProvider { get; }

        /// <summary>
        /// <inheritdoc cref="IBungieClient.ScopeToUser" />
        /// </summary>
        /// <param name="token">Auth token</param>
        /// <returns></returns>
        public IUserContextBungieClient ScopeToUser(AuthorizationTokenData token)
        {
            return new UserContextBungieClient(Repository, token, Authentication, ApiAccess);
        }

        /// <summary>
        /// <inheritdoc cref="IBungieClient.TryGetDefinitionAsync{T}"/>
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="locale"></param>
        /// <param name="success"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async ValueTask<bool> TryGetDefinitionAsync<T>(uint hash, BungieLocales locale, Action<T> success)
            where T : IDestinyDefinition
        {
            if (Repository.TryGetDestinyDefinition<T>(hash, locale, out var definition))
            {
                success(definition);
                return true;
            }

            definition = await DefinitionProvider.LoadDefinition<T>(hash, locale);
            if (definition is null)
                return false;
            if (_configuration.CacheDefinitions)
                Repository.AddDefinition(locale, definition);
            success(definition);
            return true;
        }

        public bool TryGetDefinition<T>(uint hash, BungieLocales locale, out T definition) where T : IDestinyDefinition
        {
            if (Repository.TryGetDestinyDefinition<T>(hash, locale, out definition))
            {
                return true;
            }

            var defTask = DefinitionProvider.LoadDefinition<T>(hash, locale);
            definition = defTask.GetAwaiter().GetResult();
            if (!defTask.IsCompleted)
                throw new Exception("ValueTask faulted to get result.");
            if (definition is null)
                return false;
            if (_configuration.CacheDefinitions)
                Repository.AddDefinition(locale, definition);
            return true;
        }

        public async ValueTask<bool> TryGetHistoricalStatDefinitionAsync(string key, BungieLocales locale,
            Action<DestinyHistoricalStatsDefinition> success)
        {
            if (Repository.TryGetDestinyHistoricalDefinition(locale, key, out var definition))
            {
                success(definition);
                return true;
            }

            definition = await DefinitionProvider.LoadHistoricalStatsDefinition(key, locale);
            if (definition is null)
                return false;
            if (_configuration.CacheDefinitions)
                Repository.AddDestinyHistoricalDefinition(locale, definition);
            success(definition);
            return true;
        }

        public bool TryGetHistoricalStatDefinition(string key, BungieLocales locale,
            out DestinyHistoricalStatsDefinition definition)
        {
            if (Repository.TryGetDestinyHistoricalDefinition(locale, key, out definition))
            {
                return true;
            }

            var getterTask = DefinitionProvider.LoadHistoricalStatsDefinition(key, locale);
            definition = getterTask.GetAwaiter().GetResult();

            if (!getterTask.IsCompleted)
                throw new Exception("ValueTask faulted to get result.");

            if (definition is null)
                return false;
            if (_configuration.CacheDefinitions)
                Repository.AddDestinyHistoricalDefinition(locale, definition);
            return true;
        }
    }
}