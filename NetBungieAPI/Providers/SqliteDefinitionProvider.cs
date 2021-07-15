using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBungieAPI.Logging;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Models.Destiny.Config;
using NetBungieAPI.Models.Destiny.Definitions.HistoricalStats;

namespace NetBungieAPI.Providers
{
    public class SqliteDefinitionProvider : DefinitionProvider
    {
        private readonly DefinitionsEnum[] _nonExistInSqliteDefinitions =
        {
            DefinitionsEnum.DestinyUnlockValueDefinition,
            DefinitionsEnum.DestinyProgressionMappingDefinition,
            DefinitionsEnum.DestinyHistoricalStatsDefinition,
            DefinitionsEnum.DestinyEnemyRaceDefinition
        };

        private readonly string ManifestPath;

        private readonly Dictionary<DestinyManifest, string> _availableManifests = new();
        private readonly SQLiteConnection _connection;
        private DestinyManifest _currentManifest;
        private readonly Dictionary<BungieLocales, string> _databasePaths = new();
        private DestinyManifest _latestManifest;

        public SqliteDefinitionProvider(string manifestsPath)
        {
            _connection = new SQLiteConnection();
            ManifestPath = manifestsPath;
        }

        public override async Task OnLoad()
        {
            Logger.Log("OnLoad started.", LogType.Debug);
            await GetAvailableManifests();
            Logger.Log("Checking if preferred manifest exists.", LogType.Debug);
            if (ManifestVersionSettings.ForceLoadManifestVersion &&
                !string.IsNullOrWhiteSpace(ManifestVersionSettings.PreferredLoadedManifestVersion))
                if (await CheckExistingManifestData(ManifestVersionSettings.PreferredLoadedManifestVersion))
                {
                    UsedManifest = _availableManifests
                        .FirstOrDefault(x => x.Key.Version == ManifestVersionSettings.PreferredLoadedManifestVersion)
                        .Key;
                    Logger.Log($"Set manifest version to: {UsedManifest.Version}", LogType.Debug);
                }

            Logger.Log("Searching locales...", LogType.Debug);
            foreach (var locale in DefinitionLoadingSettings.Locales)
            {
                Logger.Log($"Mapping locale: {locale}", LogType.Debug);
                var fileLocation =
                    $"{ManifestPath}\\{UsedManifest.Version}\\MobileWorldContent\\{locale.LocaleToString()}\\{Path.GetFileName(UsedManifest.MobileWorldContentPaths[locale.LocaleToString()])}";
                _databasePaths.Add(locale, fileLocation);
            }
        }

        public override async ValueTask<IEnumerable<DestinyManifest>> GetAvailableManifests()
        {
            if (!Directory.Exists(ManifestPath))
                throw new Exception($"No manifest folder found at: {ManifestPath}");

            var versions = Directory.EnumerateDirectories(ManifestPath);
            Parallel.ForEach(versions, version =>
            {
                var files = Directory.EnumerateFiles(version, "Manifest.json", SearchOption.TopDirectoryOnly);
                var manifestPath = files.FirstOrDefault();
                if (manifestPath == null)
                    return;
                if (_availableManifests.ContainsValue(version))
                    return;
                Logger.Log($"Found manifest at: {manifestPath}", LogType.Info);
                var json = File.ReadAllText(manifestPath);
                var folderManifest = SerializationHelper.Deserialize<DestinyManifest>(json);
                _availableManifests.TryAdd(folderManifest, version);
            });
            return _availableManifests.Select(x => x.Key);
        }

        public override async ValueTask<DestinyManifest> GetCurrentManifest()
        {
            return UsedManifest;
        }

        public override async ValueTask<bool> CheckForUpdates()
        {
            var latestManifest = await Destiny2MethodsAccess.GetDestinyManifest();
            return !(await GetAvailableManifests()).Contains(latestManifest.Response);
        }

        public override async Task Update()
        {
            await DownloadNewManifestData(UsedManifest);
        }

        public override async Task DownloadNewManifestData(DestinyManifest manifestData)
        {
            var path = $"{ManifestPath}\\{manifestData.Version}";
            await DownloadMobileAssetContent(manifestData, path, true);
            await DownloadMobileGearAssetDataBases(manifestData, path, true);
            await DownloadMobileWorldContent(manifestData, path, true);
            await DownloadMobileClanBannerDatabase(manifestData, path, true);
            if (!File.Exists($"{path}/Manifest.json"))
            {
                var manifestJson = SerializationHelper.Serialize(UsedManifest);
                await File.WriteAllTextAsync($"{path}/Manifest.json", manifestJson);
            }
        }

