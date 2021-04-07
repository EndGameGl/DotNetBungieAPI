using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Serialization
{
    public class ReadOnlyCollectionConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            if (!typeToConvert.IsGenericType)
            {
                return false;
            }

            if (typeToConvert.GetGenericTypeDefinition() != typeof(ReadOnlyCollection<>))
            {
                return false;
            }

            return true;
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            Type collectionType = typeToConvert.GetGenericArguments()[0];

            JsonConverter converter = (JsonConverter)Activator.CreateInstance(
                typeof(ReadOnlyCollectionConverter<>).MakeGenericType(
                    new Type[] { collectionType }),
                BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                args: new object[] { options },
                culture: null);

            return converter;
        }

        private class ReadOnlyCollectionConverter<T> : JsonConverter<ReadOnlyCollection<T>>
        {
            private readonly Type _valueType;
            private readonly JsonConverter<T> _valueConverter;
            public override bool HandleNull => true;
            public ReadOnlyCollectionConverter(JsonSerializerOptions options)
            {
                _valueConverter = (JsonConverter<T>)options.GetConverter(typeof(T));
                _valueType = typeof(T);
            }
            public override ReadOnlyCollection<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                IList<T> tempCollection = new List<T>();
                if (reader.TokenType == JsonTokenType.Null)
                    return Defaults.EmptyReadOnlyCollection<T>();
                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndArray)
                        return new ReadOnlyCollection<T>(tempCollection);
                    tempCollection.Add(_valueConverter.Read(ref reader, _valueType, options));
                }
                throw new JsonException();
            }
            public override void Write(Utf8JsonWriter writer, ReadOnlyCollection<T> value, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }
        }
    }
}
