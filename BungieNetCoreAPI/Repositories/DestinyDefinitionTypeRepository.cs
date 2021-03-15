using NetBungieAPI.Destiny.Definitions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace NetBungieAPI.Repositories
{
    /// <summary>
    /// Repository for any <see cref="IDestinyDefinition"/>
    /// </summary>
    /// <typeparam name="T">More specific type of <see cref="IDestinyDefinition"/></typeparam>
    public class DestinyDefinitionTypeRepository
    {
        private ConcurrentDictionary<uint, IDestinyDefinition> _definitions;
        public Type Type { get; }
        public DestinyDefinitionTypeRepository(Type storedType, int concurrencyLevel, int capacity = 31)
        {
            Type = storedType;
            _definitions = new ConcurrentDictionary<uint, IDestinyDefinition>(concurrencyLevel, capacity);
        }
        public bool Add(IDestinyDefinition definition) => _definitions.TryAdd(definition.Hash, definition);
        public bool Remove(uint hash) => _definitions.TryRemove(hash, out _);
        public IEnumerable<IDestinyDefinition> Where(Func<IDestinyDefinition, bool> predicate) => EnumerateValues().Where(predicate);
        public IEnumerable<IDestinyDefinition> EnumerateValues() => _definitions.Select(x => x.Value);      
        public bool TryGetDefinition(uint hash, out IDestinyDefinition definition) => _definitions.TryGetValue(hash, out definition);
        public bool TryGetDefinition<T>(uint hash, out T definition) where T : IDestinyDefinition
        {
            definition = default;
            if (_definitions.TryGetValue(hash, out var item))
            {
                definition = (T)item;
                return true;
            }
            else
                return false;
        }
        public override string ToString()
        {
            return $"{Type.Name}: {_definitions.Count} entities.";
        }
        public void MapValues()
        {
            foreach (var definition in EnumerateValues())
            {
                definition.MapValues();
            }
        }
    }
}
