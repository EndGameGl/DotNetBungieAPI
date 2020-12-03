using BungieNetCoreAPI.Destiny;
using BungieNetCoreAPI.Destiny.Definitions;
using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using System;
using System.Collections.Generic;

namespace BungieNetCoreAPI
{
    public static class GlobalDefinitionsCacheRepository
    {
        private static DefinitionCacheRepository cache = new DefinitionCacheRepository("en");
        public static void LoadAllDataFromDisk(string localManifestPath, DestinyManifest manifest)
        {
            cache.LoadDataFromDisk(localManifestPath, manifest);
        }
        public static void AddDefinitionToCache(string definitionName, DestinyDefinition defValue)
        {
            cache.Add(definitionName, defValue);
        }
        public static bool TryGetDestinyDefinition(string definitionName, uint key, out DestinyDefinition definition)
        {
            return cache.TryGetDefinition(definitionName, key, out definition);
        }
        public static IEnumerable<T> Search<T>(Func<DestinyDefinition, bool> predicate) where T : DestinyDefinition
        {
            return cache.Search<T>(predicate);
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
        public static IEnumerable<DestinyInventoryItemDefinition> GetItemsWithTrait(string trait)
        {
            return cache.Search<DestinyInventoryItemDefinition>(x =>
            {
                var traits = (x as DestinyInventoryItemDefinition).TraitIds;
                if (traits == null)
                    return false;
                else
                {
                    return traits.Contains(trait);
                }
            });
        }
    }
}
