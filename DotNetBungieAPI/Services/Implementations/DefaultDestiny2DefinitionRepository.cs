﻿using System.Collections.Concurrent;
using DotNetBungieAPI.Clients;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Destiny;
using DotNetBungieAPI.Models.Destiny.Definitions.HistoricalStats;
using DotNetBungieAPI.Repositories;
using DotNetBungieAPI.Service.Abstractions;
using DotNetBungieAPI.Services.Default.ServiceConfigurations;
using DotNetBungieAPI.Services.Implementations.ServiceConfigurations;
using Microsoft.Extensions.Logging;

namespace DotNetBungieAPI.Services.Implementations;

internal sealed class DefaultDestiny2DefinitionRepository : IDestiny2DefinitionRepository
{
    private readonly DefaultDestiny2DefinitionRepositoryConfiguration _configuration;
    private readonly ConcurrentDictionary<BungieLocales, DestinyDefinitionsRepository> _localisedRepositories;
    private readonly IBungieClientConfiguration _bungieClientConfiguration;
    private readonly ILogger<DefaultDestiny2DefinitionRepository> _logger;

    public DefaultDestiny2DefinitionRepository(
        IBungieClientConfiguration bungieClientConfiguration,
        IDefinitionAssemblyData assemblyData,
        ILogger<DefaultDestiny2DefinitionRepository> logger,
        DefaultDestiny2DefinitionRepositoryConfiguration configuration)
    {
        _bungieClientConfiguration = bungieClientConfiguration;
        _logger = logger;
        _configuration = configuration;
        _localisedRepositories =
            new ConcurrentDictionary<BungieLocales, DestinyDefinitionsRepository>(
                configuration.AppConcurrencyLevel, _bungieClientConfiguration.UsedLocales.Count);

        foreach (var locale in _bungieClientConfiguration.UsedLocales)
            _localisedRepositories.TryAdd(
                locale,
                new DestinyDefinitionsRepository(
                    locale,
                    assemblyData,
                    logger,
                    configuration));
    }

    public bool TryGetDestinyDefinition<T>(
        uint key,
        BungieLocales locale,
        out T definition)
        where T : IDestinyDefinition
    {
        definition = default;
        return _localisedRepositories.TryGetValue(locale, out var repository) &&
               repository.TryGetDefinition(key, out definition);
    }

    public bool TryGetDestinyHistoricalDefinition(
        BungieLocales locale,
        string key,
        out DestinyHistoricalStatsDefinition statsDefinition)
    {
        statsDefinition = default;
        return _localisedRepositories.TryGetValue(locale, out var repository) &&
               repository.TryGetHistoricalStatsDefinition(key, out statsDefinition);
    }

    public IEnumerable<DestinyHistoricalStatsDefinition> GetAllHistoricalStatsDefinitions(
        BungieLocales locale)
    {
        return _localisedRepositories.TryGetValue(locale, out var repository)
            ? repository.GetAllHistoricalStats
            : null;
    }

    public bool AddDestinyHistoricalDefinition(
        BungieLocales locale,
        DestinyHistoricalStatsDefinition statsDefinition)
    {
        return _localisedRepositories.TryGetValue(locale, out var repository) &&
               repository.AddDestinyHistoricalStatsDefinition(statsDefinition);
    }

    public IEnumerable<T> Search<T>(
        BungieLocales locale,
        Func<IDestinyDefinition, bool> predicate) where T : IDestinyDefinition
    {
        return _localisedRepositories.TryGetValue(locale, out var repository)
            ? repository.Search<T>(predicate)
            : null;
    }

    public IEnumerable<T> GetAll<T>(BungieLocales locale = BungieLocales.EN) where T : IDestinyDefinition
    {
        return _localisedRepositories.TryGetValue(locale, out var repository)
            ? repository.GetAll<T>()
            : null;
    }

    public bool AddDefinition<T>(BungieLocales locale, T definition) where T : IDestinyDefinition
    {
        return _localisedRepositories.TryGetValue(locale, out var repository) &&
               repository.AddDefinition(definition);
    }

    public bool AddDefinition(BungieLocales locale, IDestinyDefinition definition)
    {
        return _localisedRepositories.TryGetValue(locale, out var repository) &&
               repository.AddDefinition(definition);
    }

    public IEnumerable<BungieLocales> AvailableLocales => _localisedRepositories.Select(x => x.Key);
    public IEnumerable<DefinitionsEnum> AllowedDefinitions => _configuration.AllowedDefinitions;

    public void Clear()
    {
        foreach (var repository in _localisedRepositories) repository.Value.Clear();
    }
}