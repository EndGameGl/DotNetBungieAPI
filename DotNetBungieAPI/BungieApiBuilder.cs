using DotNetBungieAPI.Clients;
using DotNetBungieAPI.Services;
using DotNetBungieAPI.Services.ApiAccess;
using DotNetBungieAPI.Services.ApiAccess.Interfaces;
using DotNetBungieAPI.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetBungieAPI
{
    /// <summary>
    ///     Static class helper for building <see cref="IBungieClient" />
    /// </summary>
    public static class BungieApiBuilder
    {
        public static IBungieClient GetApiClient(
            Action<BungieClientConfiguration> configure,
            IServiceCollection serviceCollection = null)
        {
            serviceCollection ??= new ServiceCollection();

            var configuration = new BungieClientConfiguration(serviceCollection);
            configure.Invoke(configuration);

            serviceCollection.AddSingleton(configuration);
            serviceCollection.AddSingleton<IBungieClient, BungieClient>();
            serviceCollection.AddSingleton<IDefinitionAssemblyData, DefinitionAssemblyData>();

            serviceCollection.AddSingleton<IBungieApiAccess, BungieApiAccess>();

            serviceCollection.AddSingleton<IFireteamMethodsAccess, FireteamMethodsAccess>();
            serviceCollection.AddSingleton<IContentMethodsAccess, ContentMethodsAccess>();
            serviceCollection.AddSingleton<IAppMethodsAccess, AppMethodsAccess>();
            serviceCollection.AddSingleton<IForumMethodsAccess, ForumMethodsAccess>();
            serviceCollection.AddSingleton<IGroupV2MethodsAccess, GroupV2MethodsAccess>();
            serviceCollection.AddSingleton<IUserMethodsAccess, UserMethodsAccess>();
            serviceCollection.AddSingleton<ITokenMethodsAccess, TokenMethodsAccess>();
            serviceCollection.AddSingleton<IDestiny2MethodsAccess, Destiny2MethodsAccess>();
            serviceCollection.AddSingleton<ICommunityContentMethodsAccess, CommunityContentMethodsAccess>();
            serviceCollection.AddSingleton<ISocialMethodsAccess, SocialMethodsAccess>();
            serviceCollection.AddSingleton<ITrendingMethodsAccess, TrendingMethodsAccess>();
            serviceCollection.AddSingleton<IMiscMethodsAccess, MiscMethodsAccess>();

            return serviceCollection.BuildServiceProvider().GetService<IBungieClient>();
        }

        /// <summary>
        ///     Registers <see cref="IBungieClient" /> to specified <see cref="IServiceCollection" />
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="configure"></param>
        /// <returns></returns>
        public static IServiceCollection UseBungieApiClient(
            this IServiceCollection serviceCollection,
            Action<BungieClientConfiguration> configure)
        {
            var configuration = new BungieClientConfiguration(serviceCollection);
            configure.Invoke(configuration);

            serviceCollection.AddSingleton(configuration);
            serviceCollection.AddSingleton<IBungieClient, BungieClient>();
            serviceCollection.AddSingleton<IDefinitionAssemblyData, DefinitionAssemblyData>();

            serviceCollection.AddSingleton<IBungieApiAccess, BungieApiAccess>();

            serviceCollection.AddSingleton<IFireteamMethodsAccess, FireteamMethodsAccess>();
            serviceCollection.AddSingleton<IContentMethodsAccess, ContentMethodsAccess>();
            serviceCollection.AddSingleton<IAppMethodsAccess, AppMethodsAccess>();
            serviceCollection.AddSingleton<IForumMethodsAccess, ForumMethodsAccess>();
            serviceCollection.AddSingleton<IGroupV2MethodsAccess, GroupV2MethodsAccess>();
            serviceCollection.AddSingleton<IUserMethodsAccess, UserMethodsAccess>();
            serviceCollection.AddSingleton<ITokenMethodsAccess, TokenMethodsAccess>();
            serviceCollection.AddSingleton<IDestiny2MethodsAccess, Destiny2MethodsAccess>();
            serviceCollection.AddSingleton<ICommunityContentMethodsAccess, CommunityContentMethodsAccess>();
            serviceCollection.AddSingleton<ISocialMethodsAccess, SocialMethodsAccess>();
            serviceCollection.AddSingleton<ITrendingMethodsAccess, TrendingMethodsAccess>();
            serviceCollection.AddSingleton<IMiscMethodsAccess, MiscMethodsAccess>();

            return serviceCollection;
        }
    }
}