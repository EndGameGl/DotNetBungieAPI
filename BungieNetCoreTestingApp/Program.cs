using BungieNetCoreAPI;
using BungieNetCoreAPI.Bungie;
using BungieNetCoreAPI.Clients;
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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BungieNetCoreTestingApp
{
    class Program
    {
        private static BungiePlatfromClient client;
        static void Main(string[] args)
        {
            
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            var data = await client.GetMembershipFromHardLinkedCredential(76561198083556532);
            await Task.Delay(Timeout.Infinite);
        }
    }
}