        public override async Task DeleteOldManifestData()
        {
            var currentManifests = await GetAvailableManifests();
            var manifestList = currentManifests.ToList();
            manifestList.Remove(UsedManifest);
            foreach (var manifestData in manifestList) await DeleteManifestData(manifestData);
        }

        public override async Task DeleteManifestData(DestinyManifest manifestData)
        {
            var manifestPath = $"{ManifestPath}\\{manifestData.Version}";
            if (Directory.Exists(manifestPath))
            {
                foreach (var file in Directory.EnumerateFiles(manifestPath)) File.Delete(file);

                foreach (var directory in Directory.EnumerateDirectories(manifestPath))
                    Directory.Delete(directory, true);

                Directory.Delete(manifestPath);
            }
        }

        public override async ValueTask<bool> CheckExistingManifestData(string version)
        {
            return (await GetAvailableManifests()).Any(x => x.Version == version);
        }

        private static bool IsZIP(string filepath)
        {
            if (File.Exists(filepath))
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

            return false;
        }

        private async Task DownloadMobileAssetContent(DestinyManifest manifest, string path, bool shouldUnpack)
        {
            Logger.Log("Started loading MobileAssetContent", LogType.Info);
            var filePath = $"{path}/MobileAssetContentPath/{Path.GetFileName(manifest.MobileAssetContentPath)}";
            var directoryPath = $"{path}/MobileAssetContentPath";

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            Logger.Log($"Getting data from: {manifest.MobileAssetContentPath}", LogType.Info);
            if (!File.Exists(filePath))
                await HttpClientInstance.DownloadFileStreamFromCDNAsync(manifest.MobileAssetContentPath, filePath);
            else
                Logger.Log("File already exists, skipping.", LogType.Info);

            if (shouldUnpack)
            {
                Logger.Log("Unpacking zip...", LogType.Info);
                var packedFileName = $"{filePath}.zip";
                if (IsZIP(filePath))
                {
                    File.Move(filePath, packedFileName);
                    ZipFile.ExtractToDirectory(packedFileName, directoryPath);
                    Logger.Log("Clearing leftovers.", LogType.Info);
                    File.Delete(packedFileName);
                }
                else
                {
                    Logger.Log("File is already unpacked", LogType.Info);
                }
            }

            Logger.Log("Finished loading MobileAssetContent", LogType.Info);
        }

        private async Task DownloadMobileGearAssetDataBases(DestinyManifest manifest, string path, bool shouldUnpack)
        {
            Logger.Log("Started loading MobileGearAssetDataBases", LogType.Info);
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
                    await HttpClientInstance.DownloadFileStreamFromCDNAsync(entry.Path, filePath);
                else
                    Logger.Log("File already exists, skipping.", LogType.Info);

                if (!shouldUnpack)
                    continue;
                Logger.Log("Unpacking zip...", LogType.Info);
                var packedFileName = $"{filePath}.zip";
                if (IsZIP($"{filePath}"))
                {
                    File.Move($"{filePath}", packedFileName);
                    ZipFile.ExtractToDirectory(packedFileName, $"{entryPath}");
                    Logger.Log("Clearing leftovers.", LogType.Info);
                    File.Delete(packedFileName);
                }
                else
                {
                    Logger.Log("File is already unpacked", LogType.Info);
                }
            }

            Logger.Log("Finished loading MobileGearAssetDataBases",
                LogType.Info);
        }

        private async Task DownloadMobileWorldContent(DestinyManifest manifest, string path, bool shouldUnpack)
        {
            Logger.Log("Started loading MobileWorldContent", LogType.Info);
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
                    await HttpClientInstance.DownloadFileStreamFromCDNAsync(entry.Value, filePath);
                else
                    Logger.Log("File already exists, skipping.", LogType.Info);

                if (shouldUnpack)
                {
                    Logger.Log("Unpacking zip...", LogType.Info);
                    var packedFileName = $"{filePath}.zip";
                    if (IsZIP($"{filePath}"))
                    {
                        File.Move($"{filePath}", packedFileName);
                        ZipFile.ExtractToDirectory(packedFileName, $"{entryPath}");
                        Logger.Log("Clearing leftovers.", LogType.Info);
                        File.Delete(packedFileName);
                    }
                    else
                    {
                        Logger.Log("File is already unpacked", LogType.Info);
                    }
                }
            }

