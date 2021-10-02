using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NetBungieAPI.Helpers;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Models.Destiny.Config;
using NetBungieAPI.Models.Destiny.Definitions.HistoricalStats;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Default.ServiceConfigurations;
using NetBungieAPI.Services.Interfaces;

namespace NetBungieAPI.Services.Default
{
    internal sealed class SqliteDefinitionProvider : IDefinitionProvider
    {
        private const string SelectDefinitionQuery = "SELECT json FROM {0} WHERE id = {1}";
        private const string SelectHistoricalDefinitionQuery = "SELECT json FROM {0} WHERE key = '{1}'";

        private const string SelectAllDefinitionsQuery = "SELECT json FROM {0}";

        private const string ConnectionStringTemplate = "Data Source={0}; Version=3;";

        private readonly DefinitionsEnum[] _nonExistInSqliteDefinitions =
        {
            DefinitionsEnum.DestinyUnlockValueDefinition,
            DefinitionsEnum.DestinyProgressionMappingDefinition,
            DefinitionsEnum.DestinyHistoricalStatsDefinition,
            DefinitionsEnum.DestinyEnemyRaceDefinition
        };

        private readonly DotNetBungieApiDefaultDefinitionProviderConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly IBungieNetJsonSerializer _serializer;
        private readonly IDestiny2MethodsAccess _destiny2MethodsAccess;
        private readonly IDotNetBungieApiHttpClient _httpClient;
        private readonly IDefinitionAssemblyData _assemblyData;

        private DestinyManifest _currentManifest;
        private DestinyManifest _latestManifest;

        private Dictionary<BungieLocales, string> _databasePaths = new()
        {
            [BungieLocales.EN] = string.Empty,
            [BungieLocales.RU] = string.Empty,
            [BungieLocales.DE] = string.Empty,
            [BungieLocales.ES] = string.Empty,
            [BungieLocales.ES_MX] = string.Empty,
            [BungieLocales.FR] = string.Empty,
            [BungieLocales.IT] = string.Empty,
            [BungieLocales.JA] = string.Empty,
            [BungieLocales.KO] = string.Empty,
            [BungieLocales.PL] = string.Empty,
            [BungieLocales.PT_BR] = string.Empty,
            [BungieLocales.ZH_CHS] = string.Empty,
            [BungieLocales.ZH_CHT] = string.Empty
        };

        private Dictionary<BungieLocales, SQLiteConnection> _sqliteConnections = new()
        {
            [BungieLocales.EN] = new SQLiteConnection(),
            [BungieLocales.RU] = new SQLiteConnection(),
            [BungieLocales.DE] = new SQLiteConnection(),
            [BungieLocales.ES] = new SQLiteConnection(),
            [BungieLocales.ES_MX] = new SQLiteConnection(),
            [BungieLocales.FR] = new SQLiteConnection(),
            [BungieLocales.IT] = new SQLiteConnection(),
            [BungieLocales.JA] = new SQLiteConnection(),
            [BungieLocales.KO] = new SQLiteConnection(),
            [BungieLocales.PL] = new SQLiteConnection(),
            [BungieLocales.PT_BR] = new SQLiteConnection(),
            [BungieLocales.ZH_CHS] = new SQLiteConnection(),
            [BungieLocales.ZH_CHT] = new SQLiteConnection()
        };

        internal SqliteDefinitionProvider(
            DotNetBungieApiDefaultDefinitionProviderConfiguration configuration,
            ILogger logger,
            IBungieNetJsonSerializer serializer,
            IDestiny2MethodsAccess destiny2MethodsAccess,
            IDotNetBungieApiHttpClient httpClient,
            IDefinitionAssemblyData assemblyData)
        {
            _configuration = configuration;
            _logger = logger;
            _serializer = serializer;
            _destiny2MethodsAccess = destiny2MethodsAccess;
            _httpClient = httpClient;
            _assemblyData = assemblyData;
        }

