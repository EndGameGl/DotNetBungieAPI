using System.Reflection;
using System.Text.Json;

namespace DotNetBungieAPI.Models.Serialization;

/// <summary>
///     Definition hash pointer converter factory
/// </summary>
public sealed class DefinitionHashPointerConverterFactory : JsonConverterFactory
{
    private readonly Type _definitionHashPointerType = typeof(DefinitionHashPointer<>);

    /// <summary>
    ///     <inheritdoc cref="JsonConverterFactory.CanConvert" />
    /// </summary>
    /// <param name="typeToConvert"></param>
    /// <returns></returns>
    public override bool CanConvert(Type typeToConvert)
    {
        if (!typeToConvert.IsGenericType)
            return false;

        var genericTypeDef = typeToConvert.GetGenericTypeDefinition();

        return genericTypeDef == _definitionHashPointerType;
    }

    /// <summary>
    ///     <inheritdoc cref="JsonConverterFactory.CreateConverter" />
    /// </summary>
    /// <param name="typeToConvert"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var definitionType = typeToConvert.GetGenericArguments()[0];

        var converter = (JsonConverter)
            Activator.CreateInstance(
                typeof(DefinitionHashPointerConverter<>).MakeGenericType(definitionType),
                BindingFlags.Instance | BindingFlags.Public,
                null,
                [],
                null
            )!;

        return converter;
    }

    private class DefinitionHashPointerConverter<T> : JsonConverter<DefinitionHashPointer<T>>
        where T : IDestinyDefinition
    {
        public override bool HandleNull => true;

        public override DefinitionHashPointer<T> ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return Read(ref reader, typeToConvert, options);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DefinitionHashPointer<T> value,
            JsonSerializerOptions options
        )
        {
            Write(writer, value, options);
        }
        
        public override DefinitionHashPointer<T> Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return reader.TokenType switch
            {
                JsonTokenType.String => new DefinitionHashPointer<T>(uint.Parse(reader.GetString()!)),
                JsonTokenType.Null => DefinitionHashPointer<T>.Empty,
                JsonTokenType.PropertyName => new DefinitionHashPointer<T>(uint.Parse(reader.GetString()!)),
                _ => new DefinitionHashPointer<T>(reader.GetUInt32())
            };
        }

        public override void Write(
            Utf8JsonWriter writer,
            DefinitionHashPointer<T> value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Hash, options);
        }
    }
}
