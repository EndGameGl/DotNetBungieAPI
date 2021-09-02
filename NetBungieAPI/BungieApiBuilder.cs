using System;
using System.Threading.Tasks;
using NetBungieAPI.Clients;
using NetBungieAPI.Clients.Settings;

namespace NetBungieAPI
{
    /// <summary>
    /// Static class helper for building <see cref="IBungieClient"/>
    /// </summary>
    public static class BungieApiBuilder
    {
        /// <summary>
        /// Gets api client synchronously
        /// </summary>
        /// <param name="configure">Configuration action</param>
        /// <returns></returns>
        public static IBungieClient GetApiClient(Action<BungieClientSettings> configure)
        {
            var logger = StaticUnityContainer.GetLogger();
            var configuration = StaticUnityContainer.GetConfiguration();
            configuration.Configure(configure);
            var client = StaticUnityContainer.GetService<IBungieClient>();
            client.AddListener(configuration.Settings.InternalSettings.OnLog);
            Task.Run(async () =>
            {
                configuration.Settings.AfterConfiguration();
                var provider = configuration.Settings.DefinitionLoadingSettings.UsedProvider;
                await provider.OnLoadInternal(configuration);
                if (configuration.Settings.ManifestVersionSettings.CheckUpdates)
                {
                    if (!configuration.Settings.DefinitionLoadingSettings.DownloadLatestManifestOnLoad)
                    {
                        if (await provider.CheckForUpdates())
                            await provider.Update();
                    }
                    else
                    {
                        var manifest = await provider.GetCurrentManifest();
                        if (!await provider.CheckExistingManifestData(manifest.Version)) await provider.Update();
                    }

                    if (configuration.Settings.ManifestVersionSettings.KeepOldVersions == false)
                        await provider.DeleteOldManifestData();
                }

                await provider.OnLoad();
            }).Wait();


            client.Repository.Provider = configuration.Settings.DefinitionLoadingSettings.UsedProvider;
            if (!configuration.Settings.DefinitionLoadingSettings.LoadAllDefinitionsOnStatup)
                return client;

            if (configuration.Settings.DefinitionLoadingSettings.WaitAllDefinitionsToLoad)
            {
                client.Repository.Provider.ReadDefinitionsToRepository(
                    configuration.Settings.DefinitionLoadingSettings.AllowedDefinitions).Wait();

                if (configuration.Settings.DefinitionLoadingSettings.PremapDefinitionPointers)
                    client.Repository.PremapPointers();
            }
            else
            {
                Task.Run(async () =>
                {
                    await client.Repository.Provider.ReadDefinitionsToRepository(configuration.Settings
                        .DefinitionLoadingSettings.AllowedDefinitions);

                    if (configuration.Settings.DefinitionLoadingSettings.PremapDefinitionPointers)
                        client.Repository.PremapPointers();

                    (client as BungieClient)!.SignalDefinitionsLoadedInternal();
                });
            }

            return client;
        }

        /// <summary>
        /// Gets api client asynchronously
        /// </summary>
        /// <param name="configure">Configuration action</param>
        /// <returns></returns>
        public static async ValueTask<IBungieClient> GetApiClientAsync(Action<BungieClientSettings> configure)
        {
            var logger = StaticUnityContainer.GetLogger();
            var configuration = StaticUnityContainer.GetConfiguration();
            configuration.Configure(configure);
            var client = StaticUnityContainer.GetService<IBungieClient>();
            client.AddListener(configuration.Settings.InternalSettings.OnLog);

            configuration.Settings.AfterConfiguration();
            var provider = configuration.Settings.DefinitionLoadingSettings.UsedProvider;
            await provider.OnLoadInternal(configuration);
            if (configuration.Settings.ManifestVersionSettings.CheckUpdates)
            {
                if (!configuration.Settings.DefinitionLoadingSettings.DownloadLatestManifestOnLoad)
                {
                    if (await provider.CheckForUpdates())
                        await provider.Update();
                }
                else
                {
                    var manifest = await provider.GetCurrentManifest();
                    if (!await provider.CheckExistingManifestData(manifest.Version)) await provider.Update();
                }

                if (configuration.Settings.ManifestVersionSettings.KeepOldVersions == false)
                    await provider.DeleteOldManifestData();
            }

            await provider.OnLoad();

            client.Repository.Provider = configuration.Settings.DefinitionLoadingSettings.UsedProvider;
            if (!configuration.Settings.DefinitionLoadingSettings.LoadAllDefinitionsOnStatup)
                return client;

            if (configuration.Settings.DefinitionLoadingSettings.WaitAllDefinitionsToLoad)
            {
                await client.Repository.Provider.ReadDefinitionsToRepository(configuration.Settings
                    .DefinitionLoadingSettings.AllowedDefinitions);

                if (configuration.Settings.DefinitionLoadingSettings.PremapDefinitionPointers)
                    client.Repository.PremapPointers();
            }
            else
            {
                Task.Run(async () =>
                {
                    await client.Repository.Provider.ReadDefinitionsToRepository(configuration.Settings
                        .DefinitionLoadingSettings.AllowedDefinitions);

                    if (configuration.Settings.DefinitionLoadingSettings.PremapDefinitionPointers)
                        client.Repository.PremapPointers();

                    (client as BungieClient)!.SignalDefinitionsLoadedInternal();
                });
            }

            return client;
        }
    }
}