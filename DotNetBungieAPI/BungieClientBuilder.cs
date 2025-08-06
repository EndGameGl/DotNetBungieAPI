using DotNetBungieAPI.ApiBuilder;
using DotNetBungieAPI.Clients;
using DotNetBungieAPI.Service.Abstractions;
using DotNetBungieAPI.Services.Implementations;
using DotNetBungieAPI.Services.Implementations.ServiceConfigurations;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetBungieAPI;

public class BungieClientBuilder : IBungieClientBuilder
{
    public IBungieClientConfiguration ClientConfiguration { get; }
    public IServiceConfigurator<IAuthorizationHandler> Authorization { get; }
    public IServiceConfigurator<IDestiny2DefinitionRepository> DefinitionRepository { get; }
    public IServiceConfigurator<IDefinitionProvider> DefinitionProvider { get; }
    public IServiceConfigurator<IDestiny2ResetService> Destiny2ResetService { get; }
    public IServiceConfigurator<IBungieNetJsonSerializer> BungieNetJsonSerializer { get; }
    public IServiceConfigurator<IDotNetBungieApiHttpClient> DotNetBungieApiHttpClient { get; }

    public BungieClientBuilder(IServiceCollection? serviceCollection)
    {
        serviceCollection ??= new ServiceCollection();
        ClientConfiguration = new BungieClientConfiguration();
        Authorization = new ServiceConfigurator<IAuthorizationHandler>(serviceCollection);
        DefinitionRepository = new ServiceConfigurator<IDestiny2DefinitionRepository>(serviceCollection);
        DefinitionProvider = new ServiceConfigurator<IDefinitionProvider>(serviceCollection);
        Destiny2ResetService = new ServiceConfigurator<IDestiny2ResetService>(serviceCollection);
        BungieNetJsonSerializer = new ServiceConfigurator<IBungieNetJsonSerializer>(serviceCollection);
        DotNetBungieApiHttpClient = new ServiceConfigurator<IDotNetBungieApiHttpClient>(serviceCollection);
    }

    public void ValidateAndRegisterServices()
    {
        if ((Authorization as ServiceConfigurator<IAuthorizationHandler>)!.IsConfigured is false)
        {
            Authorization.Use<DefaultAuthorizationHandler>();
        }

        if ((DefinitionRepository as ServiceConfigurator<IDestiny2DefinitionRepository>)!.IsConfigured is false)
        {
            DefinitionRepository.Use<DefaultDestiny2DefinitionRepository, DefaultDestiny2DefinitionRepositoryConfiguration>((_) => { });
        }

        if ((DefinitionProvider as ServiceConfigurator<IDefinitionProvider>)!.IsConfigured is false)
        {
            DefinitionProvider.Use<NullDefinitionProvider, NullDefinitionProviderConfig>((_) => { });
        }

        if ((Destiny2ResetService as ServiceConfigurator<IDestiny2ResetService>)!.IsConfigured is false)
        {
            Destiny2ResetService.Use<DefaultDestiny2ResetService>();
        }

        if ((BungieNetJsonSerializer as ServiceConfigurator<IBungieNetJsonSerializer>)!.IsConfigured is false)
        {
            BungieNetJsonSerializer.Use<DefaultBungieNetJsonSerializer, DotNetBungieApiJsonSerializerConfiguration>((_) => { });
        }

        if ((DotNetBungieApiHttpClient as ServiceConfigurator<IDotNetBungieApiHttpClient>)!.IsConfigured is false)
        {
            DotNetBungieApiHttpClient.Use<DefaultDotNetBungieApiHttpClient, DotNetBungieApiHttpClientConfiguration>((_) => { });
        }
    }
}
