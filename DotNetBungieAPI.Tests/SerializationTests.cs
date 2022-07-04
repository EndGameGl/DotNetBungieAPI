using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Models.Destiny.Config;
using DotNetBungieAPI.Models.Destiny.Definitions.Checklists;
using DotNetBungieAPI.Serialization;
using Xunit;
using Xunit.Priority;

namespace DotNetBungieAPI.Tests
{
    public class SerializationTests
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly string _manifestJson;
        private readonly string _destinyChecklistDefinition;

        public SerializationTests()
        {
            _jsonSerializerOptions = new JsonSerializerOptions()
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString,
                WriteIndented = true,
                Converters =
                {
                    new ReadOnlyCollectionConverterFactory(),
                    new DefinitionHashPointerConverterFactory(),
                    new ReadOnlyDictionaryConverterFactory(),
                    new HistoricalStatDefinitionPointerConverter(),
                    new DestinyResourceConverter(),
                    new StringEnumConverterFactory()
                }
            };
            _manifestJson = File.ReadAllText("./JsonTestAssets/DestinyManifest.json");
            _destinyChecklistDefinition = File.ReadAllText("./JsonTestAssets/DestinyChecklistDefinition_3373333905.json");
        }

        [Fact]
        [Priority(0)]
        public void DeserializeDestinyManifest()
        {
            var manifest = JsonSerializer.Deserialize<DestinyManifest>(_manifestJson, _jsonSerializerOptions);

            Assert.NotNull(manifest);

            Assert.Equal(
                "106284.22.06.21.1351-1-bnet.44999",
                manifest!.Version);

            Assert.Equal(
                "/common/destiny2_content/sqlite/en/world_sql_content_c1d4ac435e5ce5b3046fe2d0e6190ce4.content",
                manifest.MobileWorldContentPaths["en"]);

            Assert.Equal(3, manifest.MobileGearAssetDataBases.Count);
        }
        
        [Fact]
        [Priority(1)]
        public void SerializeDestinyManifest()
        {
            var manifest = JsonSerializer.Deserialize<DestinyManifest>(_manifestJson, _jsonSerializerOptions);

            Assert.NotNull(manifest);

            var serializedManifest = JsonSerializer.Serialize(manifest, _jsonSerializerOptions);

            Assert.Equal(_manifestJson, serializedManifest);
        }

        [Fact]
        [Priority(2)]
        public void DeserializeDestinyChecklistDefinition()
        {
            var destinyChecklistDefinition = JsonSerializer.Deserialize<DestinyChecklistDefinition>(
                _destinyChecklistDefinition, 
                _jsonSerializerOptions);

            Assert.NotNull(destinyChecklistDefinition);
            
            Assert.Equal(3373333905, destinyChecklistDefinition!.Hash);
            
            Assert.Equal(
                "View Lucent Moths", 
                destinyChecklistDefinition.ViewActionString);
            
            Assert.Equal(
                "Collect and mount all unique Lucent Moths in the Throne World.",
                destinyChecklistDefinition.DisplayProperties.Description);
            
            Assert.Equal(10, destinyChecklistDefinition.Entries.Count);
        }
    }
}