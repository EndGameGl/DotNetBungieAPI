using NetBungieAPI.Logging;
using NetBungieAPI.Models;
using NetBungieAPI.Repositories;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using NetBungieAPI.Models.Destiny.Config;

namespace NetBungieAPI.Services
{
    public class ManifestVersionHandler : IManifestVersionHandler
    {
        internal const ManifestContentDownloadFilter AllFilters =
            ManifestContentDownloadFilter.JsonWorldComponentContent |
            ManifestContentDownloadFilter.JsonWorldContent |
            ManifestContentDownloadFilter.MobileAssetContent |
            ManifestContentDownloadFilter.MobileClanBannerDatabase |
            ManifestContentDownloadFilter.MobileGearAssetDataBases |
            ManifestContentDownloadFilter.MobileWorldContent;

        private Stopwatch _stopwatch = new Stopwatch();
        private readonly IJsonSerializationHelper _serializationHelper;
        private readonly IDestiny2MethodsAccess _d2Api;
        private readonly ILogger _logger;
        private readonly IConfigurationService _configuration;
        private readonly ILocalisedDestinyDefinitionRepositories _repository;
        private readonly IHttpClientInstance _httpClientInstance;

        private IList<DestinyManifest> _manifestsCache;
        private BungieResponse<DestinyManifest> _latestVersionApiResponse;
        public DestinyManifest CurrentUsedManifest => _latestVersionApiResponse.Response;

        public ManifestVersionHandler(ILogger logger, IConfigurationService configuration, IDestiny2MethodsAccess d2Api,
            ILocalisedDestinyDefinitionRepositories repository, IHttpClientInstance httpClientInstance, IJsonSerializationHelper serializationHelper)
        {
            _d2Api = d2Api;
            _logger = logger;
            _configuration = configuration;
            _repository = repository;
            _httpClientInstance = httpClientInstance;
            _serializationHelper = serializationHelper;
        }

        public async ValueTask<bool> HasUpdates()
        {
            if (!_configuration.Settings.ManifestVersionSettings.CheckUpdates)
                throw new Exception("Update checking is turned off. Apply proper settings to enable update checking.");

            var manifests = FindManifestsAt(_configuration.Settings.LocalFileSettings.VersionsRepositoryPath);

            _latestVersionApiResponse = await _d2Api.GetDestinyManifest();
            if (_latestVersionApiResponse?.Response == null)
                throw new Exception("Failed to load newest manifest.");

            var latestManifest = _latestVersionApiResponse.Response;
            if (manifests.Count == 0)
                return true;

            return !manifests.Any(x => x.Version.Equals(latestManifest.Version));
        }

        public IList<DestinyManifest> FindManifestsAt(string path)
        {
            if (!Directory.Exists(path))
                throw new Exception($"No manifest folder found at: {path}");

            var manifests = new List<DestinyManifest>();
            var versions = Directory.EnumerateDirectories(path);
            Parallel.ForEach(versions, (version) =>
            {
                var files = Directory.EnumerateFiles(version, "Manifest.json", SearchOption.TopDirectoryOnly);
                var manifestPath = files.FirstOrDefault();
                if (manifestPath == null) 
                    return;
                _logger.Log($"Found manifest at: {manifestPath}", LogType.Info);
                var json = File.ReadAllText(manifestPath);
                var folderManifest = _serializationHelper.Deserialize<DestinyManifest>(json);
                manifests.Add(folderManifest);
            });
            return manifests;
        }

        public async Task DownloadLastVersion()
        {
            if (_latestVersionApiResponse == null)
                _latestVersionApiResponse = await _d2Api.GetDestinyManifest();
            await DownloadManifestFilesLocally(_latestVersionApiResponse.Response,
                _configuration.Settings.LocalFileSettings.VersionsRepositoryPath, true);
        }

        public async Task DownloadManifestFilesLocally(DestinyManifest manifest, string path, bool unpackSQLite = true,
            ManifestContentDownloadFilter filters = AllFilters)
        {
            path = $"{path}\\{manifest.Version}";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            if (filters.HasFlag(ManifestContentDownloadFilter.MobileAssetContent))
                await DownloadMobileAssetContent(manifest, path, unpackSQLite);
            if (filters.HasFlag(ManifestContentDownloadFilter.MobileGearAssetDataBases))
                await DownloadMobileGearAssetDataBases(manifest, path, unpackSQLite);
            if (filters.HasFlag(ManifestContentDownloadFilter.MobileWorldContent))
                await DownloadMobileWorldContent(manifest, path, unpackSQLite);
            if (filters.HasFlag(ManifestContentDownloadFilter.JsonWorldContent))
                await DownloadJsonWorldContent(manifest, path);
            if (filters.HasFlag(ManifestContentDownloadFilter.JsonWorldComponentContent))
                await DownloadJsonWorldComponentContent(manifest, path);
            if (filters.HasFlag(ManifestContentDownloadFilter.MobileClanBannerDatabase))
                await DownloadMobileClanBannerDatabase(manifest, path, unpackSQLite);

            if (!File.Exists($"{path}/Manifest.json"))
            {
                var manifestJson = _serializationHelper.Serialize(CurrentUsedManifest);
                File.WriteAllText($"{path}/Manifest.json", manifestJson);
            }

            stopwatch.Stop();
            _logger.Log($"Finished getting data! {stopwatch.ElapsedMilliseconds} ms.", LogType.Info);
        }

