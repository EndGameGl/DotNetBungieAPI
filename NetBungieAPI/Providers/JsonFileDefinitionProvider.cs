using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NetBungieAPI.Logging;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Models.Destiny.Config;
using NetBungieAPI.Models.Destiny.Definitions.HistoricalStats;
using NetBungieAPI.Providers.Json;

namespace NetBungieAPI.Providers
{
    /// <summary>
    /// Definition provider based of json files
    /// </summary>
    public class JsonFileDefinitionProvider : DefinitionProvider
    {
        private readonly string ManifestPath;
        private readonly Dictionary<BungieLocales, JsonAggregateDefinitionMapping> _fileMappings = new();
        private readonly Dictionary<BungieLocales, string> _filePaths = new();

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="manifestsPath">path to manifest</param>
        public JsonFileDefinitionProvider(string manifestsPath)
        {
            ManifestPath = manifestsPath;
        }

        /// <summary>
        /// <inheritdoc cref="DefinitionProvider.OnLoad"/>
        /// </summary>
        public override Task OnLoad()
        {
            foreach (var locale in DefinitionLoadingSettings.Locales)
            {
                var fileLocation =
                    $"{ManifestPath}\\{UsedManifest.Version}\\JsonWorldContent\\{locale.LocaleToString()}\\{Path.GetFileName(UsedManifest.JsonWorldContentPaths[locale.LocaleToString()])}";
                _filePaths.Add(locale, fileLocation);
                OnLoadInternal(locale, fileLocation);
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// <inheritdoc cref="DefinitionProvider.OnLoadInternal"/>
        /// </summary>
        private void OnLoadInternal(BungieLocales locale, string path)
        {
            _fileMappings.Add(locale, new JsonAggregateDefinitionMapping());
            DefinitionsEnum? currentReadValue = null;
            var array = File.ReadAllBytes(path);
            var reader = new Utf8JsonReader(array);
            while (reader.Read())
            {
                if (reader.TokenType is JsonTokenType.StartObject or JsonTokenType.EndObject
                    or JsonTokenType.StartArray or JsonTokenType.EndArray)
                    continue;
                switch (reader.CurrentDepth)
                {
                    case 1:
                        if (Enum.TryParse<DefinitionsEnum>(reader.GetString(), out var enumValue))
                        {
                            if (((IList)DefinitionLoadingSettings.AllowedDefinitions).Contains(enumValue))
                            {
                                currentReadValue = enumValue;
                                _fileMappings[locale].Mappings.Add(enumValue, new JsonAggregateDefinitionTypeMapping());
                            }
                            else
                            {
                                reader.Skip();
                                currentReadValue = null;
                            }
                        }
                        else
                        {
                            reader.Skip();
                            currentReadValue = null;
                        }

                        break;
                    case 2:
                        if (currentReadValue.HasValue)
                        {
                            var hash = uint.Parse(reader.GetString());
                            var index = reader.BytesConsumed;
                            reader.Skip();
                            _fileMappings[locale].Mappings[currentReadValue.Value].DefinitionsData.Add(hash,
                                new JsonAggregateDefinitionTypeUnitMapping
                                {
                                    Position = index,
                                    Length = reader.BytesConsumed - index
                                });
                        }

                        break;
                }
            }
        }

        public override async Task ReadDefinitionsToRepository(IEnumerable<DefinitionsEnum> definitionsToLoad)
        {
            Repositories.Initialize(DefinitionLoadingSettings.Locales);
            byte[] buffer;
            foreach (var filePath in _filePaths)
            {
                Logger.Log($"Loading locale: {filePath.Key}.", LogType.Info);
                await using var fileStream = File.OpenRead(filePath.Value);
                foreach (var fileMapping in _fileMappings[filePath.Key].Mappings)
                {
                    Logger.Log($"Loading definitions: {fileMapping.Key}.", LogType.Info);
                    var type = AssemblyData.DefinitionsToTypeMapping[fileMapping.Key].DefinitionType;
                    foreach (var definitionPointerData in fileMapping.Value.DefinitionsData)
                    {
                        buffer = new byte[definitionPointerData.Value.Length];
                        fileStream.Position = definitionPointerData.Value.Position;
                        await fileStream.ReadAsync(buffer.AsMemory(0, buffer.Length));
                        Repositories.AddDefinition(
                            fileMapping.Key,
                            filePath.Key,
                            (IDestinyDefinition)await SerializationHelper.DeserializeAsync(buffer, type));
                    }
                }
            }
        }

        public override async ValueTask<T> LoadDefinition<T>(uint hash, BungieLocales locale)
        {
            var location = _fileMappings[locale].Mappings[DefinitionHashPointer<T>.EnumValue].DefinitionsData[hash];
            await using var fileStream = File.OpenRead(_filePaths[locale]);
            var buffer = new byte[location.Length];
            fileStream.Position = location.Position;
            await fileStream.ReadAsync(buffer.AsMemory(0, (int)location.Length));
            return await SerializationHelper.DeserializeAsync<T>(buffer);
        }

        public override async ValueTask<string> ReadDefinitionAsJson(DefinitionsEnum enumValue, uint hash,
            BungieLocales locale)
        {
            var location = _fileMappings[locale].Mappings[enumValue].DefinitionsData[hash];
            await using var fileStream = File.OpenRead(_filePaths[locale]);
            var buffer = new byte[location.Length];
            fileStream.Position = location.Position;
            await fileStream.ReadAsync(buffer.AsMemory(0, (int)location.Length));
            return Encoding.UTF8.GetString(buffer);
        }

        public override async ValueTask<ReadOnlyCollection<T>> LoadMultipleDefinitions<T>(uint[] hashes,
            BungieLocales locale)
        {
            var results = new List<T>();
            await using var fileStream = File.OpenRead(_filePaths[locale]);
            byte[] buffer;
            foreach (var hash in hashes)
            {
                var location = _fileMappings[locale].Mappings[DefinitionHashPointer<T>.EnumValue].DefinitionsData[hash];
                buffer = new byte[location.Length];
                fileStream.Position = location.Position;
                await fileStream.ReadAsync(buffer.AsMemory(0, (int)location.Length));
                results.Add(await SerializationHelper.DeserializeAsync<T>(buffer));
            }

            return new ReadOnlyCollection<T>(results);
        }

        public override ValueTask<DestinyHistoricalStatsDefinition> LoadHistoricalStatsDefinition(string id,
            BungieLocales locale)
        {
            throw new ProviderUnsupportedException("This definition is not supported for current provider",
                DefinitionsEnum.DestinyHistoricalStatsDefinition);
        }

        /// <summary>
        /// <inheritdoc cref="DefinitionProvider.LoadHistoricalStatsDefinitionAsJson"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        /// <exception cref="ProviderUnsupportedException"></exception>
        public override ValueTask<string> LoadHistoricalStatsDefinitionAsJson(string id, BungieLocales locale)
        {
            throw new ProviderUnsupportedException("This definition is not supported for current provider",
                DefinitionsEnum.DestinyHistoricalStatsDefinition);
        }

        public override async ValueTask<ReadOnlyCollection<T>> LoadAllDefinitions<T>(BungieLocales locale)
        {
            var results = new List<T>();
            await using var fileStream = File.OpenRead(_filePaths[locale]);
            byte[] buffer;
            foreach (var hashData in _fileMappings[locale].Mappings[DefinitionHashPointer<T>.EnumValue].DefinitionsData)
            {
                var location = hashData.Value;
                buffer = new byte[location.Length];
                fileStream.Position = location.Position;
                await fileStream.ReadAsync(buffer.AsMemory(0, (int)location.Length));
                results.Add(await SerializationHelper.DeserializeAsync<T>(buffer));
            }

            return new ReadOnlyCollection<T>(results);
        }

        public override ValueTask<IEnumerable<DestinyManifest>> GetAvailableManifests()
        {
            throw new NotImplementedException();
        }

        public override ValueTask<DestinyManifest> GetCurrentManifest()
        {
            throw new NotImplementedException();
        }

        public override ValueTask<bool> CheckForUpdates()
        {
            throw new NotImplementedException();
        }

        public override Task Update()
        {
            throw new NotImplementedException();
        }

        public override Task DownloadNewManifestData(DestinyManifest manifestData)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteOldManifestData()
        {
            throw new NotImplementedException();
        }

        public override Task DeleteManifestData(DestinyManifest manifestData)
        {
            throw new NotImplementedException();
        }

        public override ValueTask<bool> CheckExistingManifestData(string version)
        {
            throw new NotImplementedException();
        }
    }
}