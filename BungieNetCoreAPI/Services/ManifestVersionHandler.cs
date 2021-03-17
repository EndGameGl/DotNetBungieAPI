using NetBungieAPI.Clients;
using NetBungieAPI.Destiny;
using NetBungieAPI.Logging;
using NetBungieAPI.Repositories;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NetBungieAPI.Services
{
    public class ManifestVersionHandler : IManifestVersionHandler
    {
        private readonly IDestiny2MethodsAccess _d2Api;
        private readonly ILogger _logger;
        private readonly IConfigurationService _configuration;
        private readonly ILocalisedDestinyDefinitionRepositories _repository;

        private DestinyManifest _currentUsedManifest;

        public DestinyManifest CurrentManifest => _currentUsedManifest;

        public ManifestVersionHandler(ILogger logger, IConfigurationService configuration, IDestiny2MethodsAccess d2Api,
            ILocalisedDestinyDefinitionRepositories repository)
        {
            _d2Api = d2Api;
            _logger = logger;
            _configuration = configuration;
            _repository = repository;
        }

        public async Task InitiateManifestHandler()
        {
            if (_configuration.Settings.IsUsingPreloadedData)
            {
                var manifests = await CollectManifestData();
                if (_configuration.Settings.ShouldLoadSpecifiedManifest)
                {
                    var manifest = manifests.FirstOrDefault(x => x.Version == _configuration.Settings.PreferredLoadedManifest);
                    if (manifest != null)
                    {
                        _currentUsedManifest = manifest;
                        await LoadData(manifest);
                    }
                }
                else if (_configuration.Settings.CheckUpdates)
                {
                    var latestManifest = await CheckManifestUpdates(manifests);
                    _currentUsedManifest = latestManifest;
                    await LoadData(latestManifest);
                }
                else
                {
                    var latestDate = manifests.Max(x => x.VersionDate);
                    var latestManifest = manifests.Single(x => x.VersionDate == latestDate);
                    _currentUsedManifest = latestManifest;
                    await LoadData(latestManifest);
                }
            }
        }
        private async Task LoadData(DestinyManifest manifest)
        {
            await manifest.DownloadAndSaveToLocalFiles(unpackSqlite: true);

            _repository.LoadAllDataFromDisk(
                localManifestPath: $"{_configuration.Settings.VersionsRepositoryPath}\\{_currentUsedManifest.Version}",
                manifest: manifest);
            _logger.Log("Manifest load finished.", LogType.Info);
        }
        private async Task<List<DestinyManifest>> CollectManifestData()
        {
            if (!Directory.Exists(_configuration.Settings.VersionsRepositoryPath))
                Directory.CreateDirectory(_configuration.Settings.VersionsRepositoryPath);

            List<DestinyManifest> manifests = new List<DestinyManifest>();
            var versions = Directory.GetDirectories(_configuration.Settings.VersionsRepositoryPath);
            _logger.Log($"{versions.Length} folders found in versions directory. Attempting to find manifests...", LogType.Info);

            foreach (var version in versions)
            {
                var files = Directory.GetFiles(version);
                var manifest = files.FirstOrDefault(x => Path.GetFileName(x) == "Manifest.json");
                if (!string.IsNullOrWhiteSpace(manifest))
                {
                    _logger.Log($"Found manifest at: {manifest}", LogType.Info);
                    var folderManifest = JsonConvert.DeserializeObject<DestinyManifest>(await File.ReadAllTextAsync(manifest));
                    _logger.Log($"Manifest version: {folderManifest.Version} - Date: {folderManifest.VersionDate.ToShortDateString()}", LogType.Info);
                    manifests.Add(folderManifest);
                }
            }

            return manifests;
        }
        private async Task<DestinyManifest> CheckManifestUpdates(IEnumerable<DestinyManifest> destinyManifests)
        {
            var latestManifest = (await _d2Api.GetDestinyManifest()).Response;

            if (destinyManifests.Count() == 0)
                return latestManifest;

            if (destinyManifests.Any(x => x.Version.Equals(latestManifest.Version)))
                return latestManifest;

            return latestManifest;
        }
    }
}