        private static bool IsZIP(string filepath)
        {
            if (File.Exists(filepath))
            {
                try
                {
                    using var zipFile = ZipFile.OpenRead(filepath);
                    var entries = zipFile.Entries;
                    return true;
                }
                catch (InvalidDataException)
                {
                    return false;
                }
            }
            else
                return false;
        }

        private async Task DownloadMobileAssetContent(DestinyManifest manifest, string path, bool shouldUnpack)
        {
            _stopwatch.Start();
            _logger.Log("Started loading MobileAssetContent", LogType.Info);
            var filePath = $"{path}/MobileAssetContentPath/{Path.GetFileName(manifest.MobileAssetContentPath)}";
            var directoryPath = $"{path}/MobileAssetContentPath";

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            _logger.Log($"Getting data from: {manifest.MobileAssetContentPath}", LogType.Info);
            if (!File.Exists(filePath))
            {
                await _httpClientInstance.DownloadFileStreamFromCDNAsync(manifest.MobileAssetContentPath, filePath);
            }
            else
                _logger.Log("File already exists, skipping.", LogType.Info);

            if (shouldUnpack)
            {
                _logger.Log("Unpacking zip...", LogType.Info);
                var packedFileName = $"{filePath}.zip";
                if (IsZIP(filePath))
                {
                    File.Move(filePath, packedFileName);
                    ZipFile.ExtractToDirectory(packedFileName, directoryPath);
                    _logger.Log("Clearing leftovers.", LogType.Info);
                    File.Delete(packedFileName);
                }
                else
                    _logger.Log("File is already unpacked", LogType.Info);
            }

            _stopwatch.Stop();
            _logger.Log($"Finished loading MobileAssetContent: {_stopwatch.ElapsedMilliseconds} ms", LogType.Info);
            _stopwatch.Reset();
        }

        private async Task DownloadMobileGearAssetDataBases(DestinyManifest manifest, string path, bool shouldUnpack)
        {
            _stopwatch.Start();
            _logger.Log("Started loading MobileGearAssetDataBases", LogType.Info);
            var rootDirectoryPath = $"{path}/MobileGearAssetDataBases";
            if (!Directory.Exists(rootDirectoryPath))
                Directory.CreateDirectory(rootDirectoryPath);

            foreach (var entry in manifest.MobileGearAssetDataBases)
            {
                var entryPath = $"{path}/MobileGearAssetDataBases/{entry.Version}";
                var filePath = $"{path}/MobileGearAssetDataBases/{entry.Version}/{Path.GetFileName(entry.Path)}";
                if (!Directory.Exists(entryPath))
                    Directory.CreateDirectory(entryPath);

                if (!File.Exists(filePath))
                {
                    await _httpClientInstance.DownloadFileStreamFromCDNAsync(entry.Path, filePath);
                }
                else
                    _logger.Log("File already exists, skipping.", LogType.Info);

                if (!shouldUnpack) 
                    continue;
                _logger.Log("Unpacking zip...", LogType.Info);
                var packedFileName = $"{filePath}.zip";
                if (IsZIP($"{filePath}"))
                {
                    File.Move($"{filePath}", packedFileName);
                    ZipFile.ExtractToDirectory(packedFileName, $"{entryPath}");
                    _logger.Log("Clearing leftovers.", LogType.Info);
                    File.Delete(packedFileName);
                }
                else
                    _logger.Log("File is already unpacked", LogType.Info);
            }

            _stopwatch.Stop();
            _logger.Log($"Finished loading MobileGearAssetDataBases: {_stopwatch.ElapsedMilliseconds} ms",
                LogType.Info);
            _stopwatch.Reset();
        }

        private async Task DownloadMobileWorldContent(DestinyManifest manifest, string path, bool shouldUnpack)
        {
            _stopwatch.Start();
            _logger.Log("Started loading MobileWorldContent", LogType.Info);
            var rootDirectoryPath = $"{path}/MobileWorldContent";
            if (!Directory.Exists(rootDirectoryPath))
                Directory.CreateDirectory(rootDirectoryPath);

            foreach (var entry in manifest.MobileWorldContentPaths)
            {
                var entryPath = $"{path}/MobileWorldContent/{entry.Key}";
                var filePath = $"{path}/MobileWorldContent/{entry.Key}/{Path.GetFileName(entry.Value)}";
                if (!Directory.Exists(entryPath))
                    Directory.CreateDirectory(entryPath);

                if (!File.Exists(filePath))
                {
                    await _httpClientInstance.DownloadFileStreamFromCDNAsync(entry.Value, filePath);
                }
                else
                    _logger.Log("File already exists, skipping.", LogType.Info);

                if (shouldUnpack)
                {
                    _logger.Log("Unpacking zip...", LogType.Info);
                    var packedFileName = $"{filePath}.zip";
                    if (IsZIP($"{filePath}"))
                    {
                        File.Move($"{filePath}", packedFileName);
                        ZipFile.ExtractToDirectory(packedFileName, $"{entryPath}");
                        _logger.Log("Clearing leftovers.", LogType.Info);
                        File.Delete(packedFileName);
                    }
                    else
                        _logger.Log("File is already unpacked", LogType.Info);
                }
            }

            _stopwatch.Stop();
            _logger.Log($"Finished loading MobileWorldContent: {_stopwatch.ElapsedMilliseconds} ms", LogType.Info);
            _stopwatch.Reset();
        }