            Logger.Log("Finished loading MobileWorldContent", LogType.Info);
        }

        private async Task DownloadMobileClanBannerDatabase(DestinyManifest manifest, string path, bool shouldUnpack)
        {
            Logger.Log("Started loading MobileClanBannerDatabase", LogType.Info);
            var filePath = $"{path}/MobileClanBannerDatabase/{Path.GetFileName(manifest.MobileClanBannerDatabasePath)}";
            var directoryPath = $"{path}/MobileClanBannerDatabase";

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            Logger.Log($"Getting data from: {manifest.MobileClanBannerDatabasePath}", LogType.Info);
            if (!File.Exists(filePath))
                await HttpClientInstance.DownloadFileStreamFromCDNAsync(manifest.MobileClanBannerDatabasePath,
                    filePath);
            else
                Logger.Log("File already exists, skipping.", LogType.Info);

            if (shouldUnpack)
            {
                Logger.Log("Unpacking zip...", LogType.Info);
                var packedFileName = $"{filePath}.zip";
                if (IsZIP(filePath))
                {
                    File.Move(filePath, packedFileName);
                    ZipFile.ExtractToDirectory(packedFileName, directoryPath);
                    Logger.Log("Clearing leftovers.", LogType.Info);
                    File.Delete(packedFileName);
                }
                else
                {
                    Logger.Log("File is already unpacked", LogType.Info);
                }
            }

            Logger.Log("Finished loading MobileClanBannerDatabase",
                LogType.Info);
        }

        #region Definition loading

        public override async Task ReadDefinitionsToRepository(IEnumerable<DefinitionsEnum> definitionsToLoad)
        {
            Repositories.Initialize(DefinitionLoadingSettings.Locales);

            foreach (var locale in DefinitionLoadingSettings.Locales)
            {
                Repositories.SetLocaleContext(locale);
                Logger.Log($"Loading locale: {locale}.", LogType.Info);
                _connection.ConnectionString = $"Data Source={_databasePaths[locale]}; Version=3;";
                _connection.Open();
                foreach (var definitionType in definitionsToLoad)
                {
                    if (_nonExistInSqliteDefinitions.Contains(definitionType))
                        continue;
                    Logger.Log($"Loading definitions: {definitionType}.", LogType.Info);
                    var runtimeType = AssemblyData.DefinitionsToTypeMapping[definitionType].DefinitionType;
                    var commandObj = new SQLiteCommand
                    {
                        Connection = _connection,
                        CommandText = $"SELECT * FROM {definitionType}"
                    };
                    var reader = commandObj.ExecuteReader();
                    while (reader.Read())
                    {
                        var parsedDefinition =
                            (IDestinyDefinition) await SerializationHelper.DeserializeAsync(
                                (byte[]) reader[1],
                                runtimeType);
                        Repositories.AddDefinition(definitionType, locale, parsedDefinition);
                    }
                }

                Logger.Log("Loading definitions: DestinyHistoricalStatsDefinition.", LogType.Info);
                var historicalFetchCommand = new SQLiteCommand
                {
                    Connection = _connection,
                    CommandText = "SELECT * FROM DestinyHistoricalStatsDefinition"
                };
                var histReader = historicalFetchCommand.ExecuteReader();
                while (histReader.Read())
                {
                    var parsedDefinition = await SerializationHelper.DeserializeAsync<DestinyHistoricalStatsDefinition>(
                        (byte[]) histReader[1]);
                    Repositories.AddDestinyHistoricalDefinition(locale, parsedDefinition);
                }

                _connection.Close();
                Repositories.ResetLocaleContext();
            }
        }

        public override async ValueTask<T> LoadDefinition<T>(uint hash, BungieLocales locale)
        {
            T result = default;
            _connection.ConnectionString = $"Data Source={_databasePaths[locale]}; Version=3;";
            _connection.Open();
            var commandObj = new SQLiteCommand
            {
                Connection = _connection,
                CommandText = $"SELECT * FROM {DefinitionHashPointer<T>.EnumValue} WHERE id='{(int) hash}'"
            };
            var reader = commandObj.ExecuteReader();
            while (reader.Read())
            {
                var byteArray = (byte[]) reader[1];
                result = await SerializationHelper.DeserializeAsync<T>(byteArray);
            }

            _connection.Close();
            return result;
        }

        public override async ValueTask<string> ReadDefinitionAsJson(DefinitionsEnum enumValue, uint hash,
            BungieLocales locale)
        {
            var result = string.Empty;
            _connection.ConnectionString = $"Data Source={_databasePaths[locale]}; Version=3;";
            _connection.Open();
            var commandObj = new SQLiteCommand
            {
                Connection = _connection,
                CommandText = $"SELECT * FROM {enumValue} WHERE id='{(int) hash}'"
            };
            var reader = commandObj.ExecuteReader();
            while (reader.Read())
            {
                var byteArray = (byte[]) reader[1];
                result = Encoding.UTF8.GetString(byteArray);
            }

            _connection.Close();
            return result;
        }

        public override async ValueTask<ReadOnlyCollection<T>> LoadMultipleDefinitions<T>(uint[] hashes,
            BungieLocales locale)
        {
            IList<T> tempCollection = new List<T>(hashes.Length);
            _connection.ConnectionString = $"Data Source={_databasePaths[locale]}; Version=3;";
            _connection.Open();
            foreach (var hash in hashes)
            {
                var commandObj = new SQLiteCommand
                {
                    Connection = _connection,
                    CommandText = $"SELECT * FROM {DefinitionHashPointer<T>.EnumValue} WHERE id='{(int) hash}'"
                };
                var reader = commandObj.ExecuteReader();
                while (reader.Read())
                {
                    var byteArray = (byte[]) reader[1];
                    tempCollection.Add(await SerializationHelper.DeserializeAsync<T>(byteArray));
                }
            }

            _connection.Close();
            return new ReadOnlyCollection<T>(tempCollection);
        }

        public override async ValueTask<DestinyHistoricalStatsDefinition> LoadHistoricalStatsDefinition(string id,
            BungieLocales locale)
        {
            DestinyHistoricalStatsDefinition result = default;
            _connection.ConnectionString = $"Data Source={_databasePaths[locale]}; Version=3;";
            _connection.Open();
            var commandObj = new SQLiteCommand
            {
                Connection = _connection,
                CommandText = $"SELECT * FROM DestinyHistoricalStatsDefinition WHERE key='{id}'"
            };
            var reader = commandObj.ExecuteReader();
            while (reader.Read())
            {
                var byteArray = (byte[]) reader[1];
                result = await SerializationHelper.DeserializeAsync<DestinyHistoricalStatsDefinition>(byteArray);
            }

            _connection.Close();
            return result;
        }

        public override async ValueTask<string> LoadHistoricalStatsDefinitionAsJson(string id, BungieLocales locale)
        {
            return await Task.Run(() =>
            {
                var result = string.Empty;
                _connection.ConnectionString = $"Data Source={_databasePaths[locale]}; Version=3;";
                _connection.Open();
                var commandObj = new SQLiteCommand
                {
                    Connection = _connection,
                    CommandText = $"SELECT * FROM DestinyHistoricalStatsDefinition WHERE key='{id}'"
                };
                var reader = commandObj.ExecuteReader();
                while (reader.Read())
                {
                    var byteArray = (byte[]) reader[1];
                    result = Encoding.UTF8.GetString(byteArray);
                }

                _connection.Close();
                return result;
            });
        }

        public override async ValueTask<ReadOnlyCollection<T>> LoadAllDefinitions<T>(BungieLocales locale)
        {
            IList<T> tempCollection = new List<T>();
            _connection.ConnectionString = $"Data Source={_databasePaths[locale]}; Version=3;";
            _connection.Open();
            var commandObj = new SQLiteCommand
            {
                Connection = _connection,
                CommandText = $"SELECT * FROM {DefinitionHashPointer<T>.EnumValue}"
            };
            var reader = commandObj.ExecuteReader();
            while (reader.Read())
            {
                var byteArray = (byte[]) reader[1];
                tempCollection.Add(await SerializationHelper.DeserializeAsync<T>(byteArray));
            }

            _connection.Close();
            return new ReadOnlyCollection<T>(tempCollection);
        }

        #endregion
    }
}