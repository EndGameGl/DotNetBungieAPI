using DotNetBungieAPI.ApiBuilder;
using DotNetBungieAPI.Service.Abstractions;
using DotNetBungieAPI.Services.Implementations;
using DotNetBungieAPI.Services.Implementations.ServiceConfigurations;
using Microsoft.Extensions.Logging;

namespace DotNetBungieAPI.Extensions;

/// <summary>
///     Extensions helper class for configuring services
/// </summary>
public static class BungieClientBuilderExtensions
{
    public static void ConfigureDefaultRepository(
        this IServiceConfigurator<IDestiny2DefinitionRepository> repositoryConfig,
        Action<DefaultDestiny2DefinitionRepositoryConfiguration> configure)
    {
        repositoryConfig.Use<
            DefaultDestiny2DefinitionRepository,
            DefaultDestiny2DefinitionRepositoryConfiguration>(configure);
    }

    public static void ConfigureDefaultJsonSerializer(
        this IServiceConfigurator<IBungieNetJsonSerializer> serviceConfigurator,
        Action<DotNetBungieApiJsonSerializerConfiguration> configure)
    {
        serviceConfigurator.Use<
            DefaultBungieNetJsonSerializer,
            DotNetBungieApiJsonSerializerConfiguration>(configure);
    }

    public static void ConfigureDefaultHttpClient(
        this IServiceConfigurator<IDotNetBungieApiHttpClient> serviceConfigurator,
        Action<DotNetBungieApiHttpClientConfiguration> configure)
    {
        serviceConfigurator.Use<
            DefaultDotNetBungieApiHttpClient,
            DotNetBungieApiHttpClientConfiguration>(configure);
    }
}