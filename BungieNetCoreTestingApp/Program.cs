using BungieNetCoreAPI;
using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Bungie;
using BungieNetCoreAPI.Clients;
using BungieNetCoreAPI.Destiny;
using BungieNetCoreAPI.Destiny.Definitions.Achievements;
using BungieNetCoreAPI.Destiny.Definitions.Activities;
using BungieNetCoreAPI.Destiny.Definitions.ActivityGraphs;
using BungieNetCoreAPI.Destiny.Definitions.ActivityInteractables;
using BungieNetCoreAPI.Destiny.Definitions.ActivityModes;
using BungieNetCoreAPI.Destiny.Definitions.ActivityModifiers;
using BungieNetCoreAPI.Destiny.Definitions.ActivityTypes;
using BungieNetCoreAPI.Destiny.Definitions.ArtDyeChannels;
using BungieNetCoreAPI.Destiny.Definitions.ArtDyeReferences;
using BungieNetCoreAPI.Destiny.Definitions.Artifacts;
using BungieNetCoreAPI.Destiny.Definitions.Bonds;
using BungieNetCoreAPI.Destiny.Definitions.BreakerTypes;
using BungieNetCoreAPI.Destiny.Definitions.CharacterCustomizationCategories;
using BungieNetCoreAPI.Destiny.Definitions.CharacterCustomizationOptions;
using BungieNetCoreAPI.Destiny.Definitions.Checklists;
using BungieNetCoreAPI.Destiny.Definitions.Classes;
using BungieNetCoreAPI.Destiny.Definitions.Collectibles;
using BungieNetCoreAPI.Destiny.Definitions.DamageTypes;
using BungieNetCoreAPI.Destiny.Definitions.Destinations;
using BungieNetCoreAPI.Destiny.Definitions.EnemyRaces;
using BungieNetCoreAPI.Destiny.Definitions.EnergyTypes;
using BungieNetCoreAPI.Destiny.Definitions.EntitlementOffers;
using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using BungieNetCoreAPI.Destiny.Definitions.Objectives;
using BungieNetCoreAPI.Destiny.Definitions.Unlocks;
using BungieNetCoreAPI.Destiny.Definitions.UnlockValues;
using BungieNetCoreAPI.Destiny.Definitions.Vendors;
using BungieNetCoreAPI.Destiny.Profile.Components.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace BungieNetCoreTestingApp
{
    class Program
    {
        private static BungiePlatfromClient client;
        static void Main(string[] args)
        {
            
            client = new BungiePlatfromClient("75187ab684d94a338c1b5a6996c217f8");   
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            var manifest = await client.GetDestinyManifest();
            //await manifest.DownloadAndSaveToLocalFiles("manifestLocalFiles");
            GlobalDefinitionsCacheRepository.Initialize(new string[] 
            { 
                "en"
                //"ru"
                //"de",
                //"es",
                //"es-mx",
                //"fr",
                //"it",
                //"ja",
                //"ko",
                //"pl",
                //"pt-br",
                //"zh-chs",
                //"zh-cht"
            });
            GlobalDefinitionsCacheRepository.LoadAllDataFromDisk(@"H:\BungieNetCoreAPIRepository\Database", manifest);

            var searchResult = GlobalDefinitionsCacheRepository
                .Search<DestinyObjectiveDefinition>("en",
                x => (x as DestinyObjectiveDefinition).Stats?.Stat != null)
                .ToList();

            await Task.Delay(Timeout.Infinite);
        }
    }
}