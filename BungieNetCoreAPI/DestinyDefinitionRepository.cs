using BungieNetCoreAPI.Destiny.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BungieNetCoreAPI
{
    public class DestinyDefinitionRepository
    {
        private Dictionary<uint, DestinyDefinition> _definitions;
        public Type Type { get; }
        public DestinyDefinitionRepository(Type type)
        {
            _definitions = new Dictionary<uint, DestinyDefinition>();
            Type = type;
        }
        public bool Add (DestinyDefinition item)
        {
            if (Type.IsInstanceOfType(item))
            {
                if (!_definitions.ContainsKey(item.Hash))
                {
                    _definitions.Add(item.Hash, item);
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
        public bool TryGetDefinition(uint key, out DestinyDefinition definition)
        {
            definition = null;
            if (_definitions.TryGetValue(key, out definition))
                return true;
            else
                return false;
        }
        public List<DestinyDefinition> GetAllAsList()
        {
            return _definitions.Values.ToList();
        }
        public bool RemoveByHash(uint key)
        {
            return _definitions.Remove(key);
        }
    }
}
