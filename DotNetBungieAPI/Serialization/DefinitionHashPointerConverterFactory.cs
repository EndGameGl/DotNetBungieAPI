using System.Reflection;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Destiny;

namespace DotNetBungieAPI.Serialization;

/// <summary>
///     Definition hash pointer converter factory
/// </summary>
internal sealed class DefinitionHashPointerConverterFactory : JsonConverterFactory
{
    private readonly Type _definitionHashPointerType = typeof(DefinitionHashPointer<>);

    /// <summary>
    ///     <inheritdoc cref="JsonConverterFactory.CanConvert" />
    /// </summary>
    /// <param name="typeToConvert"></param>
    /// <returns></returns>
    public override bool CanConvert(Type typeToConvert)
    {
        if (!typeToConvert.IsGenericType) return false;

        return typeToConvert.GetGenericTypeDefinition() == _definitionHashPointerType;
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

        var converter = (JsonConverter)Activator.CreateInstance(
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
            JsonSerializer.Serialize(writer, value.Hash, options);
        }
    }
}