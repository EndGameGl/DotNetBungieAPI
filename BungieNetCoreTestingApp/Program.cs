using BungieNetCoreAPI;
using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Bungie;
using BungieNetCoreAPI.Clients;
using BungieNetCoreAPI.Destiny;
using BungieNetCoreAPI.Destiny.Definitions;
using BungieNetCoreAPI.Destiny.Definitions.Achievements;
using BungieNetCoreAPI.Destiny.Definitions.Activities;
using BungieNetCoreAPI.Destiny.Definitions.ActivityGraphs;
using BungieNetCoreAPI.Destiny.Definitions.ActivityModes;
using BungieNetCoreAPI.Destiny.Definitions.Artifacts;
using BungieNetCoreAPI.Destiny.Definitions.BreakerTypes;
using BungieNetCoreAPI.Destiny.Definitions.Checklists;
using BungieNetCoreAPI.Destiny.Definitions.Classes;
using BungieNetCoreAPI.Destiny.Definitions.Collectibles;
using BungieNetCoreAPI.Destiny.Definitions.DamageTypes;
using BungieNetCoreAPI.Destiny.Definitions.Destinations;
using BungieNetCoreAPI.Destiny.Definitions.EnemyRaces;
using BungieNetCoreAPI.Destiny.Definitions.EnergyTypes;
using BungieNetCoreAPI.Destiny.Definitions.EquipmentSlots;
using BungieNetCoreAPI.Destiny.Definitions.Factions;
using BungieNetCoreAPI.Destiny.Definitions.Genders;
using BungieNetCoreAPI.Destiny.Definitions.InventoryBuckets;
using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using BungieNetCoreAPI.Destiny.Definitions.ItemCategories;
using BungieNetCoreAPI.Destiny.Responses;
using BungieNetCoreAPI.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Unity;
using BungieNetCoreAPI.Repositories;
using BungieNetCoreAPI.Destiny.Definitions.ItemTierTypes;
using BungieNetCoreAPI.Destiny.Definitions.Locations;
using BungieNetCoreAPI.Destiny.Definitions.Lores;
using BungieNetCoreAPI.Destiny.Definitions.MaterialRequirementSets;
using BungieNetCoreAPI.Destiny.Definitions.MedalTiers;
using BungieNetCoreAPI.Destiny.Definitions.Metrics;
using BungieNetCoreAPI.Destiny.Definitions.Milestones;
using BungieNetCoreAPI.Destiny.Definitions.Objectives;
using BungieNetCoreAPI.Destiny.Definitions.Places;
using BungieNetCoreAPI.Destiny.Definitions.PlugSets;
using BungieNetCoreAPI.Destiny.Definitions.PowerCaps;
using BungieNetCoreAPI.Destiny.Definitions.PresentationNodes;
using BungieNetCoreAPI.Destiny.Definitions.ProgressionLevelRequirements;

namespace BungieNetCoreTestingApp
{
    class Program
    {
        private static BungieClient _bungieClient;
        static void Main(string[] args)
        {

            _bungieClient = new BungieClient(
                settings: new BungieClientSettings()
                {
                    UseExistingConfig = true,
                    ExistingConfigPath = "configs.json"
                });
            _bungieClient.LogListener.OnNewMessage += (mes) => Console.WriteLine(mes);
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {

            await _bungieClient.Run();

            //var milestones = await BungieClient.Platform.GetPublicMilestones();

            var coll = _bungieClient.Repository.GetAll<DestinyProgressionLevelRequirementDefinition>().ToList();

            coll.ForEach(x => x.MapValues());

            RunDeepEqualityCheck(coll);

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