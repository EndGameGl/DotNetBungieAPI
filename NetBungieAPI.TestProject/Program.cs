using NetBungieAPI.Models.Applications;
using NetBungieAPI.Clients;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;
using NetBungieAPI.HashReferences;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Models.Destiny.Definitions.Activities;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Models.Social;

namespace NetBungieAPI.TestProject
{
    internal class Program
    {
        private static readonly DestinyComponentType[] ALL_COMPONENTS_ARRAY = new DestinyComponentType[]
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
            _bungieClient = await BungieApiBuilder.GetApiClientAsync((settings) =>
            {
                settings
                    .AddApiKey(args[0])
                    .AddClientIdAndSecret(int.Parse(args[1]), args[2])
                    .SpecifyApplicationScopes(ApplicationScopes.ReadUserData |
                                              ApplicationScopes.AdminGroups |
                                              ApplicationScopes.ReadBasicUserProfile)
                    .UseDefaultProvider(@"H:\BungieNetCoreAPIRepository\Manifests")
                    .EnableLogging((mes) => Console.WriteLine(mes))
                    //PremapDefinitions()
                    //.LoadAllDefinitionsOnStartup(waitEverythingToLoad: true)
                    .SetLocales(new BungieLocales[]
                    {
                        BungieLocales.EN
                    })
                    .SetUpdateBehaviour(false, true);
                //.TryLoadManifestVersion("96750.21.08.09.1845-3-bnet.39541");
            });

            var adoredDefinitionResponse = await _bungieClient
                .ApiAccess
                .Destiny2
                .GetDestinyEntityDefinition<DestinyInventoryItemDefinition>(
                    DefinitionsEnum.DestinyInventoryItemDefinition,
                    DefinitionHashes.InventoryItems.Adored);

            if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyInventoryItemDefinition>(
                DefinitionHashes.InventoryItems.Adored, BungieLocales.EN, out var adoredDefinition))
            {
                Console.WriteLine($"{adoredDefinition.DisplayProperties.Name}");
            }

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
                    if (item.DeepEquals(itemNested))
                        equalCount++;

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
            for (var i = 0; i < amount; i++) totalTime += MeasureOperation(action, false);

            Console.WriteLine($"Ran op {amount} times in {totalTime} ms ({totalTime / amount} per op.)");
        }
    }
}