using DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

namespace DotNetBungieAPI.OpenApi.CSharp.Library;

public static class PropertyTypeDataExtensions
{
    internal static string GetCSharpType(this IOpenApiComponentSchema property)
    {
        return property switch
        {
            OpenApiArrayComponentSchema arrayComponent => GetArrayTypeFromSchema(arrayComponent),
            OpenApiDictionaryComponentSchema dictionaryComponent
                => GetDictionaryTypeFromSchema(dictionaryComponent),
            OpenApiEmptyObjectComponentSchema => "object",
            OpenApiEnumReferenceComponentSchema enumReference
                => $"{enumReference.EnumReference.GetCSharpType()}",
            OpenApiIntegerComponentSchema integerComponent
                => GetIntTypeFromSchema(integerComponent),
            OpenApiStringComponentSchema { Format: "date-time" } => "DateTime",
            OpenApiStringComponentSchema { Format: "byte" } => "byte",
            OpenApiStringComponentSchema => "string",
            OpenApiNumberComponentSchema numberComponent => numberComponent.Format,
            OpenApiObjectMultiTypeComponentSchema openApiObjectMultiTypeComponentSchema
                => $"{openApiObjectMultiTypeComponentSchema.AllOf[0].GetCSharpType()}",
            OpenApiBooleanComponentSchema => "bool",
            OpenApiComponentReference openApiComponentReference
                => openApiComponentReference.GetReferencedPath(),
            _ => throw new NotImplementedException(),
        };
    }

    public static string GetCSharpPropertyName(this string name)
    {
        return $"{char.ToUpper(name[0])}{name[1..]}";
    }

    private static string GetIntTypeFromSchema(OpenApiIntegerComponentSchema integerComponent)
    {
        if (integerComponent.MappedDefinition is { Reference: not null })
        {
            return $"DefinitionHashPointer<{integerComponent.MappedDefinition.GetReferencedPath()}>";
        }

        return $"{Resources.TypeMappings[integerComponent.Format]}";
    }

    private static string GetArrayTypeFromSchema(OpenApiArrayComponentSchema arrayComponent)
    {
        if (arrayComponent.MappedDefinition is { Reference: not null })
        {
            return $"DefinitionHashPointer<{arrayComponent.MappedDefinition.GetReferencedPath()}>[]";
        }

        return $"{arrayComponent.Items.GetCSharpType()}[]";
    }

    private static string GetDictionaryTypeFromSchema(
        OpenApiDictionaryComponentSchema dictionaryComponent
    )
    {
        if (dictionaryComponent.MappedDefinition is { Reference: not null })
        {
            return $"Dictionary<DefinitionHashPointer<{dictionaryComponent.MappedDefinition.GetReferencedPath()}>, {dictionaryComponent.AdditionalProperties.GetCSharpType()}>";
        }

        return $"Dictionary<{dictionaryComponent.DictionaryKey.GetCSharpType()}, {dictionaryComponent.AdditionalProperties.GetCSharpType()}>";
    }
}
