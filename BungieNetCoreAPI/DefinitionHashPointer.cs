using BungieNetCoreAPI.Destiny.Definitions;
using System;
using System.Threading.Tasks;

namespace BungieNetCoreAPI
{
    public struct DefinitionHashPointer<T> where T: DestinyDefinition
    {
        public uint Hash { get; }
        private string _definitionName { get; }
        public DefinitionHashPointer(uint hash, string definitionName)
        {
            Hash = hash;
            _definitionName = definitionName;
        }
        public async Task<T> GetDefinition()
        {
            if (DefinitionsCacheRepository.TryGetDestinyDefinition(_definitionName, Hash, out var definition))
            {
                return (T)definition;
            }
            else
                throw new Exception();
        }
    }
}
