using DotNetBungieAPI.Exceptions;
using DotNetBungieAPI.Models.Applications;
using DotNetBungieAPI.Services.Default;
using DotNetBungieAPI.Services.Default.ServiceConfigurations;
using DotNetBungieAPI.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DotNetBungieAPI.Clients;

public sealed class BungieClientConfiguration
{
    internal bool AuthHandlerConfigured = false;
    internal bool DefinitionProviderConfigured = false;
    internal bool HttpClientConfigured = false;
    internal bool LoggerConfigured = false;
    internal bool RepositoryConfigured = false;
    internal bool SerializerConfigured = false;
    internal bool ResetServiceConfigured = false;

    internal readonly Lazy<Type> DefaultAuthorizationHandlerType = new(() => typeof(DefaultAuthorizationHandler));
    internal readonly Lazy<Type> DefaultDefinitionProviderType = new(() => typeof(SqliteDefinitionProvider));
    internal readonly Lazy<Type> DefaultHttpClientType = new(() => typeof(DefaultDotNetBungieApiHttpClient));
    internal readonly Lazy<Type> DefaultLoggerType = new(() => typeof(DefaultDotNetBungieApiLogger));
    internal readonly Lazy<Type> DefaultRepositoryType = new(() => typeof(DefaultDestiny2DefinitionRepository));
    internal readonly Lazy<Type> DefaultSerializerType = new(() => typeof(DefaultBungieNetJsonSerializer));
    internal readonly Lazy<Type> DefaultResetServiceType = new(() => typeof(DefaultDestiny2ResetService));
    internal readonly IServiceCollection ServiceCollection;

    private string _apiKey;
    private int _clientId;
    private string _clientSecret;

    internal BungieClientConfiguration(IServiceCollection serviceCollection)
    {
        ServiceCollection = serviceCollection;
    }

    /// <summary>
    ///     Application API key. You can find one at https://www.bungie.net/en/Application.
    /// </summary>
    public string ApiKey
    {
        get => _apiKey;
        set => _apiKey = Conditions.NotNullOrWhiteSpace(value);
    }

    /// <summary>
    ///     Application OAuth client ID. You can find one at https://www.bungie.net/en/Application.
    /// </summary>
    public int ClientId
    {
        get => _clientId;
        set => _clientId = Conditions.Int32MoreThan(value, 0);
    }

    /// <summary>
    ///     Application OAuth client secret. You can find one at https://www.bungie.net/en/Application.
    /// </summary>
    public string ClientSecret
    {
        get => _clientSecret;
        set => _clientSecret = Conditions.NotNullOrWhiteSpace(value);
    }

    /// <summary>
    ///     Only specified scope API operations will be allowed to run in this app.
    /// </summary>
    public ApplicationScopes ApplicationScopes { get; set; }

    /// <summary>
    ///     Caches definitions to repository if not present currently after fetching from provider.
    /// </summary>
    public bool CacheDefinitions { get; set; }

    /// <summary>
    ///     Checks whether scope is available for this app
    /// </summary>
    /// <param name="applicationScope"></param>
    /// <returns></returns>
    public bool HasSufficientRights(ApplicationScopes applicationScope)
    {
        return ApplicationScopes.HasFlag(applicationScope);
    }

    /// <summary>
    ///     Configures default console logger
    /// </summary>
    /// <param name="configure"></param>
    /// <returns></returns>
    public BungieClientConfiguration UseDefaultLogger(Action<DotNetBungieApiLoggerConfiguration> configure = null)
    {
        if (LoggerConfigured)
            throw new ServiceAlreadyConfiguredException(typeof(ILogger));

        var configuration = new DotNetBungieApiLoggerConfiguration();
        configure?.Invoke(configuration);
        ServiceCollection.AddSingleton(configuration);
        ServiceCollection.AddSingleton(typeof(ILogger), DefaultLoggerType.Value);
        LoggerConfigured = true;
        return this;
    }

