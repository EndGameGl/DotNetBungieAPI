﻿using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny;

namespace NetBungieAPI.Serialization
{
    public class DefinitionHashPointerConverterFactory : JsonConverterFactory
    {
        private readonly Type _definitionHashPointerType = typeof(DefinitionHashPointer<>);

        public override bool CanConvert(Type typeToConvert)
        {
            if (!typeToConvert.IsGenericType) return false;

            return typeToConvert.GetGenericTypeDefinition() == _definitionHashPointerType;
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var definitionType = typeToConvert.GetGenericArguments()[0];

            var converter = (JsonConverter) Activator.CreateInstance(
                typeof(DefinitionHashPointerConverter<>).MakeGenericType(definitionType),
                BindingFlags.Instance | BindingFlags.Public,
                null,
                Array.Empty<object>(),
                null);

            return converter;
        }

        private class DefinitionHashPointerConverter<T> : JsonConverter<DefinitionHashPointer<T>>
            where T : IDestinyDefinition
        {
            public override bool HandleNull => true;

            public override DefinitionHashPointer<T> Read(ref Utf8JsonReader reader, Type typeToConvert,
                JsonSerializerOptions options)
            {
                return reader.TokenType == JsonTokenType.Null
                    ? DefinitionHashPointer<T>.Empty
                    : new DefinitionHashPointer<T>(reader.GetUInt32());
            }

            public override void Write(Utf8JsonWriter writer, DefinitionHashPointer<T> value,
                JsonSerializerOptions options)
            {
                if (value.Hash.HasValue)
                    writer.WriteNumber("hash", value.Hash.Value);
            }
        }
    }
}