        public async ValueTask<T> LoadDefinition<T>(uint hash, BungieLocales locale) where T : IDestinyDefinition
        {
            T result = default;
            var connection = _sqliteConnections[locale];
            connection.Open();
            var commandObj = new SQLiteCommand
            {
                Connection = connection,
                CommandText = string.Format(SelectDefinitionQuery, DefinitionHashPointer<T>.EnumValue, hash.ToInt32())
            };
            var reader = commandObj.ExecuteReader();
            if (reader.Read())
            {
                var byteArray = (byte[])reader[0];
                result = await _serializer.DeserializeAsync<T>(byteArray);
                result!.SetPointerLocales(locale);
            }
            else
            {
                reader.Close();
                connection.Close();
                throw new Exception($"Definition with hash {hash} wasn't found in database.");
            }

            reader.Close();
            connection.Close();
            return result;
        }

        public async ValueTask<DestinyHistoricalStatsDefinition> LoadHistoricalStatsDefinition(string id,
            BungieLocales locale)
        {
            DestinyHistoricalStatsDefinition result = default;
            var connection = _sqliteConnections[locale];
            connection.Open();
            var commandObj = new SQLiteCommand
            {
                Connection = connection,
                CommandText = string.Format(SelectDefinitionQuery, "DestinyHistoricalStatsDefinition", id)
            };
            var reader = commandObj.ExecuteReader();
            if (reader.Read())
            {
                var byteArray = (byte[])reader[0];
                result = await _serializer.DeserializeAsync<DestinyHistoricalStatsDefinition>(byteArray);
            }
            else
            {
                reader.Close();
                connection.Close();
                throw new Exception($"Historical definition with key {id} wasn't found in database.");
            }

            reader.Close();
            connection.Close();
            return result;
        }

        public ValueTask<string> ReadDefinitionAsJson(DefinitionsEnum enumValue, uint hash, BungieLocales locale)
        {
            string result;
            var connection = _sqliteConnections[locale];
            connection.Open();
            var commandObj = new SQLiteCommand
            {
                Connection = connection,
                CommandText = string.Format(SelectDefinitionQuery, enumValue, hash.ToInt32())
            };
            var reader = commandObj.ExecuteReader();
            if (reader.Read())
            {
                var byteArray = (byte[])reader[0];
                result = Encoding.UTF8.GetString(byteArray);
            }
            else
            {
                reader.Close();
                connection.Close();
                throw new Exception($"Definition with hash {hash} wasn't found in database.");
            }

            reader.Close();
            connection.Close();
            return ValueTask.FromResult(result);
        }

        public ValueTask<string> LoadHistoricalStatsDefinitionAsJson(string id, BungieLocales locale)
        {
            string result;
            var connection = _sqliteConnections[locale];
            connection.Open();
            var commandObj = new SQLiteCommand
            {
                Connection = connection,
                CommandText = string.Format(SelectDefinitionQuery, "DestinyHistoricalStatsDefinition", id)
            };
            var reader = commandObj.ExecuteReader();
            if (reader.Read())
            {
                var byteArray = (byte[])reader[0];
                result = Encoding.UTF8.GetString(byteArray);
            }
            else
            {
                reader.Close();
                connection.Close();
                throw new Exception($"Historical definition with key {id} wasn't found in database.");
            }

            reader.Close();
            connection.Close();
            return ValueTask.FromResult(result);
        }

