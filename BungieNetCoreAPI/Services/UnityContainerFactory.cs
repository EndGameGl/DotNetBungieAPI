using BungieNetCoreAPI.Logging;
using BungieNetCoreAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace BungieNetCoreAPI.Services
{
    internal static class UnityContainerFactory
    {
        internal static IUnityContainer Container;
        static UnityContainerFactory()
        {
            Container = new UnityContainer();
            Container.RegisterType<ILogger, Logger>(TypeLifetime.Singleton);
            Container.RegisterType<IConfigurationService, ConfigurationService>(TypeLifetime.Singleton);
            Container.RegisterType<IHttpClientInstance, HttpClientInstance>(TypeLifetime.Singleton);
            Container.RegisterType<ILocalisedManifestDefinitionRepositories, LocalisedManifestDefinitionRepositories>(TypeLifetime.Singleton);
            Container.RegisterType<IManifestUpdateHandler, ManifestUpdateHandler>(TypeLifetime.Singleton);
            Container.RegisterType<IDefinitionAssemblyData, DefinitionAssemblyData>(TypeLifetime.Singleton);
        }
    }
}
