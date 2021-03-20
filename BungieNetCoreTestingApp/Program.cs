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
using NetBungieAPI.Fireteam;
using NetBungieAPI.Forum;
using NetBungieAPI.Services;
using NetBungieAPI.Services.Interfaces;
using NetBungieAPI.Trending;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

        private static IBungieClient _bungieClient;
        static void Main(string[] args)
        {
            _bungieClient = BungieApiBuilder.GetApiClient((settings) =>
            {
                settings.IncludeApiKey(args[0])
                .SetDefinitionsLoadingBehaviour(
                    saveToAppMemory: true,
                    preferredSource: DefinitionSources.SQLite,
                    retryDownloading: false,
                    DestinyLocales.EN)
                .UsePreloadedData("H:\\BungieNetCoreAPIRepository\\Manifests")
                .UseVersionControl(
                    keepOldVersions: true,
                    checkUpdates: true,
                    repositoryPath: string.Empty)
                .EnableLogging()
                .PremapPointers()
                .IncludeClientIdAndSecret(clientId: int.Parse(args[1]), clientSecret: args[2]);

                //settings.EnableTokenRenewal(refreshRate: 30000);

            });

            ////var link = BungieClient.Platform.GetAuthorizationLink();
            ////Console.WriteLine(link);
            ////Console.Write("State: ");
            ////var state = Console.ReadLine();
            ////Console.WriteLine();
            ////Console.Write("Code: ");
            ////var code = Console.ReadLine();
            ////Console.WriteLine();

            ////BungieClient.Platform.ReceiveCode(state, code);
            ////BungieClient.Platform.GetAuthorizationToken(code).GetAwaiter().GetResult();

            _bungieClient.AddListener((mes) => Console.WriteLine(mes));
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            var response = await _bungieClient.ApiAccess.GroupV2.GetUserClanInviteSetting(BungieMembershipType.TigerSteam);

            //await _bungieClient.Run();

            //var activity = await _bungieClient.ApiAccess.Destiny2.GetPublicMilestones();

            //foreach (var milestone in activity.Response)
            //{
            //    milestone.Value.Milestone.TryMapValue();
            //    milestone.Value.Activities?.ForEach(x => 
            //    { 
            //        x?.Activity.TryMapValue(); 
            //        x?.Modifiers.ForEach(x => x.TryMapValue());
            //        x?.ChallengeObjectives.ForEach(x => x.TryMapValue()); 
            //        });
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
    }
}