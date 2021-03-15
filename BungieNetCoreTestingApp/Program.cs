using NetBungieAPI;
using NetBungieAPI.Attributes;
using NetBungieAPI.Bungie;
using NetBungieAPI.Clients;
using NetBungieAPI.Destiny;
using NetBungieAPI.Destiny.Definitions;
using NetBungieAPI.Destiny.Definitions.Achievements;
using NetBungieAPI.Destiny.Definitions.Activities;
using NetBungieAPI.Destiny.Definitions.ActivityGraphs;
using NetBungieAPI.Destiny.Definitions.ActivityModes;
using NetBungieAPI.Destiny.Definitions.Artifacts;
using NetBungieAPI.Destiny.Definitions.BreakerTypes;
using NetBungieAPI.Destiny.Definitions.Checklists;
using NetBungieAPI.Destiny.Definitions.Classes;
using NetBungieAPI.Destiny.Definitions.Collectibles;
using NetBungieAPI.Destiny.Definitions.DamageTypes;
using NetBungieAPI.Destiny.Definitions.Destinations;
using NetBungieAPI.Destiny.Definitions.EnemyRaces;
using NetBungieAPI.Destiny.Definitions.EnergyTypes;
using NetBungieAPI.Destiny.Definitions.EquipmentSlots;
using NetBungieAPI.Destiny.Definitions.Factions;
using NetBungieAPI.Destiny.Definitions.Genders;
using NetBungieAPI.Destiny.Definitions.InventoryBuckets;
using NetBungieAPI.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Destiny.Definitions.ItemCategories;
using NetBungieAPI.Destiny.Responses;
using NetBungieAPI.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BungieNetCoreTestingApp
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
                DestinyComponentType.Metrics
        };

        private static BungieClient _bungieClient;

        static void Main(string[] args)
        {
            _bungieClient = new BungieClient((settings) => 
            {
                settings.IncludeApiKey(args[0]);

                settings.SetDefinitionsLoadingBehaviour(
                    saveToAppMemory: true,
                    tryDownloadMissingDefinitions: true,
                    preferredSource: DefinitionSources.SQLite,
                    retryDownloading: false,
                    DestinyLocales.EN);

                settings.UsePreloadedData("H:\\BungieNetCoreAPIRepository\\Manifests");

                settings.UseVersionControl(
                    keepOldVersions: true, 
                    checkUpdates: false, 
                    repositoryPath: string.Empty);

                settings.EnableLogging();

                settings.PremapPointers();

                settings.IncludeClientIdAndSecret(clientId: int.Parse(args[1]), clientSecret: args[2]);

                //settings.EnableTokenRenewal(refreshRate: 30000);

            });

            //var link = BungieClient.Platform.GetAuthorizationLink();
            //Console.WriteLine(link);
            //Console.Write("State: ");
            //var state = Console.ReadLine();
            //Console.WriteLine();
            //Console.Write("Code: ");
            //var code = Console.ReadLine();
            //Console.WriteLine();

            //BungieClient.Platform.ReceiveCode(state, code);
            //BungieClient.Platform.GetAuthorizationToken(code).GetAwaiter().GetResult();

            _bungieClient.AddListener((mes) => Console.WriteLine(mes));
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            var data = await AppMethods.GetBungieApplications();
            var moreData = await AppMethods.GetApplicationApiUsage(data.Response.First().ApplicationId);
            //await _bungieClient.Run();

            //var aggregateActivityStats = await BungieClient.Platform.GetDestinyAggregateActivityStats(
            //    membershipType: BungieMembershipType.TigerSteam,
            //    destinyMembershipId: 4611686018483306402,
            //    characterId: 2305843009404108262);


            //var pgcr = await BungieClient.Platform.GetPostGameCarnageReport(activityHistory.Response.Activities.First().ActivityDetails.InstanceId);

            //var accountStats = await BungieClient.Platform.GetHistoricalStatsForAccount(BungieMembershipType.TigerSteam, 4611686018483306402);

            //var profileData = await BungieClient.Platform.GetProfile(
            //    membershipType: BungieMembershipType.TigerSteam,
            //    destinyMembershipId: 4611686018483306402,

            //    ALL_COMPONENTS_ARRAY);

            //if (aggregateActivityStats.ErrorCode == PlatformErrorCodes.Success && aggregateActivityStats.Response != null)
            //{
            //    StringBuilder sb = new StringBuilder();

            //    foreach (var activityStat in aggregateActivityStats.Response.Activities)
            //    {
            //        if (activityStat.Activity.TryGetDefinition(out var actDef))
            //        {
            //            sb.AppendLine($"{{{actDef.DisplayProperties?.Name}}}");
            //        }
            //        else
            //            sb.AppendLine("{Unknown activity.}");
            //        foreach (var item in activityStat.Values)
            //        {
            //            sb.AppendLine($"    {item.Key}: {item.Value.BasicValue.DisplayValue}");
            //        }
            //    }
            //    Console.WriteLine(sb.ToString());
            //}

            await Task.Delay(Timeout.Infinite);
        }

        private static void RunDeepEqualityCheck<T>(List<T> collection) where T : IDeepEquatable<T>
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int uniqueItems = 0;
            foreach (var item in collection)
            {
                int equalCount = 0;
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
            Stopwatch sw = new Stopwatch();
            sw.Start();
            action.Invoke();
            sw.Stop();
            if (writeResult)
                Console.WriteLine($"{sw.ElapsedMilliseconds} ms elapsed.");
            return sw.ElapsedMilliseconds;
        }
        private static void MeasureOperationMultiple(Action action, int amount)
        {
            double totalTime = 0.0;
            for (int i = 0; i < amount; i++)
            {
                totalTime += MeasureOperation(action, false);
            }

            Console.WriteLine($"Ran op {amount} times in {totalTime} ms ({amount / totalTime} op/ms)");
        }
        private void PrintWeapons(List<DestinyInventoryItemDefinition> weapons)
        {
            string indent = new string(' ', 4);
            Random rnd = new Random();

            var key = Console.ReadKey();

            while (key.Key != ConsoleKey.Escape)
            {
                var randomWeapon = weapons.ElementAt(rnd.Next(0, weapons.Count));

                var weaponSockets = randomWeapon.Sockets;

                if (randomWeapon.ItemCategories.Any(x => x.Hash == 3109687656))
                    return;

                Console.WriteLine($"Weapon: {randomWeapon.DisplayProperties.Name} ({randomWeapon.ItemTypeAndTierDisplayName}), {weaponSockets.SocketEntries.Count} sockets.");

                foreach (var category in weaponSockets.SocketCategories)
                {
                    if (category.SocketCategory.TryGetDefinition(out var categoryDef))
                    {
                        Console.WriteLine($"Category: {categoryDef.DisplayProperties.Name}");

                        foreach (var index in category.SocketIndexes)
                        {
                            var socketData = weaponSockets.SocketEntries[index];

                            string message = $"{indent}{socketData.SingleInitialItem.Value.DisplayProperties.Name}";

                            if (socketData.ReusablePlugSet.TryGetDefinition(out var plugSet))
                            {
                                List<DestinyInventoryItemDefinition> plugs = new List<DestinyInventoryItemDefinition>();
                                foreach (var plugSetItem in plugSet.ReusablePlugItems)
                                {
                                    if (plugSetItem.PlugItem.TryGetDefinition(out var item))
                                    {
                                        plugs.Add(item);
                                    }
                                }
                                if (plugs.Count > 0)
                                {
                                    var plugNames = plugs.Select(x => x.DisplayProperties.Name);
                                    message += $" ({string.Join(", ", plugNames)})";
                                }
                            }

                            Console.WriteLine(message);
                        }
                    }
                }

                Console.WriteLine(new string('-', 20));

                key = Console.ReadKey();
            }
        }
    }
}