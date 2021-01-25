using BungieNetCoreAPI;
using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Bungie;
using BungieNetCoreAPI.Clients;
using BungieNetCoreAPI.Destiny;
using BungieNetCoreAPI.Destiny.Definitions.Activities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

            
            var result = _bungieClient.Repository.GetAll<DestinyActivityDefinition>(DefinitionsEnum.DestinyActivityDefinition, DestinyLocales.EN).WithName("harbinger").ToList();

            await Task.Delay(Timeout.Infinite);
        }
    }
}