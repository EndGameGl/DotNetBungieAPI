using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NetBungieAPI.Serialization
{
    public class ReadOnlyDictionaryStructKeyConverterFactory : JsonConverterFactory
    {
        private Type _genericReadOnlyDictType = typeof(ReadOnlyDictionary<,>);
        public override bool CanConvert(Type typeToConvert)
        {
            if (!typeToConvert.IsGenericType)
            {
                return false;
            }

            if (typeToConvert.GetGenericTypeDefinition() != _genericReadOnlyDictType)
            {
                return false;
            }

            if (!typeToConvert.GenericTypeArguments[0].IsValueType)
                return false;

            return true;
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var keyType = typeToConvert.GetGenericArguments()[0];
            var valueType = typeToConvert.GetGenericArguments()[1];

            var converter = (JsonConverter)Activator.CreateInstance(
                typeof(ReadOnlyDictionaryConverter<,>).MakeGenericType(
                    new Type[] { keyType, valueType }),
                BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                args: new object[] { options },
                culture: null);

            return converter;
        }

        private class ReadOnlyDictionaryConverter<TKey, TValue> : JsonConverter<ReadOnlyDictionary<TKey, TValue>> where TKey : struct
        {
            private readonly Type _keyType;

            public override bool HandleNull => true;
            public ReadOnlyDictionaryConverter(JsonSerializerOptions options)
            {
                _keyType = typeof(TKey);
            }
            public override ReadOnlyDictionary<TKey, TValue> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Null)
                    return Defaults.EmptyReadOnlyDictionary<TKey, TValue>();
                IDictionary<TKey, TValue> tempDictionary = new Dictionary<TKey, TValue>();
                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndObject)
                        return new ReadOnlyDictionary<TKey, TValue>(tempDictionary);

                    var key = reader.GetString();
                    tempDictionary.Add(
                        key: (TKey)Convert.ChangeType(key, _keyType),
                        value: JsonSerializer.Deserialize<TValue>(ref reader, options)
                    );
                }
                throw new JsonException();
            }
            public override void Write(Utf8JsonWriter writer, ReadOnlyDictionary<TKey, TValue> value, JsonSerializerOptions options)
            {
                writer.WriteStartObject();

                foreach ((var key, var val) in value)
                {
                    var propertyName = key.ToString();
                    writer.WritePropertyName(propertyName);

                    JsonSerializer.Serialize(writer, val, options);
                }

                writer.WriteEndObject();
            }
        }
    }
}
