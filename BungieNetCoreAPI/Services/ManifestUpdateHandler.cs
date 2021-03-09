using BungieNetCoreAPI.Clients;
using BungieNetCoreAPI.Destiny;
using BungieNetCoreAPI.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BungieNetCoreAPI.Services
{
    public class ManifestUpdateHandler : IManifestUpdateHandler
    {
        private readonly ILogger _logger;
        private readonly IConfigurationService _configuration;
        private Dictionary<DestinyManifest, string> _manifests;
        private string _versionControlPath;
        private DestinyManifest _currentUsedManifest;

        public DestinyManifest CurrentManifest => _currentUsedManifest;

        public ManifestUpdateHandler(ILogger logger, IConfigurationService configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _manifests = new Dictionary<DestinyManifest, string>();
            _versionControlPath = _configuration.Settings.VersionsRepositoryPath;
        }

        public async Task UpdateManifestData()
        {
            _logger.Log("Checking manifest version...", LogType.Info);
            _logger.Log("Downloading latest manifest...", LogType.Info);
            var latestManifest = await BungieClient.Platform.GetDestinyManifest();
            var latestFoundEqual = _manifests.Keys.FirstOrDefault(x => x.Version.Equals(latestManifest.Response.Version));
            if (latestFoundEqual != null)
            {
                _logger.Log("Manifest is already up to date.", LogType.Info);
                _currentUsedManifest = latestFoundEqual;
            }
            else
            {
                _logger.Log("Manifest requires update.", LogType.Info);
                _currentUsedManifest = latestManifest.Response;
            }
        }

        public async Task InitiateManifestHandler()
        {
            _logger.Log("initializing manifest handler...", LogType.Info);
            if (!Directory.Exists(_versionControlPath))
                Directory.CreateDirectory(_versionControlPath);

            var versions = Directory.GetDirectories(_versionControlPath);
            _logger.Log($"{versions.Length} folders found in versions directory. Attempting to find manifests...", LogType.Info);
            foreach (var version in versions)
            {
                var files = Directory.GetFiles(version);
                var manifest = files.FirstOrDefault(x => Path.GetFileName(x) == "Manifest.json");
                if (!string.IsNullOrWhiteSpace(manifest))
                {
                    _logger.Log($"Found manifest at: {manifest}", LogType.Info);
                    var folderManifest = JsonConvert.DeserializeObject<DestinyManifest>(await File.ReadAllTextAsync(manifest));
                    _logger.Log($"Manifest version: {folderManifest.Version} - Date: {folderManifest.VersionDate}", LogType.Info);
                    _manifests.Add(folderManifest, version);
                }
            }
        }

        public async Task LoadData()
        {
            if (_currentUsedManifest == null)
                _currentUsedManifest = _manifests.Keys.Last();
            _logger.Log("Downloading/verifying manifest data.", LogType.Info);
            await _currentUsedManifest.DownloadAndSaveToLocalFiles(true);
            var repo = StaticUnityContainer.GetDestinyDefinitionRepositories();
            repo.LoadAllDataFromDisk(
                localManifestPath: $"{_versionControlPath}\\{_currentUsedManifest.Version}",
                manifest: _currentUsedManifest);
            _logger.Log("Manifest load finished.", LogType.Info);
        }
    }
}