    /// <summary>
    ///     Enables this library use custom <see cref="Microsoft.Extensions.Logging.ILogger" />
    /// </summary>
    /// <returns></returns>
    public BungieClientConfiguration UseCustomLogger<T>() where T : ILogger
    {
        if (LoggerConfigured)
            throw new ServiceAlreadyConfiguredException(typeof(ILogger));

        ServiceCollection.AddSingleton(typeof(ILogger), typeof(T));
        LoggerConfigured = true;
        return this;
    }

    /// <summary>
    ///     Configures default json serializer for this application
    /// </summary>
    /// <param name="configure"></param>
    /// <returns></returns>
    public BungieClientConfiguration UseDefaultBungieNetJsonSerializer(
        Action<DotNetBungieApiJsonSerializerConfiguration> configure = null)
    {
        if (SerializerConfigured)
            throw new ServiceAlreadyConfiguredException(typeof(IBungieNetJsonSerializer));

        var configuration = new DotNetBungieApiJsonSerializerConfiguration
        {
            Options = new JsonSerializerOptions()
        };
        configure?.Invoke(configuration);
        ServiceCollection.AddSingleton(configuration);
        ServiceCollection.AddSingleton(typeof(IBungieNetJsonSerializer), DefaultSerializerType.Value);
        SerializerConfigured = true;
        return this;
    }

    /// <summary>
    ///     Sets custom <see cref="IBungieNetJsonSerializer" /> for this application
    /// </summary>
    /// <returns></returns>
    public BungieClientConfiguration UseCustomBungieNetJsonSerializer<T>() where T : IBungieNetJsonSerializer
    {
        if (SerializerConfigured)
            throw new ServiceAlreadyConfiguredException(typeof(IBungieNetJsonSerializer));

        ServiceCollection.AddSingleton(typeof(IBungieNetJsonSerializer), typeof(T));
        SerializerConfigured = true;
        return this;
    }

    /// <summary>
    ///     Configures default <see cref="IDotNetBungieApiHttpClient"/> for this application
    /// </summary>
    /// <param name="configure"></param>
    /// <returns></returns>
    public BungieClientConfiguration UseDefaultHttpClient(
        Action<DotNetBungieApiHttpClientConfiguration> configure = null)
    {
        if (HttpClientConfigured)
            throw new ServiceAlreadyConfiguredException(typeof(IDotNetBungieApiHttpClient));

        var configuration = new DotNetBungieApiHttpClientConfiguration();
        configure?.Invoke(configuration);
        ServiceCollection.AddSingleton(configuration);
        ServiceCollection.AddSingleton(typeof(IDotNetBungieApiHttpClient), DefaultHttpClientType.Value);
        HttpClientConfigured = true;
        return this;
    }

    /// <summary>
    ///     Sets custom <see cref="IDotNetBungieApiHttpClient"/> for this application
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public BungieClientConfiguration UseCustomHttpClient<T>() where T : IDotNetBungieApiHttpClient
    {
        if (HttpClientConfigured)
            throw new ServiceAlreadyConfiguredException(typeof(IDotNetBungieApiHttpClient));

        ServiceCollection.AddSingleton(typeof(IDotNetBungieApiHttpClient), typeof(T));
        HttpClientConfigured = true;
        return this;
    }

    /// <summary>
    ///     Configures default <see cref="IAuthorizationHandler"/> for this application
    /// </summary>
    /// <returns></returns>
    public BungieClientConfiguration UseDefaultAuthorizationHandler()
    {
        if (AuthHandlerConfigured)
            throw new ServiceAlreadyConfiguredException(typeof(IAuthorizationHandler));

        ServiceCollection.AddSingleton(typeof(IAuthorizationHandler), DefaultAuthorizationHandlerType.Value);
        AuthHandlerConfigured = true;
        return this;
    }

    /// <summary>
    ///     Uses custom <see cref="IAuthorizationHandler"/> implementation for this application
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public BungieClientConfiguration UseCustomAuthorizationHandler<T>() where T : IAuthorizationHandler
    {
        if (AuthHandlerConfigured)
            throw new ServiceAlreadyConfiguredException(typeof(IAuthorizationHandler));

        ServiceCollection.AddSingleton(typeof(IAuthorizationHandler), typeof(T));
        AuthHandlerConfigured = true;
        return this;
    }

