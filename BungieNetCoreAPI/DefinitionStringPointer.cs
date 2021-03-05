//using BungieNetCoreAPI.Clients;
//using BungieNetCoreAPI.Destiny;
//using BungieNetCoreAPI.Repositories;
//using BungieNetCoreAPI.Services;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BungieNetCoreAPI
//{
//    public class DefinitionStringPointer<T> : IDeepEquatable<DefinitionStringPointer<T>>
//    {
//        internal bool Exists;
//        internal T m_value;
//        private readonly ILocalisedManifestDefinitionRepositories _repository;

//        /// <summary>
//        /// Definition hash, guaranteed to be unique across it's type.
//        /// </summary>
//        public string ID { get; }
//        /// <summary>
//        /// Definition type enum value
//        /// </summary>
//        public DefinitionsEnum DefinitionEnumType { get; }
//        /// <summary>
//        /// Definition locale
//        /// </summary>
//        public DestinyLocales Locale { get; }
//        /// <summary>
//        /// Whether this hash isn't empty.
//        /// </summary>
//        public bool HasValidID => !string.IsNullOrWhiteSpace(ID);
//        /// <summary>
//        /// Fetches value from this pointer
//        /// </summary>
//        public T Value
//        {
//            get
//            {
//                if (m_value != null && Exists)
//                    return m_value;
//                if (HasValidID)
//                {
//                    if (_repository.TryGetDestinyDefinition<T>(DefinitionEnumType, ID.Value, Locale, out var definition))
//                    {
//                        return definition;
//                    }
//                    else if (BungieClient.Configuration.Settings.TryDownloadMissingDefinitions)
//                    {
//                        definition = BungieClient.Platform.GetDestinyEntityDefinition<T>(DefinitionEnumType, ID.Value).GetAwaiter().GetResult();
//                        _repository.AddDefinitionToCache(DefinitionEnumType, definition, Locale);
//                        return definition;
//                    }
//                    else
//                        throw new Exception($"No {DefinitionEnumType} was found with {ID} hash.");
//                }
//                else
//                    throw new Exception("Invalid hash value.");
//            }
//            internal set
//            {
//                m_value = value;
//            }
//        }

//        /// <summary>
//        /// Class .ctor
//        /// </summary>
//        /// <param name="id">Definition hash</param>
//        /// <param name="type">Definition type</param>
//        public DefinitionStringPointer(string id, DefinitionsEnum type)
//        {
//            m_value = default;
//            Exists = false;
//            ID = id;
//            DefinitionEnumType = type;
//            _repository = StaticUnityContainer.GetDestinyDefinitionRepositories();
//            Locale = _repository.CurrentLocaleLoadContext;
//        }
//        internal DefinitionStringPointer(string id, DefinitionsEnum type, DestinyLocales locale, T def = default, ILocalisedManifestDefinitionRepositories repo = null)
//        {
//            if (def != null)
//            {
//                m_value = def;
//                Exists = true;
//            }
//            ID = id;
//            DefinitionEnumType = type;
//            if (repo != null)
//                _repository = repo;
//            else
//                _repository = StaticUnityContainer.GetDestinyDefinitionRepositories();
//            Locale = locale;
//        }

//        /// <summary>
//        /// Tries to get definition from local cache/API
//        /// </summary>
//        /// <param name="definition">Found definition</param>
//        /// <returns>True, if found, False otherwise</returns>
//        public bool TryGetDefinition(out T definition)
//        {
//            definition = default;
//            if (m_value != null)
//            {
//                definition = m_value;
//                return true;
//            }
//            if (HasValidID)
//            {
//                if (_repository.TryGetDestinyDefinition<T>(DefinitionEnumType, ID, Locale, out var foundDefinition))
//                {
//                    definition = foundDefinition;
//                    return true;
//                }
//                else if (BungieClient.Configuration.Settings.TryDownloadMissingDefinitions)
//                {
//                    definition = BungieClient.Platform.GetDestinyEntityDefinition<T>(DefinitionEnumType, ID).GetAwaiter().GetResult();
//                    _repository.AddDefinitionToCache(DefinitionEnumType, definition, Locale);
//                    return true;
//                }
//                else
//                    return false;
//            }
//            else
//                return false;
//        }
//        public override string ToString()
//        {
//            return $"{{{DefinitionEnumType} - {ID} - {Locale}}}";
//        }

//        internal void TryMapValue()
//        {
//            if (m_value != null && Exists)
//                return;
//            if (HasValidID)
//            {
//                if (_repository.TryGetDestinyDefinition<T>(DefinitionEnumType, ID, Locale, out var definition))
//                {
//                    m_value = definition;
//                    Exists = true;
//                }
//            }
//        }
//        public bool DeepEquals(DefinitionStringPointer<T> other)
//        {
//            return other != null &&
//                   ID == other.ID &&
//                   DefinitionEnumType == other.DefinitionEnumType &&
//                   Locale == other.Locale;
//        }
//    }
//}
