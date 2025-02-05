using System.Reflection;

namespace DotNetBungieAPI.Serialization;

/// <summary>
///     Json converter for <see cref="ReadOnlyCollection{T}"/>
/// </summary>
public sealed class ReadOnlyCollectionConverterFactory : JsonConverterFactory
{
    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    /// <param name="typeToConvert"><inheritdoc /></param>
    /// <returns><inheritdoc /></returns>
    public override bool CanConvert(Type typeToConvert)
    {
        if (!typeToConvert.IsGenericType)
            return false;

        if (typeToConvert.GetGenericTypeDefinition() != typeof(ReadOnlyCollection<>))
            return false;

        return true;
    }

    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    /// <param name="typeToConvert"><inheritdoc /></param>
    /// <param name="options"><inheritdoc /></param>
    /// <returns><inheritdoc /></returns>
    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var collectionType = typeToConvert.GetGenericArguments()[0];

        var converter = (JsonConverter)
            Activator.CreateInstance(
                type: typeof(ReadOnlyCollectionConverter<>).MakeGenericType(collectionType),
                bindingAttr: BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                args: [options],
                culture: null
            )!;

        return converter;
    }

    private class ReadOnlyCollectionConverter<T> : JsonConverter<ReadOnlyCollection<T>>
    {
        private readonly JsonSerializerOptions _options;

        public ReadOnlyCollectionConverter(JsonSerializerOptions options)
        {
            _options = options;
        }

        public override bool HandleNull => true;

        public override ReadOnlyCollection<T> Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
                return ReadOnlyCollection<T>.Empty;

            var content = JsonSerializer.Deserialize<T[]>(ref reader, options);
            return new ReadOnlyCollection<T>(content);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReadOnlyCollection<T> value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStartArray();

            foreach (var item in value)
                JsonSerializer.Serialize(writer, item, options);

            writer.WriteEndArray();
        }
    }
}
