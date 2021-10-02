using DotNetBungieAPI.Clients;
using DotNetBungieAPI.Services;
using DotNetBungieAPI.Services.ApiAccess;
using DotNetBungieAPI.Services.ApiAccess.Interfaces;
using DotNetBungieAPI.Services.Interfaces;
using Microsoft.Extensions.Logging;
using DotNetBungieAPI.Repositories;
using DotNetBungieAPI.Services.Default;
using Unity;

namespace DotNetBungieAPI
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