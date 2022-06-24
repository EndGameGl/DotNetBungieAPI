using System.Collections;
using System.Reflection;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Destiny;

namespace DotNetBungieAPI.Serialization;

internal sealed class ReadOnlyDictionaryConverterFactory : JsonConverterFactory
{
    private readonly Type _genericReadOnlyDictType = typeof(ReadOnlyDictionary<,>);

    public override bool CanConvert(Type typeToConvert)
    {
        if (!typeToConvert.IsGenericType) return false;

        if (typeToConvert.GetGenericTypeDefinition() != _genericReadOnlyDictType) return false;

        return true;
    }

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            var keyType = typeToConvert.GetGenericArguments()[0];
            var valueType = typeToConvert.GetGenericArguments()[1];


            var converter = (JsonConverter)Activator.CreateInstance(
                typeof(ReadOnlyDictionaryConverter<,>).MakeGenericType(keyType, valueType),
                BindingFlags.Instance | BindingFlags.Public,
                null,
                new object[] { options },
                null);

            return converter;
        }
        catch
        {
            return null;
        }
    }

    private class ReadOnlyDictionaryConverter<TKey, TValue> : JsonConverter<ReadOnlyDictionary<TKey, TValue>>
    {
        public ReadOnlyDictionaryConverter(JsonSerializerOptions options)
        {
        }

        public override bool HandleNull => true;

        public override ReadOnlyDictionary<TKey, TValue> Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return ReadOnlyDictionaries<TKey, TValue>.Empty;

            IDictionary<TKey, TValue> values = new Dictionary<TKey, TValue>();

            TKey currentPropertyName = default;

            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.EndObject:
                        return new ReadOnlyDictionary<TKey, TValue>(values);
                    case JsonTokenType.PropertyName:
                        currentPropertyName = JsonSerializer.Deserialize<TKey>($"\"{reader.GetString()}\"", options);
                        break;
                    default:
                        var value = JsonSerializer.Deserialize<TValue>(ref reader, options);
                        values.Add(currentPropertyName, value);
                        break;
                }
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer,
            ReadOnlyDictionary<TKey, TValue> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            foreach (var (key, val) in value)
            {
                var serializedKey = JsonSerializer.Serialize(key, options);
                writer.WritePropertyName(serializedKey);

                JsonSerializer.Serialize(writer, val, options);
            }

            writer.WriteEndObject();
        }
    }
}