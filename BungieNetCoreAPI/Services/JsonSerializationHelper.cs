using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using NetBungieAPI.Serialization;
using NetBungieAPI.Services.Interfaces;

namespace NetBungieAPI.Services
{
    public class JsonSerializationHelper : IJsonSerializationHelper
    {
        public JsonSerializerOptions Options { get; } = new()
        {
            Converters =
            {
                new ReadOnlyCollectionConverterFactory(),
                new DefinitionHashPointerConverterFactory(),
                new ReadOnlyDictionaryEnumKeyConverterFactory(),
                new ReadOnlyDictionaryStructKeyConverterFactory(),
                new ReadOnlyDictionaryDefinitionPointerKeyConverterFactory(),
                new ReadOnlyDictionaryStringKeyConverterFactory()
            },
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            WriteIndented = true
        };

        public async Task<object> DeserializeAsync(byte[] data, Type type)
        {
            await using Stream readStream = new MemoryStream(data);
            return await JsonSerializer.DeserializeAsync(readStream, type, Options);
        }

        public async Task<T> DeserializeAsync<T>(byte[] data)
        {
            await using Stream readStream = new MemoryStream(data);
            return await JsonSerializer.DeserializeAsync<T>(readStream, Options);
        }

        public async Task<object> DeserializeAsync(Stream data, Type type)
        {
            return await JsonSerializer.DeserializeAsync(data, type, Options);
        }
        
        public async Task<T> DeserializeAsync<T>(Stream data)
        {
            return await JsonSerializer.DeserializeAsync<T>(data, Options);
        }

        public object Deserialize(string json, Type type)
        {
            return JsonSerializer.Deserialize(json, type, Options);
        }
        
        public object Deserialize(ReadOnlySpan<byte> data, Type type)
        {
            return JsonSerializer.Deserialize(data, type, Options);
        }

        public T Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json, Options);
        }
        
        public T Deserialize<T>(byte[] data)
        {
            return JsonSerializer.Deserialize<T>(data, Options);
        }

        public string Serialize<T>(T obj)
        {
            return JsonSerializer.Serialize(obj, Options);
        }

        public JsonSerializationHelper()
        {
            
        }
        
        
    }
}