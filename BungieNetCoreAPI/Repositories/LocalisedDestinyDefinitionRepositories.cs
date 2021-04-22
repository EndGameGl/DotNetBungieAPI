using NetBungieAPI.Logging;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Models.Destiny.Definitions.Activities;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Services.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBungieAPI.Models.Destiny.Config;
using NetBungieAPI.Providers;

namespace NetBungieAPI.Repositories
{
    public class LocalisedDestinyDefinitionRepositories : ILocalisedDestinyDefinitionRepositories
    {
        private BungieLocales? _currentLocaleLoadContext;
        private readonly ILogger _logger;
        private readonly IConfigurationService _configs;
        private readonly IDefinitionAssemblyData _assemblyData;

        public BungieLocales CurrentLocaleLoadContext => _currentLocaleLoadContext ?? BungieLocales.EN;
        public DefinitionProvider Provider { get; set; }
        private ConcurrentDictionary<BungieLocales, DestinyDefinitionsRepository> _localisedRepositories;

        public LocalisedDestinyDefinitionRepositories(ILogger logger, IConfigurationService config,
            IDefinitionAssemblyData assemblyData)
        {
            _logger = logger;
            _configs = config;
            _assemblyData = assemblyData;
        }

        public void Initialize(BungieLocales[] locales)
        {
            _logger.Log("Initializing Global Definitions Cache Repository", LogType.Info);
            _localisedRepositories =
                new ConcurrentDictionary<BungieLocales, DestinyDefinitionsRepository>(
                    _configs.Settings.DefinitionLoadingSettings.AppConcurrencyLevel, locales.Length);
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
                Task.Run(async () => await Provider.ReadDefinitionsToRepository(_configs.Settings.DefinitionLoadingSettings.AllowedDefinitions));
                ResetLocaleContext();
            }

            if (_configs.Settings.DefinitionLoadingSettings.PremapDefinitionPointers)
            {
                _logger.Log("Premapping pointers...", LogType.Info);
                foreach (var repo in _localisedRepositories.Select(x => x.Value))
                {
                    repo.PremapPointers();
                }

                _logger.Log("Finished premapping pointers!", LogType.Info);
            }
        }

        public void AddDefinitionToCache(DefinitionsEnum definitionType, IDestinyDefinition defValue,
            BungieLocales locale)
        {
            _localisedRepositories[locale].AddDefinition(definitionType, defValue);
        }

        public bool TryGetDestinyDefinition(DefinitionsEnum definitionType, uint key, BungieLocales locale,
            out IDestinyDefinition definition)
        {
            return _localisedRepositories[locale].TryGetDefinition(definitionType, key, out definition);
        }

        public bool TryGetDestinyDefinition<T>(DefinitionsEnum definitionType, uint key, BungieLocales locale,
            out T definition) where T : IDestinyDefinition
        {
            return _localisedRepositories[locale].TryGetDefinition(definitionType, key, out definition);
        }

        public IEnumerable<T> Search<T>(DefinitionsEnum definitionType, BungieLocales locale,
            Func<IDestinyDefinition, bool> predicate) where T : IDestinyDefinition
        {
            return _localisedRepositories[locale].Search<T>(definitionType, predicate);
        }

        public IEnumerable<T> GetAll<T>(DefinitionsEnum definitionType, BungieLocales locale)
            where T : IDestinyDefinition
        {
            return _localisedRepositories[locale].GetAll<T>(definitionType);
        }

        public IEnumerable<T> GetAll<T>(BungieLocales locale = BungieLocales.EN) where T : IDestinyDefinition
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
        public List<DestinyInventoryItemDefinition> GetItemsWithTrait(BungieLocales locale, string trait)
        {
            return _localisedRepositories[locale].Search<DestinyInventoryItemDefinition>(
                DefinitionsEnum.DestinyInventoryItemDefinition, x =>
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

        public List<DestinyInventoryItemDefinition> GetSacks(BungieLocales locale)
        {
            return _localisedRepositories[locale]
                .Search<DestinyInventoryItemDefinition>(DefinitionsEnum.DestinyInventoryItemDefinition,
                    x => (x as DestinyInventoryItemDefinition).Sack != null)
                .ToList();
        }

        public List<DestinyActivityDefinition> SearchActivitiesByName(BungieLocales locale, string name)
        {
            return _localisedRepositories[locale]
                .Search<DestinyActivityDefinition>(DefinitionsEnum.DestinyActivityDefinition,
                    x => (x as DestinyActivityDefinition).DisplayProperties.Name.Contains(name,
                        StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public void SetLocaleContext(BungieLocales locale)
        {
            _currentLocaleLoadContext = locale;
        }

        public void ResetLocaleContext()
        {
            _currentLocaleLoadContext = null;
        }

        public string FetchJSONFromDB(BungieLocales locale, DefinitionsEnum definitionType, uint hash)
        {
            return Provider.ReadDefinitionAsJson(definitionType, hash, locale).Result;
        }

        public bool AddDefinition(DefinitionsEnum definitionType, BungieLocales locale, IDestinyDefinition definition)
        {
            return _localisedRepositories[locale].AddDefinition(definitionType, definition);
        }
    }
}