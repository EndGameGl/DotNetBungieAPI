using System.Reflection;

namespace DotNetBungieAPI.Serialization;

/// <summary>
///     Json converter for <see cref="ReadOnlyDictionary{TKey,TValue}"/>
/// </summary>
public sealed class ReadOnlyDictionaryConverterFactory : JsonConverterFactory
{
    private readonly Type _genericReadOnlyDictType = typeof(ReadOnlyDictionary<,>);

    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    /// <param name="typeToConvert"><inheritdoc /></param>
    /// <returns><inheritdoc /></returns>
    public override bool CanConvert(Type typeToConvert)
    {
        if (!typeToConvert.IsGenericType)
            return false;

        if (typeToConvert.GetGenericTypeDefinition() != _genericReadOnlyDictType)
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
        var keyType = typeToConvert.GetGenericArguments()[0];
        var valueType = typeToConvert.GetGenericArguments()[1];

        var converter = (JsonConverter)
            Activator.CreateInstance(
                type: typeof(ReadOnlyDictionaryConverter<,>).MakeGenericType(keyType, valueType),
                bindingAttr: BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                args: [options],
                culture: null
            )!;

        return converter;
    }

    private class ReadOnlyDictionaryConverter<TKey, TValue>
        : JsonConverter<ReadOnlyDictionary<TKey, TValue>> where TKey : notnull
    {
        public ReadOnlyDictionaryConverter(JsonSerializerOptions options) { }

        public override bool HandleNull => true;

        public override ReadOnlyDictionary<TKey, TValue> Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
                return ReadOnlyDictionary<TKey, TValue>.Empty;

            var values = new Dictionary<TKey, TValue>();

            TKey currentPropertyName = default;

            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.EndObject:
                        return new ReadOnlyDictionary<TKey, TValue>(values);
                    case JsonTokenType.PropertyName:
                        var propertyValue = reader.GetString();
                        currentPropertyName = JsonSerializer.Deserialize<TKey>(
                            $"\"{propertyValue}\"",
                            options
                        );
                        break;
                    default:
                        var value = JsonSerializer.Deserialize<TValue>(ref reader, options);
                        values.Add(currentPropertyName, value);
                        break;
                }
            }

            throw new JsonException();
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReadOnlyDictionary<TKey, TValue> value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStartObject();

            foreach (var (key, val) in value)
            {
                if (key is string stringKey)
                {
                    writer.WritePropertyName(stringKey);
                }
                else
                {
                    var serializedKey = JsonSerializer.Serialize(key, options);
                    writer.WritePropertyName(serializedKey);
                }

                JsonSerializer.Serialize(writer, val, options);
            }

            writer.WriteEndObject();
        }
    }
}
