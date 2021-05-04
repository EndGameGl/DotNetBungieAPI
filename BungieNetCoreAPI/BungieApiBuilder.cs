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
            var logger = StaticUnityContainer.GetLogger();
            var configuration = StaticUnityContainer.GetConfiguration();
            configuration.Configure(configure);
            var client = StaticUnityContainer.GetService<IBungieClient>();
            client.AddListener(configuration.Settings.InternalSettings.OnLog);
            Task.Run(async () =>
            {
                configuration.Settings.AfterConfigurated();
                var provider = configuration.Settings.DefinitionLoadingSettings.UsedProvider;
                await provider.OnLoadInternal(configuration);
                if (configuration.Settings.ManifestVersionSettings.CheckUpdates == true)
                {
                    if (await provider.CheckForUpdates())
                        await provider.Update();
                    if (configuration.Settings.ManifestVersionSettings.KeepOldVersions == false)
                        await provider.DeleteOldManifestData();
                }

                await provider.OnLoad();
            }).Wait();


            client.Repository.Provider = configuration.Settings.DefinitionLoadingSettings.UsedProvider;
            if (!configuration.Settings.DefinitionLoadingSettings.LoadAllDefinitionsOnStatup)
                return client;

            if (configuration.Settings.DefinitionLoadingSettings.WaitAllDefinitionsToLoad)
                Task.Run(async () =>
                {
                    await client.Repository.Provider.ReadDefinitionsToRepository(configuration.Settings
                        .DefinitionLoadingSettings.AllowedDefinitions);
                    if (configuration.Settings.DefinitionLoadingSettings.PremapDefinitionPointers)
                        client.Repository.PremapPointers();
                }).Wait();
            else
                Task.Run(async () =>
                {
                    await client.Repository.Provider.ReadDefinitionsToRepository(configuration.Settings
                        .DefinitionLoadingSettings.AllowedDefinitions);
                    if (configuration.Settings.DefinitionLoadingSettings.PremapDefinitionPointers)
                        client.Repository.PremapPointers();
                });

            return client;
        }
    }
}