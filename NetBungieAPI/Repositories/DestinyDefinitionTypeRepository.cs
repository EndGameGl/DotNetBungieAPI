﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using NetBungieAPI.Models.Destiny;

namespace NetBungieAPI.Repositories
{
    /// <summary>
    ///     Repository for any <see cref="IDestinyDefinition" />
    /// </summary>
    public class DestinyDefinitionTypeRepository
    {
        private readonly ConcurrentDictionary<uint, IDestinyDefinition> _definitions;

        public DestinyDefinitionTypeRepository(Type storedType, int concurrencyLevel, int capacity = 31)
        {
            Type = storedType;
            _definitions = new ConcurrentDictionary<uint, IDestinyDefinition>(concurrencyLevel, capacity);
        }

        public Type Type { get; }

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

        public bool TryGetDefinition(uint hash, out IDestinyDefinition definition)
        {
            return _definitions.TryGetValue(hash, out definition);
        }

        public bool TryGetDefinition<T>(uint hash, out T definition) where T : IDestinyDefinition
        {
            definition = default;
            if (_definitions.TryGetValue(hash, out var item))
            {
                definition = (T) item;
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"{Type.Name}: {_definitions.Count} entities.";
        }

        public void MapValues()
        {
            foreach (var definition in EnumerateValues()) definition.MapValues();
        }
    }
}