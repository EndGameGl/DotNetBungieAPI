using System.IO;
using System.Threading.Tasks;
using DotNetBungieAPI.Serialization;
using DotNetBungieAPI.Services.Default.ServiceConfigurations;
using DotNetBungieAPI.Services.Interfaces;

namespace DotNetBungieAPI.Services.Default;

/// <summary>
///     <inheritdoc cref="IBungieNetJsonSerializer" />
/// </summary>
internal sealed class DefaultBungieNetJsonSerializer : IBungieNetJsonSerializer
{
    private readonly JsonSerializerOptions _serializerOptions;

    public DefaultBungieNetJsonSerializer(DotNetBungieApiJsonSerializerConfiguration configuration)
    {
        _serializerOptions = configuration.Options;
        _serializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString;
        _serializerOptions.Converters.Add(new ReadOnlyCollectionConverterFactory());
        _serializerOptions.Converters.Add(new DefinitionHashPointerConverterFactory());
        _serializerOptions.Converters.Add(new ReadOnlyDictionaryDefinitionPointerKeyConverterFactory());
        _serializerOptions.Converters.Add(new ReadOnlyDictionaryEnumKeyConverterFactory());
        _serializerOptions.Converters.Add(new ReadOnlyDictionaryStructKeyConverterFactory());
        _serializerOptions.Converters.Add(new ReadOnlyDictionaryStringKeyConverterFactory());
        _serializerOptions.Converters.Add(new HistoricalStatDefinitionPointerConverter());
        _serializerOptions.Converters.Add(new DestinyResourceConverter());
        _serializerOptions.Converters.Add(new StringEnumConverterFactory());
    }


    public async ValueTask<object> DeserializeAsync(byte[] data, Type type)
    {
        await using Stream readStream = new MemoryStream(data);
        return await JsonSerializer.DeserializeAsync(readStream, type, _serializerOptions).ConfigureAwait(false);
    }

    public async ValueTask<T> DeserializeAsync<T>(byte[] data)
    {
        await using Stream readStream = new MemoryStream(data);
        return await JsonSerializer.DeserializeAsync<T>(readStream, _serializerOptions).ConfigureAwait(false);
    }

    public async ValueTask<object> DeserializeAsync(Stream data, Type type)
    {
        return await JsonSerializer.DeserializeAsync(data, type, _serializerOptions).ConfigureAwait(false);
    }

    public async ValueTask<T> DeserializeAsync<T>(Stream data)
    {
        return await JsonSerializer.DeserializeAsync<T>(data, _serializerOptions).ConfigureAwait(false);
    }

    public object Deserialize(string json, Type type)
    {
        return JsonSerializer.Deserialize(json, type, _serializerOptions);
    }

    public object Deserialize(ReadOnlySpan<byte> data, Type type)
    {
        return JsonSerializer.Deserialize(data, type, _serializerOptions);
    }

    public T Deserialize<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json, _serializerOptions);
    }

    public T Deserialize<T>(byte[] data)
    {
        return JsonSerializer.Deserialize<T>(data, _serializerOptions);
    }

    public string Serialize<T>(T obj)
    {
        return JsonSerializer.Serialize(obj, _serializerOptions);
    }

    public async Task SerializeAsync<T>(Stream stream, T data)
    {
        await JsonSerializer.SerializeAsync(stream, data, _serializerOptions).ConfigureAwait(false);
    }
}