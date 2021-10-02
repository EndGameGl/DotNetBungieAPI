using NetBungieAPI.Models.Applications;
using NetBungieAPI.Clients;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NetBungieAPI.Authorization;
using NetBungieAPI.HashReferences;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;

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
            _bungieClient = BungieApiBuilder.GetApiClient((BungieClientConfiguration configuration) =>
            {
                configuration.ApiKey = args[0];
                configuration.ClientId = int.Parse(args[1]);
                configuration.ClientSecret = args[2];
                configuration.ApplicationScopes = ApplicationScopes.ReadUserData |
                                                  ApplicationScopes.AdminGroups |
                                                  ApplicationScopes.ReadBasicUserProfile;
                configuration
                    .UseDefaultLogger(loggingConfig =>
                    {
                        loggingConfig.IsEnabled = true;
                        loggingConfig.LogEventLevels(new[]
                        {
                            LogLevel.Debug, 
                            LogLevel.Information,
                            LogLevel.Error
                        });
                    })
                    .UseDefaultBungieNetJsonSerializer(serializerConfig =>
                    {
                        serializerConfig.Options.WriteIndented = false;
                    })
                    .UseDefaultHttpClient(httpClientConfig =>
                    {
                        httpClientConfig.HttpClient.Timeout = TimeSpan.FromSeconds(30);
                    })
                    .UseDefaultAuthorizationHandler()
                    .UseDefaultDefinitionProvider(providerConfig =>
                    {
                        providerConfig.ManifestFolderPath = "H:\\BungieNetCoreAPIRepository\\Manifests";
                        providerConfig.FetchLatestManifestOnInitialize = false;
                        providerConfig.AutoUpdateManifestOnStartup = true;
                    })
                    .UseDefaultDefinitionRepository(repositoryConfig =>
                    {
                        repositoryConfig.UsedLocales.Add(BungieLocales.EN);
                    });
            });

            await _bungieClient.DefinitionProvider.Initialize();

            _bungieClient.TryGetDefinition<DestinyInventoryItemDefinition>(DefinitionHashes.InventoryItems.Adored, BungieLocales.EN, out var adoredDef);
            
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