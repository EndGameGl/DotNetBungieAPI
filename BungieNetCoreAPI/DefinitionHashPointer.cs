using BungieNetCoreAPI.Destiny.Definitions;
using System;
using System.Threading.Tasks;

namespace BungieNetCoreAPI
{
    public struct DefinitionHashPointer<T> where T: DestinyDefinition
    {
        public uint? Hash { get; }
        private string _definitionName { get; }
        public bool HasValue => Hash.HasValue;
        public DefinitionHashPointer(uint? hash, string definitionName)
        {
            Hash = hash;
            _definitionName = definitionName;
        }
        public async Task<T> GetDefinition()
        {
            if (HasValue)
            {
                if (GlobalDefinitionsCacheRepository.TryGetDestinyDefinition(_definitionName, Hash.Value, out var definition))
                {
                    return (T)definition;
                }
                else
                    throw new Exception("No definition was found.");
            }
            else
                throw new Exception("No hash value has been detected.");
        }
    }
}
