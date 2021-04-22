using NetBungieAPI.Clients;
using NetBungieAPI.Clients.Settings;
using System;
using System.Threading.Tasks;

namespace NetBungieAPI
{
    public static class BungieApiBuilder
    {
        public static IBungieClient GetApiClient(Action<BungieClientSettings> configure)
        {
            var configuration = StaticUnityContainer.GetConfiguration();
            configuration.Configure(configure);
            var client = StaticUnityContainer.GetService<IBungieClient>();
            client.AddListener(configuration.Settings.InternalSettings.OnLog);
            
            Task.Run(async () =>
            {
                await configuration.Settings.AfterConfigurated();

                await configuration.Settings.DefinitionLoadingSettings.UsedProvider.InternalOnLoad(configuration);

                await configuration.Settings.DefinitionLoadingSettings.UsedProvider.OnLoad();
            }).Wait();

            
            client.Repository.Provider = configuration.Settings.DefinitionLoadingSettings.UsedProvider;
            if (configuration.Settings.DefinitionLoadingSettings.LoadAllDefinitionsOnStatup)
                Task.Run(async () =>
                {
                    await client.Repository.Provider.ReadDefinitionsToRepository(configuration.Settings
                        .DefinitionLoadingSettings.AllowedDefinitions);
                }).Wait();
            return client;
        }
    }
}