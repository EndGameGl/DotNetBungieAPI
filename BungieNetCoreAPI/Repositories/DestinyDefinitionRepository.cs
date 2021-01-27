using BungieNetCoreAPI.Destiny.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BungieNetCoreAPI.Repositories
{
    /// <summary>
    /// Repository for any <see cref="IDestinyDefinition"/>
    /// </summary>
    /// <typeparam name="T">More specific type of <see cref="IDestinyDefinition"/></typeparam>
    public class DestinyDefinitionRepository
    {
        public Type Type { get; }
        private Dictionary<uint, IDestinyDefinition> _definitions;
        public DestinyDefinitionRepository(Type storedType)
        {
            Type = storedType;
            _definitions = new Dictionary<uint, IDestinyDefinition>();
        }
        public bool Add(IDestinyDefinition definition)
        {
            if (!_definitions.ContainsKey(definition.Hash))
            {
                _definitions.Add(definition.Hash, definition);
                return true;
            }
            else
                return false;
        }
        public IEnumerable<IDestinyDefinition> Where(Func<IDestinyDefinition, bool> predicate)
        {
            return _definitions.Values.Where(predicate);
        }
        public IEnumerable<IDestinyDefinition> Enumerate()
        {
            return _definitions.Values.AsEnumerable();
        }
        public bool Remove(uint hash)
        {
            return _definitions.Remove(hash);
        }
        public bool TryGetDefinition<T>(uint hash, out T definition) where T : IDestinyDefinition
        {
            _definitions.TryGetValue(hash, out var item);
            definition = (T)item;
            return definition != null;
        }
        public void SortByIndex()
        {
            _definitions = _definitions.OrderBy(x => x.Value.Index).ToDictionary(x => x.Key, y => y.Value);
        }

        public override string ToString()
        {
            return $"{Type.Name}: {_definitions.Count} entities.";
        }
    }
}
