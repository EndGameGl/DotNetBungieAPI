using BungieNetCoreAPI.Destiny.Definitions;
using System;

namespace BungieNetCoreAPI
{
    public struct DefinitionHashPointer<T> where T: DestinyDefinition
    {
        public uint? Hash { get; }
        public string DefinitionName { get; }
        public string Locale { get; }
        public bool HasValidHash => Hash.HasValue && Hash.Value > 0;
        public T Value
        {
            get
            {
                if (HasValidHash)
                {
                    if (GlobalDefinitionsCacheRepository.TryGetDestinyDefinition(DefinitionName, Hash.Value, Locale, out var definition))
                    {
                        return (T)definition;
                    }
                    else
                        throw new Exception($"No {DefinitionName} was found with {Hash} hash.");
                }
                else
                    throw new Exception("Invalid hash value.");
            }
        }
        public DefinitionHashPointer(uint? hash, string definitionName, string locale)
        {
            Hash = hash;
            DefinitionName = definitionName;
            Locale = locale;
        }
        public bool TryGetDefinition(out T definition)
        {
            definition = default;
            if (HasValidHash)
            {
                if (GlobalDefinitionsCacheRepository.TryGetDestinyDefinition(DefinitionName, Hash.Value, Locale, out var foundDefinition))
                {
                    definition = (T)foundDefinition;
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
    }
}
