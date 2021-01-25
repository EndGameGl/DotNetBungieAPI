using BungieNetCoreAPI.Clients;
using BungieNetCoreAPI.Destiny;
using BungieNetCoreAPI.Destiny.Definitions;
using BungieNetCoreAPI.Repositories;
using BungieNetCoreAPI.Services;
using System;
using Unity;

namespace BungieNetCoreAPI
{
    public struct DefinitionHashPointer<T> where T: IDestinyDefinition
    {
        private readonly ILocalisedManifestDefinitionRepositories _repository;
        public uint? Hash { get; }
        public DefinitionsEnum DefinitionEnumType { get; }
        public DestinyLocales Locale { get; }
        public bool HasValidHash => Hash.HasValue && Hash.Value > 0;
        public T Value
        {
            get
            {
                if (HasValidHash)
                {
                    if (_repository.TryGetDestinyDefinition<T>(DefinitionEnumType, Hash.Value, Locale, out var definition))
                    {
                        return definition;
                    }
                    else if (BungieClient.Configuration.Settings.TryDownloadMissingDefinitions)
                    {
                        definition = BungieClient.Platform.GetDestinyEntityDefinition<T>(DefinitionEnumType, Hash.Value).GetAwaiter().GetResult();
                        _repository.AddDefinitionToCache(DefinitionEnumType, definition, Locale);
                        return definition;
                    }
                    else
                        throw new Exception($"No {DefinitionEnumType} was found with {Hash} hash.");
                }
                else
                    throw new Exception("Invalid hash value.");
            }
        }
        public DefinitionHashPointer(uint? hash, DefinitionsEnum type)
        {
            Hash = hash;
            DefinitionEnumType = type;
            _repository = UnityContainerFactory.Container.Resolve<ILocalisedManifestDefinitionRepositories>();
            Locale = _repository.CurrentLocaleLoadContext;
        }
        public bool TryGetDefinition(out T definition)
        {
            definition = default;
            if (HasValidHash)
            {
                if (_repository.TryGetDestinyDefinition<T>(DefinitionEnumType, Hash.Value, Locale, out var foundDefinition))
                {
                    definition = foundDefinition;
                    return true;
                }
                else if (BungieClient.Configuration.Settings.TryDownloadMissingDefinitions)
                {
                    definition = BungieClient.Platform.GetDestinyEntityDefinition<T>(DefinitionEnumType, Hash.Value).GetAwaiter().GetResult();
                    _repository.AddDefinitionToCache(DefinitionEnumType, definition, Locale);
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
            return $"{{{DefinitionEnumType} - {Hash} - {Locale}}}";
        }
    }
}