    /// <summary>
    ///     Configures default <see cref="IDefinitionProvider"/> for this application
    /// </summary>
    /// <param name="configure"></param>
    /// <returns></returns>
    public BungieClientConfiguration UseDefaultDefinitionProvider(
        Action<DotNetBungieApiDefaultDefinitionProviderConfiguration> configure = null)
    {
        if (DefinitionProviderConfigured)
            throw new ServiceAlreadyConfiguredException(typeof(IDefinitionProvider));

        var configuration = new DotNetBungieApiDefaultDefinitionProviderConfiguration();
        configure?.Invoke(configuration);
        ServiceCollection.AddSingleton(configuration);
        ServiceCollection.AddSingleton(typeof(IDefinitionProvider), DefaultDefinitionProviderType.Value);
        DefinitionProviderConfigured = true;
        return this;
    }

    /// <summary>
    ///     Uses custom <see cref="IDefinitionProvider"/> implementation for this application
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public BungieClientConfiguration UseCustomDefinitionProvider<T>() where T : IDefinitionProvider
    {
        if (DefinitionProviderConfigured)
            throw new ServiceAlreadyConfiguredException(typeof(IDefinitionProvider));

        ServiceCollection.AddSingleton(typeof(IDefinitionProvider), typeof(T));
        DefinitionProviderConfigured = true;
        return this;
    }

    /// <summary>
    ///      Configures default <see cref="IDestiny2DefinitionRepository"/> for this application
    /// </summary>
    /// <param name="configure"></param>
    /// <returns></returns>
    public BungieClientConfiguration UseDefaultDefinitionRepository(
        Action<DefaultDestiny2DefinitionRepositoryConfiguration> configure = null)
    {
        if (RepositoryConfigured)
            throw new ServiceAlreadyConfiguredException(typeof(IDestiny2DefinitionRepository));

        var configuration = new DefaultDestiny2DefinitionRepositoryConfiguration();
        configure?.Invoke(configuration);
        ServiceCollection.AddSingleton(configuration);
        ServiceCollection.AddSingleton(typeof(IDestiny2DefinitionRepository), DefaultRepositoryType.Value);
        RepositoryConfigured = true;
        return this;
    }

    /// <summary>
    ///     Uses custom <see cref="IDestiny2DefinitionRepository"/> implementation for this application
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public BungieClientConfiguration UseCustomDefinitionRepository<T>() where T : IDestiny2DefinitionRepository
    {
        if (RepositoryConfigured)
            throw new ServiceAlreadyConfiguredException(typeof(IDestiny2DefinitionRepository));

        ServiceCollection.AddSingleton(typeof(IDestiny2DefinitionRepository), typeof(T));
        RepositoryConfigured = true;
        return this;
    }

    /// <summary>
    ///     Configures default <see cref="IDestiny2ResetService"/> for this application
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ServiceAlreadyConfiguredException"></exception>
    public BungieClientConfiguration UseDefaultDestiny2ResetService()
    {
        if (ResetServiceConfigured)
            throw new ServiceAlreadyConfiguredException(typeof(IDestiny2ResetService));

        ServiceCollection.AddSingleton(typeof(IDestiny2ResetService), DefaultResetServiceType.Value);
        ResetServiceConfigured = true;
        return this;
    }

    /// <summary>
    ///     Uses custom <see cref="IDestiny2ResetService"/> implementation for this application
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ServiceAlreadyConfiguredException"></exception>
    public BungieClientConfiguration UseCustomDestiny2ResetService<T>() where T : IDestiny2ResetService
    {
        if (ResetServiceConfigured)
            throw new ServiceAlreadyConfiguredException(typeof(IDestiny2ResetService));

        ServiceCollection.AddSingleton(typeof(IDestiny2ResetService), typeof(T));
        ResetServiceConfigured = true;
        return this;
    }
}