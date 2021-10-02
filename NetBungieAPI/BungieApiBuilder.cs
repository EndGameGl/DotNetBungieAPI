using System;
using Microsoft.Extensions.Logging;
using NetBungieAPI.Clients;
using Unity;

namespace NetBungieAPI
{
    /// <summary>
    /// Static class helper for building <see cref="IBungieClient"/>
    /// </summary>
    public static class BungieApiBuilder
    {
        public static IBungieClient GetApiClient(Action<BungieClientConfiguration> configure)
        {
            var configuration = new BungieClientConfiguration(); 
            configure.Invoke(configuration);

            StaticUnityContainer.Container.RegisterInstance(configuration);
            var logger = StaticUnityContainer.GetService<ILogger>();
            logger.LogInformation("Registered all services");

            return StaticUnityContainer.GetService<IBungieClient>();
        }
    }
}