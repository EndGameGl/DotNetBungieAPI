using Microsoft.Extensions.Logging;
using NetBungieAPI.Clients;
using NetBungieAPI.Repositories;
using NetBungieAPI.Services;
using NetBungieAPI.Services.ApiAccess;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Default;
using NetBungieAPI.Services.Interfaces;
using Unity;

namespace NetBungieAPI
{
    internal static class StaticUnityContainer
    {
        internal static readonly IUnityContainer Container;

        static StaticUnityContainer()
        {
            Container = new UnityContainer();
            Container.RegisterType<IDefinitionAssemblyData, DefinitionAssemblyData>(TypeLifetime.Singleton);
            Container.RegisterType<IBungieClient, BungieClient>(TypeLifetime.Singleton);
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
            Container.RegisterType<ISocialMethodsAccess, SocialMethodsAccess>(TypeLifetime.Singleton);
            Container.RegisterType<ITrendingMethodsAccess, TrendingMethodsAccess>(TypeLifetime.Singleton);
            Container.RegisterType<IMiscMethodsAccess, MiscMethodsAccess>(TypeLifetime.Singleton);
        }

        public static T GetService<T>()
        {
            return Container.Resolve<T>();
        }
    }
}