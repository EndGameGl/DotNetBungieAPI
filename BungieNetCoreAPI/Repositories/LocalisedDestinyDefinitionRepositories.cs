using NetBungieAPI.Destiny;
using NetBungieAPI.Destiny.Definitions;
using NetBungieAPI.Destiny.Definitions.Activities;
using NetBungieAPI.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Logging;
using NetBungieAPI.Services;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using Unity;

namespace NetBungieAPI.Repositories
{
    public class LocalisedDestinyDefinitionRepositories : ILocalisedDestinyDefinitionRepositories
    {
        private DestinyLocales? _currentLocaleLoadContext;
        private readonly ILogger _logger;
        private readonly IConfigurationService _configs;
        private readonly IDefinitionAssemblyData _assemblyData;

        public DestinyLocales CurrentLocaleLoadContext => _currentLocaleLoadContext == null ? DestinyLocales.EN : _currentLocaleLoadContext.Value;

        private ConcurrentDictionary<DestinyLocales, DestinyDefinitionsRepository> _localisedRepositories;

        public LocalisedDestinyDefinitionRepositories(ILogger logger, IConfigurationService config, IDefinitionAssemblyData assemblyData)
        {
            _logger = logger;
            _configs = config;
            _assemblyData = assemblyData;
        }

        public void Initialize(DestinyLocales[] locales)
        {
            _logger.Log("Initializing Global Definitions Cache Repository", LogType.Info);
            _localisedRepositories = new ConcurrentDictionary<DestinyLocales, DestinyDefinitionsRepository>(_configs.Settings.AppConcurrencyLevel, locales.Length);
            foreach (var locale in locales)
            {
                _localisedRepositories.TryAdd(
                    key: locale,
                    value: new DestinyDefinitionsRepository(
                        locale: locale,
                        assemblyData: _assemblyData,
                        configuration: _configs,
                        logger: _logger));
            }
        }
        public void LoadAllDataFromDisk(string localManifestPath, DestinyManifest manifest)
        {
            foreach (var repo in _localisedRepositories.Values)
            {
                SetLocaleContext(repo.Locale);
                repo.LoadDataFromFiles(localManifestPath, manifest);
                ResetLocaleContext();
            }
            if (_configs.Settings.PremapDefinitionPointers)
            {
                _logger.Log("Premapping pointers...", LogType.Info);
                foreach (var repo in _localisedRepositories.Select(x => x.Value))
                {
                    repo.PremapPointers();
                }
                _logger.Log("Finished premapping pointers!", LogType.Info);
            }
        }
        public void AddDefinitionToCache(DefinitionsEnum definitionType, IDestinyDefinition defValue, DestinyLocales locale)
        {
            _localisedRepositories[locale].AddDefinition(definitionType, defValue);
        }
        public bool TryGetDestinyDefinition(DefinitionsEnum definitionType, uint key, DestinyLocales locale, out IDestinyDefinition definition)
        {
            return _localisedRepositories[locale].TryGetDefinition(definitionType, key, out definition);
        }
        public bool TryGetDestinyDefinition<T>(DefinitionsEnum definitionType, uint key, DestinyLocales locale, out T definition) where T : IDestinyDefinition
        {
            return _localisedRepositories[locale].TryGetDefinition(definitionType, key, out definition);
        }
        public IEnumerable<T> Search<T>(DefinitionsEnum definitionType, DestinyLocales locale, Func<IDestinyDefinition, bool> predicate) where T : IDestinyDefinition
        {
            return _localisedRepositories[locale].Search<T>(definitionType, predicate);
        }
        public IEnumerable<T> GetAll<T>(DefinitionsEnum definitionType, DestinyLocales locale) where T : IDestinyDefinition
        {
            return _localisedRepositories[locale].GetAll<T>(definitionType);
        }
        public IEnumerable<T> GetAll<T>(DestinyLocales locale = DestinyLocales.EN) where T : IDestinyDefinition
        {
            return _localisedRepositories[locale].GetAll<T>(_assemblyData.TypeToEnumMapping[typeof(T)]);
        }

