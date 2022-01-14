namespace DotNetBungieAPI.Generated.Models.Content.Models;

public sealed class ContentTypeProperty
{

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("rootPropertyName")]
    public string RootPropertyName { get; init; }

    [JsonPropertyName("readableName")]
    public string ReadableName { get; init; }

    [JsonPropertyName("value")]
    public string Value { get; init; }

    [JsonPropertyName("propertyDescription")]
    public string PropertyDescription { get; init; }

    [JsonPropertyName("localizable")]
    public bool Localizable { get; init; }

    [JsonPropertyName("fallback")]
    public bool Fallback { get; init; }

    [JsonPropertyName("enabled")]
    public bool Enabled { get; init; }

    [JsonPropertyName("order")]
    public int Order { get; init; }

    [JsonPropertyName("visible")]
    public bool Visible { get; init; }

    [JsonPropertyName("isTitle")]
    public bool IsTitle { get; init; }

    [JsonPropertyName("required")]
    public bool Required { get; init; }

    [JsonPropertyName("maxLength")]
    public int MaxLength { get; init; }

    [JsonPropertyName("maxByteLength")]
    public int MaxByteLength { get; init; }

    [JsonPropertyName("maxFileSize")]
    public int MaxFileSize { get; init; }

    [JsonPropertyName("regexp")]
    public string Regexp { get; init; }

    [JsonPropertyName("validateAs")]
    public string ValidateAs { get; init; }

    [JsonPropertyName("rssAttribute")]
    public string RssAttribute { get; init; }

    [JsonPropertyName("visibleDependency")]
    public string VisibleDependency { get; init; }

    [JsonPropertyName("visibleOn")]
    public string VisibleOn { get; init; }

    [JsonPropertyName("datatype")]
    public Content.Models.ContentPropertyDataTypeEnum Datatype { get; init; }

    [JsonPropertyName("attributes")]
    public Dictionary<string, string> Attributes { get; init; }

    [JsonPropertyName("childProperties")]
    public List<Content.Models.ContentTypeProperty> ChildProperties { get; init; }

    [JsonPropertyName("contentTypeAllowed")]
    public string ContentTypeAllowed { get; init; }

    [JsonPropertyName("bindToProperty")]
    public string BindToProperty { get; init; }

    [JsonPropertyName("boundRegex")]
    public string BoundRegex { get; init; }

    [JsonPropertyName("representationSelection")]
    public Dictionary<string, string> RepresentationSelection { get; init; }

    [JsonPropertyName("defaultValues")]
    public List<Content.Models.ContentTypeDefaultValue> DefaultValues { get; init; }

    [JsonPropertyName("isExternalAllowed")]
    public bool IsExternalAllowed { get; init; }

    [JsonPropertyName("propertySection")]
    public string PropertySection { get; init; }

    [JsonPropertyName("weight")]
    public int Weight { get; init; }

    [JsonPropertyName("entitytype")]
    public string Entitytype { get; init; }

    [JsonPropertyName("isCombo")]
    public bool IsCombo { get; init; }

    [JsonPropertyName("suppressProperty")]
    public bool SuppressProperty { get; init; }

    [JsonPropertyName("legalContentTypes")]
    public List<string> LegalContentTypes { get; init; }

    [JsonPropertyName("representationValidationString")]
    public string RepresentationValidationString { get; init; }

    [JsonPropertyName("minWidth")]
    public int MinWidth { get; init; }

    [JsonPropertyName("maxWidth")]
    public int MaxWidth { get; init; }

    [JsonPropertyName("minHeight")]
    public int MinHeight { get; init; }

    [JsonPropertyName("maxHeight")]
    public int MaxHeight { get; init; }

    [JsonPropertyName("isVideo")]
    public bool IsVideo { get; init; }

    [JsonPropertyName("isImage")]
    public bool IsImage { get; init; }
}
