using BungieNetCoreAPI.Destiny;
using BungieNetCoreAPI.Destiny.Definitions;
using BungieNetCoreAPI.Destiny.Definitions.Activities;
using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using BungieNetCoreAPI.Logging;
using BungieNetCoreAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity;

namespace BungieNetCoreAPI.Repositories
{
    public class LocalisedDefinitionsCacheRepository : ILocalisedDefinitionsCacheRepository
    {
        private string _currentLocaleLoadContext;
        private readonly ILogger _logger;
        private readonly IConfigurationService _configs;
        public string CurrentLocaleLoadContext => string.IsNullOrWhiteSpace(_currentLocaleLoadContext) ? "en" : _currentLocaleLoadContext;

        private Dictionary<string, DefinitionCacheRepository> _localisedRepositories;

        public LocalisedDefinitionsCacheRepository()
        {
            _logger = UnityContainerFactory.Container.Resolve<ILogger>();
            _configs = UnityContainerFactory.Container.Resolve<IConfigurationService>();
        }

        public void Initialize(DestinyLocales[] locales)
        {
            _logger.Log("Initializing Global Definitions Cache Repository", LogType.Info);
            _localisedRepositories = new Dictionary<string, DefinitionCacheRepository>();
            foreach (var locale in locales)
            {
                var localeAsString = locale.LocaleToString();
                _localisedRepositories.Add(localeAsString, new DefinitionCacheRepository(localeAsString, _configs.Settings.LoadMode, _configs.Settings.DefinitionLoadRules));
            }
        }
        public void LoadAllDataFromDisk(string localManifestPath, DestinyManifest manifest)
        {
            foreach (var repo in _localisedRepositories.Values)
            {
                repo.LoadDataFromFiles(_configs.Settings.LoadMode, localManifestPath, manifest);
            }
        }
        public void AddDefinitionToCache(string definitionName, DestinyDefinition defValue, string locale)
        {
            _localisedRepositories[locale].Add(definitionName, defValue);
        }
        public bool TryGetDestinyDefinition(string definitionName, uint key, string locale, out DestinyDefinition definition)
        {
            return _localisedRepositories[locale].TryGetDefinition(definitionName, key, out definition);
        }
        public IEnumerable<T> Search<T>(string locale, Func<DestinyDefinition, bool> predicate) where T : DestinyDefinition
        {
            return _localisedRepositories[locale].Search<T>(predicate);
        }
        public IEnumerable<T> GetAll<T>(string locale)
        {
            return _localisedRepositories[locale].GetAll<T>();
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
        public List<DestinyInventoryItemDefinition> GetItemsWithTrait(string locale, string trait)
        {
            return _localisedRepositories[locale].Search<DestinyInventoryItemDefinition>(x =>
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
        public List<DestinyInventoryItemDefinition> GetSacks(string locale)
        {
            return _localisedRepositories[locale]
                .Search<DestinyInventoryItemDefinition>(x => (x as DestinyInventoryItemDefinition).Sack != null)
                .ToList();
        }
        public List<DestinyActivityDefinition> SearchActivitiesByName(string locale, string name)
        {
            return _localisedRepositories[locale]
                .Search<DestinyActivityDefinition>(x => (x as DestinyActivityDefinition).DisplayProperties.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        public void SetLocaleContext(string locale)
        {
            _currentLocaleLoadContext = locale;
        }
        public void ResetLocaleContext()
        {
            _currentLocaleLoadContext = string.Empty;
        }
    }
}
