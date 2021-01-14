using BungieNetCoreAPI.Destiny.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BungieNetCoreAPI.Repositories
{
    /// <summary>
    /// Repository for any <see cref="DestinyDefinition"/>
    /// </summary>
    /// <typeparam name="T">More specific type of <see cref="DestinyDefinition"/></typeparam>
    public class DestinyDefinitionRepository<T> : IDestinyCacheRepository where T : DestinyDefinition
    {
        private Dictionary<uint, T> _definitions;
        public Type DefinitionType { get; }
        public DestinyDefinitionRepository()
        {
            DefinitionType = typeof(T);
            _definitions = new Dictionary<uint, T>();
        }
        public bool Add(DestinyDefinition definition)
        {
            if (DefinitionType.IsInstanceOfType(definition))
            {
                if (!_definitions.ContainsKey(definition.Hash))
                {
                    _definitions.Add(definition.Hash, (T)definition);
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
        public IEnumerable<DestinyDefinition> Where(Func<DestinyDefinition, bool> predicate)
        {
            return _definitions.Values.Where(predicate);
        }
        public IEnumerable<DestinyDefinition> GetAll()
        {
            return _definitions.Values;
        }
        public bool Remove(uint hash)
        {
            return _definitions.Remove(hash);
        }
        public bool TryGetDefinition(uint hash, out DestinyDefinition definition)
        {
            _definitions.TryGetValue(hash, out var item);
            definition = item;
            return definition != null;
        }
    }
}
