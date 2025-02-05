using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Destiny;
using DotNetBungieAPI.Models.Destiny.Definitions.HistoricalStats;
using DotNetBungieAPI.Repositories;
using DotNetBungieAPI.Service.Abstractions;
using DotNetBungieAPI.Services.Implementations.ServiceConfigurations;
using Microsoft.Extensions.Logging;

namespace DotNetBungieAPI.Services.Implementations;

internal sealed class DefaultDestiny2DefinitionRepository : IDestiny2DefinitionRepository
{
    private readonly DefaultDestiny2DefinitionRepositoryConfiguration _configuration;
    private readonly ConcurrentDictionary<
        BungieLocales,
        DestinyDefinitionsRepository
    > _localisedRepositories;
    private readonly IBungieClientConfiguration _bungieClientConfiguration;

    public DefaultDestiny2DefinitionRepository(
        IBungieClientConfiguration bungieClientConfiguration,
        IDefinitionAssemblyData assemblyData,
        ILogger<DefaultDestiny2DefinitionRepository> logger,
        DefaultDestiny2DefinitionRepositoryConfiguration configuration
    )
    {
        _bungieClientConfiguration = bungieClientConfiguration;
        _configuration = configuration;
        _localisedRepositories = new ConcurrentDictionary<
            BungieLocales,
            DestinyDefinitionsRepository
        >(configuration.AppConcurrencyLevel, _bungieClientConfiguration.UsedLocales.Count);

        foreach (var locale in _bungieClientConfiguration.UsedLocales)
            _localisedRepositories.TryAdd(
                locale,
                new DestinyDefinitionsRepository(locale, assemblyData, logger, configuration)
            );
    }

    public bool TryGetDestinyDefinition<T>(
        uint key,
        [NotNullWhen(true)] out T? definition,
        BungieLocales locale = BungieLocales.EN
    )
        where T : IDestinyDefinition
    {
        definition = default;
        return _localisedRepositories.TryGetValue(locale, out var repository)
            && repository.TryGetDefinition(key, out definition);
    }

    public bool TryGetDestinyHistoricalDefinition(
        string key,
        out DestinyHistoricalStatsDefinition? statsDefinition,
        BungieLocales locale = BungieLocales.EN
    )
    {
        statsDefinition = default;
        return _localisedRepositories.TryGetValue(locale, out var repository)
            && repository.TryGetHistoricalStatsDefinition(key, out statsDefinition);
    }

    public IEnumerable<DestinyHistoricalStatsDefinition>? GetAllHistoricalStatsDefinitions(
        BungieLocales locale = BungieLocales.EN
    )
    {
        return _localisedRepositories.TryGetValue(locale, out var repository)
            ? repository.GetAllHistoricalStats
            : null;
    }

    public bool AddDestinyHistoricalDefinition(
        DestinyHistoricalStatsDefinition statsDefinition,
        BungieLocales locale = BungieLocales.EN
    )
    {
        return _localisedRepositories.TryGetValue(locale, out var repository)
            && repository.AddDestinyHistoricalStatsDefinition(statsDefinition);
    }

    public IEnumerable<T> Search<T>(
        Func<T, bool> predicate,
        BungieLocales locale = BungieLocales.EN
    )
        where T : IDestinyDefinition
    {
        return _localisedRepositories.TryGetValue(locale, out var repository)
            ? repository.Search<T>(predicate)
            : Enumerable.Empty<T>();
    }

    public IEnumerable<T> GetAll<T>(BungieLocales locale = BungieLocales.EN)
        where T : IDestinyDefinition
    {
        return _localisedRepositories.TryGetValue(locale, out var repository)
            ? repository.GetAll<T>()
            : Enumerable.Empty<T>();
    }

    public bool AddDefinition<T>(T definition, BungieLocales locale = BungieLocales.EN)
        where T : IDestinyDefinition
    {
        return _localisedRepositories.TryGetValue(locale, out var repository)
            && repository.AddDefinition(definition);
    }

    public bool AddDefinition(
        IDestinyDefinition definition,
        BungieLocales locale = BungieLocales.EN
    )
    {
        return _localisedRepositories.TryGetValue(locale, out var repository)
            && repository.AddDefinition(definition);
    }

    public IEnumerable<BungieLocales> AvailableLocales => _localisedRepositories.Select(x => x.Key);

    public IEnumerable<DefinitionsEnum> AllowedDefinitions => _configuration.AllowedDefinitions;

    public void Clear()
    {
        foreach (var repository in _localisedRepositories)
        {
            repository.Value.Clear();
        }
    }

    public void Clear(DefinitionsEnum definitionType)
    {
        foreach (var (_, repo) in _localisedRepositories)
        {
            repo.Clear(definitionType);
        }
    }

    public void Clear(DefinitionsEnum definitionType, BungieLocales locale)
    {
        foreach (var (_, repo) in _localisedRepositories.Where(x => x.Key == locale))
        {
            repo.Clear(definitionType);
        }
    }

    public void Clear(BungieLocales locale)
    {
        foreach (var (_, repo) in _localisedRepositories.Where(x => x.Key == locale))
        {
            repo.Clear();
        }
    }
}
