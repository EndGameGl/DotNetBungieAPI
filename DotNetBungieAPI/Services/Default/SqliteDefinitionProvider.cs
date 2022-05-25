using System.Collections.Concurrent;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;
using DotNetBungieAPI.Clients;
using DotNetBungieAPI.Extensions;
using DotNetBungieAPI.Helpers;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Destiny;
using DotNetBungieAPI.Models.Destiny.Config;
using DotNetBungieAPI.Models.Destiny.Definitions.HistoricalStats;
using DotNetBungieAPI.Models.Destiny.Rendering;
using DotNetBungieAPI.Services.ApiAccess.Interfaces;
using DotNetBungieAPI.Services.Default.Provider.Sqlite;
using DotNetBungieAPI.Services.Default.ServiceConfigurations;
using DotNetBungieAPI.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace DotNetBungieAPI.Services.Default;

internal sealed class SqliteDefinitionProvider : IDefinitionProvider
{
    private const string SelectDefinitionQuery = "SELECT json FROM {0} WHERE id = {1}";
    private const string SelectHistoricalDefinitionQuery = "SELECT json FROM {0} WHERE key = '{1}'";
    private const string SelectAllDefinitionsQuery = "SELECT json FROM {0}";

    private const string SelectDestinyGearAssetDefinition =
        "SELECT json FROM DestinyGearAssetsDefinition WHERE id = {0}";

    private const string SearchHashesWhichReferenceId = "SELECT id FROM {0} WHERE json LIKE '%{1}%'";

    private const string ConnectionStringTemplate = "Data Source={0}; Version=3;";
    private readonly IDefinitionAssemblyData _assemblyData;

    private readonly BungieClientConfiguration _bungieClientConfiguration;
    private readonly DotNetBungieApiDefaultDefinitionProviderConfiguration _configuration;
    private readonly IDestiny2MethodsAccess _destiny2MethodsAccess;
    private readonly IDotNetBungieApiHttpClient _httpClient;
    private readonly ILogger _logger;

    private readonly DefinitionsEnum[] _sqliteDefinitionsBlacklist =
    {
        DefinitionsEnum.DestinyUnlockValueDefinition,
        DefinitionsEnum.DestinyProgressionMappingDefinition,
        DefinitionsEnum.DestinyHistoricalStatsDefinition,
        DefinitionsEnum.DestinyEnemyRaceDefinition
    };

    private readonly IBungieNetJsonSerializer _serializer;

    private DestinyManifest _currentManifest;

    private readonly Dictionary<BungieLocales, string> _databasePaths = new()
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

    private DestinyManifest _latestManifest;

    private readonly Dictionary<BungieLocales, SQLiteConnection> _sqliteConnections = new()
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

    private readonly SQLiteConnection _mobileGearAssetDataBaseConnection = new();

    public SqliteDefinitionProvider(
        BungieClientConfiguration bungieClientConfiguration,
        DotNetBungieApiDefaultDefinitionProviderConfiguration configuration,
        ILogger logger,
        IBungieNetJsonSerializer serializer,
        IDestiny2MethodsAccess destiny2MethodsAccess,
        IDotNetBungieApiHttpClient httpClient,
        IDefinitionAssemblyData assemblyData)
    {
        _bungieClientConfiguration = bungieClientConfiguration;
        _configuration = configuration;
        _logger = logger;
        _serializer = serializer;
        _destiny2MethodsAccess = destiny2MethodsAccess;
        _httpClient = httpClient;
        _assemblyData = assemblyData;
    }

    public async ValueTask<T> LoadDefinition<T>(uint hash, BungieLocales locale) where T : IDestinyDefinition
    {
        T result;
        var connection = _sqliteConnections[locale];
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
        return result;
    }

