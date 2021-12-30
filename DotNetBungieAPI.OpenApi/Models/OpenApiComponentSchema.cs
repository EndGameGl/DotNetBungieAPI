using System.Diagnostics;
using System.Text.Json.Serialization;
using DotNetBungieAPI.OpenApi.Extensions;

namespace DotNetBungieAPI.OpenApi.Models;

public class OpenApiComponentSchema
{
    [JsonPropertyName("enum")] public List<string> Enum { get; init; }

    [JsonPropertyName("type")] public string Type { get; init; }

    [JsonPropertyName("format")] public string Format { get; init; }

    [JsonPropertyName("x-enum-values")] public List<EnumValue> EnumValues { get; init; }

    [JsonPropertyName("x-enum-is-bitmask")]
    public bool EnumIsBitmask { get; init; }

    [JsonPropertyName("x-enum-reference")] public OpenApiComponentSchema EnumReference { get; init; }

    [JsonPropertyName("$ref")] public string TypeReference { get; init; }

    [JsonPropertyName("description")] public string Description { get; init; }

    [JsonPropertyName("items")] public OpenApiComponentSchema Items { get; init; }

    [JsonPropertyName("properties")] public Dictionary<string, OpenApiComponentSchema> Properties { get; init; }

    [JsonPropertyName("nullable")] public bool Nullable { get; init; }

    [JsonPropertyName("additionalProperties")]
    public OpenApiComponentSchema AdditionalProperties { get; init; }

    [JsonPropertyName("x-dictionary-key")] public OpenApiComponentSchema DictionaryKey { get; init; }

    [JsonPropertyName("x-mapped-definition")]
    public OpenApiComponentSchema MappedDefinition { get; init; }

    [JsonPropertyName("allOf")] public List<OpenApiComponentSchema> AllOf { get; init; }

    [JsonPropertyName("x-destiny-component-type-dependency")]
    public string DestinyComponentTypeDependency { get; init; }

    public string DebugType => GetCSharpType();

    public string GetCSharpType()
    {
        if (AllOf is not null)
        {
            return AllOf.FirstOrDefault()?.TypeReference.GetFullTypeName();
        }
        
        if (TypeReference is not null)
        {
            return TypeReference.GetFullTypeName();
        }

        if (Type == "object")
        {
            if (AdditionalProperties is not null)
            {
                if (DictionaryKey is not null)
                {
                    return
                        $"Dictionary<{DictionaryKey.GetCSharpType()}, {AdditionalProperties.GetCSharpType()}>";
                }

                return
                    $"Dictionary<{AdditionalProperties.GetCSharpType()}, {AdditionalProperties.GetCSharpType()}>";
            }

            return "object";
        }
        else if (Type == "array")
        {
            if (Items.TypeReference is not null)
            {
                return $"List<{Items.GetCSharpType()}>";
            }

            if (Items.EnumReference is not null)
            {
                return $"List<{Items.EnumReference.GetCSharpType()}>";
            }

            return $"List<{Items.GetCSharpValueType()}>";
        }
        else
        {
            return GetCSharpValueType();
        }

        return string.Empty;
    }

    private string GetCSharpValueType()
    {
        if (Type == "string")
        {
            return Format == "date-time" ? $"DateTime{(Nullable ? "?" : "")}" : "string";
        }

        if (Type == "number")
        {
            return $"{Format}{(Nullable ? "?" : "")}";
        }

        if (Type == "integer")
        {
            if (EnumReference is not null)
            {
                return $"{EnumReference.TypeReference.GetFullTypeName()}{(Nullable ? "?" : "")}";
            }

            return $"{Resources.TypeMappings[Format]}{(Nullable ? "?" : "")}";
        }

        if (Type == "boolean")
            return $"bool{(Nullable ? "?" : "")}";

        throw new Exception($"Type is not a ValueType: {Type}");
    }
}