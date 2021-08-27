using NetBungieAPI.Models.Applications;
using NetBungieAPI.Clients;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.HashReferences;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Models.Destiny.Definitions.Achievements;
using NetBungieAPI.Models.Destiny.Definitions.Activities;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModes;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModifiers;
using NetBungieAPI.Models.Destiny.Definitions.ActivityTypes;
using NetBungieAPI.Models.Destiny.Definitions.Artifacts;
using NetBungieAPI.Models.Destiny.Definitions.BreakerTypes;
using NetBungieAPI.Models.Destiny.Definitions.Checklists;
using NetBungieAPI.Models.Destiny.Definitions.Classes;
using NetBungieAPI.Models.Destiny.Definitions.Collectibles;
using NetBungieAPI.Models.Destiny.Definitions.DamageTypes;
using NetBungieAPI.Models.Destiny.Definitions.Destinations;
using NetBungieAPI.Models.Destiny.Definitions.EnergyTypes;
using NetBungieAPI.Models.Destiny.Definitions.EquipmentSlots;
using NetBungieAPI.Models.Destiny.Definitions.Factions;
using NetBungieAPI.Models.Destiny.Definitions.Genders;
using NetBungieAPI.Models.Destiny.Definitions.InventoryBuckets;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Models.Destiny.Definitions.ItemCategories;
using NetBungieAPI.Models.Destiny.Definitions.ItemTierTypes;
using NetBungieAPI.Models.Destiny.Definitions.Locations;
using NetBungieAPI.Models.Destiny.Definitions.Lore;
using NetBungieAPI.Models.Destiny.Definitions.MedalTiers;
using NetBungieAPI.Models.Destiny.Definitions.Metrics;
using NetBungieAPI.Models.Destiny.Definitions.Milestones;
using NetBungieAPI.Models.Destiny.Definitions.Objectives;
using NetBungieAPI.Models.Destiny.Definitions.Places;
using NetBungieAPI.Models.Destiny.Definitions.PlugSets;
using NetBungieAPI.Models.Destiny.Definitions.PowerCaps;
using NetBungieAPI.Models.Destiny.Definitions.PresentationNodes;
using NetBungieAPI.Models.Destiny.Definitions.ProgressionMappings;
using NetBungieAPI.Models.Destiny.Definitions.Progressions;
using NetBungieAPI.Models.Destiny.Definitions.Races;
using NetBungieAPI.Models.Destiny.Definitions.Records;
using NetBungieAPI.Models.Destiny.Definitions.ReportReasonCategories;
using NetBungieAPI.Models.Destiny.Definitions.SandboxPerks;
using NetBungieAPI.Models.Destiny.Definitions.SeasonPasses;
using NetBungieAPI.Models.Destiny.Definitions.Seasons;
using NetBungieAPI.Models.Destiny.Definitions.SocketCategories;
using NetBungieAPI.Models.Destiny.Definitions.SocketTypes;
using NetBungieAPI.Models.Destiny.Definitions.Stats;
using NetBungieAPI.Models.Destiny.Definitions.TraitCategories;
using NetBungieAPI.Models.Destiny.Definitions.Traits;
using NetBungieAPI.Models.Destiny.Definitions.VendorGroups;
using NetBungieAPI.Models.Destiny.Definitions.Vendors;
using NetBungieAPI.Providers;

namespace NetBungieAPI.TestProject
{
    class Program
    {
        private static DestinyComponentType[] ALL_COMPONENTS_ARRAY = new DestinyComponentType[]
        {
            DestinyComponentType.Profiles,
            DestinyComponentType.VendorReceipts,
            DestinyComponentType.ProfileInventories,
            DestinyComponentType.ProfileCurrencies,
            DestinyComponentType.ProfileProgression,
            DestinyComponentType.PlatformSilver,

            DestinyComponentType.Characters,
            DestinyComponentType.CharacterInventories,
            DestinyComponentType.CharacterProgressions,
            DestinyComponentType.CharacterRenderData,
            DestinyComponentType.CharacterActivities,
            DestinyComponentType.CharacterEquipment,

            DestinyComponentType.ItemInstances,
            DestinyComponentType.ItemObjectives,
            DestinyComponentType.ItemPerks,
            DestinyComponentType.ItemRenderData,
            DestinyComponentType.ItemStats,
            DestinyComponentType.ItemSockets,
            DestinyComponentType.ItemTalentGrids,
            DestinyComponentType.ItemCommonData,
            DestinyComponentType.ItemPlugStates,
            DestinyComponentType.ItemPlugObjectives,
            DestinyComponentType.ItemReusablePlugs,

            DestinyComponentType.Vendors,
            DestinyComponentType.VendorCategories,
            DestinyComponentType.VendorSales,

            DestinyComponentType.Kiosks,
            DestinyComponentType.CurrencyLookups,
            DestinyComponentType.PresentationNodes,
            DestinyComponentType.Collectibles,
            DestinyComponentType.Records,
            DestinyComponentType.Transitory,
            DestinyComponentType.Metrics,
            DestinyComponentType.StringVariables
        };

