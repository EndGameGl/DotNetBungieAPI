using BungieNetCoreAPI.Destiny.Definitions;
using System;
using System.Threading.Tasks;

namespace BungieNetCoreAPI
{
    public struct DefinitionHashPointer<T> where T: DestinyDefinition
    {
        public uint? Hash { get; }
        public string DefinitionName { get; }
        public string Locale { get; }
        public bool HasValue => Hash.HasValue && Hash.Value > 0;
        public T Value
        {
            get
            {
                if (HasValue)
                {
                    if (GlobalDefinitionsCacheRepository.TryGetDestinyDefinition(DefinitionName, Hash.Value, Locale, out var definition))
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
        public DefinitionHashPointer(uint? hash, string definitionName, string locale)
        {
            Hash = hash;
            DefinitionName = definitionName;
            Locale = locale;
        }
        public async Task<T> GetDefinition()
        {
            if (HasValue)
            {
                if (GlobalDefinitionsCacheRepository.TryGetDestinyDefinition(DefinitionName, Hash.Value, Locale, out var definition))
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
