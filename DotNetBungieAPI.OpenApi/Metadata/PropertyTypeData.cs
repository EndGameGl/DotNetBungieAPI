using System.Reflection.Metadata;
using DotNetBungieAPI.OpenApi.Extensions;
using DotNetBungieAPI.OpenApi.Models;

namespace DotNetBungieAPI.OpenApi.Metadata;

public class PropertyTypeData
{
    public string OriginPropertyName { get; }
    public string Description { get; }

    public bool IsClassObject { get; private set; } = false;
    public bool IsValueType { get; private set; } = false;
    public bool IsCollection { get; private set; } = false;
    public bool IsDictionary { get; private set; } = false;
    public bool IsNullable { get; private set; } = true;

    public PropertyTypeData[] GenericProperties { get; } = new PropertyTypeData[2];

    public PropertyTypeData(
        string typeName,
        OpenApiComponentSchema openApiComponentSchema)
    {
        OriginPropertyName = typeName;
        AnalyzeType(openApiComponentSchema);
        Description = openApiComponentSchema.Description;
    }

    private void AnalyzeType(OpenApiComponentSchema schema)
    {
        IsNullable = schema.Nullable;
        switch (schema)
        {
            case { TypeReference: not null }:
                IsClassObject = true;
                return;

            // simple object ref 
            case { Type: "object", AllOf.Count: > 0 }:
                IsClassObject = true;
                return;

            // // simple object ref 
            // case { Type: "object", TypeReference: not null }:
            //     IsClassObject = true;
            //     return schema.TypeReference.GetFullTypeName();

            // dictionary with key specified
            case { Type: "object", AdditionalProperties: not null, DictionaryKey: not null }:
                IsDictionary = true;
                GenericProperties[0] = new PropertyTypeData("DictionaryKey", schema.DictionaryKey);
                GenericProperties[1] = new PropertyTypeData("DictionaryValue", schema.AdditionalProperties);
                return;

            // dictionary with key unspecified
            case { Type: "object", AdditionalProperties: not null, DictionaryKey: null }:
                IsDictionary = true;
                GenericProperties[0] = new PropertyTypeData("DictionaryKey", schema.AdditionalProperties);
                GenericProperties[1] = new PropertyTypeData("DictionaryValue", schema.AdditionalProperties);
                return;

            // no type specified
            case { Type: "object" }:
                return;

            // list
            case { Type: "array", Items: not null }:
                IsCollection = true;
                switch (schema.Items)
                {
                    // T is object
                    case { TypeReference: not null }:
                        GenericProperties[0] = new PropertyTypeData("", schema.Items);
                        return;
                    // T is enum
                    case { EnumReference: not null }:
                        GenericProperties[0] = new PropertyTypeData("", schema.Items.EnumReference)
                        {
                            IsValueType = true
                        };
                        return;
                    // T is value type
                    default:
                        GenericProperties[0] = new PropertyTypeData("", schema.Items);
                        return;
                }
            // DateTime
            case { Type: "string", Format: "date-time" }:
                IsValueType = true;
                return;

            // string
            case { Type: "string" }:
                IsValueType = true;
                return;

            // float or double
            case { Type: "number" }:
                IsValueType = true;
                return;

            // enum
            case { Type: "integer", EnumReference: not null }:
                IsValueType = true;
                return;

            // int variable
            case { Type: "integer" }:
                IsValueType = true;
                return;

            // bool
            case { Type: "boolean" }:
                IsValueType = true;
                return;

            default:
                throw new Exception("Type couldn't be processed");
        }
    }
}