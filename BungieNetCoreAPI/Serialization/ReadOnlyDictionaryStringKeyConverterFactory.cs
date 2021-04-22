﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Serialization
{
    public class ReadOnlyDictionaryStringKeyConverterFactory : JsonConverterFactory
    {
        private Type _genericReadOnlyDictType = typeof(ReadOnlyDictionary<,>);
        private Type _stringType = typeof(string);

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

            if (typeToConvert.GenericTypeArguments[0] != _stringType)
                return false;

            return true;
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var valueType = typeToConvert.GetGenericArguments()[1];

            var converter = (JsonConverter) Activator.CreateInstance(
                typeof(ReadOnlyDictionaryStringKeyConverterFactory.ReadOnlyDictionaryStringKeyConverter<,>)
                    .MakeGenericType(
                        new Type[] {_stringType, valueType}),
                BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                args: new object[] {options},
                culture: null);

            return converter;
        }

        private class
            ReadOnlyDictionaryStringKeyConverter<TKey, TValue> : JsonConverter<ReadOnlyDictionary<TKey, TValue>>
            where TKey : IConvertible
        {
            private Type _stringType = typeof(string);

            public override bool HandleNull => true;

            public ReadOnlyDictionaryStringKeyConverter(JsonSerializerOptions options)
            {
            }

            public override ReadOnlyDictionary<TKey, TValue> Read(ref Utf8JsonReader reader, Type typeToConvert,
                JsonSerializerOptions options)
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
                        key: (TKey) Convert.ChangeType(key, _stringType),
                        value: JsonSerializer.Deserialize<TValue>(ref reader, options)
                    );
                }

                throw new JsonException();
            }

            public override void Write(Utf8JsonWriter writer, ReadOnlyDictionary<TKey, TValue> value,
                JsonSerializerOptions options)
            {
                writer.WriteStartObject();

                foreach ((var key, var val) in value)
                {
                    var propertyName = key.ToString();
                    writer.WritePropertyName(options.PropertyNamingPolicy?.ConvertName(propertyName) ?? propertyName);

                    JsonSerializer.Serialize(writer, val, options);
                }

                writer.WriteEndObject();
            }
        }
    }
}