    public async ValueTask<DestinyHistoricalStatsDefinition> LoadHistoricalStatsDefinition(string id,
        BungieLocales locale)
    {
        DestinyHistoricalStatsDefinition result = default;
        var connection = _sqliteConnections[locale];
        var commandObj = new SQLiteCommand
        {
            Connection = connection,
            CommandText = string.Format(SelectHistoricalDefinitionQuery, "DestinyHistoricalStatsDefinition", id)
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
        return result;
    }

    public ValueTask<string> ReadDefinitionRaw(DefinitionsEnum enumValue, uint hash, BungieLocales locale)
    {
        string result;
        var connection = _sqliteConnections[locale];
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
        return ValueTask.FromResult(result);
    }

    public ValueTask<string> ReadHistoricalStatsDefinitionRaw(string id, BungieLocales locale)
    {
        string result;
        var connection = _sqliteConnections[locale];
        var commandObj = new SQLiteCommand
        {
            Connection = connection,
            CommandText = string.Format(SelectHistoricalDefinitionQuery, "DestinyHistoricalStatsDefinition", id)
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
            throw new Exception($"Historical definition with key {id} wasn't found in database.");
        }

        reader.Close();
        connection.Close();
        return ValueTask.FromResult(result);
    }

    public async ValueTask<IEnumerable<DestinyManifest>> GetAvailableManifests()
    {
        if (!Directory.Exists(_configuration.ManifestFolderPath))
            throw new Exception($"No manifest folder found at: {_configuration.ManifestFolderPath}");

        var versions = Directory.EnumerateDirectories(_configuration.ManifestFolderPath);
        var values = new ConcurrentDictionary<string, DestinyManifest>();
#if NET5_0
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
#endif

#if NET6_0_OR_GREATER
        await Parallel.ForEachAsync(versions, async (version, cancellationToken) =>
        {
            var files = Directory.EnumerateFiles(
                version,
                "Manifest.json",
                SearchOption.TopDirectoryOnly);

            var manifestPath = files.FirstOrDefault();
            if (manifestPath == null)
                return;
            _logger.LogInformation("Found manifest at: {ManifestPath}", manifestPath);

            await using var fileStream = File.OpenRead(manifestPath);
            var folderManifest = await _serializer.DeserializeAsync<DestinyManifest>(fileStream);
            values.TryAdd(version, folderManifest);
        });
#endif
        return values.Select(x => x.Value);
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

        var availableManifests = await GetAvailableManifests();

        if (availableManifests.Contains(latestManifest.Response))
            return false;

        return true;
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
        var manifestPath = Path.Combine(_configuration.ManifestFolderPath, version);

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
                var filePath = Path.Combine(
                    _configuration.ManifestFolderPath,
                    _configuration.PreferredManifestVersion,
                    "Manifest.json");
                _currentManifest = await _serializer
                    .DeserializeAsync<DestinyManifest>(await File.ReadAllBytesAsync(filePath));

                try
                {
                    OnCurrentManifestChanged(_currentManifest);
                    return;
                }
                catch (Exception ex)
                {
                    _logger.LogError(
                        ex,
                        "Couldn't load exact version of manifest: {Version}",
                        _currentManifest.Version);
                }
            }
        }

        if (_configuration.AutoUpdateManifestOnStartup)
        {
            if (await CheckForUpdates())
            {
                await DownloadManifestData(_latestManifest);
                if (_configuration.DeleteOldManifestDataAfterUpdates)
                    await DeleteOldManifestData();

                if (!_configuration.TryLoadExactVersion)
                {
                    _currentManifest = _latestManifest;
                }
            }
            else
            {
                _currentManifest = _latestManifest;
                await Update();
            }
        }

