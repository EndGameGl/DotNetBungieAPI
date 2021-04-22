using NetBungieAPI.Clients;
using NetBungieAPI.Clients.Settings;
using NetBungieAPI.Services;
using System;
using System.Threading.Tasks;

namespace NetBungieAPI
{
    public class BungieApiBuilder
    {
        public static IBungieClient GetApiClient(Action<BungieClientSettings> configure)
        {
            var configuration = StaticUnityContainer.GetConfiguration();
            configuration.Configure(configure);
            
            Task.Run(async () =>
            {
                await configuration.Settings.AfterConfigurated();
                
                await configuration.Settings.DefinitionLoadingSettings.UsedProvider?.InternalOnLoad(configuration);
                
                await configuration.Settings.DefinitionLoadingSettings.UsedProvider?.OnLoad();
            }).Wait();
            
            var client = StaticUnityContainer.GetService<IBungieClient>();
            client.Repository.Provider = configuration.Settings.DefinitionLoadingSettings.UsedProvider;
            return client;
        }
    }
}
