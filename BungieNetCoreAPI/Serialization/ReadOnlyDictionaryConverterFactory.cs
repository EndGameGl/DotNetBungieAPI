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
    public class ReadOnlyDictionaryConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            if (!typeToConvert.IsGenericType)
            {
                return false;
            }

            if (typeToConvert.GetGenericTypeDefinition() != typeof(ReadOnlyDictionary<,>))
            {
                return false;
            }

            return true;
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            Type keyType = typeToConvert.GetGenericArguments()[0];
            Type valueType = typeToConvert.GetGenericArguments()[1];

            JsonConverter converter = (JsonConverter)Activator.CreateInstance(
                typeof(ReadOnlyDictionaryConverter<,>).MakeGenericType(
                    new Type[] { keyType, valueType }),
                BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                args: new object[] { options },
                culture: null);

            return converter;
        }

        private class ReadOnlyDictionaryConverter<T, P> : JsonConverter<ReadOnlyDictionary<T, P>> where T : IConvertible
        {
            private readonly Type _keyType;
            private readonly Type _valueType;
            private readonly JsonConverter<T> _keyConverter;
            private readonly JsonConverter<P> _valueConverter;

            public override bool HandleNull => true;
            public ReadOnlyDictionaryConverter(JsonSerializerOptions options)
            {
                _keyConverter = (JsonConverter<T>)options.GetConverter(typeof(T));
                _valueConverter = (JsonConverter<P>)options.GetConverter(typeof(P));
                _keyType = typeof(T);
                _valueType = typeof(P);
            }
            public override ReadOnlyDictionary<T, P> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Null)
                    return Defaults.EmptyReadOnlyDictionary<T, P>();
                IDictionary<T, P> tempDictionary = new Dictionary<T, P>();
                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndObject)
                        return new ReadOnlyDictionary<T, P>(tempDictionary);

                    var key =  reader.GetString();
                    if (decimal.TryParse(key, out var value))
                    {
                        tempDictionary.Add(
                        key: (T)Convert.ChangeType(value, _keyType),
                        value: _valueConverter.Read(ref reader, _valueType, options));
                    }
                    else
                    {
                        tempDictionary.Add(
                            key: (T)Convert.ChangeType(key, _keyType),
                            value: JsonSerializer.Deserialize<P>(ref reader, options));// _valueConverter.Read(ref reader, _valueType, options));
                    }
                }
                throw new JsonException();
            }
            public override void Write(Utf8JsonWriter writer, ReadOnlyDictionary<T, P> value, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }
        }
    }
}
