namespace DotNetBungieAPI.Service.Abstractions;

/// <summary>
///     Bungie client builder
/// </summary>
public interface IBungieClientBuilder
{
    /// <summary>
    ///     Main client configuration
    /// </summary>
    IBungieClientConfiguration ClientConfiguration { get; }

    /// <summary>
    ///     OAuth2 client configuration
    /// </summary>
    IServiceConfigurator<IAuthorizationHandler> Authorization { get; }

    /// <summary>
    ///     Definition repository configuration
    /// </summary>
    IServiceConfigurator<IDestiny2DefinitionRepository> DefinitionRepository { get; }

    /// <summary>
    ///     Definition provider configuration
    /// </summary>
    IServiceConfigurator<IDefinitionProvider> DefinitionProvider { get; }

    /// <summary>
    ///     Destiny 2 reset service configuration
    /// </summary>
    IServiceConfigurator<IDestiny2ResetService> Destiny2ResetService { get; }

    /// <summary>
    ///     Json serializer configuration
    /// </summary>
    IServiceConfigurator<IBungieNetJsonSerializer> BungieNetJsonSerializer { get; }

    /// <summary>
    ///     Http client configuration
    /// </summary>
    IServiceConfigurator<IDotNetBungieApiHttpClient> DotNetBungieApiHttpClient { get; }
}
