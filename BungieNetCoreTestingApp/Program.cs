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

            var coll = _bungieClient.Repository.GetAll<DestinyClassDefinition>(DefinitionsEnum.DestinyClassDefinition, DestinyLocales.EN).ToList();

            RunDeepEqualityCheck(coll);
            //MeasureOperation(() => activityPointersCollection = coll.Select(x => x.GetPointer()).ToList());

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

        private static void MeasureOperation(Action action)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            action.Invoke();
            sw.Stop();
            Console.WriteLine($"{sw.ElapsedMilliseconds} ms elapsed.");
        }
    }
}