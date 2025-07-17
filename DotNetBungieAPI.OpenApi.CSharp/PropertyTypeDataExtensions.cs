using DotNetBungieAPI.OpenApi.Extensions;
using DotNetBungieAPI.OpenApi.Metadata;
using DotNetBungieAPI.OpenApi.Models;

namespace DotNetBungieAPI.OpenApi.CSharp;

public static class PropertyTypeDataExtensions
{
    internal static string GetCSharpType(this PropertyTypeData property)
    {
        if (property.IsCollection)
        {
            var genericProperty = property.GenericProperties[0];
            return $"List<{genericProperty.GetCSharpType()}>";
        }

        if (property.IsHashMap)
        {
            var keyProperty = property.GenericProperties[0];
            var valueProperty = property.GenericProperties[1];
            return $"Dictionary<{keyProperty.GetCSharpType()}, {valueProperty.GetCSharpType()}>";
        }

        if (property.IsClass)
        {
            if (property.TypeReference is null)
                return "object";
            return $"{property.TypeReference.GetFullTypeName()}";
        }

        if (property.IsEnum)
        {
            return $"{property.TypeReference.GetFullTypeName()}";
        }

        if (property.IsValue)
        {
            return $"{property.FormatCSharpValueType()}";
        }

        throw new Exception("Failed to format C# property");
    }

    private static string FormatCSharpValueType(this PropertyTypeData property)
    {
        return property switch
        {
            { TypeReference: "string", Format: "date-time" } => "DateTime",
            { TypeReference: "string" } => "string",
            { TypeReference: "boolean" } => "bool",
            { TypeReference: "number" } => property.Format,
            { TypeReference: "integer" } => Resources.TypeMappings[property.Format],
            _ => throw new Exception("Failed to format C# property")
        };
    }

    public static string GetCSharpPropertyName(this string name)
    {
        return $"{char.ToUpper(name[0])}{name[1..]}";
    }
}