        OnCurrentManifestChanged(_currentManifest);
    }

    public async Task ChangeManifestVersion(string version)
    {
        var manifests = await GetAvailableManifests();
        var neededManifest = manifests.FirstOrDefault(x => x.Version.Equals(version));
        if (neededManifest is null)
        {
            throw new Exception($"Couldn't find manifest version when changing to: {version}");
        }

        OnCurrentManifestChanged(neededManifest);
    }

    public async Task ReadToRepository(IDestiny2DefinitionRepository repository)
    {
        var definitionsToLoad = repository.AllowedDefinitions.ToList();
        foreach (var nonExistInSqliteDefinition in _sqliteDefinitionsBlacklist)
            definitionsToLoad.Remove(nonExistInSqliteDefinition);

        definitionsToLoad.Remove(DefinitionsEnum.DestinyHistoricalStatsDefinition);

        _logger.LogInformation("Reading all definitions into repository");
        foreach (var locale in repository.AvailableLocales)
        {
            _logger.LogInformation("Reading locale: {Locale}", locale);
            var connection = _sqliteConnections[locale];
#if NET5_0
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
#endif
#if NET6_0_OR_GREATER
            await Parallel.ForEachAsync(definitionsToLoad, async (definitionType, cancellationToken) =>
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
                    var parsedDefinition = (IDestinyDefinition)await _serializer.DeserializeAsync(
                        (byte[])reader[0],
                        runtimeType);
                    parsedDefinition.SetPointerLocales(locale);
                    repository.AddDefinition(definitionType, locale, parsedDefinition);
                }
            });
