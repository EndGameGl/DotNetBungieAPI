using BungieNetCoreAPI.Clients;
using BungieNetCoreAPI.Destiny.Definitions;
using BungieNetCoreAPI.Repositories;
using BungieNetCoreAPI.Services;
using System;
using Unity;

namespace BungieNetCoreAPI
{
    public struct DefinitionHashPointer<T> where T: DestinyDefinition
    {
        private readonly ILocalisedDefinitionsCacheRepository _repository;
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
                    if (_repository.TryGetDestinyDefinition(DefinitionName, Hash.Value, Locale, out var definition))
                    {
                        return (T)definition;
                    }
                    else if (BungieClient.Configuration.Settings.TryDownloadMissingDefinitions)
                    {
                        definition = BungieClient.Platform.GetDestinyEntityDefinition<T>(DefinitionName, Hash.Value).GetAwaiter().GetResult();
                        _repository.AddDefinitionToCache(DefinitionName, definition, Locale);
                        return (T)definition;
                    }
                    else
                        throw new Exception($"No {DefinitionName} was found with {Hash} hash.");
                }
                else
                    throw new Exception("Invalid hash value.");
            }
        }
        public DefinitionHashPointer(uint? hash, string definitionName)
        {
            Hash = hash;
            DefinitionName = definitionName;
            _repository = UnityContainerFactory.Container.Resolve<ILocalisedDefinitionsCacheRepository>();
            Locale = _repository.CurrentLocaleLoadContext;
        }
        public bool TryGetDefinition(out T definition)
        {
            definition = default;
            if (HasValidHash)
            {
                if (_repository.TryGetDestinyDefinition(DefinitionName, Hash.Value, Locale, out var foundDefinition))
                {
                    definition = (T)foundDefinition;
                    return true;
                }
                else if (BungieClient.Configuration.Settings.TryDownloadMissingDefinitions)
                {
                    definition = BungieClient.Platform.GetDestinyEntityDefinition<T>(DefinitionName, Hash.Value).GetAwaiter().GetResult();
                    _repository.AddDefinitionToCache(DefinitionName, definition, Locale);
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
        public override string ToString()
        {
            return $"{{{DefinitionName} - {Hash} - {Locale}}}";
        }
    }
}
