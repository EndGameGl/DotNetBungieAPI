﻿using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using DotNetBungieAPI.Extensions;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny;
using DotNetBungieAPI.Models.Destiny.Definitions.HistoricalStats;
using DotNetBungieAPI.Service.Abstractions;
using DotNetBungieAPI.Services.Implementations.ServiceConfigurations;
using Microsoft.Extensions.Logging;

namespace DotNetBungieAPI.Repositories;

/// <summary>
///     Repository class for storing and accessing all classes with <see cref="DestinyDefinitionAttribute" />
///     attribute
/// </summary>
internal sealed class DestinyDefinitionsRepository
{
    private readonly IDefinitionAssemblyData _assemblyData;

    private readonly ConcurrentDictionary<
        DefinitionsEnum,
        DestinyDefinitionTypeRepository
    > _definitionRepositories;
    private readonly ConcurrentDictionary<
        string,
        DestinyHistoricalStatsDefinition
    > _historicalStatsDefinitions;
    private readonly ILogger _logger;

    internal DestinyDefinitionsRepository(
        BungieLocales locale,
        IDefinitionAssemblyData assemblyData,
        ILogger logger,
        DefaultDestiny2DefinitionRepositoryConfiguration configuration
    )
    {
        _assemblyData = assemblyData;
        _logger = logger;
        Locale = locale;

        var definitionsLoaded = configuration.AllowedDefinitions.Count;
        var concurrencyLevel = configuration.AppConcurrencyLevel;

        _logger.LogDebug(
            "Initializing definitions repository with settings: Locale: {Locale}, Concurrency level: {ConcurrencyLevel}, Capacity: {DefinitionsLoaded}",
            Locale,
            concurrencyLevel,
            definitionsLoaded
        );

        _definitionRepositories = new ConcurrentDictionary<
            DefinitionsEnum,
            DestinyDefinitionTypeRepository
        >(concurrencyLevel, definitionsLoaded);
        foreach (var definition in configuration.AllowedDefinitions)
            _definitionRepositories.TryAdd(
                definition,
                new DestinyDefinitionTypeRepository(
                    _assemblyData.DefinitionsToTypeMapping[definition].DefinitionType,
                    concurrencyLevel
                )
            );

        _historicalStatsDefinitions = new ConcurrentDictionary<
            string,
            DestinyHistoricalStatsDefinition
        >(concurrencyLevel, 31);
    }

    /// <summary>
    ///     Locale of this repository
    /// </summary>
    public BungieLocales Locale { get; }

    public IEnumerable<DestinyHistoricalStatsDefinition> GetAllHistoricalStats =>
        _historicalStatsDefinitions.Select(x => x.Value);

    /// <summary>
    ///     Adds definition from repository, if possible
    /// </summary>
    /// <param name="definition"></param>
    /// <returns></returns>
    public bool AddDefinition(IDestinyDefinition definition)
    {
        return _definitionRepositories.TryGetValue(
                definition.DefinitionEnumValue,
                out var repository
            ) && repository.Add(definition);
    }

    public bool AddDestinyHistoricalStatsDefinition(DestinyHistoricalStatsDefinition definition)
    {
        return _historicalStatsDefinitions.TryAdd(definition.StatId, definition);
    }

    /// <summary>
    ///     Removes definition from repository, if possible
    /// </summary>
    /// <param name="definitionType"></param>
    /// <param name="hash"></param>
    /// <returns></returns>
    public bool RemoveDefinition(DefinitionsEnum definitionType, uint hash)
    {
        return _definitionRepositories.TryGetValue(definitionType, out var repository)
            && repository.Remove(hash);
    }

    public bool TryGetHistoricalStatsDefinition(
        string name,
        out DestinyHistoricalStatsDefinition val
    )
    {
        return _historicalStatsDefinitions.TryGetValue(name, out val);
    }

    /// <summary>
    ///     Gets definition from repository, if possible
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="hash"></param>
    /// <param name="definition"></param>
    /// <returns></returns>
    public bool TryGetDefinition<T>(uint hash, out T definition)
        where T : IDestinyDefinition
    {
        definition = default;
        if (
            _definitionRepositories.TryGetValue(
                DefinitionHashPointer<T>.EnumValue,
                out var repository
            )
        )
        {
            if (repository.TryGetDefinition<T>(hash, out var value))
            {
                definition = value;
                return definition != null;
            }

            return false;
        }

        return false;
    }

    /// <summary>
    ///     Gets definition from repository, if possible
    /// </summary>
    /// <param name="definitionType"></param>
    /// <param name="hash"></param>
    /// <param name="definition"></param>
    /// <returns></returns>
    public bool TryGetDefinition(
        DefinitionsEnum definitionType,
        uint hash,
        out IDestinyDefinition? definition
    )
    {
        definition = default;
        if (_definitionRepositories.TryGetValue(definitionType, out var repository))
        {
            if (repository.TryGetDefinition(hash, out definition))
                return definition != null;
            return false;
        }

        return false;
    }

    /// <summary>
    ///     Searches through repository with given predicate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public IEnumerable<T> Search<T>(Func<T, bool> predicate)
        where T : IDestinyDefinition
    {
        return _definitionRepositories.TryGetValue(
            DefinitionHashPointer<T>.EnumValue,
            out var repository
        )
            ? GetAll<T>().Where(predicate)
            : Enumerable.Empty<T>();
    }

    public IEnumerable<T> GetAll<T>()
        where T : IDestinyDefinition
    {
        return _definitionRepositories.TryGetValue(
            DefinitionHashPointer<T>.EnumValue,
            out var repository
        )
            ? repository.EnumerateValues().UnsafeCast<IDestinyDefinition, T>()
            : Enumerable.Empty<T>();
    }

    public void Clear()
    {
        foreach (var repository in _definitionRepositories.Values)
            repository.Clear();
        _historicalStatsDefinitions.Clear();
    }

    public void Clear(DefinitionsEnum definitionType)
    {
        foreach (var (type, repo) in _definitionRepositories.Where(x => x.Key == definitionType))
        {
            repo.Clear();
        }

        if (definitionType == DefinitionsEnum.DestinyHistoricalStatsDefinition)
            _historicalStatsDefinitions.Clear();
    }
}