#endif

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
        }
    }

    public async ValueTask<DestinyGearAssetDefinition> GetGearAssetDefinition(uint itemHash)
    {
        var destinyGearAssetDefinitionFetchCommand = new SQLiteCommand
        {
            Connection = _mobileGearAssetDataBaseConnection,
            CommandText = string.Format(SelectDestinyGearAssetDefinition, itemHash.ToInt32())
        };
        var reader = destinyGearAssetDefinitionFetchCommand.ExecuteReader();
        if (reader.Read())
            return await _serializer.DeserializeAsync<DestinyGearAssetDefinition>((byte[])reader[0]);
        return null;
    }

    public async Task DownloadManifestData(DestinyManifest manifestData)
    {
        var folderPath = Path.Combine(_configuration.ManifestFolderPath, manifestData.Version);
        var manifestFilePath = Path.Combine(folderPath, "Manifest.json");

        await DownloadSqliteDatabases(
            "MobileWorldContent",
            folderPath,
            manifestData
                .MobileWorldContentPaths
                .Where(x => _bungieClientConfiguration.UsedLocales.Contains(x.Key.ParseLocale()))
                .ToDictionary(x => x.Key, x => x.Value));

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

    public void Dispose()
    {
        foreach (var (_, connection) in _sqliteConnections)
        {
            if (connection is not null)
            {
                try
                {
                    connection.Close();
                    connection.Dispose();
                }
                catch (Exception exception)
                {
                    _logger.LogError(exception, "Error in {DisposeName}", nameof(Dispose));
                }
            }
        }
    }

    public async ValueTask DisposeAsync()
    {
        foreach (var (_, connection) in _sqliteConnections)
        {
            if (connection is not null)
            {
                try
                {
                    await connection.CloseAsync();
                    await connection.DisposeAsync();
                }
                catch (Exception exception)
                {
                    _logger.LogError(exception, "Error in {DisposeAsyncName}", nameof(DisposeAsync));
                }
            }
        }
    }

    private async Task DownloadSqliteDatabases(string propertyName, string path, IDictionary<string, string> values)
    {
        _logger.LogInformation("Started loading {PropertyName}", propertyName);
        var rootDirectoryPath = Path.Combine(path, propertyName);
        rootDirectoryPath.EnsureDirectoryExists();

        var downloadTasks = new List<Task>(values.Count);

        foreach (var (key, value) in values)
        {
            var task = Task.Run(async () =>
            {
                var entryPath = Path.Combine(path, propertyName, key);
                var filePath = Path.Combine(path, propertyName, key, Path.GetFileName(value));
                entryPath.EnsureDirectoryExists();
                if (!File.Exists(filePath))
                    await DownloadAndUnpackSqliteFile(filePath, value);
                else
                    _logger.LogInformation("File already exists, skipping");
            });

            downloadTasks.Add(task);
        }

        await Task.WhenAll(downloadTasks.ToArray());

        _logger.LogInformation("Finished loading {PropertyName}", propertyName);
    }

    private async Task DownloadSqliteDatabase(string propertyName, string path, string dbSourcePath)
    {
        _logger.LogInformation("Started loading {PropertyName}", propertyName);
        var rootDirectoryPath = Path.Combine(path, propertyName);
        rootDirectoryPath.EnsureDirectoryExists();

        var filePath = Path.Combine(path, propertyName, Path.GetFileName(dbSourcePath));
        if (!File.Exists(filePath))
            await DownloadAndUnpackSqliteFile(filePath, dbSourcePath);
        else
            _logger.LogInformation("File already exists, skipping");


        _logger.LogInformation("Finished loading {PropertyName}", propertyName);
    }

    private async Task DownloadAndUnpackSqliteFile(string filePath, string dbSourcePath)
    {
        _logger.LogInformation("Downloading and writing db file: {FilePath}", filePath);
        await using (var fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
        {
            var (httpContentStream, contentLength) = await _httpClient.GetStreamFromWebSourceAsync(dbSourcePath);

            using var archive = new ZipArchive(httpContentStream);
            foreach (var zipArchiveEntry in archive.Entries)
            {
                await using var zipArchiveEntryStream = zipArchiveEntry.Open();
                await zipArchiveEntryStream.CopyToAsync(fileStream);
            }

            await httpContentStream.DisposeAsync();
        }
    }

    private async Task UpdateLatestManifest()
    {
        var latestManifestResponse = await _destiny2MethodsAccess.GetDestinyManifest();
        if (!latestManifestResponse.IsSuccessfulResponseCode) throw latestManifestResponse.ToException();

        _latestManifest = latestManifestResponse.Response;
    }

    private void OnCurrentManifestChanged(DestinyManifest manifestData)
    {
        foreach (var (locale, connection) in _sqliteConnections)
        {
            if (connection is not null && connection.State != ConnectionState.Closed)
                connection.Close();
        }

        foreach (var (localeStr, path) in manifestData.MobileWorldContentPaths)
        {
            var locale = ParseLocaleFromString(localeStr);

            if (!_bungieClientConfiguration.UsedLocales.Contains(locale))
                continue;

            var newPath = Path.Combine(
                _configuration.ManifestFolderPath,
                manifestData.Version,
                "MobileWorldContent",
                localeStr,
                Path.GetFileName(path));

            _databasePaths[locale] = newPath;
            _sqliteConnections[locale].ConnectionString = string.Format(ConnectionStringTemplate, newPath);
            _sqliteConnections[locale].ParseViaFramework = true;
            _sqliteConnections[locale].Open();
        }

        var assetsEntry = _currentManifest.MobileGearAssetDataBases.FirstOrDefault(x => x.Version == 2);
        if (assetsEntry is not null)
        {
            var mobileGearAssetDataBasePath = Path.Combine(
                _configuration.ManifestFolderPath,
                manifestData.Version,
                "MobileGearAssetDataBases",
                "2",
                Path.GetFileName(assetsEntry.Path));
            _mobileGearAssetDataBaseConnection.ConnectionString =
                string.Format(ConnectionStringTemplate, mobileGearAssetDataBasePath);
            _mobileGearAssetDataBaseConnection.Open();
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

    public async IAsyncEnumerable<DbDefinitionReference> SearchForReferencingEntriesAsync(uint lookupHash)
    {
        var definitionsToLoad = Enum.GetValues<DefinitionsEnum>().ToList();

        foreach (var nonExistInSqliteDefinition in _sqliteDefinitionsBlacklist)
            definitionsToLoad.Remove(nonExistInSqliteDefinition);

        definitionsToLoad.Remove(DefinitionsEnum.DestinyHistoricalStatsDefinition);

        var connection = _sqliteConnections
            .FirstOrDefault(x => x.Value.State.HasFlag(ConnectionState.Open));

        foreach (var definitionType in definitionsToLoad)
        {
            var commandObj = new SQLiteCommand
            {
                Connection = connection.Value,
                CommandText = string.Format(SearchHashesWhichReferenceId, definitionType.ToString(), lookupHash)
            };
            var reader = commandObj.ExecuteReader();
            while (reader.Read())
            {
                var hashInt32 = reader.GetInt32(0);
                yield return new DbDefinitionReference(definitionType, hashInt32.ToUInt32());
            }

            reader.Close();
        }
    }
}