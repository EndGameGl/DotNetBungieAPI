using System;
using System.Text.Json;
using DotNetBungieAPI.Models.Applications;
using DotNetBungieAPI.Services.Default;
using DotNetBungieAPI.Services.Default.ServiceConfigurations;
using DotNetBungieAPI.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DefaultDestiny2DefinitionRepository = DotNetBungieAPI.Services.Default.DefaultDestiny2DefinitionRepository;

namespace DotNetBungieAPI.Clients
{
    public sealed class BungieClientConfiguration
    {
        internal readonly IServiceCollection ServiceCollection;
        internal readonly Lazy<Type> DefaultAuthorizationHandlerType = new(() => typeof(DefaultAuthorizationHandler));
        internal readonly Lazy<Type> DefaultSerializerType = new(() => typeof(DefaultBungieNetJsonSerializer));
        internal readonly Lazy<Type> DefaultRepositoryType = new(() => typeof(DefaultDestiny2DefinitionRepository));
        internal readonly Lazy<Type> DefaultHttpClientType = new(() => typeof(DefaultDotNetBungieApiHttpClient));
        internal readonly Lazy<Type> DefaultLoggerType = new(() => typeof(DefaultDotNetBungieApiLogger));
        internal readonly Lazy<Type> DefaultDefinitionProviderType = new(() => typeof(SqliteDefinitionProvider));

        private string _apiKey;
        private int _clientId;
        private string _clientSecret;
        private ApplicationScopes _applicationScopes;

        /// <summary>
        /// Checks whether scope is available for this app
        /// </summary>
        /// <param name="applicationScope"></param>
        /// <returns></returns>
        public bool HasSufficientRights(ApplicationScopes applicationScope)
        {
            return _applicationScopes.HasFlag(applicationScope);
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
        public ApplicationScopes ApplicationScopes
        {
            get => _applicationScopes;
            set => _applicationScopes = value;
        }

        /// <summary>
        /// Caches definitions to repository if not present currently after fetching from provider.
        /// </summary>
        public bool CacheDefinitions { get; set; }

        internal BungieClientConfiguration(IServiceCollection serviceCollection)
        {
            ServiceCollection = serviceCollection;
        }

        /// <summary>
        /// Configures default console logger
        /// </summary>
        /// <param name="configure"></param>
        /// <returns></returns>
        public BungieClientConfiguration UseDefaultLogger(Action<DotNetBungieApiLoggerConfiguration> configure)
        {
            var configuration = new DotNetBungieApiLoggerConfiguration();
            configure?.Invoke(configuration);
            ServiceCollection.AddSingleton(configuration);
            ServiceCollection.AddSingleton(typeof(ILogger), DefaultLoggerType.Value);
            return this;
        }

        /// <summary>
        /// Enables this library use custom <see cref="Microsoft.Extensions.Logging.ILogger"/>
        /// </summary>
        /// <returns></returns>
        public BungieClientConfiguration UseCustomLogger<T>() where T : ILogger
        {
            ServiceCollection.AddSingleton(typeof(ILogger), typeof(T));
            return this;
        }

        /// <summary>
        /// Configures default json serializer for this application 
        /// </summary>
        /// <param name="configure"></param>
        /// <returns></returns>
        public BungieClientConfiguration UseDefaultBungieNetJsonSerializer(
            Action<DotNetBungieApiJsonSerializerConfiguration> configure)
        {
            var configuration = new DotNetBungieApiJsonSerializerConfiguration()
            {
                Options = new JsonSerializerOptions()
            };
            configure?.Invoke(configuration);
            ServiceCollection.AddSingleton(configuration);
            ServiceCollection.AddSingleton(typeof(IBungieNetJsonSerializer), DefaultSerializerType.Value);
            return this;
        }

        /// <summary>
        /// Sets custom <see cref="IBungieNetJsonSerializer"/> for this application
        /// </summary>
        /// <returns></returns>
        public BungieClientConfiguration UseCustomBungieNetJsonSerializer<T>() where T : IBungieNetJsonSerializer
        {
            ServiceCollection.AddSingleton(typeof(IBungieNetJsonSerializer), typeof(T));
            return this;
        }

        public BungieClientConfiguration UseDefaultHttpClient(
            Action<DotNetBungieApiHttpClientConfiguration> configure)
        {
            var configuration = new DotNetBungieApiHttpClientConfiguration();
            configure?.Invoke(configuration);
            ServiceCollection.AddSingleton(configuration);
            ServiceCollection.AddSingleton(typeof(IDotNetBungieApiHttpClient), DefaultHttpClientType.Value);
            return this;
        }

        public BungieClientConfiguration UseCustomHttpClient<T>() where T : IDotNetBungieApiHttpClient
        {
            ServiceCollection.AddSingleton(typeof(IDotNetBungieApiHttpClient), typeof(T));
            return this;
        }

        public BungieClientConfiguration UseDefaultAuthorizationHandler()
        {
            ServiceCollection.AddSingleton(typeof(IAuthorizationHandler), DefaultAuthorizationHandlerType.Value);
            return this;
        }

        public BungieClientConfiguration UseCustomAuthorizationHandler<T>() where T : IAuthorizationHandler
        {
            ServiceCollection.AddSingleton(typeof(IAuthorizationHandler), typeof(T));
            return this;
        }

        public BungieClientConfiguration UseDefaultDefinitionProvider(
            Action<DotNetBungieApiDefaultDefinitionProviderConfiguration> configure)
        {
            var configuration = new DotNetBungieApiDefaultDefinitionProviderConfiguration();
            configure?.Invoke(configuration);
            ServiceCollection.AddSingleton(configuration);
            ServiceCollection.AddSingleton(typeof(IDefinitionProvider), DefaultDefinitionProviderType.Value);
            return this;
        }

        public BungieClientConfiguration UseCustomDefinitionProvider<T>() where T : IDefinitionProvider
        {
            ServiceCollection.AddSingleton(typeof(IDefinitionProvider), typeof(T));
            return this;
        }

        public BungieClientConfiguration UseDefaultDefinitionRepository(
            Action<DefaultDestiny2DefinitionRepositoryConfiguration> configure)
        {
            var configuration = new DefaultDestiny2DefinitionRepositoryConfiguration();
            configure?.Invoke(configuration);
            ServiceCollection.AddSingleton(configuration);
            ServiceCollection.AddSingleton(typeof(IDestiny2DefinitionRepository), DefaultRepositoryType.Value);
            return this;
        }

        public BungieClientConfiguration UseCustomDefinitionRepository<T>() where T : IDestiny2DefinitionRepository
        {
            ServiceCollection.AddSingleton(typeof(IDestiny2DefinitionRepository), typeof(T));
            return this;
        }
    }
}