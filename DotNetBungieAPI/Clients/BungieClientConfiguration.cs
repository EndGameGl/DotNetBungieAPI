using System;
using System.Text.Json;
using DotNetBungieAPI.Models.Applications;
using DotNetBungieAPI.Services.Default;
using DotNetBungieAPI.Services.Default.ServiceConfigurations;
using DotNetBungieAPI.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Unity;
using DefaultDestiny2DefinitionRepository = DotNetBungieAPI.Services.Default.DefaultDestiny2DefinitionRepository;

namespace DotNetBungieAPI.Clients
{
    public sealed class BungieClientConfiguration
    {
        private string _apiKey;
        private int _clientId;
        private string _clientSecret;
        private ApplicationScopes _applicationScopes;

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
        
        public bool CacheDefinitions { get; set; }

        /// <summary>
        /// Configures default console logger
        /// </summary>
        /// <param name="configure"></param>
        /// <returns></returns>
        public BungieClientConfiguration UseDefaultLogger(Action<DotNetBungieApiLoggerConfiguration> configure)
        {
            var configuration = new DotNetBungieApiLoggerConfiguration();
            configure(configuration);
            StaticUnityContainer.Container.RegisterInstance(configuration);
            StaticUnityContainer.Container.RegisterType<ILogger, DefaultDotNetBungieApiLogger>(TypeLifetime.Singleton);
            return this;
        }

        /// <summary>
        /// Enables this library use custom <see cref="Microsoft.Extensions.Logging.ILogger"/>
        /// </summary>
        /// <returns></returns>
        public BungieClientConfiguration UseCustomLogger<T>() where T : ILogger
        {
            StaticUnityContainer.Container.RegisterType(typeof(ILogger), typeof(T), TypeLifetime.Singleton);
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
            configure(configuration);
            StaticUnityContainer.Container.RegisterInstance(configuration);
            StaticUnityContainer.Container.RegisterType<IBungieNetJsonSerializer, DefaultBungieNetJsonSerializer>(
                TypeLifetime.Singleton);
            return this;
        }

        /// <summary>
        /// Sets custom <see cref="IBungieNetJsonSerializer"/> for this application
        /// </summary>
        /// <returns></returns>
        public BungieClientConfiguration UseCustomBungieNetJsonSerializer<T>() where T : IBungieNetJsonSerializer
        {
            StaticUnityContainer.Container.RegisterType(typeof(IBungieNetJsonSerializer), typeof(T),
                TypeLifetime.Singleton);
            return this;
        }

        public BungieClientConfiguration UseDefaultHttpClient(
            Action<DotNetBungieApiHttpClientConfiguration> configure)
        {
            var configuration = new DotNetBungieApiHttpClientConfiguration();
            configure(configuration);
            StaticUnityContainer.Container.RegisterInstance(configuration);
            StaticUnityContainer.Container.RegisterType<IDotNetBungieApiHttpClient, DefaultDotNetBungieApiHttpClient>(
                TypeLifetime.Singleton);
            return this;
        }

        public BungieClientConfiguration UseCustomHttpClient<T>() where T : IDotNetBungieApiHttpClient
        {
            StaticUnityContainer.Container.RegisterType(typeof(IDotNetBungieApiHttpClient), typeof(T),
                TypeLifetime.Singleton);
            return this;
        }

        public BungieClientConfiguration UseDefaultAuthorizationHandler()
        {
            StaticUnityContainer.Container.RegisterType<IAuthorizationHandler, DefaultAuthorizationHandler>(TypeLifetime
                .Singleton);
            return this;
        }

        public BungieClientConfiguration UseCustomAuthorizationHandler<T>() where T : IAuthorizationHandler
        {
            StaticUnityContainer.Container.RegisterType(typeof(IAuthorizationHandler), typeof(T),
                TypeLifetime.Singleton);
            return this;
        }

        public BungieClientConfiguration UseDefaultDefinitionProvider(
            Action<DotNetBungieApiDefaultDefinitionProviderConfiguration> configure)
        {
            var configuration = new DotNetBungieApiDefaultDefinitionProviderConfiguration();
            configure(configuration);
            StaticUnityContainer.Container.RegisterInstance(configuration);
            StaticUnityContainer.Container.RegisterType<IDefinitionProvider, SqliteDefinitionProvider>(TypeLifetime
                .Singleton);
            return this;
        }

        public BungieClientConfiguration UseCustomDefinitionProvider<T>()
        {
            StaticUnityContainer.Container.RegisterType(typeof(IDefinitionProvider), typeof(T),
                TypeLifetime.Singleton);
            return this;
        }

        public BungieClientConfiguration UseDefaultDefinitionRepository(
            Action<DefaultDestiny2DefinitionRepositoryConfiguration> configure)
        {
            var configuration = new DefaultDestiny2DefinitionRepositoryConfiguration();
            configure(configuration);
            StaticUnityContainer.Container.RegisterInstance(configuration);
            StaticUnityContainer.Container
                .RegisterType<IDestiny2DefinitionRepository, Services.Default.DefaultDestiny2DefinitionRepository>(TypeLifetime
                    .Singleton);
            return this;
        }

        public BungieClientConfiguration UseCustomDefinitionRepository<T>()
        {
            StaticUnityContainer.Container.RegisterType(typeof(IDestiny2DefinitionRepository), typeof(T),
                TypeLifetime.Singleton);
            return this;
        }
    }
}