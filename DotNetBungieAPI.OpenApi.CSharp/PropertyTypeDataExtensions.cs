using DotNetBungieAPI.OpenApi.Extensions;
using DotNetBungieAPI.OpenApi.Metadata;
using DotNetBungieAPI.OpenApi.Models;

namespace DotNetBungieAPI.OpenApi.CSharp;

public static class PropertyTypeDataExtensions
{
    public static string GetCSharpType(this OpenApiComponentSchema schema)
    {
        return schema switch
        {
            { TypeReference: not null } => schema.TypeReference.GetFullTypeName(),
            // simple object ref 
            { Type: "object", AllOf.Count: > 0 } => schema.AllOf.First().TypeReference?.GetFullTypeName(),
            // simple object ref 
            //{ Type: "object", TypeReference: not null } => schema.TypeReference.GetFullTypeName(),
            // dictionary with key specified
            { Type: "object", AdditionalProperties: not null, DictionaryKey: not null } =>
                $"Dictionary<{GetCSharpType(schema.DictionaryKey)}, {GetCSharpType(schema.AdditionalProperties)}>",
            // dictionary with key unspecified
            { Type: "object", AdditionalProperties: not null, DictionaryKey: null } =>
                $"Dictionary<{GetCSharpType(schema.AdditionalProperties)}, {GetCSharpType(schema.AdditionalProperties)}>",
            // no type specified
            { Type: "object" } => "object",
            // list
            { Type: "array", Items: not null } => schema.Items switch
            {
                // T is object
                { TypeReference: not null } => $"List<{GetCSharpType(schema.Items)}>",
                // T is enum
                { EnumReference: not null } => $"List<{GetCSharpType(schema.Items.EnumReference)}>",
                // T is value type, process as is
                _ => $"List<{GetCSharpType(schema.Items)}>"
            },
            // DateTime
            { Type: "string", Format: "date-time" } => $"DateTime{(schema.Nullable ? "?" : "")}",
            // string
            { Type: "string" } => "string",
            // float or double
            { Type: "number" } => $"{schema.Format}{(schema.Nullable ? "?" : "")}",
            // enum
            { Type: "integer", EnumReference: not null } =>
                $"{schema.EnumReference.TypeReference.GetFullTypeName()}{(schema.Nullable ? "?" : "")}",
            // int variable
            { Type: "integer" } => $"{Resources.TypeMappings[schema.Format]}{(schema.Nullable ? "?" : "")}",
            // bool
            { Type: "boolean" } => $"bool{(schema.Nullable ? "?" : "")}",
            _ => throw new Exception("Type couldn't be processed")
        };
    }

    public static string GetCSharpPropertyName(this string name)
    {
        return $"{char.ToUpper(name[0])}{name[1..]}";
    }
}