        public ValueTask<IEnumerable<DestinyManifest>> GetAvailableManifests()
        {
            if (!Directory.Exists(_configuration.ManifestFolderPath))
                throw new Exception($"No manifest folder found at: {_configuration.ManifestFolderPath}");

            var versions = Directory.EnumerateDirectories(_configuration.ManifestFolderPath);
            var values = new ConcurrentDictionary<string, DestinyManifest>();
            Parallel.ForEach(versions, version =>
            {
                var files = Directory.EnumerateFiles(
                    version,
                    "Manifest.json",
                    SearchOption.TopDirectoryOnly);
                var manifestPath = files.FirstOrDefault();
                if (manifestPath == null)
                    return;
                _logger.LogInformation("Found manifest at: {ManifestPath}", manifestPath);
                var json = File.ReadAllText(manifestPath);
                var folderManifest = _serializer.Deserialize<DestinyManifest>(json);
                values.TryAdd(version, folderManifest);
            });
            return ValueTask.FromResult(values.Select(x => x.Value));
        }

        public ValueTask<DestinyManifest> GetCurrentManifest()
        {
            return ValueTask.FromResult(_currentManifest);
        }

        public async ValueTask<bool> CheckForUpdates()
        {
            var latestManifest = await _destiny2MethodsAccess.GetDestinyManifest();

            if (!latestManifest.IsSuccessfulResponseCode)
                throw latestManifest.ToException();

            _latestManifest = latestManifest.Response;

            return !(await GetAvailableManifests()).Contains(latestManifest.Response);
        }

        public async Task Update()
        {
            await DownloadManifestData(_latestManifest);
        }

        public async Task DeleteOldManifestData()
        {
            var latestManifestResponse = await _destiny2MethodsAccess.GetDestinyManifest();

            if (!latestManifestResponse.IsSuccessfulResponseCode)
                throw latestManifestResponse.ToException();

            _latestManifest = latestManifestResponse.Response;

            var currentManifests = await GetAvailableManifests();

            var manifestList = currentManifests.ToList();

            manifestList.Remove(_latestManifest);
            manifestList.Remove(_currentManifest);

            foreach (var manifestData in manifestList)
                await DeleteManifestData(manifestData.Version);
        }

        public Task DeleteManifestData(string version)
        {
            var manifestPath = $"{_configuration.ManifestFolderPath}\\{version}";

            if (!Directory.Exists(manifestPath))
                return Task.CompletedTask;

            foreach (var file in Directory.EnumerateFiles(manifestPath)) File.Delete(file);

            foreach (var directory in Directory.EnumerateDirectories(manifestPath))
                Directory.Delete(directory, true);

            Directory.Delete(manifestPath);

            return Task.CompletedTask;
        }

        public async ValueTask<bool> CheckExistingManifestData(string version)
        {
            return (await GetAvailableManifests()).Any(x => x.Version == version);
        }

        public async Task Initialize()
        {
            if (_configuration.FetchLatestManifestOnInitialize)
            {
                await UpdateLatestManifest();
                _currentManifest = _latestManifest;
            }

            if (_configuration.TryLoadExactVersion)
            {
                if (await CheckExistingManifestData(_configuration.PreferredManifestVersion))
                {
                    var filePath =
                        $"{_configuration.ManifestFolderPath}\\{_configuration.PreferredManifestVersion}\\Manifest.json";
                    _currentManifest =
                        await _serializer.DeserializeAsync<DestinyManifest>(await File.ReadAllBytesAsync(filePath));
                }
            }

            if (_configuration.AutoUpdateManifestOnStartup)
            {
                if (await CheckForUpdates())
                {
                    await DownloadManifestData(_latestManifest);
                    if (_configuration.DeleteOldManifestDataAfterUpdates)
                    {
                        await DeleteOldManifestData();
                    }

                    if (!_configuration.TryLoadExactVersion)
                    {
                        _currentManifest = _latestManifest;
                        OnCurrentManifestChanged(_latestManifest);
                    }
                }
                else
                {
                    _currentManifest = _latestManifest;
                }
            }

            OnCurrentManifestChanged(_currentManifest);

            //var availableManifests = await GetAvailableManifests();
        }