        /// <summary>
        /// Gets all items with given trait
        /// <para>Possible traits:</para>
        /// <para>item_type: weapon, armor, ghost_hologram, boost, emote, finisher, currency, engram, shader, emblem, consumable, light_subclass, ghost,
        /// weapon_ornament, ship, vehicle, aura, dark_subclass, bounty</para>
        /// <para>armor_type: head, chest, arms, legs, class</para>
        /// <para>weapon_type: rocket_launcher, sniper_rifle, grenade_launcher, pulse_rifle, shotgun, auto_rifle, sidearm, bow, fusion_rifle, machinegun, 
        /// trace_rifle, hand_cannon, scout_rifle, submachinegun, sword, linear_fusion_rifle</para>
        /// <para>foundry: suros, fotc, hakke, omolon, veist, field_forged, tex_mechanica, daito</para>
        /// <para>faction: new_monarchy, trials, vanguard, iron_banner, crucible, dead_orbit, future_war_cult, gambit, mamba, commando</para>
        /// <para>inventory_filtering: quest, bounty, featured</para>
        /// <para>quest: new_light, seasonal, playlists, past, exotic, current_release</para>
        /// <para>mamba_role: collector, defender, invader, killer</para>
        /// </summary>
        /// <param name="trait">Item trait to search for</param>
        /// <returns></returns>
        public List<DestinyInventoryItemDefinition> GetItemsWithTrait(DestinyLocales locale, string trait)
        {
            return _localisedRepositories[locale].Search<DestinyInventoryItemDefinition>(DefinitionsEnum.DestinyInventoryItemDefinition, x =>
            {
                var traits = (x as DestinyInventoryItemDefinition).TraitIds;
                if (traits == null)
                    return false;
                else
                {
                    return traits.Contains(trait);
                }
            }).ToList();
        }
        public List<DestinyInventoryItemDefinition> GetSacks(DestinyLocales locale)
        {
            return _localisedRepositories[locale]
                .Search<DestinyInventoryItemDefinition>(DefinitionsEnum.DestinyInventoryItemDefinition, x => (x as DestinyInventoryItemDefinition).Sack != null)
                .ToList();
        }
        public List<DestinyActivityDefinition> SearchActivitiesByName(DestinyLocales locale, string name)
        {
            return _localisedRepositories[locale]
                .Search<DestinyActivityDefinition>(DefinitionsEnum.DestinyActivityDefinition, x => (x as DestinyActivityDefinition).DisplayProperties.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        public void SetLocaleContext(DestinyLocales locale)
        {
            _currentLocaleLoadContext = locale;
        }
        public void ResetLocaleContext()
        {
            _currentLocaleLoadContext = null;
        }
        public string FetchJSONFromDB(DestinyLocales locale, DefinitionsEnum definitionType, uint hash)
        {
            if (!_assemblyData.DefinitionsToTypeMapping[definitionType].AttributeData.Sources.HasFlag(Attributes.DefinitionSources.SQLite))
                throw new Exception("This definition type isn't present in SQLite database.");

            var manifest = StaticUnityContainer.GetManifestUpdateHandler().CurrentManifest;
            var mobileWorldContentPathsLocalePath = Path.GetFileName(manifest.MobileWorldContentPaths[locale.LocaleToString()]);
            var connectionString = @$"Data Source={_configs.Settings.VersionsRepositoryPath}\\{manifest.Version}\\MobileWorldContent\\{locale.LocaleToString()}\\{mobileWorldContentPathsLocalePath}; Version=3;";
            string result = string.Empty;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM {definitionType.ToString()} WHERE id={hash.ToInt32()}";
                SQLiteCommand command = new SQLiteCommand
                {
                    Connection = connection,
                    CommandText = query
                };
                try
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var byteArray = (byte[])reader["json"];
                        result = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
                    }
                }
                catch (Exception e)
                {
                    _logger.Log(e.Message, LogType.Error);
                }
                connection.Close();
            }
            return result;
        }
    }
}
