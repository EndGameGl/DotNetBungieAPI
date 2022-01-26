using System.Reflection.Metadata;
using DotNetBungieAPI.OpenApi.Extensions;
using DotNetBungieAPI.OpenApi.Models;

namespace DotNetBungieAPI.OpenApi.Metadata;

public class PropertyTypeData
{
    public string CSharpPropertyName { get; }
    public string CSharpPropertyTypeName { get; }

    public string OriginPropertyName { get; }
    public string Description { get; }

    public bool IsClassObject { get; private set; } = false;
    public bool IsValueType { get; private set; } = false;
    public bool IsCollection { get; private set; } = false;
    public bool IsDictionary { get; private set; } = false;
    public bool IsNullable { get; private set; } = true;

    public PropertyTypeData[] GenericProperties { get; private set; } = new PropertyTypeData[2];

    public PropertyTypeData(
        string typeName,
        OpenApiComponentSchema openApiComponentSchema)
    {
        OriginPropertyName = typeName;
        CSharpPropertyTypeName = AnalyzeCSharpType(openApiComponentSchema);
        Description = openApiComponentSchema.Description;
        if (!string.IsNullOrEmpty(typeName))
            CSharpPropertyName = $"{char.ToUpper(typeName[0])}{typeName[1..]}";
    }

    private string AnalyzeCSharpType(OpenApiComponentSchema schema)
    {
        IsNullable = schema.Nullable;
        switch (schema)
        {
            case { TypeReference: not null }:
                IsClassObject = true;
                return schema.TypeReference.GetFullTypeName();

            // simple object ref 
            case { Type: "object", AllOf.Count: > 0 }:
                IsClassObject = true;
                return schema.AllOf.First().TypeReference?.GetFullTypeName();

            // // simple object ref 
            // case { Type: "object", TypeReference: not null }:
            //     IsClassObject = true;
            //     return schema.TypeReference.GetFullTypeName();

            // dictionary with key specified
            case { Type: "object", AdditionalProperties: not null, DictionaryKey: not null }:
                IsDictionary = true;
                GenericProperties[0] = new PropertyTypeData("DictionaryKey", schema.DictionaryKey);
                GenericProperties[1] = new PropertyTypeData("DictionaryValue", schema.AdditionalProperties);
                return
                    $"Dictionary<{GetCSharpType(schema.DictionaryKey)}, {GetCSharpType(schema.AdditionalProperties)}>";

            // dictionary with key unspecified
            case { Type: "object", AdditionalProperties: not null, DictionaryKey: null }:
                IsDictionary = true;
                GenericProperties[0] = new PropertyTypeData("DictionaryKey", schema.AdditionalProperties);
                GenericProperties[1] = new PropertyTypeData("DictionaryValue", schema.AdditionalProperties);
                return
                    $"Dictionary<{GetCSharpType(schema.AdditionalProperties)}, {GetCSharpType(schema.AdditionalProperties)}>";

            // no type specified
            case { Type: "object" }:
                return "object";

            // list
            case { Type: "array", Items: not null }:
                IsCollection = true;
                switch (schema.Items)
                {
                    // T is object
                    case { TypeReference: not null }:
                        GenericProperties[0] = new PropertyTypeData("", schema.Items);
                        return $"List<{GetCSharpType(schema.Items)}>";
                    // T is enum
                    case { EnumReference: not null }:
                        GenericProperties[0] = new PropertyTypeData("", schema.Items.EnumReference)
                        {
                            IsValueType = true
                        };
                        return $"List<{GetCSharpType(schema.Items.EnumReference)}>";
                    // T is value type
                    default:
                        GenericProperties[0] = new PropertyTypeData("", schema.Items);
                        return $"List<{GetCSharpType(schema.Items)}>";
                }
            // DateTime
            case { Type: "string", Format: "date-time" }:
                IsValueType = true;
                return $"DateTime{(schema.Nullable ? "?" : "")}";

            // string
            case { Type: "string" }:
                IsValueType = true;
                return "string";

            // float or double
            case { Type: "number" }:
                IsValueType = true;
                return $"{schema.Format}{(schema.Nullable ? "?" : "")}";

            // enum
            case { Type: "integer", EnumReference: not null }:
                IsValueType = true;
                return $"{schema.EnumReference.TypeReference.GetFullTypeName()}{(schema.Nullable ? "?" : "")}";

            // int variable
            case { Type: "integer" }:
                IsValueType = true;
                return $"{Resources.TypeMappings[schema.Format]}{(schema.Nullable ? "?" : "")}";

            // bool
            case { Type: "boolean" }:
                IsValueType = true;
                return $"bool{(schema.Nullable ? "?" : "")}";

            default:
                throw new Exception("Type couldn't be processed");
        }
    }

    private static string GetCSharpType(OpenApiComponentSchema schema)
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
}