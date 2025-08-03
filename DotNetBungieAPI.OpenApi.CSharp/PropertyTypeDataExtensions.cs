using DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

namespace DotNetBungieAPI.OpenApi.CSharp;

public static class PropertyTypeDataExtensions
{
    internal static string GetCSharpType(this IOpenApiComponentSchema property)
    {
        return property switch
        {
            OpenApiArrayComponentSchema arrayComponent => $"{arrayComponent.Items.GetCSharpType()}[]",
            OpenApiDictionaryComponentSchema dictionaryComponent
                => $"Dictionary<{dictionaryComponent.DictionaryKey.GetCSharpType()}, {dictionaryComponent.AdditionalProperties.GetCSharpType()}>",
            OpenApiEmptyObjectComponentSchema => "object",
            OpenApiEnumReferenceComponentSchema enumReference => $"{enumReference.EnumReference.GetCSharpType()}",
            OpenApiIntegerComponentSchema integerComponent => $"{Resources.TypeMappings[integerComponent.Format]}",
            OpenApiStringComponentSchema { Format: "date-time" } => "DateTime",
            OpenApiStringComponentSchema { Format: "byte" } => "byte",
            OpenApiStringComponentSchema => "string",
            OpenApiNumberComponentSchema numberComponent => numberComponent.Format,
            OpenApiObjectMultiTypeComponentSchema openApiObjectMultiTypeComponentSchema => $"{openApiObjectMultiTypeComponentSchema.AllOf[0].GetCSharpType()}",
            OpenApiBooleanComponentSchema => "bool",
            OpenApiComponentReference openApiComponentReference => openApiComponentReference.GetReferencedPath(),
            _ => throw new NotImplementedException(),
        };
    }

    public static string GetCSharpPropertyName(this string name)
    {
        return $"{char.ToUpper(name[0])}{name[1..]}";
    }
}
