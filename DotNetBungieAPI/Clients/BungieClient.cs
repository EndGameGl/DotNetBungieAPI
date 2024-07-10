using System.Threading.Tasks;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Destiny;
using DotNetBungieAPI.Models.Destiny.Definitions.HistoricalStats;
using DotNetBungieAPI.Service.Abstractions;

namespace DotNetBungieAPI.Clients;

/// <summary>
///     <see cref="IBungieClient" /> implementation
/// </summary>
internal sealed class BungieClient : IBungieClient
{
    internal static IBungieClient Instance { get; set; }
    private readonly IBungieClientConfiguration _configuration;

    public BungieClient(
        IBungieApiAccess apiAccess,
        IAuthorizationHandler authorizationHandler,
        IDestiny2DefinitionRepository repository,
        IDefinitionProvider definitionProvider,
        IDestiny2ResetService destiny2ResetService,
        IBungieClientConfiguration configuration,
        IDotNetBungieApiHttpClient dotNetBungieApiHttpClient,
        IBungieNetJsonSerializer bungieNetJsonSerializer
    )
    {
        ResetService = destiny2ResetService;
        _configuration = configuration;
        Authorization = authorizationHandler;
        Repository = repository;
        ApiAccess = apiAccess;
        DefinitionProvider = definitionProvider;
        Instance = this;
        ApiHttpClient = dotNetBungieApiHttpClient;
        Serializer = bungieNetJsonSerializer;
    }

    /// <summary>
    ///     <inheritdoc cref="IBungieClient.Authorization" />
    /// </summary>
    public IAuthorizationHandler Authorization { get; }

    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    public IBungieNetJsonSerializer Serializer { get; }

    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    public IDotNetBungieApiHttpClient ApiHttpClient { get; }

    /// <summary>
    ///     <inheritdoc cref="IBungieClient.Repository" />
    /// </summary>
    public IDestiny2DefinitionRepository Repository { get; }

    /// <summary>
    ///     <inheritdoc cref="IBungieClient.ApiAccess" />
    /// </summary>
    public IBungieApiAccess ApiAccess { get; }

    public IDefinitionProvider DefinitionProvider { get; }

    public IDestiny2ResetService ResetService { get; }

    /// <summary>
    ///     <inheritdoc cref="IBungieClient.TryGetDefinitionAsync{T}" />
    /// </summary>
    /// <param name="hash"></param>
    /// <param name="locale"></param>
    /// <param name="success"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public async ValueTask<bool> TryGetDefinitionAsync<T>(
        uint hash,
        Action<T> success,
        BungieLocales locale = BungieLocales.EN
    )
        where T : IDestinyDefinition
    {
        if (Repository.TryGetDestinyDefinition<T>(hash, out var definition, locale))
        {
            success(definition);
            return true;
        }

        if (_configuration.TryFetchDefinitionsFromProvider)
        {
            definition = await DefinitionProvider.LoadDefinition<T>(hash, locale);
            if (definition is null)
                return false;
            if (_configuration.CacheDefinitions)
                Repository.AddDefinition(definition, locale);
            success(definition);
        }

        return false;
    }

    public bool TryGetDefinition<T>(
        uint hash,
        out T definition,
        BungieLocales locale = BungieLocales.EN
    )
        where T : IDestinyDefinition
    {
        if (Repository.TryGetDestinyDefinition(hash, out definition, locale))
            return true;
        if (_configuration.TryFetchDefinitionsFromProvider)
        {
            var defTask = DefinitionProvider.LoadDefinition<T>(hash, locale);
            definition = defTask.GetAwaiter().GetResult();
            if (!defTask.IsCompleted)
                throw new Exception("ValueTask faulted to get result.");
            if (definition is null)
                return false;
            if (_configuration.CacheDefinitions)
                Repository.AddDefinition(definition, locale);
            return true;
        }

        return false;
    }

    public async ValueTask<bool> TryGetHistoricalStatDefinitionAsync(
        string key,
        Action<DestinyHistoricalStatsDefinition> success,
        BungieLocales locale = BungieLocales.EN
    )
    {
        if (Repository.TryGetDestinyHistoricalDefinition(key, out var definition, locale))
        {
            success(definition);
            return true;
        }

        if (_configuration.TryFetchDefinitionsFromProvider)
        {
            definition = await DefinitionProvider.LoadHistoricalStatsDefinition(key, locale);
            if (definition is null)
                return false;

            if (_configuration.CacheDefinitions)
                Repository.AddDestinyHistoricalDefinition(definition, locale);

            success(definition);
            return true;
        }

        return false;
    }

    public bool TryGetHistoricalStatDefinition(
        string key,
        out DestinyHistoricalStatsDefinition definition,
        BungieLocales locale = BungieLocales.EN
    )
    {
        if (Repository.TryGetDestinyHistoricalDefinition(key, out definition, locale))
            return true;

        if (_configuration.TryFetchDefinitionsFromProvider)
        {
            var getterTask = DefinitionProvider.LoadHistoricalStatsDefinition(key, locale);
            definition = getterTask.GetAwaiter().GetResult();

            if (!getterTask.IsCompleted)
                throw new Exception("ValueTask faulted to get result.");

            if (definition is null)
                return false;

            if (_configuration.CacheDefinitions)
                Repository.AddDestinyHistoricalDefinition(definition, locale);

            return true;
        }

        return false;
    }

    public void Dispose()
    {
        DefinitionProvider.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await DefinitionProvider.DisposeAsync();
    }
}
