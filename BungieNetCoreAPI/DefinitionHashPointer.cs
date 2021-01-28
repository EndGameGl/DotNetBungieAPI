using BungieNetCoreAPI.Clients;
using BungieNetCoreAPI.Destiny;
using BungieNetCoreAPI.Destiny.Definitions;
using BungieNetCoreAPI.Repositories;
using BungieNetCoreAPI.Services;
using System;
using System.Threading.Tasks;
using Unity;

namespace BungieNetCoreAPI
{
    /// <summary>
    /// Struct that points to a certain definition in database
    /// </summary>
    /// <typeparam name="T">Destiny definition type</typeparam>
    public class DefinitionHashPointer<T> : IDeepEquatable<DefinitionHashPointer<T>> where T : IDestinyDefinition
    {
        internal bool Exists;
        internal T m_value;
        private readonly ILocalisedManifestDefinitionRepositories _repository;

        /// <summary>
        /// Definition hash, guaranteed to be unique across it's type.
        /// </summary>
        public uint? Hash { get; }
        /// <summary>
        /// Definition type enum value
        /// </summary>
        public DefinitionsEnum DefinitionEnumType { get; }
        /// <summary>
        /// Definition locale
        /// </summary>
        public DestinyLocales Locale { get; }
        /// <summary>
        /// Whether this hash isn't empty.
        /// </summary>
        public bool HasValidHash => Hash.HasValue && Hash.Value > 0;
        /// <summary>
        /// Fetches value from this pointer
        /// </summary>
        public T Value
        {
            get
            {
                if (m_value != null && Exists)
                    return m_value;
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
            internal set
            {
                m_value = value;
            }
        }

        /// <summary>
        /// Struct .ctor
        /// </summary>
        /// <param name="hash">Definition hash</param>
        /// <param name="type">Definition type</param>
        public DefinitionHashPointer(uint? hash, DefinitionsEnum type)
        {
            m_value = default;
            Exists = false;
            Hash = hash;
            DefinitionEnumType = type;
            _repository = UnityContainerFactory.Container.Resolve<ILocalisedManifestDefinitionRepositories>();
            Locale = _repository.CurrentLocaleLoadContext;
        }

        internal DefinitionHashPointer(uint? hash, DefinitionsEnum type, DestinyLocales locale, T def = default, ILocalisedManifestDefinitionRepositories repo = null)
        {
            if (def != null)
            {
                m_value = def;
                Exists = true;
            }
            Hash = hash;
            DefinitionEnumType = type;
            if (repo != null)
                _repository = repo;
            else
                _repository = UnityContainerFactory.Container.Resolve<ILocalisedManifestDefinitionRepositories>();
            Locale = locale;
        }

        /// <summary>
        /// Tries to get definition from local cache/API
        /// </summary>
        /// <param name="definition">Found definition</param>
        /// <returns>True, if found, False otherwise</returns>
        public bool TryGetDefinition(out T definition)
        {
            definition = default;
            if (m_value != null)
            {
                definition = m_value;
                return true;
            }
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

        internal void TryMapValue()
        {
            if (m_value != null && Exists)
                return;
            if (HasValidHash)
            {
                if (_repository.TryGetDestinyDefinition<T>(DefinitionEnumType, Hash.Value, Locale, out var definition))
                {
                    m_value = definition;
                    Exists = true;
                }
            }
        }
        public bool DeepEquals(DefinitionHashPointer<T> other)
        {
            return other != null &&
                   Hash == other.Hash &&
                   DefinitionEnumType == other.DefinitionEnumType &&
                   Locale == other.Locale;
        }
    }
}