        public async Task ChangeManifestVersion(string version)
        {
            var manifests = await GetAvailableManifests();
            var neededManifest = manifests.FirstOrDefault(x => x.Version.Equals(version));
            if (neededManifest is null)
                throw new Exception($"Couldn't find manifest version when changing to: {version}");
            OnCurrentManifestChanged(neededManifest);
        }

        public async Task ReadToRepository(IDestiny2DefinitionRepository repository)
        {
            var definitionsToLoad = repository.AllowedDefinitions.ToList();
            foreach (var nonExistInSqliteDefinition in _nonExistInSqliteDefinitions)
            {
                definitionsToLoad.Remove(nonExistInSqliteDefinition);
            }

            definitionsToLoad.Remove(DefinitionsEnum.DestinyHistoricalStatsDefinition);

            _logger.LogInformation("Reading all definitions into repository");
            foreach (var locale in repository.AvailableLocales)
            {
                _logger.LogInformation("Reading locale: {Locale}", locale);
                var connection = _sqliteConnections[locale];
                connection.Open();

                Parallel.ForEach(definitionsToLoad, definitionType =>
                {
                    _logger.LogInformation("Reading definitions: {DefinitionType}", definitionType);
                    var runtimeType = _assemblyData.DefinitionsToTypeMapping[definitionType].DefinitionType;
                    var commandObj = new SQLiteCommand
                    {
                        Connection = connection,
                        CommandText = string.Format(SelectAllDefinitionsQuery, definitionType)
                    };

                    var reader = commandObj.ExecuteReader();
                    while (reader.Read())
                    {
                        var parsedDefinition =
                            (IDestinyDefinition)_serializer.Deserialize(
                                (byte[])reader[0],
                                runtimeType);
                        parsedDefinition.SetPointerLocales(locale);
                        repository.AddDefinition(definitionType, locale, parsedDefinition);
                    }
                });

                var historicalFetchCommand = new SQLiteCommand
                {
                    Connection = connection,
                    CommandText = string.Format(SelectAllDefinitionsQuery,
                        DefinitionsEnum.DestinyHistoricalStatsDefinition)
                };
                var histReader = historicalFetchCommand.ExecuteReader();
                while (histReader.Read())
                {
                    var parsedDefinition = await _serializer.DeserializeAsync<DestinyHistoricalStatsDefinition>(
                        (byte[])histReader[0]);
                    repository.AddDestinyHistoricalDefinition(locale, parsedDefinition);
                }

                connection.Close();
            }
        }

        public async Task DownloadManifestData(DestinyManifest manifestData)
        {
            var folderPath = $"{_configuration.ManifestFolderPath}\\{manifestData.Version}";
            var manifestFilePath = $"{folderPath}\\Manifest.json";

            await DownloadSqliteDatabases(
                "MobileWorldContent",
                folderPath,
                manifestData.MobileWorldContentPaths);

            var mobileGearAssetDataBasesDictionary = manifestData
                .MobileGearAssetDataBases
                .ToDictionary(
                    x => x.Version.ToString(),
                    x => x.Path);

            await DownloadSqliteDatabases(
                "MobileGearAssetDataBases",
                folderPath,
                mobileGearAssetDataBasesDictionary);

            await DownloadSqliteDatabase(
                "MobileAssetContent",
                folderPath,
                manifestData.MobileAssetContentPath);

            await DownloadSqliteDatabase(
                "MobileClanBannerDatabase",
                folderPath,
                manifestData.MobileClanBannerDatabasePath);

            if (!File.Exists(manifestFilePath))
            {
                var manifestJson = _serializer.Serialize(manifestData);
                await File.WriteAllTextAsync(manifestFilePath, manifestJson);
            }
        }

