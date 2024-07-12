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

    public bool MappedToDefinition { get; private set; } = false;
    public string? MappedDefinitionTypeReference { get; private set; } = null;

    public bool HashMapValueMappedToDefinition { get; private set; } = false;
    public string? HashMapValueMappedDefinitionTypeReference { get; private set; } = null;

    public List<PropertyTypeData> GenericProperties { get; } = new();

    public PropertyTypeData(string typeName, OpenApiComponentSchema openApiComponentSchema)
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
            if (openApiComponentSchema.MappedDefinition is not null)
            {
                MappedToDefinition = true;
                MappedDefinitionTypeReference = openApiComponentSchema
                    .MappedDefinition
                    .TypeReference;
            }

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
            // dictionary with key specified
            case { Type: "object", AdditionalProperties: not null, DictionaryKey: not null }:
                if (schema.MappedDefinition is not null)
                {
                    MappedToDefinition = true;
                    MappedDefinitionTypeReference = schema.MappedDefinition.TypeReference;
                }
                IsHashMap = true;
                GenericProperties.Add(new PropertyTypeData("", schema.DictionaryKey));
                GenericProperties.Add(new PropertyTypeData("", schema.AdditionalProperties));
                return;

            // no type specified
            case { Type: "object" }:
                IsClass = true;
                return;

            // list
            case { Type: "array", Items: not null }:
                IsCollection = true;
                if (schema.MappedDefinition is not null)
                {
                    MappedToDefinition = true;
                    MappedDefinitionTypeReference = schema.MappedDefinition.TypeReference;
                }
                switch (schema.Items)
                {
                    // T is object
                    case { TypeReference: not null }:
                        GenericProperties.Add(new PropertyTypeData("", schema.Items));
                        return;
                    // T is enum
                    case { EnumReference: not null }:
                        GenericProperties.Add(
                            new PropertyTypeData("", schema.Items.EnumReference) { IsValue = true }
                        );
                        return;
                    // T is value type
                    default:
                        GenericProperties.Add(new PropertyTypeData("", schema.Items));
                        return;
                }

            default:
                throw new Exception("Type couldn't be processed");
        }
    }
}
