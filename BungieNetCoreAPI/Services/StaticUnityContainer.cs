using BungieNetCoreAPI.Logging;
using BungieNetCoreAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace BungieNetCoreAPI.Services
{
    internal static class StaticUnityContainer
    {
        private static IUnityContainer Container;
        static StaticUnityContainer()
        {
            Container = new UnityContainer();
            Container.RegisterType<ILogger, Logger>(TypeLifetime.Singleton);
            Container.RegisterType<IConfigurationService, ConfigurationService>(TypeLifetime.Singleton);
            Container.RegisterType<IHttpClientInstance, HttpClientInstance>(TypeLifetime.Singleton);
            Container.RegisterType<ILocalisedManifestDefinitionRepositories, LocalisedDestinyDefinitionRepositories>(TypeLifetime.Singleton);
            Container.RegisterType<IManifestUpdateHandler, ManifestUpdateHandler>(TypeLifetime.Singleton);
            Container.RegisterType<IDefinitionAssemblyData, DefinitionAssemblyData>(TypeLifetime.Singleton);
        }
        internal static T GetService<T>() => Container.Resolve<T>();
        internal static ILogger GetLogger() => Container.Resolve<ILogger>();
        internal static IConfigurationService GetConfiguration() => Container.Resolve<IConfigurationService>();
        internal static IHttpClientInstance GetHTTPClient() => Container.Resolve<IHttpClientInstance>();
        internal static ILocalisedManifestDefinitionRepositories GetDestinyDefinitionRepositories() => Container.Resolve<ILocalisedManifestDefinitionRepositories>();
        internal static IManifestUpdateHandler GetManifestUpdateHandler() => Container.Resolve<IManifestUpdateHandler>();
        internal static IDefinitionAssemblyData GetAssemblyData() => Container.Resolve<IDefinitionAssemblyData>();
    }
}
