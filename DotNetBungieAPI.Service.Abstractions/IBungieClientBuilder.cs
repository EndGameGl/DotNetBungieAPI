using Microsoft.Extensions.Logging;

namespace DotNetBungieAPI.Service.Abstractions;

public interface IBungieClientBuilder
{
    IBungieClientConfiguration ClientConfiguration { get; }
    IServiceConfigurator<IAuthorizationHandler> Authorization { get; }
    IServiceConfigurator<IDestiny2DefinitionRepository> DefinitionRepository { get; }
    IServiceConfigurator<IDefinitionProvider> DefinitionProvider { get; }
    IServiceConfigurator<IDestiny2ResetService> Destiny2ResetService { get; }
    IServiceConfigurator<IBungieNetJsonSerializer> BungieNetJsonSerializer { get; }
    IServiceConfigurator<IDotNetBungieApiHttpClient> DotNetBungieApiHttpClient { get; }
}