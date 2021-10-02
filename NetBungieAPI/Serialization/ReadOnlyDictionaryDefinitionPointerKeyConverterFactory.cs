using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny;

namespace NetBungieAPI.Serialization
{
    internal sealed class ReadOnlyDictionaryDefinitionPointerKeyConverterFactory : JsonConverterFactory
    {
        private readonly Type _definitionPointerType = typeof(DefinitionHashPointer<>);
        private readonly Type _genericReadOnlyDictType = typeof(ReadOnlyDictionary<,>);

        public override bool CanConvert(Type typeToConvert)
        {
            if (!typeToConvert.IsGenericType) return false;

            if (typeToConvert.GetGenericTypeDefinition() != _genericReadOnlyDictType) return false;

            if (!typeToConvert.GenericTypeArguments[0].IsGenericType ||
                typeToConvert.GenericTypeArguments[0].GetGenericTypeDefinition() != _definitionPointerType)
                return false;

            return true;
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            try
            {
                var keyType = typeToConvert.GetGenericArguments()[0].GenericTypeArguments[0];
                var valueType = typeToConvert.GetGenericArguments()[1];


                var converter = (JsonConverter)Activator.CreateInstance(
                    typeof(ReadOnlyDictionaryDefinitionKeyConverter<,>).MakeGenericType(keyType, valueType),
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

        private class
            ReadOnlyDictionaryDefinitionKeyConverter<TKey, TValue> : JsonConverter<
                ReadOnlyDictionary<DefinitionHashPointer<TKey>, TValue>> where TKey : IDestinyDefinition
        {
            public ReadOnlyDictionaryDefinitionKeyConverter(JsonSerializerOptions options)
            {
            }

            public override bool HandleNull => true;

            public override ReadOnlyDictionary<DefinitionHashPointer<TKey>, TValue> Read(ref Utf8JsonReader reader,
                Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Null)
                    return Defaults.EmptyReadOnlyDictionary<DefinitionHashPointer<TKey>, TValue>();
                IDictionary<DefinitionHashPointer<TKey>, TValue> tempDictionary =
                    new Dictionary<DefinitionHashPointer<TKey>, TValue>();
                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndObject)
                        return new ReadOnlyDictionary<DefinitionHashPointer<TKey>, TValue>(tempDictionary);

                    var key = reader.GetString();
                    if (uint.TryParse(key, out var parsedKey))
                        tempDictionary.Add(
                            new DefinitionHashPointer<TKey>(parsedKey),
                            JsonSerializer.Deserialize<TValue>(ref reader, options)
                        );
                }

                throw new JsonException();
            }

            public override void Write(Utf8JsonWriter writer,
                ReadOnlyDictionary<DefinitionHashPointer<TKey>, TValue> value, JsonSerializerOptions options)
            {
                writer.WriteStartObject();

                foreach (var (key, val) in value)
                {
                    var propertyName = key.Hash.ToString();
                    writer.WritePropertyName(propertyName);

                    JsonSerializer.Serialize(writer, val, options);
                }

                writer.WriteEndObject();
            }
        }
    }
}