﻿using NetBungieAPI.Authrorization;
using NetBungieAPI.Logging;
using NetBungieAPI.Repositories;
using NetBungieAPI.Services.Interfaces;
using System;
using System.Text;
using System.Threading.Tasks;
using static NetBungieAPI.Logging.LogListener;

namespace NetBungieAPI.Clients
{
    public class BungieClient : IBungieClient
    {
        private readonly IConfigurationService _configuration;
        private readonly IAuthorizationStateHandler _authHandler;
        private readonly IHttpClientInstance _httpClient;
        private readonly IManifestVersionHandler _versionControl;
        private readonly ILogger _logger;

        private LogListener _logListener;

        public ILocalisedDestinyDefinitionRepositories Repository { get; }
        public IBungieApiAccess ApiAccess { get; }

        internal BungieClient(IConfigurationService config, IManifestVersionHandler manifestUpdateHandler,
            ILogger logger, IBungieApiAccess apiAccess, IHttpClientInstance httpClient,
            IAuthorizationStateHandler authorizationHandler, ILocalisedDestinyDefinitionRepositories repository)
        {
            _configuration = config;
            _httpClient = httpClient;
            _logger = logger;
            _versionControl = manifestUpdateHandler;
            _authHandler = authorizationHandler;
            Repository = repository;
            ApiAccess = apiAccess;
            _logListener = new LogListener();
            _logger.Register(_logListener);
        }

        public async ValueTask<bool> CheckUpdates()
        {
            return await _versionControl.HasUpdates();
        }

        public async Task DownloadLatestManifestLocally()
        {
            await _versionControl.DownloadLastVersion();
        }

        public void LoadDefinitions()
        {
            Repository.Initialize(_configuration.Settings.DefinitionLoadingSettings.Locales);
            Repository.LoadAllDataFromDisk(_configuration.Settings.LocalFileSettings.VersionsRepositoryPath,
                _versionControl.CurrentUsedManifest);
        }

        public void AddListener(NewMessageEvent eventHandler)
        {
            if (_logListener != null)
                _logListener.OnNewMessage += eventHandler;
            ;
        }

        private bool TryGetAuthorizationValue(out string value)
        {
            value = default;
            if (!_configuration.Settings.IdentificationSettings.ClientId.HasValue ||
                string.IsNullOrEmpty(_configuration.Settings.IdentificationSettings.ClientSecret))
                return false;

            value = Convert.ToBase64String(
                Encoding.UTF8.GetBytes(
                    $"{_configuration.Settings.IdentificationSettings.ClientId}:{_configuration.Settings.IdentificationSettings.ClientSecret}"));

            return true;
        }

        public string GetAuthorizationLink()
        {
            var awaiter = _authHandler.CreateNewAuthAwaiter();
            return _httpClient.GetAuthLink(_configuration.Settings.IdentificationSettings.ClientId.Value,
                awaiter.State);
        }

        public void ReceiveCode(string state, string code)
        {
            _authHandler.InputCode(state, code);
        }

        public async Task<AuthorizationTokenData> GetAuthorizationToken(string code)
        {
            if (TryGetAuthorizationValue(out var value))
            {
                var token = await _httpClient.GetAuthorizationToken(code, value);
                _authHandler.AddAuthToken(token);
                return token;
            }
            else
                throw new Exception("Couldn't form authorization value.");
        }

        public async Task<AuthorizationTokenData> RenewAuthorizationToken(AuthorizationTokenData oldToken)
        {
            return await _httpClient.RenewAuthorizationToken(oldToken);
        }

        public void SetAuthToken(AuthorizationTokenData token)
        {
            _authHandler.AddAuthToken(token);
        }
    }
}