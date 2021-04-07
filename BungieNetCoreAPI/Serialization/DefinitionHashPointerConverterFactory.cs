using NetBungieAPI.Destiny.Definitions;
using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Serialization
{
    public class DefinitionHashPointerConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            if (!typeToConvert.IsGenericType)
            {
                return false;
            }

            if (typeToConvert.GetGenericTypeDefinition() != typeof(DefinitionHashPointer<>))
            {
                return false;
            }

            return true;
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            Type definitionType = typeToConvert.GetGenericArguments()[0];

            JsonConverter converter = (JsonConverter)Activator.CreateInstance(
                typeof(DefinitionHashPointerConverter<>).MakeGenericType(
                    new Type[] { definitionType }),
                BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                args: new object[] { },
                culture: null);

            return converter;
        }

        private class DefinitionHashPointerConverter<T> : JsonConverter<DefinitionHashPointer<T>> where T : IDestinyDefinition
        {
            public override bool HandleNull => true;
            public DefinitionHashPointerConverter()
            {

            }
            public override DefinitionHashPointer<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Null)
                    return DefinitionHashPointer<T>.Empty;
                return new DefinitionHashPointer<T>(reader.GetUInt32());
            }
            public override void Write(Utf8JsonWriter writer, DefinitionHashPointer<T> value, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }
        }
    }
}
