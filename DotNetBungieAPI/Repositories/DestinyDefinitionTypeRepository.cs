﻿using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using DotNetBungieAPI.Models;

namespace DotNetBungieAPI.Repositories;

/// <summary>
///     Repository for any <see cref="IDestinyDefinition" />
/// </summary>
[DebuggerDisplay("{DebuggerDisplay}")]
public class DestinyDefinitionTypeRepository
{
    private readonly ConcurrentDictionary<uint, IDestinyDefinition> _definitions;

    public DestinyDefinitionTypeRepository(Type storedType, int concurrencyLevel, int capacity = 31)
    {
        Type = storedType;
        _definitions = new ConcurrentDictionary<uint, IDestinyDefinition>(concurrencyLevel, capacity);
    }

    public Type Type { get; }

    private string DebuggerDisplay => $"{Type.Name}: {_definitions.Count} entities.";

    public bool Add(IDestinyDefinition definition)
    {
        return _definitions.TryAdd(definition.Hash, definition);
    }

    public bool Remove(uint hash)
    {
        return _definitions.TryRemove(hash, out _);
    }

    public IEnumerable<IDestinyDefinition> Where(Func<IDestinyDefinition, bool> predicate)
    {
        return EnumerateValues().Where(predicate);
    }

    public IEnumerable<IDestinyDefinition> EnumerateValues()
    {
        return _definitions.Select(x => x.Value);
    }

    public bool TryGetDefinition(uint hash, [NotNullWhen(true)] out IDestinyDefinition? definition)
    {
        return _definitions.TryGetValue(hash, out definition);
    }

    public bool TryGetDefinition<T>(uint hash, [NotNullWhen(true)] out T? definition)
        where T : class, IDestinyDefinition
    {
        definition = null;
        if (_definitions.TryGetValue(hash, out var item))
        {
            definition = Unsafe.As<IDestinyDefinition, T>(ref item);
            return true;
        }

        return false;
    }

    public void Clear()
    {
        _definitions.Clear();
    }
}
