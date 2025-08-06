using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

namespace DotNetBungieAPI.OpenApi.Serialization;

public class IOpenApiComponentSchemaSerializer : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(IOpenApiComponentSchema);
    }

    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        return new IOpenApiComponentSchemaJsonConverter();
    }

    private class IOpenApiComponentSchemaJsonConverter : JsonConverter<IOpenApiComponentSchema>
    {
        public override IOpenApiComponentSchema? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType is not JsonTokenType.StartObject)
            {
                throw new JsonException("Incorrect token type");
            }

            var parsedObject = JsonNode.Parse(ref reader)!.AsObject();

            if (parsedObject.ContainsKey("enum") && parsedObject.ContainsKey("x-enum-values"))
            {
                return parsedObject.Deserialize<OpenApiEnumComponentSchema>(options);
            }

            if (parsedObject.ContainsKey("$ref"))
            {
                return parsedObject.Deserialize<OpenApiComponentReference>(options);
            }

            if (parsedObject.TryGetPropertyValue("type", out var schemaTypeValue))
            {
                var typeInfo = schemaTypeValue!.GetValue<string>();

                if (typeInfo is "object")
                {
                    if (parsedObject.ContainsKey("x-dictionary-key"))
                    {
                        return parsedObject.Deserialize<OpenApiDictionaryComponentSchema>(options);
                    }

                    if (parsedObject.Count == 1)
                    {
                        return parsedObject.Deserialize<OpenApiEmptyObjectComponentSchema>(options);
                    }

                    if (parsedObject.ContainsKey("allOf"))
                    {
                        return parsedObject.Deserialize<OpenApiObjectMultiTypeComponentSchema>(options);
                    }

                    return parsedObject.Deserialize<OpenApiObjectComponentSchema>(options);
                }

                if (typeInfo is "array")
                {
                    return parsedObject.Deserialize<OpenApiArrayComponentSchema>(options);
                }

                if (typeInfo is "integer")
                {
                    if (parsedObject.ContainsKey("x-enum-reference"))
                    {
                        return parsedObject.Deserialize<OpenApiEnumReferenceComponentSchema>(options);
                    }

                    return parsedObject.Deserialize<OpenApiIntegerComponentSchema>(options);
                }

                if (typeInfo is "string")
                {
                    return parsedObject.Deserialize<OpenApiStringComponentSchema>(options);
                }

                if (typeInfo is "boolean")
                {
                    return parsedObject.Deserialize<OpenApiBooleanComponentSchema>(options);
                }

                if (typeInfo is "number")
                {
                    return parsedObject.Deserialize<OpenApiNumberComponentSchema>(options);
                }
            }

            return null;
        }

        public override void Write(Utf8JsonWriter writer, IOpenApiComponentSchema value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
