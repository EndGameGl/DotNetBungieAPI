using DotNetBungieAPI.Clients;
using DotNetBungieAPI.Service.Abstractions;
using DotNetBungieAPI.Service.Abstractions.ApiAccess;
using DotNetBungieAPI.Services.ApiAccess;
using DotNetBungieAPI.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetBungieAPI;

/// <summary>
///     Static class helper for building <see cref="IBungieClient" />
/// </summary>
public static class BungieApiBuilder
{
    public static IBungieClient GetApiClient(
        Action<IBungieClientBuilder> configure,
        IServiceCollection serviceCollection = null)
    {
        serviceCollection ??= new ServiceCollection();

        var builder = new BungieClientBuilder(serviceCollection);
        configure.Invoke(builder);

        builder.ValidateAndRegisterServices();
        
        RegisterServices(serviceCollection, builder);

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
        Action<IBungieClientBuilder> configure)
    {
        var builder = new BungieClientBuilder(serviceCollection);
        configure.Invoke(builder);
        builder.ValidateAndRegisterServices();

        RegisterServices(serviceCollection, builder);

        return serviceCollection;
    }

    private static void RegisterServices(
        IServiceCollection serviceCollection,
        IBungieClientBuilder bungieClientBuilder)
    {
        serviceCollection.AddSingleton(bungieClientBuilder.ClientConfiguration);
        serviceCollection.AddSingleton<IBungieClient, BungieClient>();
        serviceCollection.AddSingleton<IDefinitionAssemblyData, DefinitionAssemblyData>();

        serviceCollection.AddSingleton<IBungieApiAccess, BungieApiAccess>();

        serviceCollection.AddSingleton<IFireteamMethodsAccess, FireteamMethodsAccess>();
        serviceCollection.AddSingleton<IContentMethodsAccess, ContentMethodsAccess>();
        serviceCollection.AddSingleton<IAppMethodsAccess, AppMethodsAccess>();
        serviceCollection.AddSingleton<IForumMethodsAccess, ForumMethodsAccess>();
        serviceCollection.AddSingleton<IGroupV2MethodsAccess, GroupV2MethodsAccess>();
        serviceCollection.AddSingleton<IUserMethodsAccess, UserMethodsAccess>();
        serviceCollection.AddSingleton<ITokensMethodsAccess, TokensMethodsAccess>();
        serviceCollection.AddSingleton<IDestiny2MethodsAccess, Destiny2MethodsAccess>();
        serviceCollection.AddSingleton<ICommunityContentMethodsAccess, CommunityContentMethodsAccess>();
        serviceCollection.AddSingleton<ISocialMethodsAccess, SocialMethodsAccess>();
        serviceCollection.AddSingleton<ITrendingMethodsAccess, TrendingMethodsAccess>();
        serviceCollection.AddSingleton<IMiscMethodsAccess, MiscMethodsAccess>();
        serviceCollection.AddSingleton<IRenderApiAccess, RenderApiAccess>();
    }
}