        private async Task DownloadSqliteDatabases(string propertyName, string path, IDictionary<string, string> values)
        {
            _logger.LogInformation("Started loading {PropertyName}", propertyName);
            var rootDirectoryPath = $"{path}\\{propertyName}";
            rootDirectoryPath.EnsureDirectoryExists();
            foreach (var (key, value) in values)
            {
                var entryPath = $"{path}\\{propertyName}\\{key}";
                var filePath = $"{path}\\{propertyName}\\{key}\\{Path.GetFileName(value)}";
                entryPath.EnsureDirectoryExists();
                if (!File.Exists(filePath))
                {
                    _logger.LogInformation("Downloading and writing db file: {FilePath}", filePath);
                    await using var fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    await using var stream = await _httpClient.GetStreamFromWebSourceAsync(value);
                    using var archive = new ZipArchive(stream);
                    foreach (var zipArchiveEntry in archive.Entries)
                    {
                        await using var zipArchiveEntryStream = zipArchiveEntry.Open();
                        await zipArchiveEntryStream.CopyToAsync(fileStream);
                    }
                }
                else
                {
                    _logger.LogInformation("File already exists, skipping");
                }
            }

            _logger.LogInformation("Finished loading {PropertyName}", propertyName);
        }

        private async Task DownloadSqliteDatabase(string propertyName, string path, string dbSourcePath)
        {
            _logger.LogInformation("Started loading {PropertyName}", propertyName);
            var rootDirectoryPath = $"{path}\\{propertyName}";
            rootDirectoryPath.EnsureDirectoryExists();

            var entryPath = $"{path}\\{propertyName}\\{dbSourcePath}";
            var filePath = $"{path}\\{propertyName}\\{Path.GetFileName(dbSourcePath)}";
            entryPath.EnsureDirectoryExists();
            if (!File.Exists(filePath))
            {
                _logger.LogInformation("Downloading and writing db file: {FilePath}", filePath);
                await using var fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
                await using var stream = await _httpClient.GetStreamFromWebSourceAsync(dbSourcePath);
                using var archive = new ZipArchive(stream);
                foreach (var zipArchiveEntry in archive.Entries)
                {
                    await using var zipArchiveEntryStream = zipArchiveEntry.Open();
                    await zipArchiveEntryStream.CopyToAsync(fileStream);
                }
            }
            else
            {
                _logger.LogInformation("File already exists, skipping");
            }


            _logger.LogInformation("Finished loading {PropertyName}", propertyName);
        }

        private async Task UpdateLatestManifest()
        {
            var latestManifestResponse = await _destiny2MethodsAccess.GetDestinyManifest();
            if (!latestManifestResponse.IsSuccessfulResponseCode)
            {
                throw latestManifestResponse.ToException();
            }

            _latestManifest = latestManifestResponse.Response;
        }

        private void OnCurrentManifestChanged(DestinyManifest manifestData)
        {
            foreach (var (localeStr, path) in manifestData.MobileWorldContentPaths)
            {
                var locale = ParseLocaleFromString(localeStr);
                var newPath =
                    $"{_configuration.ManifestFolderPath}\\{manifestData.Version}\\MobileWorldContent\\{localeStr}\\{Path.GetFileName(path)}";
                _databasePaths[locale] = newPath;
                _sqliteConnections[locale].ConnectionString = string.Format(ConnectionStringTemplate, newPath);
                _sqliteConnections[locale].ParseViaFramework = true;
            }
        }

        private static BungieLocales ParseLocaleFromString(string value)
        {
            return value switch
            {
                "en" => BungieLocales.EN,
                "ru" => BungieLocales.RU,
                "de" => BungieLocales.DE,
                "es" => BungieLocales.ES,
                "es-mx" => BungieLocales.ES_MX,
                "fr" => BungieLocales.FR,
                "it" => BungieLocales.IT,
                "ja" => BungieLocales.JA,
                "ko" => BungieLocales.KO,
                "pl" => BungieLocales.PL,
                "pt-br" => BungieLocales.PT_BR,
                "zh-chs" => BungieLocales.ZH_CHS,
                "zh-cht" => BungieLocales.ZH_CHT,
                _ => throw new Exception("Wrong locale.")
            };
        }
    }
}