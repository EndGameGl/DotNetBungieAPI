using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBungieAPI.Logging;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Models.Destiny.Definitions.HistoricalStats;

namespace NetBungieAPI.Providers
{
    public class SqliteDefinitionProvider : DefinitionProvider
    {
        private readonly DefinitionsEnum[] _nonExistInSqliteDefinitions = new DefinitionsEnum[3]
        {
            DefinitionsEnum.DestinyUnlockValueDefinition,
            DefinitionsEnum.DestinyProgressionMappingDefinition,
            DefinitionsEnum.DestinyHistoricalStatsDefinition
        };

        private SQLiteConnection _connection;
        private Dictionary<BungieLocales, string> _databasePaths = new Dictionary<BungieLocales, string>();

        public SqliteDefinitionProvider()
        {
            _connection = new SQLiteConnection();
        }

        public override async Task OnLoad()
        {
            foreach (var locale in Locales)
            {
                var fileLocation =
                    $"{ManifestPath}\\{UsedManifest.Version}\\MobileWorldContent\\{locale.LocaleToString()}\\{Path.GetFileName(UsedManifest.MobileWorldContentPaths[locale.LocaleToString()])}";
                _databasePaths.Add(locale, fileLocation);
            }
        }

        public override async Task ReadDefinitionsToRepository(IEnumerable<DefinitionsEnum> definitionsToLoad)
        {
            Repositories.Initialize(Locales);

            foreach (var locale in Locales)
            {
                Logger.Log($"Loading locale: {locale}.", LogType.Info);
                _connection.ConnectionString = $"Data Source={_databasePaths[locale]}; Version=3;";
                _connection.Open();
                foreach (var definitionType in definitionsToLoad)
                {
                    if (_nonExistInSqliteDefinitions.Contains(definitionType))
                        continue;
                    Logger.Log($"Loading definitions: {definitionType}.", LogType.Info);
                    var runtimeType = AssemblyData.DefinitionsToTypeMapping[definitionType].DefinitionType;
                    var commandObj = new SQLiteCommand()
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
                Logger.Log($"Loading definitions: DestinyHistoricalStatsDefinition.", LogType.Info);
                var historicalFetchCommand = new SQLiteCommand()
                {
                    Connection = _connection,
                    CommandText = $"SELECT * FROM DestinyHistoricalStatsDefinition"
                };
                var histReader = historicalFetchCommand.ExecuteReader();
                while (histReader.Read())
                {
                    var parsedDefinition = await SerializationHelper.DeserializeAsync<DestinyHistoricalStatsDefinition>(
                            (byte[]) histReader[1]);
                    Repositories.AddDestinyHistoricalDefinition(locale, parsedDefinition);
                }
                _connection.Close();
            }
        }

        public override async Task<T> LoadDefinition<T>(uint hash, BungieLocales locale)
        {
            T result = default;
            _connection.ConnectionString = $"Data Source={_databasePaths[locale]}; Version=3;";
            _connection.Open();
            var commandObj = new SQLiteCommand()
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

        public override async Task<string> ReadDefinitionAsJson(DefinitionsEnum enumValue, uint hash,
            BungieLocales locale)
        {
            var result = string.Empty;
            _connection.ConnectionString = $"Data Source={_databasePaths[locale]}; Version=3;";
            _connection.Open();
            var commandObj = new SQLiteCommand()
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

        public override async Task<ReadOnlyCollection<T>> LoadMultipleDefinitions<T>(uint[] hashes,
            BungieLocales locale)
        {
            IList<T> tempCollection = new List<T>(hashes.Length);
            _connection.ConnectionString = $"Data Source={_databasePaths[locale]}; Version=3;";
            _connection.Open();
            foreach (var hash in hashes)
            {
                var commandObj = new SQLiteCommand()
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

        public override async Task<DestinyHistoricalStatsDefinition> LoadHistoricalStatsDefinition(string id,
            BungieLocales locale)
        {
            DestinyHistoricalStatsDefinition result = default;
            _connection.ConnectionString = $"Data Source={_databasePaths[locale]}; Version=3;";
            _connection.Open();
            var commandObj = new SQLiteCommand()
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

        public override async Task<string> LoadHistoricalStatsDefinitionAsJson(string id, BungieLocales locale)
        {
            var result = string.Empty;
            _connection.ConnectionString = $"Data Source={_databasePaths[locale]}; Version=3;";
            _connection.Open();
            var commandObj = new SQLiteCommand()
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
        }

        public override async Task<ReadOnlyCollection<T>> LoadAllDefinitions<T>(BungieLocales locale)
        {
            IList<T> tempCollection = new List<T>();
            _connection.ConnectionString = $"Data Source={_databasePaths[locale]}; Version=3;";
            _connection.Open();
            var commandObj = new SQLiteCommand()
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
    }
}