using NetBungieAPI.Clients;
using NetBungieAPI.Logging;
using NetBungieAPI.Repositories;
using NetBungieAPI.Services;
using NetBungieAPI.Services.ApiAccess;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;
using Unity;

namespace NetBungieAPI
{
    internal static class StaticUnityContainer
    {
        private static readonly IUnityContainer Container;

        static StaticUnityContainer()
        {
            Container = new UnityContainer();
            Container.RegisterType<IBungieClient, BungieClient>(TypeLifetime.Singleton);
            Container.RegisterType<ILogger, Logger>(TypeLifetime.Singleton);
            Container.RegisterType<IConfigurationService, ConfigurationService>(TypeLifetime.Singleton);
            Container.RegisterType<IHttpClientInstance, HttpClientInstance>(TypeLifetime.Singleton);
            Container.RegisterType<ILocalisedDestinyDefinitionRepositories, LocalisedDestinyDefinitionRepositories>(
                TypeLifetime.Singleton);
            Container.RegisterType<IDefinitionAssemblyData, DefinitionAssemblyData>(TypeLifetime.Singleton);
            Container.RegisterType<IAuthorizationStateHandler, AuthorizationStateHandler>(TypeLifetime.Singleton);
            Container.RegisterType<IJsonSerializationHelper, JsonSerializationHelper>(TypeLifetime.Singleton);
            RegisterApiAccess();
        }

        private static void RegisterApiAccess()
        {
            Container.RegisterType<IBungieApiAccess, BungieApiAccess>(TypeLifetime.Singleton);

            Container.RegisterType<IFireteamMethodsAccess, FireteamMethodsAccess>(TypeLifetime.Singleton);
            Container.RegisterType<IContentMethodsAccess, ContentMethodsAccess>(TypeLifetime.Singleton);
            Container.RegisterType<IAppMethodsAccess, AppMethodsAccess>(TypeLifetime.Singleton);
            Container.RegisterType<IForumMethodsAccess, ForumMethodsAccess>(TypeLifetime.Singleton);
            Container.RegisterType<IGroupV2MethodsAccess, GroupV2MethodsAccess>(TypeLifetime.Singleton);
            Container.RegisterType<IUserMethodsAccess, UserMethodsAccess>(TypeLifetime.Singleton);
            Container.RegisterType<ITokenMethodsAccess, TokenMethodsAccess>(TypeLifetime.Singleton);
            Container.RegisterType<IDestiny2MethodsAccess, Destiny2MethodsAccess>(TypeLifetime.Singleton);
            Container.RegisterType<ICommunityContentMethodsAccess, CommunityContentMethodsAccess>(
                TypeLifetime.Singleton);
            Container.RegisterType<ITrendingMethodsAccess, TrendingMethodsAccess>(TypeLifetime.Singleton);
            Container.RegisterType<IMiscMethodsAccess, MiscMethodsAccess>(TypeLifetime.Singleton);
        }

        public static T GetService<T>()
        {
            return Container.Resolve<T>();
        }

        internal static ILogger GetLogger()
        {
            return Container.Resolve<ILogger>();
        }

        internal static IConfigurationService GetConfiguration()
        {
            return Container.Resolve<IConfigurationService>();
        }

        internal static IHttpClientInstance GetHTTPClient()
        {
            return Container.Resolve<IHttpClientInstance>();
        }

        internal static ILocalisedDestinyDefinitionRepositories GetDestinyDefinitionRepositories()
        {
            return Container.Resolve<ILocalisedDestinyDefinitionRepositories>();
        }

        internal static IDefinitionAssemblyData GetAssemblyData()
        {
            return Container.Resolve<IDefinitionAssemblyData>();
        }

        internal static IAuthorizationStateHandler GetAuthHandler()
        {
            return Container.Resolve<IAuthorizationStateHandler>();
        }
    }
}