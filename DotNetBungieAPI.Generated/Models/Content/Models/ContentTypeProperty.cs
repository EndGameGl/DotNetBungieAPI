namespace DotNetBungieAPI.Generated.Models.Content.Models;

public class ContentTypeProperty
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("rootPropertyName")]
    public string? RootPropertyName { get; set; }

    [JsonPropertyName("readableName")]
    public string? ReadableName { get; set; }

    [JsonPropertyName("value")]
    public string? Value { get; set; }

    [JsonPropertyName("propertyDescription")]
    public string? PropertyDescription { get; set; }

    [JsonPropertyName("localizable")]
    public bool? Localizable { get; set; }

    [JsonPropertyName("fallback")]
    public bool? Fallback { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("order")]
    public int? Order { get; set; }

    [JsonPropertyName("visible")]
    public bool? Visible { get; set; }

    [JsonPropertyName("isTitle")]
    public bool? IsTitle { get; set; }

    [JsonPropertyName("required")]
    public bool? Required { get; set; }

    [JsonPropertyName("maxLength")]
    public int? MaxLength { get; set; }

    [JsonPropertyName("maxByteLength")]
    public int? MaxByteLength { get; set; }

    [JsonPropertyName("maxFileSize")]
    public int? MaxFileSize { get; set; }

    [JsonPropertyName("regexp")]
    public string? Regexp { get; set; }

    [JsonPropertyName("validateAs")]
    public string? ValidateAs { get; set; }

    [JsonPropertyName("rssAttribute")]
    public string? RssAttribute { get; set; }

    [JsonPropertyName("visibleDependency")]
    public string? VisibleDependency { get; set; }

    [JsonPropertyName("visibleOn")]
    public string? VisibleOn { get; set; }

    [JsonPropertyName("datatype")]
    public Content.Models.ContentPropertyDataTypeEnum? Datatype { get; set; }

    [JsonPropertyName("attributes")]
    public Dictionary<string, string> Attributes { get; set; }

    [JsonPropertyName("childProperties")]
    public List<Content.Models.ContentTypeProperty> ChildProperties { get; set; }

    [JsonPropertyName("contentTypeAllowed")]
    public string? ContentTypeAllowed { get; set; }

    [JsonPropertyName("bindToProperty")]
    public string? BindToProperty { get; set; }

    [JsonPropertyName("boundRegex")]
    public string? BoundRegex { get; set; }

    [JsonPropertyName("representationSelection")]
    public Dictionary<string, string> RepresentationSelection { get; set; }

    [JsonPropertyName("defaultValues")]
    public List<Content.Models.ContentTypeDefaultValue> DefaultValues { get; set; }

    [JsonPropertyName("isExternalAllowed")]
    public bool? IsExternalAllowed { get; set; }

    [JsonPropertyName("propertySection")]
    public string? PropertySection { get; set; }

    [JsonPropertyName("weight")]
    public int? Weight { get; set; }

    [JsonPropertyName("entitytype")]
    public string? Entitytype { get; set; }

    [JsonPropertyName("isCombo")]
    public bool? IsCombo { get; set; }

    [JsonPropertyName("suppressProperty")]
    public bool? SuppressProperty { get; set; }

    [JsonPropertyName("legalContentTypes")]
    public List<string> LegalContentTypes { get; set; }

    [JsonPropertyName("representationValidationString")]
    public string? RepresentationValidationString { get; set; }

    [JsonPropertyName("minWidth")]
    public int? MinWidth { get; set; }

    [JsonPropertyName("maxWidth")]
    public int? MaxWidth { get; set; }

    [JsonPropertyName("minHeight")]
    public int? MinHeight { get; set; }

    [JsonPropertyName("maxHeight")]
    public int? MaxHeight { get; set; }

    [JsonPropertyName("isVideo")]
    public bool? IsVideo { get; set; }

    [JsonPropertyName("isImage")]
    public bool? IsImage { get; set; }
}
