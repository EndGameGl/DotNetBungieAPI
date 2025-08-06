using DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

namespace DotNetBungieAPI.OpenApi.CSharp.Library;

public static class PropertyTypeDataExtensions
{
    internal static string GetCSharpType(this IOpenApiComponentSchema property, string? namespaceName = null)
    {
        return property switch
        {
            OpenApiArrayComponentSchema arrayComponent => GetArrayTypeFromSchema(arrayComponent, namespaceName),
            OpenApiDictionaryComponentSchema dictionaryComponent => GetDictionaryTypeFromSchema(dictionaryComponent, namespaceName),
            OpenApiEmptyObjectComponentSchema => "object",
            OpenApiEnumReferenceComponentSchema enumReference => $"{enumReference.EnumReference.GetCSharpType(namespaceName)}",
            OpenApiIntegerComponentSchema integerComponent => GetIntTypeFromSchema(integerComponent),
            OpenApiStringComponentSchema { Format: "date-time" } => "DateTime",
            OpenApiStringComponentSchema { Format: "byte" } => "byte",
            OpenApiStringComponentSchema => "string",
            OpenApiNumberComponentSchema numberComponent => numberComponent.Format,
            OpenApiObjectMultiTypeComponentSchema openApiObjectMultiTypeComponentSchema => $"{openApiObjectMultiTypeComponentSchema.AllOf[0].GetCSharpType(namespaceName)}",
            OpenApiBooleanComponentSchema => "bool",
            OpenApiComponentReference openApiComponentReference => GetSharpReferenceType(openApiComponentReference, namespaceName),
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

    private static string GetArrayTypeFromSchema(OpenApiArrayComponentSchema arrayComponent, string? namespaceName = null)
    {
        if (arrayComponent.MappedDefinition is { Reference: not null })
        {
            if (arrayComponent.Items is OpenApiIntegerComponentSchema)
            {
                return $"DefinitionHashPointer<{arrayComponent.MappedDefinition.GetReferencedPath()}>[]";
            }
        }

        return $"{arrayComponent.Items.GetCSharpType(namespaceName)}[]";
    }

    private static string GetDictionaryTypeFromSchema(OpenApiDictionaryComponentSchema dictionaryComponent, string? namespaceName = null)
    {
        if (dictionaryComponent.MappedDefinition is { Reference: not null })
        {
            return $"Dictionary<DefinitionHashPointer<{dictionaryComponent.MappedDefinition.GetReferencedPath()}>, {dictionaryComponent.AdditionalProperties.GetCSharpType(namespaceName)}>";
        }

        return $"Dictionary<{dictionaryComponent.DictionaryKey.GetCSharpType(namespaceName)}, {dictionaryComponent.AdditionalProperties.GetCSharpType(namespaceName)}>";
    }

    private static string GetSharpReferenceType(OpenApiComponentReference reference, string? namespaceName = null)
    {
        if (namespaceName is null)
        {
            return reference.GetReferencedPath();
        }

        return $"{namespaceName}.{reference.GetReferencedPath()}";
    }
}