        private static IBungieClient _bungieClient;

        private static async Task Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            _bungieClient = BungieApiBuilder.GetApiClient((settings) =>
            {
                settings
                    .AddApiKey(key: args[0])
                    .AddClientIdAndSecret(id: int.Parse(args[1]), secret: args[2])
                    .SpecifyApplicationScopes(ApplicationScopes.ReadUserData | ApplicationScopes.AdminGroups |
                                              ApplicationScopes.ReadBasicUserProfile)
                    .UseDefaultProvider(@"H:\BungieNetCoreAPIRepository\Manifests")
                    .EnableLogging((mes) => Console.WriteLine(mes))
                    //.PremapDefinitions()
                    //.LoadAllDefinitionsOnStartup(waitEverythingToLoad: true)
                    .SetLocales(new BungieLocales[]
                    {
                        BungieLocales.EN
                    })
                    .SetUpdateBehaviour(true, true);
            });
            //_bungieClient.DefinitionsLoaded += () => Console.WriteLine("Finished loading definitions");
            sw.Stop();
            Console.WriteLine($"Startup in: {sw.ElapsedMilliseconds} ms");

            Console.WriteLine($"{Process.GetCurrentProcess().PrivateMemorySize64} bytes allocated for current app.");

            var userSearchResult = await _bungieClient.ApiAccess.User.SearchUsersByPrefix("megl");
            
            //var generator = new HashReferencesGeneration.DefinitionHashReferencesGenerator(_bungieClient);
            //await generator.Generate();

            //Console.WriteLine($"Finished dumping json.");

            // var sqliteDefinitionProvider = _bungieClient.Repository.Provider as SqliteDefinitionProvider;
            // List<DestinyInventoryItemDefinition> items = new List<DestinyInventoryItemDefinition>();
            // await foreach (var item in sqliteDefinitionProvider.GetDefinitionsRangeAsync<DestinyInventoryItemDefinition>(
            //     BungieLocales.RU, 100, 50))
            // {
            //     items.Add(item);
            // }

            await Task.Delay(Timeout.Infinite);
        }

        private static void RunDeepEqualityCheck<T>(List<T> collection) where T : IDeepEquatable<T>
        {
            var sw = new Stopwatch();
            sw.Start();
            var uniqueItems = 0;
            foreach (var item in collection)
            {
                var equalCount = 0;
                foreach (var itemNested in collection)
                {
                    if (item.DeepEquals(itemNested))
                    {
                        equalCount++;
                    }
                }

                if (equalCount == 1)
                    uniqueItems++;
            }

            sw.Stop();
            Console.WriteLine($"{sw.ElapsedMilliseconds} ms elapsed. Unique items: {uniqueItems}");
        }

        private static long MeasureOperation(Action action, bool writeResult = true)
        {
            var sw = new Stopwatch();
            sw.Start();
            action.Invoke();
            sw.Stop();
            if (writeResult)
                Console.WriteLine($"{sw.ElapsedMilliseconds} ms elapsed.");
            return sw.ElapsedMilliseconds;
        }

        private static async ValueTask<long> MeasureOperationAsync(Task task, bool writeResult = true)
        {
            var sw = new Stopwatch();
            sw.Start();
            await task.ConfigureAwait(false);
            sw.Stop();
            if (writeResult)
                Console.WriteLine($"{sw.ElapsedMilliseconds} ms elapsed.");
            return sw.ElapsedMilliseconds;
        }

        private static void MeasureOperationMultiple(Action action, int amount)
        {
            var totalTime = 0.0;
            for (var i = 0; i < amount; i++)
            {
                totalTime += MeasureOperation(action, false);
            }

            Console.WriteLine($"Ran op {amount} times in {totalTime} ms ({totalTime / amount} per op.)");
        }
    }
}