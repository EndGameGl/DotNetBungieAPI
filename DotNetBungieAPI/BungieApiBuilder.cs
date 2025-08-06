using DotNetBungieAPI.Clients;
using DotNetBungieAPI.Service.Abstractions;
using DotNetBungieAPI.Service.Abstractions.ApiAccess;
using DotNetBungieAPI.Services.ApiAccess;
using DotNetBungieAPI.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DotNetBungieAPI;

/// <summary>
///     Static class helper for building <see cref="IBungieClient" />
/// </summary>
public static class BungieApiBuilder
{
    public static IBungieClient GetApiClient(
        Action<IBungieClientBuilder> configure,
        Action<ILoggingBuilder>? loggerConfigurer = null,
        IServiceCollection? serviceCollection = null
    )
    {
        serviceCollection ??= new ServiceCollection();

        if (loggerConfigurer != null)
        {
            serviceCollection.AddLogging(loggerConfigurer);
        }
        else
        {
            serviceCollection.AddLogging(
                (builder) =>
                {
                    builder.Services.AddSingleton<ILoggerProvider, NullLoggerProvider>();
                }
            );
        }

        var builder = new BungieClientBuilder(serviceCollection);
        configure.Invoke(builder);

        builder.ValidateAndRegisterServices();

        RegisterServices(serviceCollection, builder);

        return serviceCollection.BuildServiceProvider().GetRequiredService<IBungieClient>();
    }

    /// <summary>
    ///     Registers <see cref="IBungieClient" /> to specified <see cref="IServiceCollection" />
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <param name="configure"></param>
    /// <returns></returns>
    public static IServiceCollection UseBungieApiClient(this IServiceCollection serviceCollection, Action<IBungieClientBuilder> configure)
    {
        var builder = new BungieClientBuilder(serviceCollection);
        configure.Invoke(builder);
        builder.ValidateAndRegisterServices();

        RegisterServices(serviceCollection, builder);

        return serviceCollection;
    }

    private static void RegisterServices(IServiceCollection serviceCollection, IBungieClientBuilder bungieClientBuilder)
    {
        serviceCollection.AddSingleton(bungieClientBuilder.ClientConfiguration);
        serviceCollection.AddSingleton<IBungieClient, BungieClient>();
        serviceCollection.AddSingleton<IDefinitionAssemblyData, DefinitionAssemblyData>();

        serviceCollection.AddSingleton<IBungieApiAccess, BungieApiAccess>();

        serviceCollection.AddSingleton<IFireteamApi, FireteamApi>();
        serviceCollection.AddSingleton<IContentApi, ContentApi>();
        serviceCollection.AddSingleton<IAppApi, AppApi>();
        serviceCollection.AddSingleton<IForumApi, ForumApi>();
        serviceCollection.AddSingleton<IGroupV2Api, GroupV2Api>();
        serviceCollection.AddSingleton<IUserApi, UserApi>();
        serviceCollection.AddSingleton<ITokensApi, TokensApi>();
        serviceCollection.AddSingleton<IDestiny2Api, Destiny2Api>();
        serviceCollection.AddSingleton<ICommunityContentApi, CommunityContentApi>();
        serviceCollection.AddSingleton<ISocialApi, SocialApi>();
        serviceCollection.AddSingleton<ITrendingApi, TrendingApi>();
        serviceCollection.AddSingleton<IMiscApi, MiscApi>();
    }
}
