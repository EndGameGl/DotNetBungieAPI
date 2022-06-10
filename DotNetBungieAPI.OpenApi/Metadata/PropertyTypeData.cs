using System.Reflection.Metadata;
using DotNetBungieAPI.OpenApi.Extensions;
using DotNetBungieAPI.OpenApi.Models;

namespace DotNetBungieAPI.OpenApi.Metadata;

public class PropertyTypeData
{
    public string OriginPropertyName { get; }
    public string Description { get; }
    public string TypeReference { get; set; }
    public string Format { get; set; }
    
    public bool IsEnum { get; set; }
    public bool IsClass { get; private set; } = false;
    public bool IsValue { get; private set; } = false;
    public bool IsCollection { get; private set; } = false;
    public bool IsHashMap { get; private set; } = false;
    public bool IsNullable { get; private set; } = true;

    public List<PropertyTypeData> GenericProperties { get; } = new();

    public PropertyTypeData(
        string typeName,
        OpenApiComponentSchema openApiComponentSchema)
    {
        OriginPropertyName = typeName;
        if (openApiComponentSchema.TypeReference is not null)
        {
            TypeReference = openApiComponentSchema.TypeReference;
            IsClass = true;
        }
        else if (openApiComponentSchema.Type is "object" && openApiComponentSchema.AllOf?.Count > 0)
        {
            TypeReference = openApiComponentSchema.AllOf[0].TypeReference;
            IsClass = true;
        }
        else if (openApiComponentSchema.EnumReference is not null)
        {
            IsValue = true;
            IsEnum = true;
            TypeReference = openApiComponentSchema.EnumReference.TypeReference;
        }
        else if (openApiComponentSchema.Type is not ("object" or "array"))
        {
            IsValue = true;
            TypeReference = openApiComponentSchema.Type;
            Format = openApiComponentSchema.Format;
        }
        else
        {
            AnalyzeType(openApiComponentSchema);
        }

        Description = openApiComponentSchema.Description;
    }

    private void AnalyzeType(OpenApiComponentSchema schema)
    {
        IsNullable = schema.Nullable;
        switch (schema)
        {
            case { TypeReference: not null }:
                IsClass = true;
                return;

            // simple object ref 
            case { Type: "object", AllOf.Count: > 0 }:
                IsClass = true;
                return;

            // dictionary with key specified
            case { Type: "object", AdditionalProperties: not null, DictionaryKey: not null }:
                IsHashMap = true;
                GenericProperties.Add(new PropertyTypeData("", schema.DictionaryKey));
                GenericProperties.Add(new PropertyTypeData("", schema.AdditionalProperties));
                return;

            // dictionary with key unspecified
            case { Type: "object", AdditionalProperties: not null, DictionaryKey: null }:
                IsHashMap = true;
                GenericProperties.Add(new PropertyTypeData("", schema.AdditionalProperties));
                GenericProperties.Add(new PropertyTypeData("", schema.AdditionalProperties));
                return;

            // no type specified
            case { Type: "object" }:
                IsClass = true;
                return;

            // list
            case { Type: "array", Items: not null }:
                IsCollection = true;
                switch (schema.Items)
                {
                    // T is object
                    case { TypeReference: not null }:
                        GenericProperties.Add(new PropertyTypeData("", schema.Items));
                        return;
                    // T is enum
                    case { EnumReference: not null }:
                        GenericProperties.Add(new PropertyTypeData("", schema.Items.EnumReference)
                        {
                            IsValue = true
                        });
                        return;
                    // T is value type
                    default:
                        GenericProperties.Add(new PropertyTypeData("", schema.Items));
                        return;
                }
            // DateTime
            case { Type: "string", Format: "date-time" }:
                IsValue = true;
                return;

            // string
            case { Type: "string" }:
                IsValue = true;
                return;

            // float or double
            case { Type: "number" }:
                IsValue = true;
                return;

            // enum
            case { Type: "integer", EnumReference: not null }:
                IsValue = true;
                IsEnum = true;
                return;

            // int variable
            case { Type: "integer" }:
                IsValue = true;
                return;

            // bool
            case { Type: "boolean" }:
                IsValue = true;
                return;

            default:
                throw new Exception("Type couldn't be processed");
        }
    }
}