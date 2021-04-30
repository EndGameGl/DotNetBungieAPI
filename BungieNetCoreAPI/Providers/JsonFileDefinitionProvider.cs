using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NetBungieAPI.Logging;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Models.Destiny.Definitions.HistoricalStats;
using NetBungieAPI.Providers.Json;

namespace NetBungieAPI.Providers
{
    public class JsonFileDefinitionProvider : DefinitionProvider
    {
        private Dictionary<BungieLocales, JsonAggregateDefinitionMapping> _fileMappings = new();
        private Dictionary<BungieLocales, string> _filePaths = new();

        public JsonFileDefinitionProvider()
        {
        }

        public override async Task OnLoad()
        {
            foreach (var locale in Locales)
            {
                var fileLocation =
                    $"{ManifestPath}\\{UsedManifest.Version}\\JsonWorldContent\\{locale.LocaleToString()}\\{Path.GetFileName(UsedManifest.JsonWorldContentPaths[locale.LocaleToString()])}";
                _filePaths.Add(locale, fileLocation);
                OnLoadInternal(locale, fileLocation);
            }
        }

        private void OnLoadInternal(BungieLocales locale, string path)
        {
            _fileMappings.Add(locale, new JsonAggregateDefinitionMapping());
            DefinitionsEnum? currentReadValue = null;
            var reader = new Utf8JsonReader(File.ReadAllBytes(path));
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
                            if (DefinitionsToLoad.Contains(enumValue))
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
                                new JsonAggregateDefinitionTypeUnitMapping()
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
            Repositories.Initialize(Locales);
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
                        Repositories.AddDefinitionToCache(
                            fileMapping.Key,
                            (IDestinyDefinition) await SerializationHelper.DeserializeAsync(buffer, type),
                            filePath.Key);
                    }
                }
            }
        }

        public override async Task<T> LoadDefinition<T>(uint hash, BungieLocales locale)
        {
            var location = _fileMappings[locale].Mappings[DefinitionHashPointer<T>.EnumValue].DefinitionsData[hash];
            await using var fileStream = File.OpenRead(_filePaths[locale]);
            var buffer = new byte[location.Length];
            fileStream.Position = location.Position;
            await fileStream.ReadAsync(buffer.AsMemory(0, (int) location.Length));
            return await SerializationHelper.DeserializeAsync<T>(buffer);
        }

        public override async Task<string> ReadDefinitionAsJson(DefinitionsEnum enumValue, uint hash,
            BungieLocales locale)
        {
            var location = _fileMappings[locale].Mappings[enumValue].DefinitionsData[hash];
            await using var fileStream = File.OpenRead(_filePaths[locale]);
            var buffer = new byte[location.Length];
            fileStream.Position = location.Position;
            await fileStream.ReadAsync(buffer.AsMemory(0, (int) location.Length));
            return Encoding.UTF8.GetString(buffer);
        }

        public override async Task<ReadOnlyCollection<T>> LoadMultipleDefinitions<T>(uint[] hashes,
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
                await fileStream.ReadAsync(buffer.AsMemory(0, (int) location.Length));
                results.Add(await SerializationHelper.DeserializeAsync<T>(buffer));
            }
            return new ReadOnlyCollection<T>(results);
        }

        public override async Task<DestinyHistoricalStatsDefinition> LoadHistoricalStatsDefinition(string id,
            BungieLocales locale)
        {
            throw new ProviderUnsupportedException("This definition is not supported for current provider", DefinitionsEnum.DestinyHistoricalStatsDefinition);
        }

        public override async Task<string> LoadHistoricalStatsDefinitionAsJson(string id, BungieLocales locale)
        {
            throw new ProviderUnsupportedException("This definition is not supported for current provider", DefinitionsEnum.DestinyHistoricalStatsDefinition);
        }

        public override async Task<ReadOnlyCollection<T>> LoadAllDefinitions<T>(BungieLocales locale)
        {
            var results = new List<T>();
            await using var fileStream = File.OpenRead(_filePaths[locale]);
            byte[] buffer;
            foreach (var hashData in _fileMappings[locale].Mappings[DefinitionHashPointer<T>.EnumValue].DefinitionsData)
            {
                var location = hashData.Value;
                buffer = new byte[location.Length];
                fileStream.Position = location.Position;
                await fileStream.ReadAsync(buffer.AsMemory(0, (int) location.Length));
                results.Add(await SerializationHelper.DeserializeAsync<T>(buffer));
            }
            return new ReadOnlyCollection<T>(results);
        }
    }
}