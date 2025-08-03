using DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

namespace DotNetBungieAPI.OpenApi.CSharp;

public static class PropertyTypeDataExtensions
{
    internal static string GetCSharpType(
        this IOpenApiComponentSchema property,
        string? namespaceName = null
    )
    {
        return property switch
        {
            OpenApiArrayComponentSchema arrayComponent
                => $"{arrayComponent.Items.GetCSharpType(namespaceName)}[]",
            OpenApiDictionaryComponentSchema dictionaryComponent
                => $"Dictionary<{dictionaryComponent.DictionaryKey.GetCSharpType(namespaceName)}, {dictionaryComponent.AdditionalProperties.GetCSharpType(namespaceName)}>",
            OpenApiEmptyObjectComponentSchema => "object",
            OpenApiEnumReferenceComponentSchema enumReference
                => $"{enumReference.EnumReference.GetCSharpType(namespaceName)}",
            OpenApiIntegerComponentSchema integerComponent
                => $"{Resources.TypeMappings[integerComponent.Format]}",
            OpenApiStringComponentSchema { Format: "date-time" } => "DateTime",
            OpenApiStringComponentSchema { Format: "byte" } => "byte",
            OpenApiStringComponentSchema => "string",
            OpenApiNumberComponentSchema numberComponent => numberComponent.Format,
            OpenApiObjectMultiTypeComponentSchema openApiObjectMultiTypeComponentSchema
                => $"{openApiObjectMultiTypeComponentSchema.AllOf[0].GetCSharpType(namespaceName)}",
            OpenApiBooleanComponentSchema => "bool",
            OpenApiComponentReference openApiComponentReference
                => GetSharpReferenceType(openApiComponentReference, namespaceName),
            _ => throw new NotImplementedException(),
        };
    }

    public static string GetCSharpPropertyName(this string name)
    {
        return $"{char.ToUpper(name[0])}{name[1..]}";
    }

    private static string GetSharpReferenceType(
        OpenApiComponentReference reference,
        string? namespaceName = null
    )
    {
        if (namespaceName is null)
        {
            return reference.GetReferencedPath();
        }

        return $"{namespaceName}.{reference.GetReferencedPath()}";
    }
}