        private async Task DownloadJsonWorldContent(DestinyManifest manifest, string path)
        {
            _stopwatch.Start();
            _logger.Log("Started loading JsonWorldContent", LogType.Info);
            var rootDirectoryPath = $"{path}/JsonWorldContent";
            if (!Directory.Exists(rootDirectoryPath))
                Directory.CreateDirectory(rootDirectoryPath);

            foreach (var entry in manifest.JsonWorldContentPaths)
            {
                var entryPath = $"{path}/JsonWorldContent/{entry.Key}";
                var filePath = $"{path}/JsonWorldContent/{entry.Key}/{Path.GetFileName(entry.Value)}";
                if (!Directory.Exists(entryPath))
                    Directory.CreateDirectory(entryPath);

                if (!File.Exists(filePath))
                {
                    await _httpClientInstance.DownloadFileStreamFromCDNAsync(entry.Value, filePath);
                }
                else
                    _logger.Log("File already exists, skipping.", LogType.Info);
            }

            _stopwatch.Stop();
            _logger.Log($"Finished loading JsonWorldContent: {_stopwatch.ElapsedMilliseconds} ms", LogType.Info);
            _stopwatch.Reset();
        }

        private async Task DownloadJsonWorldComponentContent(DestinyManifest manifest, string path)
        {
            _stopwatch.Start();
            _logger.Log("Started loading JsonWorldComponentContent", LogType.Info);
            var rootDirectoryPath = $"{path}/JsonWorldComponentContent";
            if (!Directory.Exists(rootDirectoryPath))
                Directory.CreateDirectory(rootDirectoryPath);

            foreach (var localeEntry in manifest.JsonWorldComponentContentPaths)
            {
                var localePath = $"{path}/JsonWorldComponentContent/{localeEntry.Key}";

                if (!Directory.Exists(localePath))
                    Directory.CreateDirectory(localePath);

                foreach (var definitionEntry in localeEntry.Value)
                {
                    var definitionPath = $"{path}/JsonWorldComponentContent/{localeEntry.Key}/{definitionEntry.Key}";
                    if (!Directory.Exists(definitionPath))
                        Directory.CreateDirectory(definitionPath);
                    var filePath =
                        $"{path}/JsonWorldComponentContent/{localeEntry.Key}/{definitionEntry.Key}/{Path.GetFileName(definitionEntry.Value)}";

                    if (!File.Exists(filePath))
                    {
                        await _httpClientInstance.DownloadFileStreamFromCDNAsync(definitionEntry.Value, filePath);
                    }
                    else
                        _logger.Log("File already exists, skipping.", LogType.Info);
                }
            }

            _stopwatch.Stop();
            _logger.Log($"Finished loading JsonWorldComponentContent: {_stopwatch.ElapsedMilliseconds} ms",
                LogType.Info);
            _stopwatch.Reset();
        }

        private async Task DownloadMobileClanBannerDatabase(DestinyManifest manifest, string path, bool shouldUnpack)
        {
            _stopwatch.Start();
            _logger.Log("Started loading MobileClanBannerDatabase", LogType.Info);
            var filePath = $"{path}/MobileClanBannerDatabase/{Path.GetFileName(manifest.MobileClanBannerDatabasePath)}";
            var directoryPath = $"{path}/MobileClanBannerDatabase";

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            _logger.Log($"Getting data from: {manifest.MobileClanBannerDatabasePath}", LogType.Info);
            if (!File.Exists(filePath))
            {
                await _httpClientInstance.DownloadFileStreamFromCDNAsync(manifest.MobileClanBannerDatabasePath,
                    filePath);
            }
            else
                _logger.Log("File already exists, skipping.", LogType.Info);

            if (shouldUnpack)
            {
                _logger.Log("Unpacking zip...", LogType.Info);
                var packedFileName = $"{filePath}.zip";
                if (IsZIP(filePath))
                {
                    File.Move(filePath, packedFileName);
                    ZipFile.ExtractToDirectory(packedFileName, directoryPath);
                    _logger.Log("Clearing leftovers.", LogType.Info);
                    File.Delete(packedFileName);
                }
                else
                    _logger.Log("File is already unpacked", LogType.Info);
            }

            _stopwatch.Stop();
            _logger.Log($"Finished loading MobileClanBannerDatabase: {_stopwatch.ElapsedMilliseconds} ms",
                LogType.Info);
            _stopwatch.Reset();
        }
    }
}